using System.Collections.Generic;

namespace XCom.Data
{
	public enum ResearchType
	{
		LaserWeapons,
		LaserPistol,
		LaserRifle,
		HeavyLaser,
		LaserCannon,
		LaserDefenses,
		PlasmaPistol,
		PlasmaPistolClip,
		PlasmaRifle,
		PlasmaRifleClip,
		HeavyPlasma,
		HeavyPlasmaClip,
		PlasmaCannon,
		PlasmaDefenses,
		MediKit,
		MotionScanner,
		AlienGrenade,
		SmallLauncher,
		StunBomb,
		BlasterLauncher,
		BlasterBomb,
		FusionMissile,
		FusionDefenses,
		UfoPowerSource,
		UfoNavigation,
		AlienAlloys,
		Elerium115,
		PersonalArmor,
		PowerSuit,
		FlyingSuit,
		UfoConstruction,
		NewFighterCraft,
		NewFighterTransporter,
		UltimateCraft,
		GravShield,
		MindProbe,
		PsiLab,
		PsiAmp,
		MindShield,
		HyperwaveDecoder,
		AlienOrigins,
		TheMartianSolution,
		CydoniaOrBust,
		AlienFood,
		AlienEntertainment,
		AlienSurgery,
		ExaminationRoom,
		AlienResearch,
		AlienHarvest,
		AlienAbduction,
		AlienInfiltration,
		AlienBase,
		AlienTerror,
		AlienRetaliation,
		AlienSupply,
		SmallScout,
		MediumScout,
		LargeScout,
		Abductor,
		Harvester,
		SupplyShip,
		TerrorShip,
		Battleship,
		Soldier,
		Terrorist,
		Navigator,
		Medic,
		Engineer,
		Leader,
		Commander,
		Alien,
		Sectoid,
		SectoidCorpse,
		SectoidSoldier,
		SectoidNavigator,
		SectoidMedic,
		SectoidEngineer,
		SectoidLeader,
		SectoidCommander,
		Floater,
		FloaterCorpse,
		FloaterSoldier,
		FloaterNavigator,
		FloaterMedic,
		FloaterEngineer,
		FloaterLeader,
		FloaterCommander,
		Snakeman,
		SnakemanCorpse,
		SnakemanSoldier,
		SnakemanNavigator,
		SnakemanMedic,
		SnakemanEngineer,
		SnakemanLeader,
		SnakemanCommander,
		Muton,
		MutonCorpse,
		MutonSoldier,
		MutonNavigator,
		MutonEngineer,
		Ethereal,
		EtherealCorpse,
		EtherealSoldier,
		EtherealLeader,
		EtherealCommander,
		Reaper,
		ReaperCorpse,
		ReaperTerrorist,
		Chrysalid,
		ChryssalidCorpse,
		ChryssalidTerrorist,
		Silacoid,
		SilacoidCorpse,
		SilacoidTerrorist,
		Celatid,
		CelatidCorpse,
		CelatidTerrorist,
		Sectopod,
		SectopodCorpse,
		SectopodTerrorist,
		Cyberdisc,
		CyberdiscCorpse,
		CyberdiscTerrorist,
	}

	public static class ResearchTypeExtensions
	{
		public static ResearchMetadata Metadata(this ResearchType researchType)
		{
			return metadata[researchType];
		}

		private static readonly ResearchMetadata laserWeapons = new ResearchMetadata
		{
			Name = "Laser Weapons",
			AverageHoursToComplete = 50,
			Points = 10
		};

		private static readonly ResearchMetadata laserPistol = new ResearchMetadata
		{
			Name = "Laser Pistol",
			AverageHoursToComplete = 100,
			Points = 10,
			RequiredResearch = new[]
			{
				new[] {  ResearchType.LaserWeapons }
			}
		};

		private static readonly ResearchMetadata laserRifle = new ResearchMetadata
		{
			Name = "Laser Rifle",
			AverageHoursToComplete = 300,
			Points = 10,
			RequiredResearch = new[]
			{
				new[] { ResearchType.LaserPistol }
			}
		};

