using System.Collections.Generic;
using System.Linq;
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
		CyberdiscAutopsy,
		Sectopod,
		SectopodAutopsy,

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
		Battleship
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
				Subject = craft
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
				Subject = craftWeapon
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
				Subject = hwp
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
				Subject = armor
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
				Subject = weapon
			};
		}

		private static TopicMetadata Grenade(GrenadeType grenade, params ResearchType[] requiredResearch)
		{
			return new TopicMetadata
			{
				Name = grenade.Metadata().Name,
				Category = TopicCategory.WeaponsAndEquipment,
				Background = Backgrounds.InfoItem,
				BackgroundPalette = 4,
				Scheme = ColorScheme.Yellow,
				RequiredResearch = requiredResearch,
				Subject = grenade
			};
		}

		private static TopicMetadata Equipment(EquipmentType equipment, params ResearchType[] requiredResearch)
		{
			return new TopicMetadata
			{
				Name = equipment.Metadata().Name,
				Category = TopicCategory.WeaponsAndEquipment,
				Background = Backgrounds.InfoItem,
				BackgroundPalette = 4,
				Scheme = ColorScheme.Yellow,
				RequiredResearch = requiredResearch,
				Subject = equipment
			};
		}

		private static TopicMetadata AlienWeapon(WeaponType weapon, params ResearchType[] requiredResearch)
		{
			return new TopicMetadata
			{
				Name = weapon.Metadata().Name,
				Category = TopicCategory.AlienArtifacts,
				Background = Backgrounds.InfoItem,
				BackgroundPalette = 4,
				Scheme = ColorScheme.Yellow,
				RequiredResearch = requiredResearch,
				Subject = weapon
			};
		}

		private static TopicMetadata AlienAmmunition(AmmunitionType ammunition, params ResearchType[] requiredResearch)
		{
			return new TopicMetadata
			{
				Name = ammunition.Metadata().Name,
				Category = TopicCategory.AlienArtifacts,
				Background = Backgrounds.InfoItem,
				BackgroundPalette = 4,
				Scheme = ColorScheme.Yellow,
				RequiredResearch = requiredResearch,
				Subject = ammunition
			};
		}

		private static TopicMetadata AlienGrenade(GrenadeType grenade, params ResearchType[] requiredResearch)
		{
			return new TopicMetadata
			{
				Name = grenade.Metadata().Name,
				Category = TopicCategory.AlienArtifacts,
				Background = Backgrounds.InfoItem,
				BackgroundPalette = 4,
				Scheme = ColorScheme.Yellow,
				RequiredResearch = requiredResearch,
				Subject = grenade
			};
		}

		private static TopicMetadata AlienEquipment(EquipmentType equipment, params ResearchType[] requiredResearch)
		{
			return new TopicMetadata
			{
				Name = equipment.Metadata().Name,
				Category = TopicCategory.AlienArtifacts,
				Background = Backgrounds.InfoItem,
				BackgroundPalette = 4,
				Scheme = ColorScheme.Yellow,
				RequiredResearch = requiredResearch,
				Subject = equipment
			};
		}

		private static TopicMetadata Facility(FacilityType facility)
		{
			return new TopicMetadata
			{
				Name = facility.Metadata().Name,
				Category = TopicCategory.BaseFacilities,
				Background = Backgrounds.InfoFacility,
				BackgroundPalette = 1,
				Scheme = ColorScheme.LightWhite,
				RequiredResearch = new[] { facility.Metadata().RequiredResearch }
					.Where(research => research != null)
					.Cast<ResearchType>()
					.ToArray(),
				Subject = facility
			};
		}

		private static TopicMetadata Alien(AlienType alien)
		{
			return new TopicMetadata
			{
				Name = alien.Metadata().Name,
				Category = TopicCategory.AlienLifeForms,
				Scheme = ColorScheme.LightWhite,
				RequiredResearch = new[] { alien.Metadata().RequiredResearch },
				Subject = alien
			};
		}

		private static TopicMetadata AlienResearch(AlienResearchType alienResearch)
		{
			return new TopicMetadata
			{
				Name = alienResearch.Metadata().Name,
				Category = TopicCategory.AlienResearch,
				Background = Backgrounds.InfoMission,
				BackgroundPalette = 3,
				Scheme = ColorScheme.LightWhite,
				RequiredResearch = new[] { alienResearch.Metadata().RequiredResearch },
				Subject = alienResearch
			};
		}

		private static TopicMetadata UfoComponent(UfoComponentType ufoComponent)
		{
			return new TopicMetadata
			{
				Name = ufoComponent.Metadata().Name,
				Category = TopicCategory.UfoComponents,
				Scheme = ColorScheme.LightWhite,
				RequiredResearch = new[] { ufoComponent.Metadata().RequiredResearch },
				Subject = ufoComponent
			};
		}

		private static TopicMetadata Ufo(UfoType ufo)
		{
			return new TopicMetadata
			{
				Name = ufo.Metadata().Name,
				Category = TopicCategory.Ufos,
				Background = Backgrounds.InfoUfo,
				BackgroundPalette = 0,
				Scheme = ColorScheme.Aqua,
				RequiredResearch = new[] { ufo.Metadata().RequiredResearch },
				Subject = ufo
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
			{ TopicType.HeavyLaser, Weapon(WeaponType.HeavyLaser, ResearchType.HeavyLaser) },
			{ TopicType.Grenade, Grenade(GrenadeType.Grenade) },
			{ TopicType.SmokeGrenade, Grenade(GrenadeType.SmokeGrenade) },
			{ TopicType.ProximityGrenade, Grenade(GrenadeType.ProximityGrenade) },
			{ TopicType.HighExplosive, Grenade(GrenadeType.HighExplosive) },
			{ TopicType.MotionScanner, Equipment(EquipmentType.MotionScanner, ResearchType.MotionScanner) },
			{ TopicType.MediKit, Equipment(EquipmentType.MediKit, ResearchType.MediKit) },
			{ TopicType.StunRod, Equipment(EquipmentType.StunRod) },
			{ TopicType.ElectroFlare, Equipment(EquipmentType.ElectroFlare) },
			{ TopicType.PsiAmp, Equipment(EquipmentType.PsiAmp, ResearchType.PsiAmp) },
			{ TopicType.HeavyPlasma, AlienWeapon(WeaponType.HeavyPlasma, ResearchType.HeavyPlasma) },
			{ TopicType.HeavyPlasmaClip, AlienAmmunition(AmmunitionType.HeavyPlasmaClip, ResearchType.HeavyPlasmaClip) },
			{ TopicType.PlasmaRifle, AlienWeapon(WeaponType.PlasmaRifle, ResearchType.PlasmaRifle) },
			{ TopicType.PlasmaRifleClip, AlienAmmunition(AmmunitionType.PlasmaRifleClip, ResearchType.PlasmaRifleClip) },
			{ TopicType.PlasmaPistol, AlienWeapon(WeaponType.PlasmaPistol, ResearchType.PlasmaPistol) },
			{ TopicType.PlasmaPistolClip, AlienAmmunition(AmmunitionType.PlasmaPistolClip, ResearchType.PlasmaPistolClip) },
			{ TopicType.BlasterLauncher, AlienWeapon(WeaponType.BlasterLauncher, ResearchType.BlasterLauncher) },
			{ TopicType.BlasterBomb, AlienAmmunition(AmmunitionType.BlasterBomb, ResearchType.BlasterBomb) },
			{ TopicType.SmallLauncher, AlienWeapon(WeaponType.SmallLauncher, ResearchType.SmallLauncher) },
			{ TopicType.StunBomb, AlienAmmunition(AmmunitionType.StunBomb, ResearchType.StunBomb) },
			{ TopicType.AlienGrenade, AlienGrenade(GrenadeType.AlienGrenade, ResearchType.AlienGrenade) },
			{ TopicType.Elerium115, AlienEquipment(EquipmentType.Elerium115, ResearchType.Elerium115) },
			{ TopicType.MindProbe, AlienEquipment(EquipmentType.MindProbe, ResearchType.MindProbe) },
			{ TopicType.AccessLift, Facility(FacilityType.AccessLift) },
			{ TopicType.LivingQuarters, Facility(FacilityType.LivingQuarters) },
			{ TopicType.Laboratory, Facility(FacilityType.Laboratory) },
			{ TopicType.Workshop, Facility(FacilityType.Workshop) },
			{ TopicType.SmallRadarSystem, Facility(FacilityType.SmallRadarSystem) },
			{ TopicType.LargeRadarSystem, Facility(FacilityType.LargeRadarSystem) },
			{ TopicType.MissileDefenses, Facility(FacilityType.MissileDefenses) },
			{ TopicType.GeneralStores, Facility(FacilityType.GeneralStores) },
			{ TopicType.AlienContainment, Facility(FacilityType.AlienContainment) },
			{ TopicType.LaserDefenses, Facility(FacilityType.LaserDefenses) },
			{ TopicType.PlasmaDefenses, Facility(FacilityType.PlasmaDefenses) },
			{ TopicType.FusionBallDefenses, Facility(FacilityType.FusionBallDefenses) },
			{ TopicType.GravShield, Facility(FacilityType.GravShield) },
			{ TopicType.MindShield, Facility(FacilityType.MindShield) },
			{ TopicType.HyperWaveDecoder, Facility(FacilityType.HyperWaveDecoder) },
			{ TopicType.PsionicLaboratory, Facility(FacilityType.PsionicLaboratory) },
			{ TopicType.Hangar, Facility(FacilityType.Hangar) },
			{ TopicType.Sectoid, Alien(AlienType.Sectoid) },
			{ TopicType.SectoidAutopsy, Alien(AlienType.SectoidAutopsy) },
			{ TopicType.Snakeman, Alien(AlienType.Snakeman) },
			{ TopicType.SnakemanAutopsy, Alien(AlienType.SnakemanAutopsy) },
			{ TopicType.Muton, Alien(AlienType.Muton) },
			{ TopicType.MutonAutopsy, Alien(AlienType.MutonAutopsy) },
			{ TopicType.Floater, Alien(AlienType.Floater) },
			{ TopicType.FloaterAutopsy, Alien(AlienType.FloaterAutopsy) },
			{ TopicType.Ethereal, Alien(AlienType.Ethereal) },
			{ TopicType.EtherealAutopsy, Alien(AlienType.EtherealAutopsy) },
			{ TopicType.Celatid, Alien(AlienType.Celatid) },
			{ TopicType.CelatidAutopsy, Alien(AlienType.CelatidAutopsy) },
			{ TopicType.Silacoid, Alien(AlienType.Silacoid) },
			{ TopicType.SilacoidAutopsy, Alien(AlienType.SilacoidAutopsy) },
			{ TopicType.Chryssalid, Alien(AlienType.Chryssalid) },
			{ TopicType.ChryssalidAutopsy, Alien(AlienType.ChryssalidAutopsy) },
			{ TopicType.Reaper, Alien(AlienType.Reaper) },
			{ TopicType.ReaperAutopsy, Alien(AlienType.ReaperAutopsy) },
			{ TopicType.Cyberdisc, Alien(AlienType.Cyberdisc) },
			{ TopicType.CyberdiscAutopsy, Alien(AlienType.CyberdiscAutopsy) },
			{ TopicType.Sectopod, Alien(AlienType.Sectopod) },
			{ TopicType.SectopodAutopsy, Alien(AlienType.SectopodAutopsy) },
			{ TopicType.AlienOrigins, AlienResearch(AlienResearchType.AlienOrigins) },
			{ TopicType.TheMartianSolution, AlienResearch(AlienResearchType.TheMartianSolution) },
			{ TopicType.CydoniaOrBust, AlienResearch(AlienResearchType.CydoniaOrBust) },
			{ TopicType.AlienResearch, AlienResearch(AlienResearchType.AlienResearch) },
			{ TopicType.AlienHarvest, AlienResearch(AlienResearchType.AlienHarvest) },
			{ TopicType.AlienAbduction, AlienResearch(AlienResearchType.AlienAbduction) },
			{ TopicType.AlienInfiltration, AlienResearch(AlienResearchType.AlienInfiltration) },
			{ TopicType.AlienBase, AlienResearch(AlienResearchType.AlienBase) },
			{ TopicType.AlienTerror, AlienResearch(AlienResearchType.AlienTerror) },
			{ TopicType.AlienRetaliation, AlienResearch(AlienResearchType.AlienRetaliation) },
			{ TopicType.AlienSupply, AlienResearch(AlienResearchType.AlienSupply) },
			{ TopicType.UfoPowerSource, UfoComponent(UfoComponentType.UfoPowerSource) },
			{ TopicType.UfoNavigation, UfoComponent(UfoComponentType.UfoNavigation) },
			{ TopicType.UfoConstruction, UfoComponent(UfoComponentType.UfoConstruction) },
			{ TopicType.AlienFood, UfoComponent(UfoComponentType.AlienFood) },
			{ TopicType.AlienEntertainment, UfoComponent(UfoComponentType.AlienEntertainment) },
			{ TopicType.AlienSurgery, UfoComponent(UfoComponentType.AlienSurgery) },
			{ TopicType.ExaminationRoom, UfoComponent(UfoComponentType.ExaminationRoom) },
			{ TopicType.AlienAlloys, UfoComponent(UfoComponentType.AlienAlloys) },
			{ TopicType.SmallScout, Ufo(UfoType.SmallScout) },
			{ TopicType.MediumScout, Ufo(UfoType.MediumScout) },
			{ TopicType.LargeScout, Ufo(UfoType.LargeScout) },
			{ TopicType.Abductor, Ufo(UfoType.Abductor) },
			{ TopicType.Harvester, Ufo(UfoType.Harvester) },
			{ TopicType.SupplyShip, Ufo(UfoType.SupplyShip) },
			{ TopicType.TerrorShip, Ufo(UfoType.TerrorShip) },
			{ TopicType.Battleship, Ufo(UfoType.Battleship) }
		};
	}
}
