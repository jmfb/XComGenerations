using XCom.Graphics;

namespace XCom.Data
{
	public class CraftWeaponMetadata
	{
		public string Name { get; set; }
		public int Ammunition { get; set; }
		public Image Image { get; set; }
		public ItemType Item { get; set; }
		public ItemType? Ammo { get; set; }

		public int RoundsInAmmo => Ammo == ItemType.CannonRounds ? 50 : 1;
		public int AmmoPerHour => Ammo == ItemType.CannonRounds ? 2 : 1;
	}
}