		private static readonly ResearchMetadata heavyLaser = new ResearchMetadata
		{
			Name = "Heavy Laser",
			AverageHoursToComplete = 460,
			Points = 10,
			RequiredResearch = new[]
			{
				new[] {  ResearchType.LaserRifle }
			}
		};

		private static readonly ResearchMetadata laserCannon = new ResearchMetadata
		{
			Name = "Laser Cannon",
			AverageHoursToComplete = 420,
			Points = 10,
			RequiredResearch = new[]
			{
				new[] { ResearchType.HeavyLaser }
			}
		};

		private static readonly ResearchMetadata laserDefenses = new ResearchMetadata
		{
			Name = "Laser Defenses",
			AverageHoursToComplete = 510,
			Points = 15,
			RequiredResearch = new[]
			{
				new[] { ResearchType.LaserCannon }
			}
		};

		private static readonly ResearchMetadata plasmaPistol = new ResearchMetadata
		{
			Name = "Plasma Pistol",
			AverageHoursToComplete = 600,
			Points = 20,
			RequiredItem = ItemType.PlasmaPistol
		};

		private static readonly ResearchMetadata plasmaPistolClip = new ResearchMetadata
		{
			Name = "Plasma Pistol Clip",
			AverageHoursToComplete = 400,
			Points = 5,
			RequiredItem = ItemType.PlasmaPistolClip
		};

		private static readonly ResearchMetadata plasmaRifle = new ResearchMetadata
		{
			Name = "Plasma Rifle",
			AverageHoursToComplete = 700,
			Points = 25,
			RequiredItem = ItemType.PlasmaRifle
		};

		private static readonly ResearchMetadata plasmaRifleClip = new ResearchMetadata
		{
			Name = "Plasma Rifle Clip",
			AverageHoursToComplete = 400,
			Points = 6,
			RequiredItem = ItemType.PlasmaRifleClip
		};

		private static readonly ResearchMetadata heavyPlasma = new ResearchMetadata
		{
			Name = "Heavy Plasma",
			AverageHoursToComplete = 800,
			Points = 30,
			RequiredItem = ItemType.HeavyPlasma
		};

		private static readonly ResearchMetadata heavyPlasmaClip = new ResearchMetadata
		{
			Name = "Heavy Plasma Clip",
			AverageHoursToComplete = 400,
			Points = 7,
			RequiredItem = ItemType.HeavyPlasmaClip
		};

		private static readonly ResearchMetadata plasmaCannon = new ResearchMetadata
		{
			Name = "Plasma Cannon",
			AverageHoursToComplete = 660,
			Points = 25,
			RequiredResearch = new[]
			{
				new[] { ResearchType.PlasmaRifle, ResearchType.PlasmaRifleClip },
				new[] { ResearchType.HeavyPlasma, ResearchType.HeavyPlasmaClip }
			}
		};

		private static readonly ResearchMetadata plasmaDefenses = new ResearchMetadata
		{
			Name = "Plasma Defenses",
			AverageHoursToComplete = 620,
			Points = 25,
			RequiredResearch = new[]
			{
				new[] { ResearchType.PlasmaCannon }
			}
		};

		private static readonly ResearchMetadata mediKit = new ResearchMetadata
		{
			Name = "Medi-Kit",
			AverageHoursToComplete = 210,
			Points = 20
		};

		private static readonly ResearchMetadata motionScanner = new ResearchMetadata
		{
			Name = "Motion Scanner",
			AverageHoursToComplete = 180,
			Points = 20
		};

		private static readonly ResearchMetadata alienGrenade = new ResearchMetadata
		{
			Name = "Alien Grenade",
			AverageHoursToComplete = 200,
			Points = 20,
			RequiredItem = ItemType.AlienGrenade
		};

