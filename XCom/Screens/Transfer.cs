using System.Collections.Generic;
using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Modals;

namespace XCom.Screens
{
	public class Transfer : Screen
	{
		private readonly Data.Base destination;
		private readonly Dictionary<object, int> itemsToTransfer = new Dictionary<object, int>();

		public Transfer(Data.Base destination)
		{
			this.destination = destination;
			GatherItemsAvailableToTransfer();

			AddControl(new Border(0, 0, 320, 200, ColorScheme.Blue, Backgrounds.Funds, 6));
			AddControl(new Label(8, Label.Center, "Transfer", Font.Large, ColorScheme.Blue));
			AddControl(new Label(22, 10, "ITEM", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(22, 150, "QUANTITY", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(22, 200, "AMOUNT TO", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(30, 205, "TRANSFER", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(22, 260, "AMOUNT AT", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(30, 260, "DESTINATION", Font.Normal, ColorScheme.Blue));
			AddControl(new ListView<object>(40, 8, 16, itemsToTransfer.Keys.ToList(), ColorScheme.Blue, Palette.GetPalette(6).GetColor(230), OnIncreaseTransfer)
				.ConfigureUpDown(200, OnDescreaseTransfer)
				.AddColumn(2, Alignment.Left, item => "")
				.AddColumn(162, Alignment.Left, GetName, item => ColorScheme.LightMagenta)
				.AddColumn(58, Alignment.Left, item => GetRemainingQuantity(item).FormatNumber(), item => ColorScheme.LightMagenta)
				.AddColumn(30, Alignment.Left, item => GetAmountToTransfer(item).FormatNumber(), item => ColorScheme.LightMagenta)
				.AddColumn(30, Alignment.Right, item => GetAmountAtDestination(item).FormatNumber(), item => ColorScheme.LightMagenta)
				.AddColumn(5, Alignment.Left, item => ""));
			AddControl(new Button(176, 8, 146, 16, "Transfer", ColorScheme.Purple, Font.Normal, OnTransfer));
			AddControl(new Button(176, 164, 146, 16, "Cancel", ColorScheme.Purple, Font.Normal, OnCancel));
		}

		private void GatherItemsAvailableToTransfer()
		{
			var selectedBase = GameState.SelectedBase;
			foreach (var soldier in selectedBase.Soldiers.Where(soldier => soldier.GetCraft() == null))
				itemsToTransfer.Add(soldier, 0);
			foreach (var craft in selectedBase.Crafts.Where(craft => craft.Status != CraftStatus.Out))
				itemsToTransfer.Add(craft, 0);
			if (selectedBase.EngineersAvailable > 0)
				itemsToTransfer.Add(ItemType.Engineer, 0);
			if (selectedBase.ScientistsAvailable > 0)
				itemsToTransfer.Add(ItemType.Scientist, 0);
			foreach (var item in selectedBase.Stores.Items.Where(item => item.Count > 0))
				itemsToTransfer.Add(item.ItemType, 0);
		}

		private static string GetName(object item)
		{
			return (item as Soldier)?.Name ??
				(item as Craft)?.Name ??
				((ItemType)item).Metadata().Name;
		}

		private static int GetAvailableQuantity(object item)
		{
			return item is Soldier ? 1 :
				item is Craft ? 1 :
				(ItemType)item == ItemType.Engineer ? GameState.SelectedBase.EngineersAvailable :
				(ItemType)item == ItemType.Scientist ? GameState.SelectedBase.ScientistsAvailable :
				GameState.SelectedBase.Stores[(ItemType)item];
		}

		private int GetRemainingQuantity(object item)
		{
			return GetAvailableQuantity(item) - GetAmountToTransfer(item);
		}

		private int GetAmountToTransfer(object item)
		{
			return itemsToTransfer[item];
		}

		private int GetAmountAtDestination(object item)
		{
			return item is Soldier ? 0 :
				item is Craft ? 0 :
				(ItemType)item == ItemType.Engineer ? destination.EngineersAvailable :
				(ItemType)item == ItemType.Scientist ? destination.ScientistsAvailable :
				destination.Stores[(ItemType)item];
		}

		private void OnIncreaseTransfer(object item)
		{
			//TODO: check hangar space, living quarters, store space, alien containment
			if (GetRemainingQuantity(item) > 0)
				++itemsToTransfer[item];
		}

		private void OnDescreaseTransfer(object item)
		{
			if (itemsToTransfer[item] > 0)
				--itemsToTransfer[item];
		}

		private void OnTransfer()
		{
			new ConfirmTransfer(destination.Name, TotalCost, OnTransferConfirmed).DoModal(this);
		}

		private static void OnCancel()
		{
			GameState.Current.SetScreen(new Base());
		}

		private int Distance => 50; //TODO: compute distance 0-100 between selected base and destination
		/*
		double TransferItemsState::getDistance() const
		{
			double x[3], y[3], z[3], r = 51.2;
			Base *base = _baseFrom;
			for (int i = 0; i < 2; ++i) {
				x[i] = r * cos(base->getLatitude()) * cos(base->getLongitude());
				y[i] = r * cos(base->getLatitude()) * sin(base->getLongitude());
				z[i] = r * -sin(base->getLatitude());
				base = _baseTo;
			}
			x[2] = x[1] - x[0];
			y[2] = y[1] - y[0];
			z[2] = z[1] - z[0];
			return sqrt(x[2] * x[2] + y[2] * y[2] + z[2] * z[2]);
		}
		*/

		private int GetTransferCost(KeyValuePair<object, int> pair)
		{
			if (pair.Key is Craft)
				return 25 * Distance * pair.Value;
			if (pair.Key is Soldier)
				return 1 * Distance * pair.Value;
			var itemType = (ItemType)pair.Key;
			if (itemType == ItemType.Engineer || itemType == ItemType.Scientist)
				return 1 * Distance * pair.Value;
			return 5 * Distance * pair.Value;
		}

		private int TotalCost => itemsToTransfer.Sum(pair => GetTransferCost(pair));
		private int HoursToTransfer => 6 + Distance / 10;

		private void OnTransferConfirmed()
		{
			GameState.Current.Data.Funds -= TotalCost;
			TransferSoldiers();
			TransferCrafts();
			TransferStoreItems();
			GameState.Current.SetScreen(new Base());
		}

		private void TransferSoldiers()
		{
			var soldiersToTransfer = itemsToTransfer
				.Where(pair => pair.Value > 0)
				.Select(item => item.Key)
				.OfType<Soldier>();
			foreach (var soldier in soldiersToTransfer)
			{
				destination.TransferredSoldiers.Add(new TransferItem<Soldier>
				{
					Item = soldier,
					HoursRemaining = HoursToTransfer
				});
				GameState.SelectedBase.Soldiers.Remove(soldier);
			}
		}

		private void TransferCrafts()
		{
			var selectedBase = GameState.SelectedBase;
			var craftsToTransfer = itemsToTransfer
				.Where(pair => pair.Value > 0)
				.Select(pair => pair.Key)
				.OfType<Craft>();
			foreach (var craft in craftsToTransfer)
			{
				destination.TransferredCrafts.Add(new TransferItem<Craft>
				{
					Item = craft,
					HoursRemaining = HoursToTransfer
				});
				selectedBase.Crafts.Remove(craft);
				var craftSoldiers = craft.SoldierIds.Select(soldierId =>
					selectedBase.Soldiers.Single(soldier => soldier.Id == soldierId));
				foreach (var craftSoldier in craftSoldiers)
				{
					destination.TransferredSoldiers.Add(new TransferItem<Soldier>
					{
						Item = craftSoldier,
						HoursRemaining = HoursToTransfer
					});
					selectedBase.Soldiers.Remove(craftSoldier);
				}
			}
		}

		private void TransferStoreItems()
		{
			var storeItemsToTransfer = itemsToTransfer
				.Where(pair => pair.Value > 0 && pair.Key is ItemType)
				.Select(pair => new StoreItem {ItemType = (ItemType) pair.Key, Count = pair.Value});
			foreach (var storeItem in storeItemsToTransfer)
			{
				destination.TransferredStores.Add(new TransferItem<StoreItem>
				{
					Item = storeItem,
					HoursRemaining = HoursToTransfer
				});
				switch (storeItem.ItemType)
				{
				case ItemType.Engineer:
					GameState.SelectedBase.EngineerCount -= storeItem.Count;
					break;
				case ItemType.Scientist:
					GameState.SelectedBase.ScientistCount -= storeItem.Count;
					break;
				default:
					GameState.SelectedBase.Stores.Remove(storeItem.ItemType, storeItem.Count);
					break;
				}
			}
		}
	}
}
