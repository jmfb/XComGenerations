using System.Web.Script.Serialization;

namespace XCom.Data
{
	public class CraftWeapon
	{
		public CraftWeaponType WeaponType { get; set; }
		public int Ammunition { get; set; }

		[ScriptIgnore]
		public bool IsFullyArmed => Ammunition == WeaponType.Metadata().Ammunition;

		public static CraftWeapon CreateLoaded(CraftWeaponType weaponType)
		{
			return new CraftWeapon
			{
				WeaponType = weaponType,
				Ammunition = weaponType.Metadata().Ammunition
			};
		}

		public static CraftWeapon CreateUnloaded(CraftWeaponType weaponType)
		{
			return new CraftWeapon
			{
				WeaponType = weaponType,
				Ammunition = 0
			};
		}

		public void Reload(int count)
		{
			var metadata = WeaponType.Metadata();
			Ammunition += count;
			if (Ammunition > metadata.Ammunition)
				Ammunition = metadata.Ammunition;
		}
	}
}
