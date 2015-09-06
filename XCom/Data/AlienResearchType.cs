using System.Collections.Generic;

namespace XCom.Data
{
	public enum AlienResearchType
	{
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
		AlienSupply
	}

	public static class AlienResearchTypeExtensions
	{
		public static AlienResearchMetadata Metadata(this AlienResearchType alienResearchType) => metadata[alienResearchType];

		private static readonly AlienResearchMetadata alienOrigins = new AlienResearchMetadata
		{
			Name = "Alien Origins",
			DescriptionLines = new[]
			{
				"It is clear that we are fighting a losing battle on earth. The",
				"alien hordes are overwhelming in number.  The best we can do",
				"is slow down their progress.  The only hope for humanity is",
				"to tackle the aliens at their source.  Our research seems to",
				"indicate a nearby base of operations within our solar system.",
				"Aliens indicate this place to be the center of an ancient",
				"civilization that pre-dates Human history.  We must locate this",
				"place as soon as possible.  However we need to capture and",
				"interrogate an alien leader to gain more detailed information.",
				"The larger UFOs probably contain at least one Alien leader."
			}
		};

		private static readonly AlienResearchMetadata theMartianSolution = new AlienResearchMetadata
		{
			Name = "The Martian Solution",
			DescriptionLines = new[]
			{
				"Our research now points to Mars as the base of alien",
				"operations.  The base is well hidden, and contains all the",
				"manufacturing and cloning facilities to fuel the infiltration of",
				"earth.  It also seems to contain a controlling computer of",
				"some kind that controls the whole operation. It seems that",
				"the hive-like alien society has some kind of 'queen bee'. This is",
				"their fundamental weakness - if we can eliminate the 'brain'",
				"then the body will die.  We must step up our research efforts",
				"before it is too late.  In order to progress we must capture",
				"the highest ranking aliens - the commanders - which only",
				"reside in alien bases."
			}
		};

		private static readonly AlienResearchMetadata cydoniaOrBust = new AlienResearchMetadata
		{
			Name = "Cydonia or Bust",
			DescriptionLines = new[]
			{
				"It is now clear that the alien hordes are being controlled",
				"from an underground base in Cydonia - which is an unusual",
				"area of Mars featuring five sided pyramids and a large",
				"formation resembling a human face.  Cydonian civilization once",
				"flourished on Mars many millions of years ago, but we do not",
				"know why it died out, or what the connection is with the",
				"latest alien activity there. Whatever the explanation we must",
				"send an expedition to Cydonia.  This is the only way that we",
				"can defeat the aliens.  We must destroy the controlling",
				"master 'brain'.  We will need an Avenger craft equipped with",
				"the most awesome destructive power at our disposal.  There",
				"is nothing more we can learn here - we must await the",
				"outcome of the Cydonian assault."
			}
		};

		private static readonly AlienResearchMetadata alienResearch = new AlienResearchMetadata
		{
			Name = "Alien Research",
			DescriptionLines = new[]
			{
				"The alien research mission is used for collecting basic data on",
				"earth and its inhabitants.  Small vehicles are predominantly",
				"used, with occasional landings in deserted areas.  This type of",
				"alien activity poses the least threat to XCom, with little",
				"concern from governments or the public."
			}
		};

		private static readonly AlienResearchMetadata alienHarvest = new AlienResearchMetadata
		{
			Name = "Alien Harvest",
			DescriptionLines = new[]
			{
				"The aliens have many uses for earth's fauna.  Animals are",
				"abducted secretly, and returned with various organs removed.",
				"Cattle mutilations are predominantly reported along with UFO",
				"sightings.  This type of alien activity causes great concern by",
				"governments and considerable anxiety amongst the population.",
				"This type of activity occurs mainly in farming land.  The",
				"theory behind the 'alien harvest' suggests that alien races",
				"originally 'seeded' the planet with its flora and fauna, and now",
				"they have returned to reap the harvest they have sown."
			}
		};