		private static readonly ResearchMetadata smallLauncher = new ResearchMetadata
		{
			Name = "Small Launcher",
			AverageHoursToComplete = 550,
			Points = 30,
			RequiredItem = ItemType.SmallLauncher
		};

		private static readonly ResearchMetadata stunBomb = new ResearchMetadata
		{
			Name = "Stun Bomb",
			AverageHoursToComplete = 180,
			Points = 10,
			RequiredItem = ItemType.StunBomb
		};

		private static readonly ResearchMetadata blasterLauncher = new ResearchMetadata
		{
			Name = "Blaster Launcher",
			AverageHoursToComplete = 900,
			RequiredItem = ItemType.BlasterLauncher,
			Points = 40
		};

		private static readonly ResearchMetadata blasterBomb = new ResearchMetadata
		{
			Name = "Blaster Bomb",
			AverageHoursToComplete = 300,
			RequiredItem = ItemType.BlasterBomb,
			Points = 10
		};

		private static readonly ResearchMetadata fusionMissile = new ResearchMetadata
		{
			Name = "Fusion Missile",
			AverageHoursToComplete = 880,
			Points = 25,
			RequiredResearch = new[]
			{
				new[] { ResearchType.BlasterLauncher, ResearchType.BlasterBomb }
			}
		};

		private static readonly ResearchMetadata fusionDefenses = new ResearchMetadata
		{
			Name = "Fusion Defenses",
			AverageHoursToComplete = 800,
			Points = 25,
			RequiredResearch = new[]
			{
				new[] { ResearchType.FusionMissile }
			}
		};

		private static readonly ResearchMetadata ufoPowerSource = new ResearchMetadata
		{
			Name = "UFO Power Source",
			AverageHoursToComplete = 450,
			Points = 30,
			RequiredItem = ItemType.UfoPowerSource
		};

		private static readonly ResearchMetadata ufoNavigation = new ResearchMetadata
		{
			Name = "UFO Navigation",
			AverageHoursToComplete = 450,
			Points = 30,
			RequiredItem = ItemType.UfoNavigation
		};

		private static readonly ResearchMetadata alienAlloys = new ResearchMetadata
		{
			Name = "Alien Alloys",
			AverageHoursToComplete = 400,
			Points = 30,
			RequiredItem = ItemType.AlienAlloys
		};

		private static readonly ResearchMetadata elerium115 = new ResearchMetadata
		{
			Name = "Elerium-115",
			AverageHoursToComplete = 450,
			Points = 40,
			RequiredItem = ItemType.Elerium115
		};

		private static readonly ResearchMetadata personalArmor = new ResearchMetadata
		{
			Name = "Personal Armor",
			AverageHoursToComplete = 180,
			Points = 20,
			RequiredResearch = new[]
			{
				new[] { ResearchType.AlienAlloys }
			}
		};

		private static readonly ResearchMetadata powerSuit = new ResearchMetadata
		{
			Name = "Power Suit",
			AverageHoursToComplete = 205,
			Points = 20,
			RequiredResearch = new[]
			{
				new[] { ResearchType.UfoPowerSource, ResearchType.Elerium115, ResearchType.PersonalArmor }
			}
		};

		private static readonly ResearchMetadata flyingSuit = new ResearchMetadata
		{
			Name = "Flying Suit",
			AverageHoursToComplete = 330,
			Points = 20,
			RequiredResearch = new[]
			{
				new[] { ResearchType.UfoNavigation, ResearchType.PowerSuit }
			}
		};

		private static readonly ResearchMetadata ufoConstruction = new ResearchMetadata
		{
			Name = "UFO Construction",
			AverageHoursToComplete = 450,
			Points = 30,
			RequiredResearch = new[]
			{
				new[]
				{
					ResearchType.UfoPowerSource,
					ResearchType.UfoNavigation,
					ResearchType.AlienAlloys,
					ResearchType.Elerium115
				}
			}
		};

		private static readonly ResearchMetadata newFighterCraft = new ResearchMetadata
		{
			Name = "New Fighter Craft",
			AverageHoursToComplete = 600,
			Points = 30,
			RequiredResearch = new[]
			{
				new[] { ResearchType.UfoConstruction }
			}
		};

