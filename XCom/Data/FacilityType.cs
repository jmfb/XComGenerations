using System.Collections.Generic;
using XCom.Content.Images.Facilities;
using XCom.Graphics;

namespace XCom.Data
{
	public enum FacilityType
	{
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
		PsionicLaboratory,
		HyperWaveDecoder,
		Hangar
	}

	public static class FacilityTypeExtensions
	{
		public static FacilityMetadata Metadata(this FacilityType facilityType)
		{
			return metadata[facilityType];
		}

		private static readonly FacilityMetadata accessLift = new FacilityMetadata
		{
			Name = "Access Lift",
			Shape = FacilityShape.Octagon,
			DaysToConstruct = 1,
			Cost = 300000,
			Maintenance = 4000,
			Image = new Image(Facilities.AccessLift),
			RowOffset = 7,
			ColumnOffset = 7,
			DescriptionLines = new[]
			{
				"The access lift allows equipment and personnel to be transferred",
				"into or out of an underground base.  It is always the first",
				"facility to be constructed on a new site.  The lift area is",
				"vulnerable to intrusion from any potential hostile force."
			}
		};

		private static readonly FacilityMetadata livingQuarters = new FacilityMetadata
		{
			Name = "Living Quarters",
			Shape = FacilityShape.Square,
			DaysToConstruct = 16,
			Cost = 400000,
			Maintenance = 10000,
			Image = new Image(Facilities.LivingQuarters),
			RowOffset = 3,
			ColumnOffset = 2,
			DescriptionLines = new[]
			{
				"Each accommodation block provides for up to 50 personnel.  The",
				"facility provides basic recreation, food and sleeping areas."
			}
		};

		private static readonly FacilityMetadata laboratory = new FacilityMetadata
		{
			Name = "Laboratory",
			Shape = FacilityShape.Square,
			DaysToConstruct = 26,
			Cost = 750000,
			Maintenance = 30000,
			Image = new Image(Facilities.Laboratory),
			RowOffset = 3,
			ColumnOffset = 3,
			DescriptionLines = new[]
			{
				"Up to 50 scientists can work in a laboratory facility.",
				"Laboratories are equipped with the latest technology for",
				"research into materials, biochemistry and cosmology. There is",
				"privileged access to the best research labs throughout the",
				"world, including military establishments."
			}
		};

		private static readonly FacilityMetadata workshop = new FacilityMetadata
		{
			Name = "Workshop",
			Shape = FacilityShape.Square,
			DaysToConstruct = 32,
			Cost = 800000,
			Maintenance = 35000,
			Image = new Image(Facilities.Workshop),
			RowOffset = 3,
			ColumnOffset = 3,
			DescriptionLines = new[]
			{
				"A workshop contains all the equipment necessary to manufacture",
				"equipment based on designs from the science labs.  Up to 50",
				"engineers can occupy a workshop, although items under",
				"construction will also consume some space."
			}
		};

		private static readonly FacilityMetadata smallRadarSystem = new FacilityMetadata
		{
			Name = "Small Radar System",
			Shape = FacilityShape.Octagon,
			DaysToConstruct = 12,
			Cost = 500000,
			Maintenance = 10000,
			Image = new Image(Facilities.SmallRadarSystem),
			RowOffset = 3,
			ColumnOffset = 3,
			DescriptionLines = new[]
			{
				"A small detection system has an effective radar range of 300",
				"nautical miles and is linked to satellite systems for ground",
				"search. Each system has a 5% chance of detecting an average",
				"sized object every 10 minutes."
			}
		};

		private static readonly FacilityMetadata largeRadarSystem = new FacilityMetadata
		{
			Name = "Large Radar System",
			Shape = FacilityShape.Square,
			DaysToConstruct = 25,
			Cost = 800000,
			Maintenance = 15000,
			Image = new Image(Facilities.LargeRadarSystem),
			RowOffset = 3,
			ColumnOffset = 3,
			DescriptionLines = new[]
			{
				"A large detection system has an effective range of 450 nautical",
				"miles and is linked to satellite systems for ground search. Each",
				"system has a 5% chance of detecting an average sized object",
				"every 10 minutes."
			}
		};