		private static readonly AlienResearchMetadata alienAbduction = new AlienResearchMetadata
		{
			Name = "Alien Abduction",
			DescriptionLines = new[]
			{
				"This is the most insidious form of alien activity.  The abduction",
				"by aliens is widely reported, despite the aliens' attempts to",
				"erase the experience from their victims' memories. Abductees",
				"report being subject to humiliating physical examinations,",
				"including impregnation of alien fetuses and bizarre genetic",
				"experiments. The purpose behind this activity appears to be",
				"linked to genetic mutation and manipulation of the aliens own",
				"genetic material. This activity causes great alarm, and occurs",
				"in populated areas or cities."
			}
		};

		private static readonly AlienResearchMetadata alienInfiltration = new AlienResearchMetadata
		{
			Name = "Alien Infiltration",
			DescriptionLines = new[]
			{
				"Earth governments can be infiltrated by alien agents which are",
				"human in appearance.  This can result in official contact between",
				"aliens and governments at the highest level. The climax of this",
				"activity is characterized by intense UFO activity in the vicinity",
				"of major cities. The aliens will attempt to sign a pact with an",
				"earth government by offering knowledge of their superior",
				"technology. In return the government will allow the aliens to",
				"conduct their activity unhindered. This alien mission represents",
				"the worst threat to XCom. If a government agrees to a pact",
				"then its funding will cease."
			}
		};

		private static readonly AlienResearchMetadata alienBase = new AlienResearchMetadata
		{
			Name = "Alien Base",
			DescriptionLines = new[]
			{
				"Aliens will construct secret underground bases in remote",
				"locations. After some initial reconnaissance flights some intense",
				"UFO activity will occur as the base is being built.  These bases",
				"are known to contain experimental labs for human abductees,",
				"and supplies for further activity in the region.  The presence",
				"of alien bases will generate a large amount of reported alien",
				"activity without the presence of UFOs. In order to locate a",
				"base an XCom craft must patrol an area for a few hours to",
				"stand some chance of detection."
			}
		};

		private static readonly AlienResearchMetadata alienTerror = new AlienResearchMetadata
		{
			Name = "Alien Terror",
			DescriptionLines = new[]
			{
				"When the aliens terrorize a city they will deploy some special",
				"forces with awesome powers.  Civilians will be directly",
				"threatened, and governments will be forced to evacuate whole",
				"areas. The main purpose behind this activity is to generate",
				"sufficient public hysteria so that governments will threaten",
				"the XCom project."
			}
		};

		private static readonly AlienResearchMetadata alienRetaliation = new AlienResearchMetadata
		{
			Name = "Alien Retaliation",
			DescriptionLines = new[]
			{
				"If XCom interceptors are being particularly successful in",
				"shooting down UFOs then the aliens may take some retaliatory",
				"action. This could result in a direct attack against an XCom",
				"base.  However, the aliens have to find an XCom base in order",
				"to attack it, and provided UFOs are kept away then there",
				"should be little danger of an assault."
			}
		};

		private static readonly AlienResearchMetadata alienSupply = new AlienResearchMetadata
		{
			Name = "Alien Supply",
			DescriptionLines = new[]
			{
				"Once an alien base is constructed then it is resupplied on a",
				"regular basis by a special supply vessel.  If one of these",
				"vessels is detected while landing then it is certain that an",
				"alien base is nearby."
			}
		};

		private static readonly Dictionary<AlienResearchType, AlienResearchMetadata> metadata = new Dictionary<AlienResearchType, AlienResearchMetadata>
		{
			{ AlienResearchType.AlienOrigins, alienOrigins },
			{ AlienResearchType.TheMartianSolution, theMartianSolution },
			{ AlienResearchType.CydoniaOrBust, cydoniaOrBust },
			{ AlienResearchType.AlienResearch, alienResearch },
			{ AlienResearchType.AlienHarvest, alienHarvest },
			{ AlienResearchType.AlienAbduction, alienAbduction },
			{ AlienResearchType.AlienInfiltration, alienInfiltration },
			{ AlienResearchType.AlienBase, alienBase },
			{ AlienResearchType.AlienTerror, alienTerror },
			{ AlienResearchType.AlienRetaliation, alienRetaliation },
			{ AlienResearchType.AlienSupply, alienSupply }
		};
	}
}
