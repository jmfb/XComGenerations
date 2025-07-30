namespace XCom.Data;

public enum ManufactureType
{
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
	HeavyPlasma,
	HeavyPlasmaClip,
	PlasmaRifle,
	PlasmaRifleClip,
	PlasmaPistol,
	PlasmaPistolClip,
	BlasterLauncher,
	BlasterBomb,
	SmallLauncher,
	StunBomb,
	AlienGrenade,
	MindProbe,
	PersonalArmor,
	PowerSuit,
	FlyingSuit,
	AlienAlloys,
	UfoPowerSource,
	UfoNavigation,
	Firestorm,
	Lightning,
	Avenger,
}

public static class ManufactureTypeExtensions
{
	public static ManufactureMetadata Metadata(this ManufactureType manufactureType)
	{
		return metadata[manufactureType];
	}

	private static readonly ManufactureMetadata fusionBallLauncher = new()
	{
		Name = "Fusion Ball Launcher",
		Category = "Craft Weapon",
		Cost = 242000,
		HoursToProduce = 400,
		SpaceRequired = 6,
		AlienAlloysRequired = 1,
		ItemProduced = ItemType.FusionBallLauncher,
		RequiredResearch = [ResearchType.FusionMissile],
	};

	private static readonly ManufactureMetadata laserCannon = new()
	{
		Name = "Laser Cannon",
		Category = "Craft Weapon",
		Cost = 182000,
		HoursToProduce = 300,
		SpaceRequired = 6,
		ItemProduced = ItemType.LaserCannon,
		RequiredResearch = [ResearchType.LaserCannon],
	};

	private static readonly ManufactureMetadata plasmaBeam = new()
	{
		Name = "Plasma Beam",
		Category = "Craft Weapon",
		Cost = 226000,
		HoursToProduce = 300,
		SpaceRequired = 8,
		EleriumRequired = 15,
		ItemProduced = ItemType.PlasmaBeam,
		RequiredResearch = [ResearchType.PlasmaCannon],
	};

	private static readonly ManufactureMetadata fusionBall = new()
	{
		Name = "Fusion Ball",
		Category = "Craft Ammunition",
		Cost = 28000,
		HoursToProduce = 600,
		SpaceRequired = 6,
		EleriumRequired = 4,
		ItemProduced = ItemType.FusionBall,
		RequiredResearch = [ResearchType.FusionMissile],
	};

	private static readonly ManufactureMetadata tankLaserCannon = new()
	{
		Name = "Tank/Laser Cannon",
		Category = "Heavy Weapons Platform",
		Cost = 500000,
		HoursToProduce = 1200,
		SpaceRequired = 25,
		ItemProduced = ItemType.TankLaserCannon,
		RequiredResearch = [ResearchType.LaserCannon],
	};

	private static readonly ManufactureMetadata hovertankPlasma = new()
	{
		Name = "Hovertank/Plasma",
		Category = "Heavy Weapons Platform",
		Cost = 850000,
		HoursToProduce = 1200,
		SpaceRequired = 30,
		AlienAlloysRequired = 5,
		EleriumRequired = 30,
		ItemProduced = ItemType.HovertankPlasma,
		RequiredResearch = [ResearchType.PlasmaCannon, ResearchType.NewFighterCraft],
	};

	private static readonly ManufactureMetadata hovertankLauncher = new()
	{
		Name = "Hovertank/Launcher",
		Category = "Heavy Weapons Platform",
		Cost = 900000,
		HoursToProduce = 1400,
		SpaceRequired = 30,
		AlienAlloysRequired = 8,
		EleriumRequired = 25,
		ItemProduced = ItemType.HovertankLauncher,
		RequiredResearch =
		[
			ResearchType.PlasmaCannon,
			ResearchType.FusionMissile,
			ResearchType.NewFighterCraft,
		],
	};

	private static readonly ManufactureMetadata hwpFusionBomb = new()
	{
		Name = "HWP Fusion Bomb",
		Category = "HWP Cannon Shells",
		Cost = 15000,
		HoursToProduce = 400,
		SpaceRequired = 25,
		AlienAlloysRequired = 8,
		EleriumRequired = 5,
		ItemProduced = ItemType.HwpFusionBomb,
		RequiredResearch =
		[
			ResearchType.PlasmaCannon,
			ResearchType.FusionMissile,
			ResearchType.NewFighterCraft,
		],
	};

