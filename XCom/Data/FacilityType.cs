using XCom.Battlescape.Tiles;
using XCom.Content.Images.Facilities;
using XCom.Graphics;

namespace XCom.Data;

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
	Hangar,
}

public static class FacilityTypeExtensions
{
	public static FacilityMetadata Metadata(this FacilityType facilityType)
	{
		return metadata[facilityType];
	}

	private static readonly FacilityMetadata accessLift = new()
	{
		Name = "Access Lift",
		Shape = FacilityShape.Octagon,
		DaysToConstruct = 1,
		Cost = 300000,
		Maintenance = 4000,
		Image = new Image(Facilities.AccessLift),
		RowOffset = 7,
		ColumnOffset = 7,
		DescriptionLines =
		[
			"The access lift allows equipment and personnel to be transferred",
			"into or out of an underground base.  It is always the first",
			"facility to be constructed on a new site.  The lift area is",
			"vulnerable to intrusion from any potential hostile force.",
		],
		Tilesets = [Tileset.XcomBase0],
	};

	private static readonly FacilityMetadata livingQuarters = new()
	{
		Name = "Living Quarters",
		Shape = FacilityShape.Square,
		DaysToConstruct = 16,
		Cost = 400000,
		Maintenance = 10000,
		Image = new Image(Facilities.LivingQuarters),
		RowOffset = 3,
		ColumnOffset = 2,
		DescriptionLines =
		[
			"Each accommodation block provides for up to 50 personnel.  The",
			"facility provides basic recreation, food and sleeping areas.",
		],
		Tilesets = [Tileset.XcomBase1],
	};

	private static readonly FacilityMetadata laboratory = new()
	{
		Name = "Laboratory",
		Shape = FacilityShape.Square,
		DaysToConstruct = 26,
		Cost = 750000,
		Maintenance = 30000,
		Image = new Image(Facilities.Laboratory),
		RowOffset = 3,
		ColumnOffset = 3,
		DescriptionLines =
		[
			"Up to 50 scientists can work in a laboratory facility.",
			"Laboratories are equipped with the latest technology for",
			"research into materials, biochemistry and cosmology. There is",
			"privileged access to the best research labs throughout the",
			"world, including military establishments.",
		],
		Tilesets = [Tileset.XcomBase2],
	};

	private static readonly FacilityMetadata workshop = new()
	{
		Name = "Workshop",
		Shape = FacilityShape.Square,
		DaysToConstruct = 32,
		Cost = 800000,
		Maintenance = 35000,
		Image = new Image(Facilities.Workshop),
		RowOffset = 3,
		ColumnOffset = 3,
		DescriptionLines =
		[
			"A workshop contains all the equipment necessary to manufacture",
			"equipment based on designs from the science labs.  Up to 50",
			"engineers can occupy a workshop, although items under",
			"construction will also consume some space.",
		],
		Tilesets = [Tileset.XcomBase3],
	};

	private static readonly FacilityMetadata smallRadarSystem = new()
	{
		Name = "Small Radar System",
		Shape = FacilityShape.Octagon,
		DaysToConstruct = 12,
		Cost = 500000,
		Maintenance = 10000,
		Image = new Image(Facilities.SmallRadarSystem),
		RowOffset = 3,
		ColumnOffset = 3,
		DescriptionLines =
		[
			"A small detection system has an effective radar range of 300",
			"nautical miles and is linked to satellite systems for ground",
			"search. Each system has a 5% chance of detecting an average",
			"sized object every 10 minutes.",
		],
		Tilesets = [Tileset.XcomBase4],
	};

	private static readonly FacilityMetadata largeRadarSystem = new()
	{
		Name = "Large Radar System",
		Shape = FacilityShape.Square,
		DaysToConstruct = 25,
		Cost = 800000,
		Maintenance = 15000,
		Image = new Image(Facilities.LargeRadarSystem),
		RowOffset = 3,
		ColumnOffset = 3,
		DescriptionLines =
		[
			"A large detection system has an effective range of 450 nautical",
			"miles and is linked to satellite systems for ground search. Each",
			"system has a 5% chance of detecting an average sized object",
			"every 10 minutes.",
		],
		Tilesets = [Tileset.XcomBase5],
	};