		private static readonly FacilityMetadata missileDefenses = new FacilityMetadata
		{
			Name = "Missile Defenses",
			Shape = FacilityShape.Octagon,
			DaysToConstruct = 16,
			Cost = 200000,
			Maintenance = 5000,
			DefenseValue = 500,
			HitRatio = 50,
			Image = new Image(Facilities.MissileDefenses),
			RowOffset = 6,
			ColumnOffset = 6,
			DescriptionLines = new[]
			{
				"Missile defenses provide some protection against incursion by",
				"hostile craft which are attempting to land near the base."
			}
		};

		private static readonly FacilityMetadata generalStores = new FacilityMetadata
		{
			Name = "General Stores",
			Shape = FacilityShape.Square,
			DaysToConstruct = 10,
			Cost = 150000,
			Maintenance = 5000,
			Image = new Image(Facilities.GeneralStores),
			RowOffset = 2,
			ColumnOffset = 2,
			DescriptionLines = new[]
			{
				"All equipment, weapons systems, munitions, recovered material",
				"and Heavy Weapons Platforms are placed in stores, with the",
				"exception of equipment assigned to craft in hangars."
			}
		};

		private static readonly FacilityMetadata alienContainment = new FacilityMetadata
		{
			Name = "Alien Containment",
			Shape = FacilityShape.Square,
			DaysToConstruct = 18,
			Cost = 400000,
			Maintenance = 15000,
			Image = new Image(Facilities.AlienContainment),
			RowOffset = 3,
			ColumnOffset = 3,
			DescriptionLines = new[]
			{
				"Living aliens are likely to require a special habitat to maintain",
				"their life systems.  The containment facility can keep up to 10",
				"alien life forms in self contained units."
			}
		};

		private static readonly FacilityMetadata laserDefenses = new FacilityMetadata
		{
			Name = "Laser Defenses",
			Shape = FacilityShape.Cross,
			DaysToConstruct = 24,
			Cost = 400000,
			Maintenance = 15000,
			DefenseValue = 600,
			HitRatio = 60,
			Image = new Image(Facilities.LaserDefenses),
			RowOffset = 5,
			ColumnOffset = 5,
			RequiredResearch = ResearchType.LaserDefenses,
			DescriptionLines = new[]
			{
				"Laser defenses provide protection against incursion by hostile",
				"craft."
			}
		};

		private static readonly FacilityMetadata plasmaDefenses = new FacilityMetadata
		{
			Name = "Plasma Defenses",
			Shape = FacilityShape.Cross,
			DaysToConstruct = 34,
			Cost = 600000,
			Maintenance = 12000,
			DefenseValue = 900,
			HitRatio = 70,
			Image = new Image(Facilities.PlasmaDefenses),
			RowOffset = 5,
			ColumnOffset = 5,
			RequiredResearch = ResearchType.PlasmaDefenses,
			DescriptionLines = new[]
			{
				"Plasma beam defenses provide powerful and efficient protection",
				"against incursion by hostile craft."
			}
		};

		private static readonly FacilityMetadata fusionBallDefenses = new FacilityMetadata
		{
			Name = "Fusion Ball Defenses",
			Shape = FacilityShape.Cross,
			DaysToConstruct = 34,
			Cost = 800000,
			Maintenance = 14000,
			DefenseValue = 1200,
			HitRatio = 80,
			Image = new Image(Facilities.FusionBallDefenses),
			RowOffset = 4,
			ColumnOffset = 4,
			RequiredResearch = ResearchType.FusionDefenses,
			DescriptionLines = new[]
			{
				"Fusion missiles provide the most effective defense against alien",
				"attacks.  These missiles create an anti-matter implosion which",
				"destroys everything within a specific radius."
			}
		};

		private static readonly FacilityMetadata gravShield = new FacilityMetadata
		{
			Name = "Grav Shield",
			Shape = FacilityShape.Octagon,
			DaysToConstruct = 38,
			Cost = 1200000,
			Maintenance = 15000,
			Image = new Image(Facilities.GravShield),
			RowOffset = 2,
			ColumnOffset = 2,
			RequiredResearch = ResearchType.GravShield,
			DescriptionLines = new[]
			{
				"The Gravity shield repels alien craft attempting to land near",
				"the base long enough for all defense systems to fire again.  In",
				"practice this will double the effectiveness of any defense",
				"systems at your base."
			}
		};

