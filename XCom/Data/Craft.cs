using System.Collections.Generic;

namespace XCom.Data
{
	public class Craft
	{
		public int Id { get; set; }
		public CraftType CraftType { get; set; }
		public int Number { get; set; }
		public int Damage { get; set; }
		public int Fuel { get; set; }
		public List<CraftWeapon> Weapons { get; set; }
		public CraftStatus Status { get; set; }
		public List<int> SoldierIds { get; set; }

		public string GetName()
		{
			return CraftType.Metadata().Name + "-" + Number;
		}

		public int GetFuelPercent()
		{
			return Fuel * 100 / CraftType.Metadata().Fuel;
		}

		public int GetDamagePercent()
		{
			return Damage * 100 / CraftType.Metadata().Damage;
		}

		public static Craft CreateRefueled(int id, CraftType craftType, int number)
		{
			return new Craft
			{
				Id = id,
				CraftType = craftType,
				Number = number,
				Damage = 0,
				Fuel = craftType.Metadata().Fuel,
				Weapons = new List<CraftWeapon>(),
				Status = CraftStatus.Ready,
				SoldierIds = new List<int>()
			};
		}
	}
}
