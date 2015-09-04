using XCom.Graphics;

namespace XCom.Data
{
	public class CraftWeaponMetadata
	{
		public string Name { get; set; }
		public int Damage { get; set; }
		public int Range { get; set; }
		public int Accuracy { get; set; }
		public int ReloadTime { get; set; }
		public int Ammunition { get; set; }
		public Image Image { get; set; }
		public ItemType Item { get; set; }
		public ItemType? Ammo { get; set; }
		public byte[] Overlay { get; set; }

		public int RoundsInAmmo => Ammo == ItemType.CannonRounds ? 50 : 1;
		public int AmmoPerHour => Ammo == ItemType.CannonRounds ? 2 : 1;
	}
}
