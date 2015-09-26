using System;
using System.Collections.Generic;
using System.Linq;
using XCom.Modals;
using XCom.Screens;
using XCom.World;

namespace XCom.Data
{
	public partial class GameData
	{
		private static void PerformHourlyUpdates()
		{
			AdvanceManufactureProjects();
			AdvanceTransfers();
			RearmCrafts();
			RefuelCrafts();
			RepairCrafts();
		}

		private static void PerformBiHourlyUpdates()
		{
			RefuelCrafts();
		}

		private static void PerformTenMinuteUpdates()
		{
			ConsumeFuel();
		}

		private static void PerformInstantaneousUpdates(long milliseconds)
		{
			MoveCrafts(milliseconds);
		}

		private static void AdvanceManufactureProjects()
		{
			foreach (var @base in GameState.Current.Data.Bases)
			{
				var activeProjects = @base.ManufactureProjects.Where(project => project.EngineersAllocated > 0).ToList();
				foreach (var project in activeProjects)
					AdvanceManufactureProject(@base, project);
			}
		}

		private static void AdvanceManufactureProject(Base @base, ManufactureProject project)
		{
			var previousUnitsProduced = project.UnitsProduced;
			project.HoursCompleted += project.EngineersAllocated;
			var totalUnitsProduced = Math.Min(project.UnitsToProduce,
				project.HoursCompleted / project.ManufactureType.Metadata().HoursToProduce);
			var newUnitsProduced = totalUnitsProduced - previousUnitsProduced;

			foreach (var unit in Enumerable.Range(0, newUnitsProduced))
			{
				project.CompleteUnit(@base);
				++project.UnitsProduced;
				if (project.UnitsProduced == project.UnitsToProduce)
					break;
				var status = project.BeginUnitProduction(@base);
				if (status == ManufactureStatus.UnitStarted)
					continue;
				@base.ManufactureProjects.Remove(project);
				NotifyProductionStopped(@base, project, status);
				return;
			}

			if (project.UnitsProduced != project.UnitsToProduce)
				return;
			@base.ManufactureProjects.Remove(project);
			NotifyProductionCompleted(@base, project);
		}

		private static void NotifyProductionStopped(Base @base, ManufactureProject project, ManufactureStatus status)
		{
			GameState.Current.Notifications.Enqueue(() =>
			{
				Screen.Geoscape.ResetGameSpeed();
				new ProductionStopped(@base.Name, project.ManufactureType.Metadata().Name, status).DoModal(GameState.Current.ActiveScreen);
			});
		}

		private static void NotifyProductionCompleted(Base @base, ManufactureProject project)
		{
			GameState.Current.Notifications.Enqueue(() =>
			{
				Screen.Geoscape.ResetGameSpeed();
				new ProductionCompleted(@base.Name, project.ManufactureType.Metadata().Name).DoModal(GameState.Current.ActiveScreen);
			});
		}

		private static void AdvanceTransfers()
		{
			DecrementTransferHoursRemaining();
			var arrivingTransfers = GatherArrivingTransfers().ToList();
			if (!arrivingTransfers.Any())
				return;
			GameState.Current.Notifications.Enqueue(() =>
			{
				new ItemsArriving(arrivingTransfers).DoModal(GameState.Current.ActiveScreen);
			});
		}

		private static void DecrementTransferHoursRemaining()
		{
			foreach (var @base in GameState.Current.Data.Bases)
			{
				foreach (var transferredSoldier in @base.TransferredSoldiers)
					--transferredSoldier.HoursRemaining;
				foreach (var transferredCraft in @base.TransferredCrafts)
					--transferredCraft.HoursRemaining;
				foreach (var transferredStore in @base.TransferredStores)
					--transferredStore.HoursRemaining;
			}
		}

