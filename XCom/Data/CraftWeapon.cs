namespace XCom.Data
{
	public class CraftWeapon
	{
		public CraftWeaponType WeaponType { get; set; }
		public int Ammunition { get; set; }

		public static CraftWeapon CreateLoaded(CraftWeaponType weaponType)
		{
			return new CraftWeapon
			{
				WeaponType = weaponType,
				Ammunition = weaponType.Metadata().Ammunition
			};
		}
	}
}
