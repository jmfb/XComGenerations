using System.Collections.Generic;
using XCom.Content.Images.CraftWeapons;
using XCom.Content.Overlays;
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
			Damage = 10,
			Range = 10,
			Accuracy = 10,
			ReloadTime = 2,
			Ammunition = 200,
			Image = new Image(CraftWeapons.Cannon),
			Item = ItemType.Cannon,
			Ammo = ItemType.CannonRounds,
			Overlay = Overlays.Cannon
		};
		private static readonly CraftWeaponMetadata avalanche = new CraftWeaponMetadata
		{
			Name = "AVALANCHE",
			Damage = 100,
			Range = 60,
			Accuracy = 100,
			ReloadTime = 20,
			Ammunition = 3,
			Image = new Image(CraftWeapons.Avalanche),
			Item = ItemType.AvalancheLauncher,
			Ammo = ItemType.AvalancheMissiles,
			Overlay = Overlays.Avalanche
		};
		private static readonly CraftWeaponMetadata stingray = new CraftWeaponMetadata
		{
			Name = "STINGRAY",
			Damage = 70,
			Range = 30,
			Accuracy = 70,
			ReloadTime = 15,
			Ammunition = 6,
			Image = new Image(CraftWeapons.Stingray),
			Item = ItemType.StingrayLauncher,
			Ammo = ItemType.StingrayMissiles,
			Overlay = Overlays.Stingray
		};
		private static readonly CraftWeaponMetadata laserBeam = new CraftWeaponMetadata
		{
			Name = "LASER BEAM",
			Damage = 70,
			Range = 21,
			Accuracy = 70,
			ReloadTime = 4,
			Ammunition = 0,
			Image = new Image(CraftWeapons.LaserBeam),
			Item = ItemType.LaserCannon,
			Ammo = null,
			Overlay = Overlays.LaserCannon
		};
		private static readonly CraftWeaponMetadata plasmaBeam = new CraftWeaponMetadata
		{
			Name = "PLASMA BEAM",
			Damage = 140,
			Range = 52,
			Accuracy = 140,
			ReloadTime = 6,
			Ammunition = 100,
			Image = new Image(CraftWeapons.PlasmaBeam),
			Item = ItemType.PlasmaBeam,
			Ammo = null,
			Overlay = Overlays.PlasmaBeam
		};
		private static readonly CraftWeaponMetadata fusionBall = new CraftWeaponMetadata
		{
			Name = "FUSION BALL",
			Damage = 230,
			Range = 65,
			Accuracy = 230,
			ReloadTime = 25,
			Ammunition = 2,
			Image = new Image(CraftWeapons.FusionBall),
			Item = ItemType.FusionBallLauncher,
			Ammo = ItemType.FusionBall,
			Overlay = Overlays.FusionBallLauncher
		};

		private static readonly Dictionary<CraftWeaponType, CraftWeaponMetadata> metadata = new Dictionary<CraftWeaponType, CraftWeaponMetadata>
		{
			{ CraftWeaponType.Cannon, cannon },
			{ CraftWeaponType.Avalanche, avalanche },
			{ CraftWeaponType.Stingray, stingray },
			{ CraftWeaponType.LaserBeam, laserBeam },
			{ CraftWeaponType.PlasmaBeam, plasmaBeam },
			{ CraftWeaponType.FusionBall, fusionBall }
		};
	}
}