		private static IEnumerable<CompletedTransfer> GatherArrivingTransfers()
		{
			foreach (var @base in GameState.Current.Data.Bases)
			{
				foreach (var transferredSoldier in @base.TransferredSoldiers.Where(item => item.HoursRemaining == 0).ToList())
					yield return CompleteSoldierTransfer(@base, transferredSoldier);
				foreach (var transferredCraft in @base.TransferredCrafts.Where(item => item.HoursRemaining == 0).ToList())
					yield return CompleteCraftTransfer(@base, transferredCraft);
				foreach (var transferredStore in @base.TransferredStores.Where(item => item.HoursRemaining == 0).ToList())
					yield return CompleteStoreTransfer(@base, transferredStore);
			}
		}

		private static CompletedTransfer CompleteSoldierTransfer(Base @base, TransferItem<Soldier> transferredSoldier)
		{
			@base.TransferredSoldiers.Remove(transferredSoldier);
			@base.Soldiers.Add(transferredSoldier.Item);
			var completedTransfer = new CompletedTransfer
			{
				Name = transferredSoldier.Item.Name,
				Quantity = 1,
				Destination = @base.Name
			};
			return completedTransfer;
		}

		private static CompletedTransfer CompleteCraftTransfer(Base @base, TransferItem<Craft> transferredCraft)
		{
			@base.TransferredCrafts.Remove(transferredCraft);
			@base.Crafts.Add(transferredCraft.Item);
			var completedTransfer = new CompletedTransfer
			{
				Name = transferredCraft.Item.Name,
				Quantity = 1,
				Destination = @base.Name
			};
			return completedTransfer;
		}

		private static CompletedTransfer CompleteStoreTransfer(Base @base, TransferItem<StoreItem> transferredStore)
		{
			@base.TransferredStores.Remove(transferredStore);
			switch (transferredStore.Item.ItemType)
			{
			case ItemType.Engineer:
				@base.EngineerCount += transferredStore.Item.Count;
				break;
			case ItemType.Scientist:
				@base.ScientistCount += transferredStore.Item.Count;
				break;
			default:
				@base.Stores.Add(transferredStore.Item.ItemType, transferredStore.Item.Count);
				break;
			}
			var completedTransfer = new CompletedTransfer
			{
				Name = transferredStore.Item.ItemType.Metadata().Name,
				Quantity = transferredStore.Item.Count,
				Destination = @base.Name
			};
			return completedTransfer;
		}

		private static void RearmCrafts()
		{
			foreach (var @base in GameState.Current.Data.Bases)
				foreach (var craft in @base.Crafts.Where(craft => craft.Status == CraftStatus.Rearming))
					RearmCraft(@base, craft);
		}

		private static void RearmCraft(Base @base, Craft craft)
		{
			var weapon = craft.Weapons.FirstOrDefault(craftWeapon => !craftWeapon.IsFullyArmed);
			if (weapon == null)
			{
				craft.TransitionStatus();
				return;
			}
			var metadata = weapon.WeaponType.Metadata();
			if (metadata.Ammo == null)
				weapon.Reload(100);
			else
			{
				foreach (var ammo in Enumerable.Range(0, metadata.AmmoPerHour))
				{
					if (@base.Stores[metadata.Ammo.Value] == 0)
					{
						NotifyNotEnoughStoresToRearmCraft(@base, craft, metadata.Ammo.Value);
						return;
					}

					@base.Stores.Remove(metadata.Ammo.Value);
					weapon.Reload(metadata.RoundsInAmmo);
					if (weapon.IsFullyArmed)
						break;
				}
			}
		}

		private static void NotifyNotEnoughStoresToRearmCraft(Base @base, Craft craft, ItemType ammoType)
		{
			if (craft.AlreadyNotified)
				return;
			craft.AlreadyNotified = true;
			GameState.Current.Notifications.Enqueue(() =>
			{
				new NotEnoughStoresToRearmCraft(@base, craft, ammoType).DoModal(GameState.Current.ActiveScreen);
			});
		}

		private static void RepairCrafts()
		{
			foreach (var @base in GameState.Current.Data.Bases)
				foreach (var craft in @base.Crafts.Where(craft => craft.Status == CraftStatus.Repairs))
					RepairCraft(craft);
		}

