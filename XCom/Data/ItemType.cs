using System.Collections.Generic;
using XCom.Content.Items;

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
		IncendiaryRocket,

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

		private static ItemMetadata StoreEquipment(string name, int purchaseHours, int cost, int salePrice, int storageSpace, byte[] image)
		{
			return new ItemMetadata
			{
				Name = name,
				AvailableToBuy = true,
				PurchaseHours = purchaseHours,
				Cost = cost,
				SalePrice = salePrice,
				StorageSpace = storageSpace,
				IsEquipment = true,
				Image = image
			};
		}

		private static ItemMetadata StoreAmmo(string name, int purchaseHours, int cost, int salePrice, int storageSpace, ItemType weapon, byte[] image)
		{
			return new ItemMetadata
			{
				Name = name,
				AvailableToBuy = true,
				PurchaseHours = purchaseHours,
				Cost = cost,
				SalePrice = salePrice,
				StorageSpace = storageSpace,
				AmmoForWeapon = weapon,
				IsEquipment = true,
				Image = image
			};
		}

		private static ItemMetadata StoreTank(string name, int purchaseHours, int cost, int salePrice)
		{
			return new ItemMetadata
			{
				Name = name,
				AvailableToBuy = true,
				PurchaseHours = purchaseHours,
				Cost = cost,
				SalePrice = salePrice,
				StorageSpace = 600,
				HwpSpace = 1
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

		private static ItemMetadata OtherEquipment(string name, int salePrice, int storageSpace, params ResearchType[] requiredResearch)
		{
			return new ItemMetadata
			{
				Name = name,
				SalePrice = salePrice,
				StorageSpace = storageSpace,
				IsEquipment = true,
				RequiredResearch = requiredResearch
			};
		}

		private static ItemMetadata OtherAmmo(string name, int salePrice, int storageSpace, ItemType weapon)
		{
			return new ItemMetadata
			{
				Name = name,
				SalePrice = salePrice,
				StorageSpace = storageSpace,
				AmmoForWeapon = weapon,
				IsEquipment = true
			};
		}

		private static ItemMetadata OtherTank(string name, int salePrice)
		{
			return new ItemMetadata
			{
				Name = name,
				SalePrice = salePrice,
				StorageSpace = 600,
				HwpSpace = 1
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

			{ ItemType.TankCannon, StoreTank("Tank/Cannon", 96, 420000, 340000) },
			{ ItemType.HwpCannonShells, StoreItem("HWP Cannon Shells", 48, 200, 100, 10) },
			{ ItemType.TankRocketLauncher, StoreTank("Tank/Rocket Launcher", 96, 480000, 360000) },
			{ ItemType.HwpRockets, StoreItem("HWP Rockets", 48, 3000, 2250, 60) },

			{ ItemType.Pistol, StoreEquipment("Pistol", 24, 800, 600, 10, Items.Pistol) },
			{ ItemType.PistolClip, StoreAmmo("Pistol Clip", 24, 70, 52, 10, ItemType.Pistol, Items.PistolClip) },
			{ ItemType.Rifle, StoreEquipment("Rifle", 24, 3000, 2250, 20, Items.Rifle) },
			{ ItemType.RifleClip, StoreAmmo("Rifle Clip", 24, 200, 150, 10, ItemType.Rifle, Items.RifleClip) },
			{ ItemType.HeavyCannon, StoreEquipment("Heavy Cannon", 24, 6400, 4800, 30, Items.HeavyCannon) },
			{ ItemType.HcApAmmo, StoreAmmo("HC-AP Ammo", 24, 300, 225, 10, ItemType.HeavyCannon, Items.HcApAmmo) },
			{ ItemType.HcHeAmmo, StoreAmmo("HC-HE Ammo", 24, 500, 275, 10, ItemType.HeavyCannon, Items.HcHeAmmo) },
			{ ItemType.HcIAmmo, StoreAmmo("HC-I Ammo", 24, 400, 300, 10, ItemType.HeavyCannon, Items.HcIAmmo) },
			{ ItemType.AutoCannon, StoreEquipment("Auto-Cannon", 24, 13500, 10125, 30, Items.AutoCannon) },
			{ ItemType.AcApAmmo, StoreAmmo("AC-AP Ammo", 24, 500, 400, 10, ItemType.AutoCannon, Items.AcApAmmo) },
			{ ItemType.AcHeAmmo, StoreAmmo("AC-HE Ammo", 24, 700, 560, 10, ItemType.AutoCannon, Items.AcHeAmmo) },
			{ ItemType.AcIAmmo, StoreAmmo("AC-I Ammo", 24, 650, 520, 10, ItemType.AutoCannon, Items.AcIAmmo) },
			{ ItemType.RocketLauncher, StoreEquipment("Rocket Launcher", 24, 4000, 3000, 40, Items.RocketLauncher) },
			{ ItemType.SmallRocket, StoreAmmo("Small Rocket", 24, 600, 480, 20, ItemType.RocketLauncher, Items.SmallRocket) },
			{ ItemType.LargeRocket, StoreAmmo("Large Rocket", 24, 900, 720, 20, ItemType.RocketLauncher, Items.LargeRocket) },
			{ ItemType.IncendiaryRocket, StoreAmmo("Incendiary Rocket", 24, 1200, 960, 20, ItemType.RocketLauncher, Items.IncendiaryRocket) },
			{ ItemType.Grenade, StoreEquipment("Grenade", 24, 300, 240, 10, Items.Grenade) },
			{ ItemType.SmokeGrenade, StoreEquipment("Smoke Grenade", 24, 150, 120, 10, Items.SmokeGrenade) },
			{ ItemType.ProximityGrenade, StoreEquipment("Proximity Grenade", 24, 500, 400, 10, Items.ProximityGrenade) },
			{ ItemType.HighExplosive, StoreEquipment("High Explosive", 24, 1500, 1200, 20, Items.HighExplosive) },
			{ ItemType.StunRod, StoreEquipment("Stun Rod", 24, 1260, 945, 10, Items.StunRod) },
			{ ItemType.ElectroFlare, StoreEquipment("Electro-flare", 24, 60, 40, 10, Items.ElectroFlare) },

			{ ItemType.FusionBallLauncher, OtherItem("Fusion Ball Launcher", 281100, 200) },
			{ ItemType.LaserCannon, OtherItem("Laser Cannon", 211000, 200) },
			{ ItemType.PlasmaBeam, OtherItem("Plasma Beam", 267300, 120) },
			{ ItemType.FusionBall, OtherItem("Fusion Ball", 53300, 60) },
			{ ItemType.TankLaserCannon, OtherTank("Tank/Laser Cannon", 594000) },
			{ ItemType.HovertankPlasma, OtherTank("Hovertank/Plasma", 980000) },
			{ ItemType.HovertankLauncher, OtherTank("Hovertank/Launcher", 1043000) },
			{ ItemType.HwpFusionBomb, OtherItem("HWP Fusion Bomb", 31500, 60) },

			{ ItemType.LaserPistol, OtherEquipment("Laser Pistol", 20000, 10) },
			{ ItemType.LaserRifle, OtherEquipment("Laser Rifle", 36900, 20) },
			{ ItemType.HeavyLaser, OtherEquipment("Heavy Laser", 61000, 30) },

			{ ItemType.MotionScanner, OtherEquipment("Motion Scanner", 45600, 10) },
			{ ItemType.MediKit, OtherEquipment("Medi-Kit", 46500, 10) },
			{ ItemType.PsiAmp, OtherEquipment("Psi-Amp", 194700, 10) },

			{ ItemType.PlasmaPistol, OtherEquipment("Plasma Pistol", 84000, 10, ResearchType.PlasmaPistol, ResearchType.PlasmaPistolClip) },
			{ ItemType.PlasmaPistolClip, OtherAmmo("Plasma Pistol Clip", 4440, 10, ItemType.PlasmaPistol) },
			{ ItemType.PlasmaRifle, OtherEquipment("Plasma Rifle", 126500, 20, ResearchType.PlasmaRifle, ResearchType.PlasmaRifleClip) },
			{ ItemType.PlasmaRifleClip, OtherAmmo("Plasma Rifle Clip", 6290, 10, ItemType.PlasmaRifle) },
			{ ItemType.HeavyPlasma, OtherEquipment("Heavy Plasma", 171600, 20, ResearchType.HeavyPlasma, ResearchType.HeavyPlasmaClip) },
			{ ItemType.HeavyPlasmaClip, OtherAmmo("Heavy Plasma Clip", 9590, 30, ItemType.HeavyPlasma) },
			{ ItemType.SmallLauncher, OtherEquipment("Small Launcher", 120000, 20, ResearchType.SmallLauncher, ResearchType.StunBomb) },
			{ ItemType.StunBomb, OtherAmmo("Stun Bomb", 15200, 10, ItemType.SmallLauncher) },
			{ ItemType.BlasterLauncher, OtherEquipment("Blaster Launcher", 144000, 30, ResearchType.BlasterLauncher, ResearchType.BlasterBomb) },
			{ ItemType.BlasterBomb, OtherAmmo("Blaster Bomb", 17028, 20, ItemType.BlasterLauncher) },
			{ ItemType.AlienGrenade, OtherEquipment("Alien Grenade", 14850, 10, ResearchType.AlienGrenade) },
			{ ItemType.MindProbe, OtherEquipment("Mind Probe", 304000, 10, ResearchType.MindProbe) },

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