	private static readonly FacilityMetadata missileDefenses = new()
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
		DescriptionLines =
		[
			"Missile defenses provide some protection against incursion by",
			"hostile craft which are attempting to land near the base.",
		],
		Tilesets = [Tileset.XcomBase6],
	};

	private static readonly FacilityMetadata generalStores = new()
	{
		Name = "General Stores",
		Shape = FacilityShape.Square,
		DaysToConstruct = 10,
		Cost = 150000,
		Maintenance = 5000,
		Image = new Image(Facilities.GeneralStores),
		RowOffset = 2,
		ColumnOffset = 2,
		DescriptionLines =
		[
			"All equipment, weapons systems, munitions, recovered material",
			"and Heavy Weapons Platforms are placed in stores, with the",
			"exception of equipment assigned to craft in hangars.",
		],
		Tilesets = [Tileset.XcomBase7],
	};

	private static readonly FacilityMetadata alienContainment = new()
	{
		Name = "Alien Containment",
		Shape = FacilityShape.Square,
		DaysToConstruct = 18,
		Cost = 400000,
		Maintenance = 15000,
		Image = new Image(Facilities.AlienContainment),
		RowOffset = 3,
		ColumnOffset = 3,
		DescriptionLines =
		[
			"Living aliens are likely to require a special habitat to maintain",
			"their life systems.  The containment facility can keep up to 10",
			"alien life forms in self contained units.",
		],
		Tilesets = [Tileset.XcomBase8],
	};

	private static readonly FacilityMetadata laserDefenses = new()
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
		DescriptionLines =
		[
			"Laser defenses provide protection against incursion by hostile",
			"craft.",
		],
		Tilesets = [Tileset.XcomBase9],
	};

	private static readonly FacilityMetadata plasmaDefenses = new()
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
		DescriptionLines =
		[
			"Plasma beam defenses provide powerful and efficient protection",
			"against incursion by hostile craft.",
		],
		Tilesets = [Tileset.XcomBase10],
	};

	private static readonly FacilityMetadata fusionBallDefenses = new()
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
		DescriptionLines =
		[
			"Fusion missiles provide the most effective defense against alien",
			"attacks.  These missiles create an anti-matter implosion which",
			"destroys everything within a specific radius.",
		],
		Tilesets = [Tileset.XcomBase11],
	};

	private static readonly FacilityMetadata gravShield = new()
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
		DescriptionLines =
		[
			"The Gravity shield repels alien craft attempting to land near",
			"the base long enough for all defense systems to fire again.  In",
			"practice this will double the effectiveness of any defense",
			"systems at your base.",
		],
		Tilesets = [Tileset.XcomBase12],
	};

	private static readonly FacilityMetadata mindShield = new()
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
		DescriptionLines =
		[
			"Since alien craft rely on brain waves to detect human presence",
			"then the most effective counter measure is to shield brain",
			"waves from the base.  This facility will drastically reduce the",
			"chances of detection by alien craft.",
		],
		Tilesets = [Tileset.XcomBase15],
	};

	private static readonly FacilityMetadata psionicLaboratory = new()
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
		DescriptionLines =
		[
			"The psionics lab can assess the psionic potential of all",
			"soldiers at the base and give them the necessary training to",
			"utilize their psionic skills.  Each lab can train up to ten",
			"soldiers.  Training is allocated at the end of each month.",
			"Psionic skills used in conjunction with a Psi-amp can be used",
			"for psionic attacks during combat.",
		],
		Tilesets = [Tileset.XcomBase14],
	};

	private static readonly FacilityMetadata hyperWaveDecoder = new()
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
		DescriptionLines =
		[
			"Alien communications rely on a supra-dimensional wave which",
			"travels almost instantaneously. The decoder facility intercepts",
			"UFO transmissions and decodes the information.  This will show",
			"the type of UFO, the alien race and the type of activity.",
		],
		Tilesets = [Tileset.XcomBase13],
	};

	private static readonly FacilityMetadata hangar = new()
	{
		Name = "Hangar",
		Shape = FacilityShape.Hangar,
		DaysToConstruct = 25,
		Cost = 200000,
		Maintenance = 25000,
		Image = new Image(Facilities.Hangar),
		RowOffset = 0,
		ColumnOffset = 0,
		DescriptionLines =
		[
			"Each hangar can accomodate one craft.  There are facilities for",
			"maintenance, refuelling and repair of XCom craft.  Each craft",
			"stationed at a base must have a free hangar assigned to it",
			"which cannot be used by other craft, even if the assigned craft",
			"is out on a mission.",
		],
		Tilesets = [Tileset.XcomBase16, Tileset.XcomBase17, Tileset.XcomBase18, Tileset.XcomBase19],
	};

	private static readonly Dictionary<FacilityType, FacilityMetadata> metadata = new()
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
		{ FacilityType.Hangar, hangar },
	};
}