		private static readonly ResearchMetadata newFighterTransporter = new ResearchMetadata
		{
			Name = "New Fighter Transporter",
			AverageHoursToComplete = 700,
			Points = 30,
			RequiredResearch = new[]
			{
				new[] { ResearchType.NewFighterCraft }
			}
		};

		private static readonly ResearchMetadata ultimateCraft = new ResearchMetadata
		{
			Name = "Ultimate Craft",
			AverageHoursToComplete = 900,
			Points = 30,
			RequiredResearch = new[]
			{
				new[] { ResearchType.NewFighterTransporter }
			}
		};

		private static readonly ResearchMetadata gravShield = new ResearchMetadata
		{
			Name = "Grav Shield",
			AverageHoursToComplete = 930,
			Points = 25,
			RequiredResearch = new[]
			{
				new[] { ResearchType.NewFighterTransporter }
			}
		};

		private static readonly ResearchMetadata mindProbe = new ResearchMetadata
		{
			Name = "Mind Probe",
			AverageHoursToComplete = 600,
			Points = 25,
			RequiredItem = ItemType.MindProbe
		};

		private static readonly ResearchMetadata psiLab = new ResearchMetadata
		{
			Name = "Psi-Lab",
			AverageHoursToComplete = 420,
			Points = 25,
			RequiredResearch = new[]
			{
				new[] { ResearchType.SectoidLeader },
				new[] { ResearchType.SectoidCommander },
				new[] { ResearchType.Ethereal }
			}
		};

		private static readonly ResearchMetadata psiAmp = new ResearchMetadata
		{
			Name = "Psi-Amp",
			AverageHoursToComplete = 500,
			Points = 20,
			RequiredResearch = new[]
			{
				new[] { ResearchType.PsiLab }
			}
		};

		private static readonly ResearchMetadata mindShield = new ResearchMetadata
		{
			Name = "Mind Shield",
			AverageHoursToComplete = 360,
			Points = 25,
			RequiredResearch = new[]
			{
				new[] { ResearchType.PsiLab }
			}
		};

		private static readonly ResearchMetadata hyperwaveDecoder = new ResearchMetadata
		{
			Name = "Hyper-Wave Decoder",
			AverageHoursToComplete = 670,
			Points = 25,
			RequiredResearch = new[]
			{
				new[] { ResearchType.Navigator }
			}
		};

		private static readonly ResearchMetadata alienOrigins = new ResearchMetadata
		{
			Name = "Alien Origins",
			AverageHoursToComplete = 300,
			Points = 60,
			RequiredResearch = new[]
			{
				new[] { ResearchType.Alien }
			}
		};

		private static readonly ResearchMetadata theMartianSolution = new ResearchMetadata
		{
			Name = "The Martian Solution",
			AverageHoursToComplete = 500,
			Points = 60,
			RequiredResearch = new[]
			{
				new[] { ResearchType.Leader, ResearchType.AlienOrigins },
				new[] { ResearchType.Commander, ResearchType.AlienOrigins }
			}
		};

		private static readonly ResearchMetadata cydoniaOrBust = new ResearchMetadata
		{
			Name = "Cydonia or Bust",
			AverageHoursToComplete = 600,
			Points = 60,
			RequiredResearch = new[]
			{
				new[] { ResearchType.Commander, ResearchType.TheMartianSolution }
			}
		};

		private static readonly ResearchMetadata alienFood = new ResearchMetadata
		{
			Name = "Alien Food",
			AverageHoursToComplete = 150,
			Points = 30,
			RequiredItem = ItemType.AlienFood
		};

		private static readonly ResearchMetadata alienEntertainment = new ResearchMetadata
		{
			Name = "Alien Entertainment",
			AverageHoursToComplete = 150,
			Points = 30,
			RequiredItem = ItemType.AlienEntertainment
		};

