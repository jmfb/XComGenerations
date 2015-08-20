using System.Collections.Generic;

namespace XCom.Data
{
	public enum ItemType
	{
		Soldier,
		Scientist,
		Engineer,

		Skyranger,
		Interceptor,

		StingrayLauncher,
		AvalancheLauncher,
		Cannon,
		StingrayMissiles,
		AvalancheMissiles,
		CannonRounds,

		TankCannon,
		HwpCannonShells,
		TankRocketLauncher,
		HwpRockets,

		Pistol,
		PistolClip,
		Rifle,
		RifleClip,
		HeavyCannon,
		HcApAmmo,
		HcHeAmmo,
		HcIAmmo,
		AutoCannon,
		AcApAmmo,
		AcHeAmmo,
		AcIAmmo,
		RocketLauncher,
		SmallRocket,
		LargeRocket,
		IncindiaryRocket,

		Grenade,
		SmokeGrenade,
		ProximityGrenade,
		HighExplosive,
		StunRod,
		ElectroFlare,

		FusionBallLauncher,
		LaserCannon,
		PlasmaBeam,
		FusionBall,
		TankLaserCannon,
		HovertankPlasma,
		HovertankLauncher,
		HwpFusionBomb,

		LaserPistol,
		LaserRifle,
		HeavyLaser,

		MotionScanner,
		MediKit,
		PsiAmp,

		PlasmaPistol,
		PlasmaPistolClip,
		PlasmaRifle,
		PlasmaRifleClip,
		HeavyPlasma,
		HeavyPlasmaClip,
		SmallLauncher,
		StunBomb,
		BlasterLauncher,
		BlasterBomb,
		AlienGrenade,
		MindProbe,

		PersonalArmor,
		PowerSuit,
		FlyingSuit,

		UfoPowerSource,
		UfoNavigation,
		AlienAlloys,
		Elerium115,
		AlienFood,
		AlienEntertainment,
		AlienSurgery,
		ExaminationRoom,

		Firestorm,
		Lightning,
		Avenger,

		SectoidCorpse,
		SectoidSoldier,
		SectoidNavigator,
		SectoidMedic,
		SectoidEngineer,
		SectoidLeader,
		SectoidCommander,
		FloaterCorpse,
		FloaterSoldier,
		FloaterNavigator,
		FloaterMedic,
		FloaterEngineer,
		FloaterLeader,
		FloaterCommander,
		SnakemanCorpse,
		SnakemanSoldier,
		SnakemanNavigator,
		SnakemanMedic,
		SnakemanEngineer,
		SnakemanLeader,
		SnakemanCommander,
		MutonCorpse,
		MutonSoldier,
		MutonNavigator,
		MutonEngineer,
		EtherealCorpse,
		EtherealSoldier,
		EtherealLeader,
		EtherealCommander,
		ReaperCorpse,
		ReaperTerrorist,
		ChryssalidCorpse,
		ChryssalidTerrorist,
		SilacoidCorpse,
		SilacoidTerrorist,
		CelatidCorpse,
		CelatidTerrorist,
		SectopodCorpse,
		SectopodTerrorist,
		CyberdiscCorpse,
		CyberdiscTerrorist
	}

	public static class ItemTypeExtensions
	{
		public static ItemMetadata Metadata(this ItemType itemType)
		{
			return metadata[itemType];
		}

		private static readonly ItemMetadata laserPistol = new ItemMetadata
		{
			Name = "Laser Pistol"
		};

		private static readonly Dictionary<ItemType, ItemMetadata> metadata = new Dictionary<ItemType, ItemMetadata>
		{
			{ ItemType.LaserPistol, laserPistol }
		};
	}
}