	private static readonly ManufactureMetadata laserPistol = new()
	{
		Name = "Laser Pistol",
		Category = "Weapon",
		Cost = 8000,
		HoursToProduce = 300,
		SpaceRequired = 2,
		ItemProduced = ItemType.LaserPistol,
		RequiredResearch = [ResearchType.LaserPistol],
	};

	private static readonly ManufactureMetadata laserRifle = new()
	{
		Name = "Laser Rifle",
		Category = "Weapon",
		Cost = 20000,
		HoursToProduce = 400,
		SpaceRequired = 3,
		ItemProduced = ItemType.LaserRifle,
		RequiredResearch = [ResearchType.LaserRifle],
	};

	private static readonly ManufactureMetadata heavyLaser = new()
	{
		Name = "Heavy Laser",
		Category = "Weapon",
		Cost = 32000,
		HoursToProduce = 700,
		SpaceRequired = 4,
		ItemProduced = ItemType.HeavyLaser,
		RequiredResearch = [ResearchType.HeavyLaser],
	};

	private static readonly ManufactureMetadata motionScanner = new()
	{
		Name = "Motion Scanner",
		Category = "Equipment",
		Cost = 34000,
		HoursToProduce = 220,
		SpaceRequired = 4,
		ItemProduced = ItemType.MotionScanner,
		RequiredResearch = [ResearchType.MotionScanner],
	};

	private static readonly ManufactureMetadata mediKit = new()
	{
		Name = "Medi-Kit",
		Category = "Equipment",
		Cost = 28000,
		HoursToProduce = 420,
		SpaceRequired = 4,
		ItemProduced = ItemType.MediKit,
		RequiredResearch = [ResearchType.MediKit],
	};

	private static readonly ManufactureMetadata psiAmp = new()
	{
		Name = "Psi-Amp",
		Category = "Equipment",
		Cost = 160000,
		HoursToProduce = 500,
		SpaceRequired = 4,
		EleriumRequired = 1,
		ItemProduced = ItemType.PsiAmp,
		RequiredResearch = [ResearchType.PsiAmp],
	};

	private static readonly ManufactureMetadata heavyPlasma = new()
	{
		Name = "Heavy Plasma",
		Category = "Weapon",
		Cost = 122000,
		HoursToProduce = 1000,
		SpaceRequired = 4,
		AlienAlloysRequired = 1,
		ItemProduced = ItemType.HeavyPlasma,
		RequiredResearch = [ResearchType.HeavyPlasma, ResearchType.HeavyPlasmaClip],
	};

	private static readonly ManufactureMetadata heavyPlasmaClip = new()
	{
		Name = "Heavy Plasma Clip",
		Category = "Ammunition",
		Cost = 6000,
		HoursToProduce = 80,
		SpaceRequired = 4,
		EleriumRequired = 3,
		ItemProduced = ItemType.HeavyPlasmaClip,
		RequiredResearch = [ResearchType.HeavyPlasma, ResearchType.HeavyPlasmaClip],
	};

	private static readonly ManufactureMetadata plasmaRifle = new()
	{
		Name = "Plasma Rifle",
		Category = "Weapon",
		Cost = 88000,
		HoursToProduce = 820,
		SpaceRequired = 4,
		AlienAlloysRequired = 1,
		ItemProduced = ItemType.PlasmaRifle,
		RequiredResearch = [ResearchType.PlasmaRifle, ResearchType.PlasmaRifleClip],
	};

	private static readonly ManufactureMetadata plasmaRifleClip = new()
	{
		Name = "Plasma Rifle Clip",
		Category = "Ammunition",
		Cost = 3000,
		HoursToProduce = 80,
		SpaceRequired = 4,
		EleriumRequired = 2,
		ItemProduced = ItemType.PlasmaRifleClip,
		RequiredResearch = [ResearchType.PlasmaRifle, ResearchType.PlasmaRifleClip],
	};

	private static readonly ManufactureMetadata plasmaPistol = new()
	{
		Name = "Plasma Pistol",
		Category = "Weapon",
		Cost = 56000,
		HoursToProduce = 600,
		SpaceRequired = 3,
		AlienAlloysRequired = 1,
		ItemProduced = ItemType.PlasmaPistol,
		RequiredResearch = [ResearchType.PlasmaPistol, ResearchType.PlasmaPistolClip],
	};

	private static readonly ManufactureMetadata plasmaPistolClip = new()
	{
		Name = "Plasma Pistol Clip",
		Category = "Ammunition",
		Cost = 2000,
		HoursToProduce = 60,
		SpaceRequired = 4,
		EleriumRequired = 1,
		ItemProduced = ItemType.PlasmaPistolClip,
		RequiredResearch = [ResearchType.PlasmaPistol, ResearchType.PlasmaPistolClip],
	};

