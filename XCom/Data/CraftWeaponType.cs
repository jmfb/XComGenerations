using System.Collections.Generic;
using XCom.Content.Images.CraftWeapons;
using XCom.Graphics;

namespace XCom.Data
{
	public enum CraftWeaponType
	{
		Cannon,
		Avalanche,
		Stingray,
		LaserBeam,
		PlasmaBeam,
		FusionBall
	}

	public static class CraftWeaponTypeExtensions
	{
		public static CraftWeaponMetadata Metadata(this CraftWeaponType craftWeaponType)
		{
			return metadata[craftWeaponType];
		}

		private static CraftWeaponMetadata Weapon(string name, int ammunition, byte[] image, ItemType item, ItemType? ammo)
		{
			return new CraftWeaponMetadata
			{
				Name = name,
				Ammunition = ammunition,
				Image = new Image(image),
				Item = item,
				Ammo = ammo
			};
		}

		private static readonly Dictionary<CraftWeaponType, CraftWeaponMetadata> metadata = new Dictionary<CraftWeaponType, CraftWeaponMetadata>
		{
			{ CraftWeaponType.Cannon, Weapon("CANNON", 200, CraftWeapons.Cannon, ItemType.Cannon, ItemType.CannonRounds) },
			{ CraftWeaponType.Avalanche, Weapon("AVALANCHE", 3, CraftWeapons.Avalanche, ItemType.AvalancheLauncher, ItemType.AvalancheMissiles) },
			{ CraftWeaponType.Stingray, Weapon("STINGRAY", 6, CraftWeapons.Stingray, ItemType.StingrayLauncher, ItemType.StingrayMissiles) },
			{ CraftWeaponType.LaserBeam, Weapon("LASER BEAM", 0, CraftWeapons.LaserBeam, ItemType.LaserCannon, null) },
			{ CraftWeaponType.PlasmaBeam, Weapon("PLASMA BEAM", 100, CraftWeapons.PlasmaBeam, ItemType.PlasmaBeam, null) },
			{ CraftWeaponType.FusionBall, Weapon("FUSION BALL", 2, CraftWeapons.FusionBall, ItemType.FusionBallLauncher, ItemType.FusionBall) }
		};
	}
}
