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
		FloaterCorpse,
		SnakemanCorpse,
		MutonCorpse,
		EtherealCorpse,
		ReaperCorpse,
		ChryssalidCorpse,
		SilacoidCorpse,
		CelatidCorpse,
		SectopodCorpse,
		CyberdiscCorpse,

		SectoidSoldier,
		SectoidNavigator,
		SectoidMedic,
		SectoidEngineer,
		SectoidLeader,
		SectoidCommander,

		FloaterSoldier,
		FloaterNavigator,
		FloaterMedic,
		FloaterEngineer,
		FloaterLeader,
		FloaterCommander,

		SnakemanSoldier,
		SnakemanNavigator,
		SnakemanMedic,
		SnakemanEngineer,
		SnakemanLeader,
		SnakemanCommander,

		MutonSoldier,
		MutonNavigator,
		MutonEngineer,

		EtherealSoldier,
		EtherealLeader,
		EtherealCommander,

		ReaperTerrorist,
		ChryssalidTerrorist,
		SilacoidTerrorist,
		CelatidTerrorist,
		SectopodTerrorist,
		CyberdiscTerrorist
	}

	public static class ItemTypeExtensions
	{
		public static ItemMetadata Metadata(this ItemType itemType)
		{
			return metadata[itemType];
		}

		private static ItemMetadata Personnel(string name, int cost)
		{
			return new ItemMetadata
			{
				Name = name,
				AvailableToBuy = true,
				PurchaseHours = 72,
				Cost = cost,
				MonthlyCost = cost / 2,
				LivingSpace = 1
			};
		}

		private static ItemMetadata Craft(string name, int purchaseHours, int cost)
		{
			return new ItemMetadata
			{
				Name = name,
				AvailableToBuy = true,
				PurchaseHours = purchaseHours,
				Cost = cost,
				MonthlyCost = cost,
				HangarSpace = 1
			};
		}

		private static ItemMetadata StoreItem(string name, int purchaseHours, int cost, int salePrice, int storageSpace)
		{
			return new ItemMetadata
			{
				Name = name,
				AvailableToBuy = true,
				PurchaseHours = purchaseHours,
				Cost = cost,
				SalePrice = salePrice,
				StorageSpace = storageSpace
			};
		}

		private static ItemMetadata OtherItem(string name, int salePrice, int storageSpace)
		{
			return new ItemMetadata
			{
				Name = name,
				SalePrice = salePrice,
				StorageSpace = storageSpace
			};
		}

		private static ItemMetadata CustomCraft(string name)
		{
			return new ItemMetadata
			{
				Name = name
			};
		}

		private static ItemMetadata Corpse(string name, int storageSpace)
		{
			return new ItemMetadata
			{
				Name = name,
				SalePrice = 20000,
				StorageSpace = storageSpace
			};
		}

		private static ItemMetadata LiveAlien(string name)
		{
			return new ItemMetadata
			{
				Name = name,
				IsLiveAlien = true
			};
		}

		private static readonly Dictionary<ItemType, ItemMetadata> metadata = new Dictionary<ItemType, ItemMetadata>
		{
			{ ItemType.Soldier, Personnel("Soldier", 40000) },
			{ ItemType.Scientist, Personnel("Scientist", 60000) },
			{ ItemType.Engineer, Personnel("Engineer", 50000) },

			{ ItemType.Skyranger, Craft("SKYRANGER", 72, 500000) },
			{ ItemType.Interceptor, Craft("INTERCEPTOR", 96, 600000) },

			{ ItemType.StingrayLauncher, StoreItem("Stingray Launcher", 48, 16000, 12000, 80) },
			{ ItemType.AvalancheLauncher, StoreItem("Avalanche Launcher", 48, 17000, 12750, 100) },
			{ ItemType.Cannon, StoreItem("Cannon", 48, 30000, 22500, 150) },
			{ ItemType.StingrayMissiles, StoreItem("Stingray Missiles", 48, 3000, 2400, 40) },
			{ ItemType.AvalancheMissiles, StoreItem("Avalanche Missiles", 48, 9000, 7200, 150) },
			{ ItemType.CannonRounds, StoreItem("Cannon Rounds (x50)", 96, 1240, 1012, 0) },

			{ ItemType.TankCannon, StoreItem("Tank/Cannon", 96, 420000, 340000, 600) },
			{ ItemType.HwpCannonShells, StoreItem("HWP Cannon Shells", 48, 200, 100, 10) },
			{ ItemType.TankRocketLauncher, StoreItem("Tank/Rocket Launcher", 96, 480000, 360000, 600) },
			{ ItemType.HwpRockets, StoreItem("HWP Rockets", 48, 3000, 2250, 60) },

			{ ItemType.Pistol, StoreItem("Pistol", 24, 800, 600, 10) },
			{ ItemType.PistolClip, StoreItem("Pistol Clip", 24, 70, 52, 10) },
			{ ItemType.Rifle, StoreItem("Rifle", 24, 3000, 2250, 20) },
			{ ItemType.RifleClip, StoreItem("Rifle Clip", 24, 200, 150, 10) },
			{ ItemType.HeavyCannon, StoreItem("Heavy Cannon", 24, 6400, 4800, 30) },
			{ ItemType.HcApAmmo, StoreItem("HC-AP Ammo", 24, 300, 225, 10) },
			{ ItemType.HcHeAmmo, StoreItem("HC-HE Ammo", 24, 500, 275, 10) },
			{ ItemType.HcIAmmo, StoreItem("HC-I Ammo", 24, 400, 300, 10) },
			{ ItemType.AutoCannon, StoreItem("Auto-Cannon", 24, 13500, 10125, 30) },
			{ ItemType.AcApAmmo, StoreItem("AC-AP Ammo", 24, 500, 400, 10) },
			{ ItemType.AcHeAmmo, StoreItem("AC-HE Ammo", 24, 700, 560, 10) },
			{ ItemType.AcIAmmo, StoreItem("AC-I Ammo", 24, 650, 520, 10) },
			{ ItemType.RocketLauncher, StoreItem("Rocket Launcher", 24, 4000, 3000, 40) },
			{ ItemType.SmallRocket, StoreItem("Small Rocket", 24, 600, 480, 20) },
			{ ItemType.LargeRocket, StoreItem("Large Rocket", 24, 900, 720, 20) },
			{ ItemType.IncindiaryRocket, StoreItem("Incindiary Rocket", 24, 1200, 960, 20) },
			{ ItemType.Grenade, StoreItem("Grenade", 24, 300, 240, 10) },
			{ ItemType.SmokeGrenade, StoreItem("Smoke Grenade", 24, 150, 120, 10) },
			{ ItemType.ProximityGrenade, StoreItem("Proximity Grenade", 24, 500, 400, 10) },
			{ ItemType.HighExplosive, StoreItem("High Explosive", 24, 1500, 1200, 20) },
			{ ItemType.StunRod, StoreItem("Stun Rod", 24, 1260, 945, 10) },
			{ ItemType.ElectroFlare, StoreItem("Electro-flare", 24, 60, 40, 10) },

			{ ItemType.FusionBallLauncher, OtherItem("Fusion Ball Launcher", 281100, 200) },
			{ ItemType.LaserCannon, OtherItem("Laser Cannon", 211000, 200) },
			{ ItemType.PlasmaBeam, OtherItem("Plasma Beam", 267300, 120) },
			{ ItemType.FusionBall, OtherItem("Fusion Ball", 53300, 60) },
			{ ItemType.TankLaserCannon, OtherItem("Tank/Laser Cannon", 594000, 600) },
			{ ItemType.HovertankPlasma, OtherItem("Hovertank/Plasma", 980000, 600) },
			{ ItemType.HovertankLauncher, OtherItem("Hovertank/Launcher", 1043000, 600) },
			{ ItemType.HwpFusionBomb, OtherItem("HWP Fusion Bomb", 31500, 60) },

			{ ItemType.LaserPistol, OtherItem("Laser Pistol", 20000, 10) },
			{ ItemType.LaserRifle, OtherItem("Laser Rifle", 36900, 20) },
			{ ItemType.HeavyLaser, OtherItem("Heavy Laser", 61000, 30) },

			{ ItemType.MotionScanner, OtherItem("Motion Scanner", 45600, 10) },
			{ ItemType.MediKit, OtherItem("Medi-Kit", 46500, 10) },
			{ ItemType.PsiAmp, OtherItem("Psi-Amp", 194700, 10) },

			{ ItemType.PlasmaPistol, OtherItem("Plasma Pistol", 84000, 10) },
			{ ItemType.PlasmaPistolClip, OtherItem("Plasma Pistol Clip", 4440, 10) },
			{ ItemType.PlasmaRifle, OtherItem("Plasma Rifle", 126500, 20) },
			{ ItemType.PlasmaRifleClip, OtherItem("Plasma Rifle Clip", 6290, 10) },
			{ ItemType.HeavyPlasma, OtherItem("Heavy Plasma", 171600, 20) },
			{ ItemType.HeavyPlasmaClip, OtherItem("Heavy Plasma Clip", 9590, 30) },
			{ ItemType.SmallLauncher, OtherItem("Small Launcher", 120000, 20) },
			{ ItemType.StunBomb, OtherItem("Stun Bomb", 15200, 10) },
			{ ItemType.BlasterLauncher, OtherItem("Blaster Launcher", 144000, 30) },
			{ ItemType.BlasterBomb, OtherItem("Blaster Bomb", 17028, 20) },
			{ ItemType.AlienGrenade, OtherItem("Alien Grenade", 14850, 10) },
			{ ItemType.MindProbe, OtherItem("Mind Probe", 304000, 10) },

			{ ItemType.PersonalArmor, OtherItem("Personal Armor", 54000, 80) },
			{ ItemType.PowerSuit, OtherItem("Power Suit", 85000, 80) },
			{ ItemType.FlyingSuit, OtherItem("Flying Suit", 115000, 80) },

			{ ItemType.UfoPowerSource, OtherItem("UFO Power Source", 250000, 70) },
			{ ItemType.UfoNavigation, OtherItem("UFO Navigation", 80000, 20) },
			{ ItemType.AlienAlloys, OtherItem("Alien Alloys", 6500, 10) },
			{ ItemType.Elerium115, OtherItem("Elerium-115", 5000, 10) },
			{ ItemType.AlienFood, OtherItem("Alien Food", 5000, 20) },
			{ ItemType.AlienEntertainment, OtherItem("Alien Entertainment", 20000, 20) },
			{ ItemType.AlienSurgery, OtherItem("Alien Surgery", 38000, 20) },
			{ ItemType.ExaminationRoom, OtherItem("Examination Room", 9000, 20) },

			{ ItemType.Firestorm, CustomCraft("Firestorm") },
			{ ItemType.Lightning, CustomCraft("Lightning") },
			{ ItemType.Avenger, CustomCraft("Avenger") },

			{ ItemType.SectoidCorpse, Corpse("Sectoid Corpse", 40) },
			{ ItemType.FloaterCorpse, Corpse("Floater Corpse", 40) },
			{ ItemType.SnakemanCorpse, Corpse("Snakeman Corpse", 40) },
			{ ItemType.MutonCorpse, Corpse("Muton Corpse", 40) },
			{ ItemType.EtherealCorpse, Corpse("Ethereal Corpse", 40) },
			{ ItemType.ReaperCorpse, Corpse("Reaper Corpse", 100) },
			{ ItemType.ChryssalidCorpse, Corpse("Chryssalid Corpse", 40) },
			{ ItemType.SilacoidCorpse, Corpse("Silacoid Corpse", 40) },
			{ ItemType.CelatidCorpse, Corpse("Celatid Corpse", 40) },
			{ ItemType.SectopodCorpse, Corpse("Sectopod Corpse", 100) },
			{ ItemType.CyberdiscCorpse, Corpse("Cyberdisc Corpse", 100) },

			{ ItemType.SectoidSoldier, LiveAlien("Sectoid Soldier") },
			{ ItemType.SectoidNavigator, LiveAlien("Sectoid Navigator") },
			{ ItemType.SectoidMedic, LiveAlien("Sectoid Medic") },
			{ ItemType.SectoidEngineer, LiveAlien("Sectoid Engineer") },
			{ ItemType.SectoidLeader, LiveAlien("Sectoid Leader") },
			{ ItemType.SectoidCommander, LiveAlien("Sectoid Commander") },

			{ ItemType.FloaterSoldier, LiveAlien("Floater Soldier") },
			{ ItemType.FloaterNavigator, LiveAlien("Floater Navigator") },
			{ ItemType.FloaterMedic, LiveAlien("Floater Medic") },
			{ ItemType.FloaterEngineer, LiveAlien("Floater Engineer") },
			{ ItemType.FloaterLeader, LiveAlien("Floater Leader") },
			{ ItemType.FloaterCommander, LiveAlien("Floater Commander") },

			{ ItemType.SnakemanSoldier, LiveAlien("Snakeman Soldier") },
			{ ItemType.SnakemanNavigator, LiveAlien("Snakeman Navigator") },
			{ ItemType.SnakemanMedic, LiveAlien("Snakeman Medic") },
			{ ItemType.SnakemanEngineer, LiveAlien("Snakeman Engineer") },
			{ ItemType.SnakemanLeader, LiveAlien("Snakeman Leader") },
			{ ItemType.SnakemanCommander, LiveAlien("Snakeman Commander") },

			{ ItemType.MutonSoldier, LiveAlien("Muton Soldier") },
			{ ItemType.MutonNavigator, LiveAlien("Muton Navigator") },
			{ ItemType.MutonEngineer, LiveAlien("Muton Engineer") },

			{ ItemType.EtherealSoldier, LiveAlien("Ethereal Soldier") },
			{ ItemType.EtherealLeader, LiveAlien("Ethereal Leader") },
			{ ItemType.EtherealCommander, LiveAlien("Ethereal Commander") },

			{ ItemType.ReaperTerrorist, LiveAlien("Reaper Terrorist") },
			{ ItemType.ChryssalidTerrorist, LiveAlien("Chryssalid Terrorist") },
			{ ItemType.SilacoidTerrorist, LiveAlien("Silacoid Terrorist") },
			{ ItemType.CelatidTerrorist, LiveAlien("Celatid Terrorist") },
			{ ItemType.SectopodTerrorist, LiveAlien("Sectopod Terrorist") },
			{ ItemType.CyberdiscTerrorist, LiveAlien("Cyberdisc Terrorist") }
		};
	}
}