	private static readonly ManufactureMetadata blasterLauncher = new()
	{
		Name = "Blaster Launcher",
		Category = "Weapon",
		Cost = 90000,
		HoursToProduce = 1200,
		SpaceRequired = 5,
		AlienAlloysRequired = 1,
		ItemProduced = ItemType.BlasterLauncher,
		RequiredResearch = [ResearchType.BlasterLauncher, ResearchType.BlasterBomb],
	};

	private static readonly ManufactureMetadata blasterBomb = new()
	{
		Name = "Blaster Bomb",
		Category = "Ammunition",
		Cost = 8000,
		HoursToProduce = 220,
		SpaceRequired = 3,
		EleriumRequired = 3,
		ItemProduced = ItemType.BlasterBomb,
		RequiredResearch = [ResearchType.BlasterLauncher, ResearchType.BlasterBomb],
	};

	private static readonly ManufactureMetadata smallLauncher = new()
	{
		Name = "Small Launcher",
		Category = "Weapon",
		Cost = 78000,
		HoursToProduce = 900,
		SpaceRequired = 3,
		AlienAlloysRequired = 1,
		ItemProduced = ItemType.SmallLauncher,
		RequiredResearch = [ResearchType.SmallLauncher, ResearchType.StunBomb],
	};

	private static readonly ManufactureMetadata stunBomb = new()
	{
		Name = "Stun Bomb",
		Category = "Ammunition",
		Cost = 7000,
		HoursToProduce = 200,
		SpaceRequired = 2,
		EleriumRequired = 1,
		ItemProduced = ItemType.StunBomb,
		RequiredResearch = [ResearchType.SmallLauncher, ResearchType.StunBomb],
	};

	private static readonly ManufactureMetadata alienGrenade = new()
	{
		Name = "Alien Grenade",
		Category = "Weapon",
		Cost = 6700,
		HoursToProduce = 200,
		SpaceRequired = 2,
		EleriumRequired = 2,
		ItemProduced = ItemType.AlienGrenade,
		RequiredResearch = [ResearchType.AlienGrenade],
	};

	private static readonly ManufactureMetadata mindProbe = new()
	{
		Name = "Mind Probe",
		Category = "Equipment",
		Cost = 262000,
		HoursToProduce = 1200,
		SpaceRequired = 4,
		EleriumRequired = 1,
		ItemProduced = ItemType.MindProbe,
		RequiredResearch = [ResearchType.MindProbe],
	};

	private static readonly ManufactureMetadata personalArmor = new()
	{
		Name = "Personal Armor",
		Category = "Personal Armor",
		Cost = 22000,
		HoursToProduce = 800,
		SpaceRequired = 12,
		AlienAlloysRequired = 4,
		ItemProduced = ItemType.PersonalArmor,
		RequiredResearch = [ResearchType.PersonalArmor],
	};

	private static readonly ManufactureMetadata powerSuit = new()
	{
		Name = "Power Suit",
		Category = "Personal Armor",
		Cost = 42000,
		HoursToProduce = 1000,
		SpaceRequired = 16,
		AlienAlloysRequired = 5,
		EleriumRequired = 5,
		ItemProduced = ItemType.PowerSuit,
		RequiredResearch = [ResearchType.PowerSuit],
	};

	private static readonly ManufactureMetadata flyingSuit = new()
	{
		Name = "Flying Suit",
		Category = "Personal Armor",
		Cost = 58000,
		HoursToProduce = 1400,
		SpaceRequired = 16,
		AlienAlloysRequired = 5,
		EleriumRequired = 16,
		ItemProduced = ItemType.FlyingSuit,
		RequiredResearch = [ResearchType.FlyingSuit],
	};

	private static readonly ManufactureMetadata alienAlloys = new()
	{
		Name = "Alien Alloys",
		Category = "UFO component",
		Cost = 3000,
		HoursToProduce = 100,
		SpaceRequired = 10,
		ItemProduced = ItemType.AlienAlloys,
		RequiredResearch = [ResearchType.AlienAlloys],
	};

	private static readonly ManufactureMetadata ufoPowerSource = new()
	{
		Name = "UFO Power Source",
		Category = "UFO component",
		Cost = 130000,
		HoursToProduce = 1400,
		SpaceRequired = 22,
		AlienAlloysRequired = 5,
		EleriumRequired = 16,
		ItemProduced = ItemType.UfoPowerSource,
		RequiredResearch = [ResearchType.UfoPowerSource],
	};