		private static readonly ResearchMetadata alienSurgery = new ResearchMetadata
		{
			Name = "Alien Surgery",
			AverageHoursToComplete = 150,
			Points = 30,
			RequiredItem = ItemType.AlienSurgery
		};

		private static readonly ResearchMetadata examinationRoom = new ResearchMetadata
		{
			Name = "Examination Room",
			AverageHoursToComplete = 150,
			Points = 30,
			RequiredItem = ItemType.ExaminationRoom
		};

		private static ResearchMetadata Corpse(string name, ItemType item)
		{
			return new ResearchMetadata
			{
				Name = name,
				AverageHoursToComplete = 180,
				Points = 50,
				RequiredItem = item
			};
		}

		private static ResearchMetadata Alien(string name, ItemType item, ResearchType race, ResearchType rank)
		{
			var medicLottery = new[]
			{
				ResearchType.Sectoid,
				ResearchType.Floater,
				ResearchType.Snakeman,
				ResearchType.Muton,
				ResearchType.Ethereal,
				ResearchType.ReaperTerrorist,
				ResearchType.ChryssalidTerrorist,
				ResearchType.SilacoidTerrorist,
				ResearchType.CelatidTerrorist,
				ResearchType.SectopodTerrorist,
				ResearchType.CyberdiscTerrorist,
			};

			var navigatorLottery = new[]
			{
				ResearchType.AlienResearch,
				ResearchType.AlienHarvest,
				ResearchType.AlienAbduction,
				ResearchType.AlienInfiltration,
				ResearchType.AlienBase,
				ResearchType.AlienTerror,
				ResearchType.AlienRetaliation,
				ResearchType.AlienSupply
			};

			var engineerLottery = new[]
			{
				ResearchType.SmallScout,
				ResearchType.MediumScout,
				ResearchType.LargeScout,
				ResearchType.Abductor,
				ResearchType.Harvester,
				ResearchType.SupplyShip,
				ResearchType.TerrorShip,
				ResearchType.Battleship
			};

			return new ResearchMetadata
			{
				Name = name,
				AverageHoursToComplete =
					race == ResearchType.Sectoid && rank == ResearchType.Commander ? 190 :
					race == ResearchType.Sectopod || race == ResearchType.Cyberdisc ? 192 :
					rank == ResearchType.Terrorist ? 170 :
					192,
				Points = 50,
				RequiredItem = item,
				AdditionalResearchResults = new[] { ResearchType.Alien, race, rank },
				LotteryResearchResults =
					rank == ResearchType.Medic ? medicLottery :
					rank == ResearchType.Navigator ? navigatorLottery :
					rank == ResearchType.Engineer ? engineerLottery :
					null
			};
		}

		private static ResearchMetadata NotResearchable(ResearchType research)
		{
			return new ResearchMetadata
			{
				Points = 50,
				RequiredResearch = new[] { new[] { research } }
			};
		}

