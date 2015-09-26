using System.Collections.Generic;
using System.Linq;

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

		public string Name => $"{CraftType.Metadata().Name}-{Number}";
		public int FuelPercent => Fuel * 100 / CraftType.Metadata().Fuel;
		public int DamagePercent => Damage * 100 / CraftType.Metadata().Damage;
		public int TotalItemCount => Stores.Items.Where(item => item.ItemType.Metadata().HwpSpace == 0).Sum(item => item.Count);
		public int TotalHwpCount => Stores.Items.Where(item => item.ItemType.Metadata().HwpSpace > 0).Sum(item => item.Count);
		public int SpaceUsed => SoldierIds.Count + TotalHwpCount * 4;
		public int SpaceAvailable => CraftType.Metadata().Space - SpaceUsed;
		public int HwpSpaceAvailable => CraftType.Metadata().HwpCount - TotalHwpCount;

		private Base Base => GameState.Current.Data.Bases.Single(@base => @base.Crafts.Contains(this));
		public string BaseName => Base.Name;

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
	}
}