		private static void RepairCraft(Craft craft)
		{
			--craft.Damage;
			if (craft.Damage == 0)
				craft.TransitionStatus();
		}

		private static void RefuelCrafts()
		{
			foreach (var @base in GameState.Current.Data.Bases)
				foreach (var craft in @base.Crafts.Where(craft => craft.Status == CraftStatus.Refuelling))
					RefuelCraft(@base, craft);
		}

		private static void RefuelCraft(Base @base, Craft craft)
		{
			var metadata = craft.CraftType.Metadata();
			switch (metadata.FuelType)
			{
			case FuelType.Normal:
				craft.Fuel += 50;
				break;
			case FuelType.Elerium115:
				if (@base.Stores[ItemType.Elerium115] == 0)
				{
					NotifyNotEnoughStoresToRefuelCraft(@base, craft);
					return;
				}
				@base.Stores.Remove(ItemType.Elerium115);
				craft.Fuel += 5;
				break;
			}
			if (craft.Fuel < metadata.Fuel)
				return;
			craft.Fuel = metadata.Fuel;
			craft.TransitionStatus();
		}

		private static void NotifyNotEnoughStoresToRefuelCraft(Base @base, Craft craft)
		{
			if (craft.AlreadyNotified)
				return;
			craft.AlreadyNotified = true;
			GameState.Current.Notifications.Enqueue(() =>
			{
				new NotEnoughStoresToRefuelCraft(@base, craft).DoModal(GameState.Current.ActiveScreen);
			});
		}

		private static void ConsumeFuel()
		{
			foreach (var craft in GameState.Current.Data.ActiveInterceptors)
			{
				switch (craft.CraftType)
				{
				case CraftType.Skyranger:
				case CraftType.Interceptor:
					craft.Fuel -= craft.IsPatrolling ? 3 : 7;
					break;
				default:
					craft.Fuel -= 1;
					break;
				}
				if (craft.Fuel < 0)
					craft.Fuel = 0;
				if (craft.FuelPercent <= 15 && !craft.LowFuel)
					ReturnCraftToBaseDueToLowFuel(craft);
			}
		}

		private static void ReturnCraftToBaseDueToLowFuel(Craft craft)
		{
			craft.IsPatrolling = false;
			craft.LowFuel = true;
			if (craft.Destination?.WorldObjectType == WorldObjectType.Waypoint)
				GameState.Current.Data.RemoveWaypoint(craft.Destination.Number);
			craft.Destination = new Destination
			{
				WorldObjectType = WorldObjectType.XcomBase,
				Number = craft.Base.Number
			};
			GameState.Current.Notifications.Enqueue(() =>
			{
				new LowFuel(craft).DoModal(GameState.Current.ActiveScreen);
			});
		}

		private static void MoveCrafts(long milliseconds)
		{
			var movingCrafts = GameState.Current.Data.ActiveInterceptors.Where(craft => !craft.IsPatrolling);
			foreach (var craft in movingCrafts)
			{
				craft.Accelerate(milliseconds);
				var distance = craft.Distance(milliseconds);
				if (distance == 0)
					continue;
				craft.Location = Trigonometry.MoveLocation(craft.Location, craft.Destination.Location, distance);
				if (craft.Location.Is(craft.Destination.Location))
					CraftArrivalAtDestination(craft);
			}
		}

		private static void CraftArrivalAtDestination(Craft craft)
		{
			switch (craft.Destination.WorldObjectType)
			{
			case WorldObjectType.XcomBase:
				craft.ReturnToBase();
				break;
			case WorldObjectType.Waypoint:
				var waypoint = craft.PatrolWaypoint();
				GameState.Current.Notifications.Enqueue(() =>
				{
					new ReachedWaypoint(craft, waypoint).DoModal(GameState.Current.ActiveScreen);
				});
				break;
			default:
				throw new NotImplementedException();
			}
		}
	}
}
