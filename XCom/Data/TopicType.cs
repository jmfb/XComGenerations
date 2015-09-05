using System.Collections.Generic;
using XCom.Content.Backgrounds;
using XCom.Graphics;

namespace XCom.Data
{
	public enum TopicType
	{
		Skyranger,
		Lightning,
		Avenger,
		Interceptor,
		Firestorm,
		Stingray,
		Avalanche,
		Cannon,
		FusionBall,
		LaserCannon,
		PlasmaBeam,

		TankCannon,
		TankRocketLauncher,
		TankLaserCannon,
		HovertankPlasma,
		HovertankLauncher,

		PersonalArmor,
		PowerSuit,
		FlyingSuit,
		Pistol,
		Rifle,
		HeavyCannon,
		AutoCannon,
		RocketLauncher,
		LaserPistol,
		LaserRifle,
		HeavyLaser/*,
		Grenade,
		SmokeGrenade,
		ProximityGrenade,
		HighExplosive,
		MotionScanner,
		MediKit,
		StunRod,
		ElectroFlare,
		PsiAmp/*,

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
		Elerium115,
		MindProbe,

		AccessLift,
		LivingQuarters,
		Laboratory,
		Workshop,
		SmallRadarSystem,
		LargeRadarSystem,
		MissileDefenses,
		GeneralStores,
		AlienContainment,
		LaserDefenses,
		PlasmaDefenses,
		FusionBallDefenses,
		GravShield,
		MindShield,
		HyperWaveDecoder,
		PsionicLaboratory,
		Hangar,

		Sectoid,
		SectoidAutopsy,
		Snakeman,
		SnakemanAutopsy,
		Muton,
		MutonAutopsy,
		Floater,
		FloaterAutopsy,
		Ethereal,
		EtherealAutopsy,
		Celatid,
		CelatidAutopsy,
		Silacoid,
		SilacoidAutopsy,
		Chryssalid,
		ChryssalidAutopsy,
		Reaper,
		ReaperAutopsy,
		Cyberdisc,
		CyberdisAutopsy,

		AlienOrigins,
		TheMartianSolution,
		CydoniaOrBust,
		AlienResearch,
		AlienHarvest,
		AlienAbduction,
		AlienInfiltration,
		AlienBase,
		AlienTerror,
		AlienRetaliation,
		AlienSupply,

		UfoPowerSource,
		UfoNavigation,
		UfoConstruction,
		AlienFood,
		AlienEntertainment,
		AlienSurgery,
		ExaminationRoom,
		AlienAlloys,

		SmallScout,
		MediumScout,
		LargeScout,
		Abductor,
		Harvester,
		SupplyShip,
		TerrorShip,
		Battleship*/
	}

	public static class TopicTypeExtensions
	{
		public static TopicMetadata Metadata(this TopicType topicType)
		{
			return metadata[topicType];
		}

		private static TopicMetadata Craft(CraftType craft, params ResearchType[] requiredResearch)
		{
			return new TopicMetadata
			{
				Name = craft.Metadata().Name,
				Category = TopicCategory.CraftAndArmament,
				Scheme = ColorScheme.LightPurple,
				RequiredResearch = requiredResearch,
				Craft = craft
			};
		}

		private static TopicMetadata Armament(CraftWeaponType craftWeapon, params ResearchType[] requiredResearch)
		{
			return new TopicMetadata
			{
				Name = craftWeapon.Metadata().Name,
				Category = TopicCategory.CraftAndArmament,
				Scheme = ColorScheme.Orange,
				RequiredResearch = requiredResearch,
				CraftWeapon = craftWeapon
			};
		}

		private static TopicMetadata HeavyWeaponsPlatform(HwpType hwp, params ResearchType[] requiredResearch)
		{
			return new TopicMetadata
			{
				Name = hwp.Metadata().Name,
				Category = TopicCategory.HeavyWeaponsPlatforms,
				Background = Backgrounds.InfoMission,
				BackgroundPalette = 3,
				Scheme = ColorScheme.LightWhite,
				RequiredResearch = requiredResearch,
				Hwp = hwp
			};
		}