		private static readonly Dictionary<ResearchType, ResearchMetadata> metadata = new Dictionary<ResearchType,ResearchMetadata>
 		{
			{ ResearchType.LaserWeapons, laserWeapons },
			{ ResearchType.LaserPistol, laserPistol },
			{ ResearchType.LaserRifle, laserRifle },
			{ ResearchType.HeavyLaser, heavyLaser },
			{ ResearchType.LaserCannon, laserCannon },
			{ ResearchType.LaserDefenses, laserDefenses },
			{ ResearchType.PlasmaPistol, plasmaPistol },
			{ ResearchType.PlasmaPistolClip, plasmaPistolClip },
			{ ResearchType.PlasmaRifle, plasmaRifle },
			{ ResearchType.PlasmaRifleClip, plasmaRifleClip },
			{ ResearchType.HeavyPlasma, heavyPlasma },
			{ ResearchType.HeavyPlasmaClip, heavyPlasmaClip },
			{ ResearchType.PlasmaCannon, plasmaCannon },
			{ ResearchType.PlasmaDefenses, plasmaDefenses },
			{ ResearchType.MediKit, mediKit },
			{ ResearchType.MotionScanner, motionScanner },
			{ ResearchType.AlienGrenade, alienGrenade },
			{ ResearchType.SmallLauncher, smallLauncher },
			{ ResearchType.StunBomb, stunBomb },
			{ ResearchType.BlasterLauncher, blasterLauncher },
			{ ResearchType.BlasterBomb, blasterBomb },
			{ ResearchType.FusionMissile, fusionMissile },
			{ ResearchType.FusionDefenses, fusionDefenses },
			{ ResearchType.UfoPowerSource, ufoPowerSource },
			{ ResearchType.UfoNavigation, ufoNavigation },
			{ ResearchType.AlienAlloys, alienAlloys },
			{ ResearchType.Elerium115, elerium115 },
			{ ResearchType.PersonalArmor, personalArmor },
			{ ResearchType.PowerSuit, powerSuit },
			{ ResearchType.FlyingSuit, flyingSuit },
			{ ResearchType.UfoConstruction, ufoConstruction },
			{ ResearchType.NewFighterCraft, newFighterCraft },
			{ ResearchType.NewFighterTransporter, newFighterTransporter },
			{ ResearchType.UltimateCraft, ultimateCraft },
			{ ResearchType.GravShield, gravShield },
			{ ResearchType.MindProbe, mindProbe },
			{ ResearchType.PsiLab, psiLab },
			{ ResearchType.PsiAmp, psiAmp },
			{ ResearchType.MindShield, mindShield },
			{ ResearchType.HyperwaveDecoder, hyperwaveDecoder },
			{ ResearchType.AlienOrigins, alienOrigins },
			{ ResearchType.TheMartianSolution, theMartianSolution },
			{ ResearchType.CydoniaOrBust, cydoniaOrBust },
			{ ResearchType.AlienFood, alienFood },
			{ ResearchType.AlienEntertainment, alienEntertainment },
			{ ResearchType.AlienSurgery, alienSurgery },
			{ ResearchType.ExaminationRoom, examinationRoom },
			{ ResearchType.AlienResearch, NotResearchable(ResearchType.AlienResearch) },
			{ ResearchType.AlienHarvest, NotResearchable(ResearchType.AlienHarvest) },
			{ ResearchType.AlienAbduction, NotResearchable(ResearchType.AlienAbduction) },
			{ ResearchType.AlienInfiltration, NotResearchable(ResearchType.AlienInfiltration) },
			{ ResearchType.AlienBase, NotResearchable(ResearchType.AlienBase) },
			{ ResearchType.AlienTerror, NotResearchable(ResearchType.AlienTerror) },
			{ ResearchType.AlienRetaliation, NotResearchable(ResearchType.AlienRetaliation) },
			{ ResearchType.AlienSupply, NotResearchable(ResearchType.AlienSupply) },
			{ ResearchType.SmallScout, NotResearchable(ResearchType.SmallScout) },
			{ ResearchType.MediumScout, NotResearchable(ResearchType.MediumScout) },
			{ ResearchType.LargeScout, NotResearchable(ResearchType.LargeScout) },
			{ ResearchType.Abductor, NotResearchable(ResearchType.Abductor) },
			{ ResearchType.Harvester, NotResearchable(ResearchType.Harvester) },
			{ ResearchType.SupplyShip, NotResearchable(ResearchType.SupplyShip) },
			{ ResearchType.TerrorShip, NotResearchable(ResearchType.TerrorShip) },
			{ ResearchType.Battleship, NotResearchable(ResearchType.Battleship) },
			{ ResearchType.Soldier, NotResearchable(ResearchType.Soldier) },
			{ ResearchType.Terrorist, NotResearchable(ResearchType.Terrorist) },
			{ ResearchType.Navigator, NotResearchable(ResearchType.Navigator) },
			{ ResearchType.Medic, NotResearchable(ResearchType.Medic) },
			{ ResearchType.Engineer, NotResearchable(ResearchType.Engineer) },
			{ ResearchType.Leader, NotResearchable(ResearchType.Leader) },
			{ ResearchType.Commander, NotResearchable(ResearchType.Commander) },
			{ ResearchType.Alien, NotResearchable(ResearchType.Alien) },
			{ ResearchType.Sectoid, NotResearchable(ResearchType.Sectoid) },
			{ ResearchType.Floater, NotResearchable(ResearchType.Floater) },
			{ ResearchType.Snakeman, NotResearchable(ResearchType.Snakeman) },
			{ ResearchType.Muton, NotResearchable(ResearchType.Muton) },
			{ ResearchType.Ethereal, NotResearchable(ResearchType.Ethereal) },
			{ ResearchType.Reaper, NotResearchable(ResearchType.Reaper) },
			{ ResearchType.Chrysalid, NotResearchable(ResearchType.Chrysalid) },
			{ ResearchType.Silacoid, NotResearchable(ResearchType.Silacoid) },
			{ ResearchType.Celatid, NotResearchable(ResearchType.Celatid) },
			{ ResearchType.Sectopod, NotResearchable(ResearchType.Sectopod) },
			{ ResearchType.Cyberdisc, NotResearchable(ResearchType.Cyberdisc) },
			{ ResearchType.SectoidCorpse, Corpse("Sectoid Corpse", ItemType.SectoidCorpse) },
			{ ResearchType.FloaterCorpse, Corpse("Floater Corpse", ItemType.FloaterCorpse) },
			{ ResearchType.SnakemanCorpse, Corpse("Snakeman Corpse", ItemType.SnakemanCorpse) },
			{ ResearchType.MutonCorpse, Corpse("Muton Corpse", ItemType.MutonCorpse) },
			{ ResearchType.EtherealCorpse, Corpse("Ethereal Corpse", ItemType.EtherealCorpse) },
			{ ResearchType.ReaperCorpse, Corpse("Reaper Corpse", ItemType.ReaperCorpse) },
			{ ResearchType.ChryssalidCorpse, Corpse("Chryssalid Corpse", ItemType.ChryssalidCorpse) },
			{ ResearchType.SilacoidCorpse, Corpse("Silacoid Corpse", ItemType.SilacoidCorpse) },
			{ ResearchType.CelatidCorpse, Corpse("Celatid Corpse", ItemType.CelatidCorpse) },
			{ ResearchType.SectopodCorpse, Corpse("Sectopod Corpse", ItemType.SectopodCorpse) },
			{ ResearchType.CyberdiscCorpse, Corpse("Cyberdisc Corpse", ItemType.CyberdiscCorpse) },
			{ ResearchType.ReaperTerrorist, Alien("Reaper Terrorist", ItemType.ReaperTerrorist, ResearchType.Reaper, ResearchType.Terrorist) },
			{ ResearchType.ChryssalidTerrorist, Alien("Chryssalid Terrorist", ItemType.ChryssalidTerrorist, ResearchType.Chrysalid, ResearchType.Terrorist) },
			{ ResearchType.SilacoidTerrorist, Alien("Silacoid Terrorist", ItemType.SilacoidTerrorist, ResearchType.Silacoid, ResearchType.Terrorist) },
			{ ResearchType.CelatidTerrorist, Alien("Celatid Terrorist", ItemType.CelatidTerrorist, ResearchType.Celatid, ResearchType.Terrorist) },
			{ ResearchType.SectopodTerrorist, Alien("Sectopod Terrorist", ItemType.SectopodTerrorist, ResearchType.Sectopod, ResearchType.Terrorist) },
			{ ResearchType.CyberdiscTerrorist, Alien("Cyberdisc Terrorist", ItemType.CyberdiscTerrorist, ResearchType.Cyberdisc, ResearchType.Terrorist) },
			{ ResearchType.SectoidSoldier, Alien("Sectoid Soldier", ItemType.SectoidSoldier, ResearchType.Sectoid, ResearchType.Soldier) },
			{ ResearchType.SectoidMedic, Alien("Sectoid Medic", ItemType.SectoidMedic, ResearchType.Sectoid, ResearchType.Medic) },
			{ ResearchType.SectoidNavigator, Alien("Sectoid Navigator", ItemType.SectoidNavigator, ResearchType.Sectoid, ResearchType.Navigator) },
			{ ResearchType.SectoidEngineer, Alien("Sectoid Engineer", ItemType.SectoidEngineer, ResearchType.Sectoid, ResearchType.Engineer) },
			{ ResearchType.SectoidLeader, Alien("Sectoid Leader", ItemType.SectoidLeader, ResearchType.Sectoid, ResearchType.Leader) },
			{ ResearchType.SectoidCommander, Alien("Sectoid Commander", ItemType.SectoidCommander, ResearchType.Sectoid, ResearchType.Commander) },
			{ ResearchType.FloaterSoldier, Alien("Floater Soldier", ItemType.FloaterSoldier, ResearchType.Floater, ResearchType.Soldier) },
			{ ResearchType.FloaterMedic, Alien("Floater Medic", ItemType.FloaterMedic, ResearchType.Floater, ResearchType.Medic) },
			{ ResearchType.FloaterNavigator, Alien("Floater Navigator", ItemType.FloaterNavigator, ResearchType.Floater, ResearchType.Navigator) },
			{ ResearchType.FloaterEngineer, Alien("Floater Engineer", ItemType.FloaterEngineer, ResearchType.Floater, ResearchType.Engineer) },
			{ ResearchType.FloaterLeader, Alien("Floater Leader", ItemType.FloaterLeader, ResearchType.Floater, ResearchType.Leader) },
			{ ResearchType.FloaterCommander, Alien("Floater Commander", ItemType.FloaterCommander, ResearchType.Floater, ResearchType.Commander) },
			{ ResearchType.SnakemanSoldier, Alien("Snakeman Soldier", ItemType.SnakemanSoldier, ResearchType.Snakeman, ResearchType.Soldier) },
			{ ResearchType.SnakemanMedic, Alien("Snakeman Medic", ItemType.SnakemanMedic, ResearchType.Snakeman, ResearchType.Medic) },
			{ ResearchType.SnakemanNavigator, Alien("Snakeman Navigator", ItemType.SnakemanNavigator, ResearchType.Snakeman, ResearchType.Navigator) },
			{ ResearchType.SnakemanEngineer, Alien("Snakeman Engineer", ItemType.SnakemanEngineer, ResearchType.Snakeman, ResearchType.Engineer) },
			{ ResearchType.SnakemanLeader, Alien("Snakeman Leader", ItemType.SnakemanLeader, ResearchType.Snakeman, ResearchType.Leader) },
			{ ResearchType.SnakemanCommander, Alien("Snakeman Commander", ItemType.SnakemanCommander, ResearchType.Snakeman, ResearchType.Commander) },
			{ ResearchType.MutonSoldier, Alien("Muton Soldier", ItemType.MutonSoldier, ResearchType.Muton, ResearchType.Soldier) },
			{ ResearchType.MutonNavigator, Alien("Muton Navigator", ItemType.MutonNavigator, ResearchType.Muton, ResearchType.Navigator) },
			{ ResearchType.MutonEngineer, Alien("Muton Engineer", ItemType.MutonEngineer, ResearchType.Muton, ResearchType.Engineer) },
			{ ResearchType.EtherealSoldier, Alien("Ethereal Soldier", ItemType.EtherealSoldier, ResearchType.Ethereal, ResearchType.Soldier) },
			{ ResearchType.EtherealLeader, Alien("Ethereal Leader", ItemType.EtherealLeader, ResearchType.Ethereal, ResearchType.Leader) },
			{ ResearchType.EtherealCommander, Alien("Ethereal Commander", ItemType.EtherealCommander, ResearchType.Ethereal, ResearchType.Commander) }
		};
	}
}
