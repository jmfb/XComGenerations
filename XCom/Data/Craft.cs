using System.Collections.Generic;

namespace XCom.Data
{
	public class Craft
	{
		public CraftType CraftType { get; set; }
		public int Number { get; set; }
		public int Damage { get; set; }
		public int Fuel { get; set; }
		public List<CraftWeapon> Weapons { get; set; }
		public CraftStatus Status { get; set; }
		public List<int> SoldierIds { get; set; }

		public string Name => CraftType.Metadata().Name + "-" + Number;

		public int GetFuelPercent()
		{
			return Fuel * 100 / CraftType.Metadata().Fuel;
		}

		public int GetDamagePercent()
		{
			return Damage * 100 / CraftType.Metadata().Damage;
		}

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
				SoldierIds = new List<int>()
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
				SoldierIds = new List<int>()
			};
		}
	}
}
