using System.Collections.Generic;
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
		PlasmaBeam/*,

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
		HeavyLaser,
		Grenade,
		SmokeGrenade,
		ProximityGrenade,
		HighExplosive,
		MotionScanner,
		MediKit,
		StunRod,
		ElectroFlare,
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

		private static TopicMetadata Craft(CraftType craft, ResearchType? requiredResearch = null)
		{
			return new TopicMetadata
			{
				Name = craft.Metadata().Name,
				Category = TopicCategory.CraftAndArmament,
				Background = null,
				Scheme = ColorScheme.LightPurple,
				RequiredResearch = requiredResearch,
				Craft = craft
			};
		}

		private static TopicMetadata Armament(CraftWeaponType craftWeapon, ResearchType? requiredResearch = null)
		{
			return new TopicMetadata
			{
				Name = craftWeapon.Metadata().Name,
				Category = TopicCategory.CraftAndArmament,
				Background = null,
				Scheme = ColorScheme.Orange,
				RequiredResearch = requiredResearch,
				CraftWeapon = craftWeapon
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
			{ TopicType.PlasmaBeam, Armament(CraftWeaponType.PlasmaBeam, ResearchType.PlasmaCannon) }
		};
	}
}