		private static TopicMetadata Armor(ArmorType armor, params ResearchType[] requiredResearch)
		{
			return new TopicMetadata
			{
				Name = armor.Metadata().Name,
				Category = TopicCategory.WeaponsAndEquipment,
				Scheme = ColorScheme.DarkYellow,
				RequiredResearch = requiredResearch,
				Armor = armor
			};
		}

		private static TopicMetadata Weapon(WeaponType weapon, params ResearchType[] requiredResearch)
		{
			return new TopicMetadata
			{
				Name = weapon.Metadata().Name,
				Category = TopicCategory.WeaponsAndEquipment,
				Background = Backgrounds.InfoItem,
				BackgroundPalette = 4,
				Scheme = ColorScheme.Yellow,
				RequiredResearch = requiredResearch,
				Weapon = weapon
			};
		}

		private static readonly Dictionary<TopicType, TopicMetadata> metadata = new Dictionary<TopicType, TopicMetadata>
		{
			{ TopicType.Skyranger, Craft(CraftType.Skyranger) },
			{ TopicType.Lightning, Craft(CraftType.Lightning, ResearchType.NewFighterTransporter) },
			{ TopicType.Avenger, Craft(CraftType.Avenger, ResearchType.UltimateCraft) },
			{ TopicType.Interceptor, Craft(CraftType.Interceptor) },
			{ TopicType.Firestorm, Craft(CraftType.Firestorm, ResearchType.NewFighterCraft) },
			{ TopicType.Stingray, Armament(CraftWeaponType.Stingray) },
			{ TopicType.Avalanche, Armament(CraftWeaponType.Avalanche) },
			{ TopicType.Cannon, Armament(CraftWeaponType.Cannon) },
			{ TopicType.FusionBall, Armament(CraftWeaponType.FusionBall, ResearchType.FusionMissile) },
			{ TopicType.LaserCannon, Armament(CraftWeaponType.LaserBeam, ResearchType.LaserCannon) },
			{ TopicType.PlasmaBeam, Armament(CraftWeaponType.PlasmaBeam, ResearchType.PlasmaCannon) },
			{ TopicType.TankCannon, HeavyWeaponsPlatform(HwpType.TankCannon) },
			{ TopicType.TankRocketLauncher, HeavyWeaponsPlatform(HwpType.TankRocketLauncher) },
			{ TopicType.TankLaserCannon, HeavyWeaponsPlatform(HwpType.TankLaser, ResearchType.LaserCannon) },
			{ TopicType.HovertankPlasma, HeavyWeaponsPlatform(HwpType.HovertankPlasma, ResearchType.PlasmaCannon, ResearchType.NewFighterCraft) },
			{ TopicType.HovertankLauncher, HeavyWeaponsPlatform(HwpType.HovertankLauncher, ResearchType.PlasmaCannon, ResearchType.FusionMissile, ResearchType.NewFighterCraft) },
			{ TopicType.PersonalArmor, Armor(ArmorType.PersonalArmor, ResearchType.PersonalArmor) },
			{ TopicType.PowerSuit, Armor(ArmorType.PowerSuit, ResearchType.PowerSuit) },
			{ TopicType.FlyingSuit, Armor(ArmorType.FlyingSuit, ResearchType.FlyingSuit) },
			{ TopicType.Pistol, Weapon(WeaponType.Pistol) },
			{ TopicType.Rifle, Weapon(WeaponType.Rifle) },
			{ TopicType.HeavyCannon, Weapon(WeaponType.HeavyCannon) },
			{ TopicType.AutoCannon, Weapon(WeaponType.AutoCannon) },
			{ TopicType.RocketLauncher, Weapon(WeaponType.RocketLauncher) },
			{ TopicType.LaserPistol, Weapon(WeaponType.LaserPistol, ResearchType.LaserPistol) },
			{ TopicType.LaserRifle, Weapon(WeaponType.LaserRifle, ResearchType.LaserRifle) },
			{ TopicType.HeavyLaser, Weapon(WeaponType.HeavyLaser, ResearchType.HeavyLaser) }
		};
	}
}