		private static readonly FacilityMetadata mindShield = new FacilityMetadata
		{
			Name = "Mind Shield",
			Shape = FacilityShape.Octagon,
			DaysToConstruct = 33,
			Cost = 1300000,
			Maintenance = 5000,
			Image = new Image(Facilities.MindShield),
			RowOffset = 3,
			ColumnOffset = 3,
			RequiredResearch = ResearchType.MindShield,
			DescriptionLines = new[]
			{
				"Since alien craft rely on brain waves to detect human presence",
				"then the most effective counter measure is to shield brain",
				"waves from the base.  This facility will drastically reduce the",
				"chances of detection by alien craft."
			}
		};

		private static readonly FacilityMetadata psionicLaboratory = new FacilityMetadata
		{
			Name = "Psionic Laboratory",
			Shape = FacilityShape.Square,
			DaysToConstruct = 24,
			Cost = 750000,
			Maintenance = 16000,
			Image = new Image(Facilities.PsionicLaboratory),
			RowOffset = 4,
			ColumnOffset = 4,
			RequiredResearch = ResearchType.PsiLab,
			DescriptionLines = new[]
			{
				"The psionics lab can assess the psionic potential of all",
				"soldiers at the base and give them the necessary training to",
				"utilize their psionic skills.  Each lab can train up to ten",
				"soldiers.  Training is allocated at the end of each month.",
				"Psionic skills used in conjunction with a Psi-amp can be used",
				"for psionic attacks during combat."
			}
		};

		private static readonly FacilityMetadata hyperWaveDecoder = new FacilityMetadata
		{
			Name = "Hyper-wave Decoder",
			Shape = FacilityShape.Octagon,
			DaysToConstruct = 26,
			Cost = 1400000,
			Maintenance = 30000,
			Image = new Image(Facilities.HyperWaveDecoder),
			RowOffset = 3,
			ColumnOffset = 3,
			RequiredResearch = ResearchType.HyperwaveDecoder,
			DescriptionLines = new[]
			{
				"Alien communications rely on a supra-dimensional wave which",
				"travels almost instantaneously. The decoder facility intercepts",
				"UFO transmissions and decodes the information.  This will show",
				"the type of UFO, the alien race and the type of activity."
			}
		};

		private static readonly FacilityMetadata hangar = new FacilityMetadata
		{
			Name = "Hangar",
			Shape = FacilityShape.Hangar,
			DaysToConstruct = 25,
			Cost = 200000,
			Maintenance = 25000,
			Image = new Image(Facilities.Hangar),
			RowOffset = 0,
			ColumnOffset = 0,
			DescriptionLines = new[]
			{
				"Each hangar can accomodate one craft.  There are facilities for",
				"maintenance, refuelling and repair of XCom craft.  Each craft",
				"stationed at a base must have a free hangar assigned to it",
				"which cannot be used by other craft, even if the assigned craft",
				"is out on a mission."
			}
		};

		private static readonly Dictionary<FacilityType, FacilityMetadata> metadata = new Dictionary<FacilityType, FacilityMetadata>
		{
			{ FacilityType.AccessLift, accessLift },
			{ FacilityType.LivingQuarters, livingQuarters },
			{ FacilityType.Laboratory, laboratory },
			{ FacilityType.Workshop, workshop },
			{ FacilityType.SmallRadarSystem, smallRadarSystem },
			{ FacilityType.LargeRadarSystem, largeRadarSystem },
			{ FacilityType.MissileDefenses, missileDefenses },
			{ FacilityType.GeneralStores, generalStores },
			{ FacilityType.AlienContainment, alienContainment },
			{ FacilityType.LaserDefenses, laserDefenses },
			{ FacilityType.PlasmaDefenses, plasmaDefenses },
			{ FacilityType.FusionBallDefenses, fusionBallDefenses },
			{ FacilityType.GravShield, gravShield },
			{ FacilityType.MindShield, mindShield },
			{ FacilityType.PsionicLaboratory, psionicLaboratory },
			{ FacilityType.HyperWaveDecoder, hyperWaveDecoder },
			{ FacilityType.Hangar, hangar }
		};
	}
}