	private static readonly ManufactureMetadata ufoNavigation = new()
	{
		Name = "UFO Navigation",
		Category = "UFO component",
		Cost = 150000,
		HoursToProduce = 1600,
		SpaceRequired = 18,
		AlienAlloysRequired = 3,
		ItemProduced = ItemType.UfoNavigation,
		RequiredResearch = [ResearchType.UfoNavigation],
	};

	private static readonly ManufactureMetadata firestorm = new()
	{
		Name = "FIRESTORM",
		Category = "CRAFT",
		Cost = 400000,
		HoursToProduce = 14000,
		SpaceRequired = 30,
		HangarSpaceRequired = 1,
		AlienAlloysRequired = 65,
		PowerSourcesRequired = 1,
		NavigationRequired = 1,
		ItemProduced = ItemType.Firestorm,
		RequiredResearch = [ResearchType.NewFighterCraft],
	};

	private static readonly ManufactureMetadata lightning = new()
	{
		Name = "LIGHTNING",
		Category = "CRAFT",
		Cost = 600000,
		HoursToProduce = 18000,
		SpaceRequired = 34,
		HangarSpaceRequired = 1,
		AlienAlloysRequired = 85,
		PowerSourcesRequired = 1,
		NavigationRequired = 1,
		ItemProduced = ItemType.Lightning,
		RequiredResearch = [ResearchType.NewFighterTransporter],
	};

	private static readonly ManufactureMetadata avenger = new()
	{
		Name = "AVENGER",
		Category = "CRAFT",
		Cost = 900000,
		HoursToProduce = 34000,
		SpaceRequired = 36,
		HangarSpaceRequired = 1,
		AlienAlloysRequired = 120,
		PowerSourcesRequired = 2,
		NavigationRequired = 1,
		ItemProduced = ItemType.Avenger,
		RequiredResearch = [ResearchType.UltimateCraft],
	};

	private static readonly Dictionary<ManufactureType, ManufactureMetadata> metadata = new()
	{
		{ ManufactureType.FusionBallLauncher, fusionBallLauncher },
		{ ManufactureType.LaserCannon, laserCannon },
		{ ManufactureType.PlasmaBeam, plasmaBeam },
		{ ManufactureType.FusionBall, fusionBall },
		{ ManufactureType.TankLaserCannon, tankLaserCannon },
		{ ManufactureType.HovertankPlasma, hovertankPlasma },
		{ ManufactureType.HovertankLauncher, hovertankLauncher },
		{ ManufactureType.HwpFusionBomb, hwpFusionBomb },
		{ ManufactureType.LaserPistol, laserPistol },
		{ ManufactureType.LaserRifle, laserRifle },
		{ ManufactureType.HeavyLaser, heavyLaser },
		{ ManufactureType.MotionScanner, motionScanner },
		{ ManufactureType.MediKit, mediKit },
		{ ManufactureType.PsiAmp, psiAmp },
		{ ManufactureType.HeavyPlasma, heavyPlasma },
		{ ManufactureType.HeavyPlasmaClip, heavyPlasmaClip },
		{ ManufactureType.PlasmaRifle, plasmaRifle },
		{ ManufactureType.PlasmaRifleClip, plasmaRifleClip },
		{ ManufactureType.PlasmaPistol, plasmaPistol },
		{ ManufactureType.PlasmaPistolClip, plasmaPistolClip },
		{ ManufactureType.BlasterLauncher, blasterLauncher },
		{ ManufactureType.BlasterBomb, blasterBomb },
		{ ManufactureType.SmallLauncher, smallLauncher },
		{ ManufactureType.StunBomb, stunBomb },
		{ ManufactureType.AlienGrenade, alienGrenade },
		{ ManufactureType.MindProbe, mindProbe },
		{ ManufactureType.PersonalArmor, personalArmor },
		{ ManufactureType.PowerSuit, powerSuit },
		{ ManufactureType.FlyingSuit, flyingSuit },
		{ ManufactureType.AlienAlloys, alienAlloys },
		{ ManufactureType.UfoPowerSource, ufoPowerSource },
		{ ManufactureType.UfoNavigation, ufoNavigation },
		{ ManufactureType.Firestorm, firestorm },
		{ ManufactureType.Lightning, lightning },
		{ ManufactureType.Avenger, avenger },
	};
}
