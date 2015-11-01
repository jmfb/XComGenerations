using System.Collections.Generic;
using System.Linq;
using XCom.Battlescape;
using XCom.Battlescape.Tiles;

namespace XCom.Data
{
	public class WeaponMetadata : BattleItemMetadata
	{
		public ItemType ItemType { get; set; }
		public Shot[] Shots { get; set; }
		public int Weight { get; set; }
		public bool IsTwoHanded { get; set; }
		public byte[] Image { get; set; }
		public int Width { get; set; }
		public int Height {get; set; }
		public string[] DescriptionLines { get; set; }
		public Dictionary<Direction, byte[]> Sprites { get; set; }

		public string Name => ItemType.Metadata().Name;
		private WeaponType ThisWeapon => EnumEx.GetValues<WeaponType>()
			.Single(weapon => ReferenceEquals(this, weapon.Metadata()));
		public List<AmmunitionType> SupportedAmmunition => EnumEx.GetValues<AmmunitionType>()
			.Where(ammo => ammo.Metadata().Weapon == ThisWeapon)
			.ToList();
	}
}
