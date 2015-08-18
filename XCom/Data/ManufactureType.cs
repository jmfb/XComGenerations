using System.Collections.Generic;

namespace XCom.Data
{
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
		Avenger
	}

	public static class ManufactureTypeExtensions
	{
		public static ManufactureMetadata Metadata(this ManufactureType manufactureType)
		{
			return metadata[manufactureType];
		}

		private static readonly ManufactureMetadata fusionBallLauncher = new ManufactureMetadata
		{
			Name = "Fusion Ball Launcher",
			Category = "Craft Weapon",
			Cost = 242000,
			HoursToProduce = 400,
			SpaceRequired = 6,
			AlienAlloysRequired = 1
		};

		private static readonly ManufactureMetadata laserCannon = new ManufactureMetadata
		{
			Name = "Laser Cannon",
			Category = "Craft Weapon",
			Cost = 182000,
			HoursToProduce = 300,
			SpaceRequired = 6
		};

		private static readonly ManufactureMetadata plasmaBeam = new ManufactureMetadata
		{
			Name = "Plasma Beam",
			Category = "Craft Weapon",
			Cost = 226000,
			HoursToProduce = 300,
			SpaceRequired = 8,
			EleriumRequired = 15
		};

		private static readonly ManufactureMetadata fusionBall = new ManufactureMetadata
		{
			Name = "Fusion Ball",
			Category = "Craft Ammunition",
			Cost = 28000,
			HoursToProduce = 600,
			SpaceRequired = 6,
			EleriumRequired = 4
		};

		private static readonly ManufactureMetadata tankLaserCannon = new ManufactureMetadata
		{
			Name = "Tank/Laser Cannon",
			Category = "Heavy Weapons Platform",
			Cost = 500000,
			HoursToProduce = 1200,
			SpaceRequired = 25
		};

		private static readonly ManufactureMetadata hovertankPlasma = new ManufactureMetadata
		{
			Name = "Hovertank/Plasma",
			Category = "Heavy Weapons Platform",
			Cost = 850000,
			HoursToProduce = 1200,
			SpaceRequired = 30,
			AlienAlloysRequired = 5,
			EleriumRequired = 30
		};

		private static readonly ManufactureMetadata hovertankLauncher = new ManufactureMetadata
		{
			Name = "Hovertank/Launcher",
			Category = "Heavy Weapons Platform",
			Cost = 900000,
			HoursToProduce = 1400,
			SpaceRequired = 30,
			AlienAlloysRequired = 8,
			EleriumRequired = 25
		};

		private static readonly ManufactureMetadata hwpFusionBomb = new ManufactureMetadata
		{
			Name = "HWP Fusion Bomb",
			Category = "HWP Cannon Shells",
			Cost = 15000,
			HoursToProduce = 400,
			SpaceRequired = 25,
			AlienAlloysRequired = 8,
			EleriumRequired = 5
		};

		private static readonly ManufactureMetadata laserPistol = new ManufactureMetadata
		{
			Name = "Laser Pistol",
			Category = "Weapon",
			Cost = 8000,
			HoursToProduce = 300,
			SpaceRequired = 2
		};

		private static readonly ManufactureMetadata laserRifle = new ManufactureMetadata
		{
			Name = "Laser Rifle",
			Category = "Weapon",
			Cost = 20000,
			HoursToProduce = 400,
			SpaceRequired = 3
		};

		private static readonly ManufactureMetadata heavyLaser = new ManufactureMetadata
		{
			Name = "Heavy Laser",
			Category = "Weapon",
			Cost = 32000,
			HoursToProduce = 700,
			SpaceRequired = 4
		};

		private static readonly ManufactureMetadata motionScanner = new ManufactureMetadata
		{
			Name = "Motion Scanner",
			Category = "Equipment",
			Cost = 34000,
			HoursToProduce = 220,
			SpaceRequired = 4
		};

		private static readonly ManufactureMetadata mediKit = new ManufactureMetadata
		{
			Name = "Medi-Kit",
			Category = "Equipment",
			Cost = 28000,
			HoursToProduce = 420,
			SpaceRequired = 4
		};

		private static readonly ManufactureMetadata psiAmp = new ManufactureMetadata
		{
			Name = "Psi-Amp",
			Category = "Equipment",
			Cost = 160000,
			HoursToProduce = 500,
			SpaceRequired = 4,
			EleriumRequired = 1
		};

		private static readonly ManufactureMetadata heavyPlasma = new ManufactureMetadata
		{
			Name = "Heavy Plasma",
			Category = "Weapon",
			Cost = 122000,
			HoursToProduce = 1000,
			SpaceRequired = 4,
			AlienAlloysRequired = 1
		};

		private static readonly ManufactureMetadata heavyPlasmaClip = new ManufactureMetadata
		{
			Name = "Heavy Plasma Clip",
			Category = "Ammunition",
			Cost = 6000,
			HoursToProduce = 80,
			SpaceRequired = 4,
			EleriumRequired = 3
		};

		private static readonly ManufactureMetadata plasmaRifle = new ManufactureMetadata
		{
			Name = "Plasma Rifle",
			Category = "Weapon",
			Cost = 88000,
			HoursToProduce = 820,
			SpaceRequired = 4,
			AlienAlloysRequired = 1
		};

		private static readonly ManufactureMetadata plasmaRifleClip = new ManufactureMetadata
		{
			Name = "Plasma Rifle Clip",
			Category = "Ammunition",
			Cost = 3000,
			HoursToProduce = 80,
			SpaceRequired = 4,
			EleriumRequired = 2
		};

		private static readonly ManufactureMetadata plasmaPistol = new ManufactureMetadata
		{
			Name = "Plasma Pistol",
			Category = "Weapon",
			Cost = 56000,
			HoursToProduce = 600,
			SpaceRequired = 3,
			AlienAlloysRequired = 1
		};

		private static readonly ManufactureMetadata plasmaPistolClip = new ManufactureMetadata
		{
			Name = "Plasma Pistol Clip",
			Category = "Ammunition",
			Cost = 2000,
			HoursToProduce = 60,
			SpaceRequired = 4,
			EleriumRequired = 1
		};

		private static readonly ManufactureMetadata blasterLauncher = new ManufactureMetadata
		{
			Name = "Blaster Launcher",
			Category = "Weapon",
			Cost = 90000,
			HoursToProduce = 1200,
			SpaceRequired = 5,
			AlienAlloysRequired = 1
		};

		private static readonly ManufactureMetadata blasterBomb = new ManufactureMetadata
		{
			Name = "Blaster Bomb",
			Category = "Ammunition",
			Cost = 8000,
			HoursToProduce = 220,
			SpaceRequired = 3,
			EleriumRequired = 3
		};

		private static readonly ManufactureMetadata smallLauncher = new ManufactureMetadata
		{
			Name = "Small Launcher",
			Category = "Weapon",
			Cost = 78000,
			HoursToProduce = 900,
			SpaceRequired = 3,
			AlienAlloysRequired = 1
		};

		private static readonly ManufactureMetadata stunBomb = new ManufactureMetadata
		{
			Name = "Stun Bomb",
			Category = "Ammunition",
			Cost = 7000,
			HoursToProduce = 200,
			SpaceRequired = 2,
			EleriumRequired = 1
		};

		private static readonly ManufactureMetadata alienGrenade = new ManufactureMetadata
		{
			Name = "Alien Grenade",
			Category = "Weapon",
			Cost = 6700,
			HoursToProduce = 200,
			SpaceRequired = 2,
			EleriumRequired = 2
		};

		private static readonly ManufactureMetadata mindProbe = new ManufactureMetadata
		{
			Name = "Mind Probe",
			Category = "Equipment",
			Cost = 262000,
			HoursToProduce = 1200,
			SpaceRequired = 4,
			EleriumRequired = 1
		};

		private static readonly ManufactureMetadata personalArmor = new ManufactureMetadata
		{
			Name = "Personal Armor",
			Category = "Personal Armor",
			Cost = 22000,
			HoursToProduce = 800,
			SpaceRequired = 12,
			AlienAlloysRequired = 4
		};

		private static readonly ManufactureMetadata powerSuit = new ManufactureMetadata
		{
			Name = "Power Suit",
			Category = "Personal Armor",
			Cost = 42000,
			HoursToProduce = 1000,
			SpaceRequired = 16,
			AlienAlloysRequired = 5,
			EleriumRequired = 5
		};

		private static readonly ManufactureMetadata flyingSuit = new ManufactureMetadata
		{
			Name = "Flying Suit",
			Category = "Personal Armor",
			Cost = 58000,
			HoursToProduce = 1400,
			SpaceRequired = 16,
			AlienAlloysRequired = 5,
			EleriumRequired = 16
		};

		private static readonly ManufactureMetadata alienAlloys = new ManufactureMetadata
		{
			Name = "Alien Alloys",
			Category = "UFO component",
			Cost = 3000,
			HoursToProduce = 100,
			SpaceRequired = 10
		};

		private static readonly ManufactureMetadata ufoPowerSource = new ManufactureMetadata
		{
			Name = "UFO Power Source",
			Category = "UFO component",
			Cost = 130000,
			HoursToProduce = 1400,
			SpaceRequired = 22,
			AlienAlloysRequired = 5,
			EleriumRequired = 16
		};

		private static readonly ManufactureMetadata ufoNavigation = new ManufactureMetadata
		{
			Name = "UFO Navigation",
			Category = "UFO component",
			Cost = 150000,
			HoursToProduce = 1600,
			SpaceRequired = 18,
			AlienAlloysRequired = 3
		};

		private static readonly ManufactureMetadata firestorm = new ManufactureMetadata
		{
			Name = "FIRESTORM",
			Category = "CRAFT",
			Cost = 400000,
			HoursToProduce = 14000,
			SpaceRequired = 30,
			AlienAlloysRequired = 65,
			PowerSourcesRequired = 1,
			NavigationRequired = 1
		};

		private static readonly ManufactureMetadata lightning = new ManufactureMetadata
		{
			Name = "LIGHTNING",
			Category = "CRAFT",
			Cost = 600000,
			HoursToProduce = 18000,
			SpaceRequired = 34,
			AlienAlloysRequired = 85,
			PowerSourcesRequired = 1,
			NavigationRequired = 1
		};

		private static readonly ManufactureMetadata avenger = new ManufactureMetadata
		{
			Name = "AVENGER",
			Category = "CRAFT",
			Cost = 900000,
			HoursToProduce = 34000,
			SpaceRequired = 36,
			AlienAlloysRequired = 120,
			PowerSourcesRequired = 2,
			NavigationRequired = 1
		};

		private static readonly Dictionary<ManufactureType, ManufactureMetadata> metadata = new Dictionary<ManufactureType, ManufactureMetadata>
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
			{ ManufactureType.Avenger, avenger }
		};
	}
}
