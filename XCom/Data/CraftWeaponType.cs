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

		private static readonly CraftWeaponMetadata cannon = new CraftWeaponMetadata
		{
			Name = "CANNON",
			Ammunition = 200,
			Image = new Image(CraftWeapons.Cannon)
		};

		private static readonly CraftWeaponMetadata avalance = new CraftWeaponMetadata
		{
			Name = "AVALANCHE",
			Ammunition = 3,
			Image = new Image(CraftWeapons.Avalanche)
		};

		private static readonly CraftWeaponMetadata stingray = new CraftWeaponMetadata
		{
			Name = "STINGRAY",
			Ammunition = 6,
			Image = new Image(CraftWeapons.Stingray)
		};

		private static readonly CraftWeaponMetadata laserBeam = new CraftWeaponMetadata
		{
			Name = "LASER BEAM",
			Ammunition = 0,
			Image = new Image(CraftWeapons.LaserBeam)
		};

		private static readonly CraftWeaponMetadata plasmaBeam = new CraftWeaponMetadata
		{
			Name = "PLASMA BEAM",
			Ammunition = 100,
			Image = new Image(CraftWeapons.PlasmaBeam)
		};

		private static readonly CraftWeaponMetadata fusionBall = new CraftWeaponMetadata
		{
			Name = "FUSION BALL",
			Ammunition = 2,
			Image = new Image(CraftWeapons.FusionBall)
		};

		private static readonly Dictionary<CraftWeaponType, CraftWeaponMetadata> metadata = new Dictionary<CraftWeaponType,CraftWeaponMetadata>
		{
			{ CraftWeaponType.Cannon, cannon },
			{ CraftWeaponType.Avalanche, avalance },
			{ CraftWeaponType.Stingray, stingray },
			{ CraftWeaponType.LaserBeam, laserBeam },
			{ CraftWeaponType.PlasmaBeam, plasmaBeam },
			{ CraftWeaponType.FusionBall, fusionBall }
		};
	}
}
