using System.Collections.Generic;

namespace XCom.Data
{
	public enum LaserWeaponType
	{
		LaserPistol,
		LaserRifle,
		HeavyLaser
	}

	public static class LaserWeaponTypeExtensions
	{
		public static LaserWeaponMetadata Metadata(this LaserWeaponType laserWeaponType) => metadata[laserWeaponType];
		
		private static LaserWeaponMetadata Create(WeaponType weapon, int damage)
		{
			return new LaserWeaponMetadata
			{
				Weapon = weapon,
				Damage = damage
			};
		}

		private static readonly Dictionary<LaserWeaponType, LaserWeaponMetadata> metadata = new Dictionary<LaserWeaponType, LaserWeaponMetadata>
		{
			{ LaserWeaponType.LaserPistol, Create(WeaponType.LaserPistol, 46) },
			{ LaserWeaponType.LaserRifle, Create(WeaponType.LaserRifle, 60) },
			{ LaserWeaponType.HeavyLaser, Create(WeaponType.HeavyLaser, 85) }
		};
	}
}
