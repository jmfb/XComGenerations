using System;
using System.Collections.Generic;
using System.Linq;
using XCom.World;

namespace XCom.Data
{
	public class Craft
	{
		public CraftType CraftType { get; set; }
		public int Number { get; set; }
		public int Damage { get; set; }
		public int Fuel { get; set; }
		public bool AlreadyNotified { get; set; }
		public List<CraftWeapon> Weapons { get; set; }
		public CraftStatus Status { get; set; }
		public List<int> SoldierIds { get; set; }
		public Stores Stores { get; set; }
		public Location Location { get; set; }
		public Destination Destination { get; set; }
		public bool IsPatrolling { get; set; }
		public bool LowFuel { get; set; }
		public double Speed { get; set; }
		public double DistanceError { get; set; }

		public string Name => $"{CraftType.Metadata().Name}-{Number}";
		public int FuelPercent => Fuel * 100 / CraftType.Metadata().Fuel;
		public int DamagePercent => Damage * 100 / CraftType.Metadata().Damage;
		public int TotalItemCount => Stores.Items.Where(item => item.ItemType.Metadata().HwpSpace == 0).Sum(item => item.Count);
		public int TotalHwpCount => Stores.Items.Where(item => item.ItemType.Metadata().HwpSpace > 0).Sum(item => item.Count);
		public int SpaceUsed => SoldierIds.Count + TotalHwpCount * 4;
		public int SpaceAvailable => CraftType.Metadata().Space - SpaceUsed;
		public int HwpSpaceAvailable => CraftType.Metadata().HwpCount - TotalHwpCount;

		public Base Base => GameState.Current.Data.Bases.Single(@base => @base.Crafts.Contains(this));
		public string MissionStatus
		{
			get
			{
				if (IsPatrolling)
					return "PATROLLING";
				if (Destination.WorldObjectType == WorldObjectType.XcomBase)
					return LowFuel ?
						"LOW FUEL - RETURNING TO BASE" :
						"RETURNING TO BASE";
				return $"DESTINATION: {Destination.Name}";
			}
		}
		public string Altitude => "VERY LOW"; //TODO: something with altitudes I guess
		public string Weapon1Name => Weapons.Count >= 1 ? Weapons[0].WeaponType.Metadata().Name : "NONE";
		public string Weapon2Name => Weapons.Count == 2 ? Weapons[1].WeaponType.Metadata().Name : "NONE";

		public static Craft CreateRefueled(CraftType craftType, int number)
		{
			return new Craft
			{
				CraftType = craftType,
				Number = number,
				Damage = 0,
				Fuel = craftType.Metadata().Fuel,
				Weapons = new List<CraftWeapon>(),
				Status = CraftStatus.Ready,
				SoldierIds = new List<int>(),
				Stores = Stores.Create()
			};
		}

		public static Craft CreateNew(CraftType craftType, int number)
		{
			return new Craft
			{
				CraftType = craftType,
				Number = number,
				Damage = 0,
				Fuel = 0,
				Weapons = new List<CraftWeapon>(),
				Status = CraftStatus.Refuelling,
				SoldierIds = new List<int>(),
				Stores = Stores.Create()
			};
		}

		public void TransitionStatus()
		{
			AlreadyNotified = false;
			switch (Status)
			{
			case CraftStatus.Repairs:
				Status = CraftStatus.Refuelling;
				break;
			case CraftStatus.Refuelling:
				Status = CraftStatus.Rearming;
				break;
			case CraftStatus.Rearming:
				Status = CraftStatus.Ready;
				break;
			}
		}

		public void Accelerate(long milliseconds)
		{
			var metadata = CraftType.Metadata();
			var maxSpeed = IsPatrolling ? metadata.Speed / 2 : metadata.Speed;
			if (Speed >= maxSpeed)
				return;
			var speedIncrease = (metadata.Acceleration * milliseconds) / 1000.0;
			Speed = Math.Min(maxSpeed, Speed + speedIncrease);
		}

		public int Distance(long milliseconds)
		{
			const double earthCircumferenceInNauticalMiles = 21639;
			const double nauticalMilesPerEightDegree = earthCircumferenceInNauticalMiles / Trigonometry.EighthDegreesCount;
			const double millisecondsPerHour = 1000 * 60 * 60;
			var distanceInNauticalMiles = (Speed * milliseconds) / millisecondsPerHour;
			var distanceInEighthDegrees = distanceInNauticalMiles / nauticalMilesPerEightDegree + DistanceError;
			var integerDistanceInEighthDegrees = (int)distanceInEighthDegrees;
			DistanceError = distanceInEighthDegrees - integerDistanceInEighthDegrees;
			return integerDistanceInEighthDegrees;
		}

		public void StartToReturnToBase()
		{
			IsPatrolling = false;
			RemoveWaypoint();
			Destination = new Destination
			{
				WorldObjectType = WorldObjectType.XcomBase,
				Number = Base.Number
			};
		}

		public void ReturnToBase()
		{
			Status = Damage > 0 ? CraftStatus.Repairs : CraftStatus.Refuelling;
			Location = null;
			Destination = null;
			Speed = 0;
			DistanceError = 0;
			IsPatrolling = false;
			LowFuel = false;
		}

		public Waypoint Patrol()
		{
			var waypoint = RemoveWaypoint();
			Destination = null;
			Speed = CraftType.Metadata().Speed / 2.0;
			IsPatrolling = true;
			return waypoint;
		}

		public Waypoint RemoveWaypoint()
		{
			return Destination?.WorldObjectType == WorldObjectType.Waypoint ?
				GameState.Current.Data.RemoveWaypoint(Destination.Number) :
				null;
		}
	}
}
