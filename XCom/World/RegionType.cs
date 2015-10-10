using System.Collections.Generic;

namespace XCom.World
{
	public enum RegionType
	{
		NorthAmerica,
		Arctic,
		Antarctica,
		SouthAmerica,
		Europe,
		NorthAfrica,
		SouthernAfrica,
		CentralAsia,
		SouthEastAsia,
		Siberia,
		Australia,
		Pacific,
		NorthAtlantic,
		SouthAtlantic,
		IndianOcean
	}

	public static class RegionTypeExtensions
	{
		public static RegionMetadata Metadata(this RegionType regionType) => metadata[regionType];

		private static readonly Dictionary<RegionType, RegionMetadata> metadata = new Dictionary<RegionType, RegionMetadata>
		{
			{ RegionType.NorthAmerica, RegionMetadata.Create("North America", 800000) },
			{ RegionType.Arctic, RegionMetadata.Create("Arctic", 950000) },
			{ RegionType.Antarctica, RegionMetadata.Create("Antarctica", 900000) },
			{ RegionType.SouthAmerica, RegionMetadata.Create("South America", 600000) },
			{ RegionType.Europe, RegionMetadata.Create("Europe", 1000000) },
			{ RegionType.NorthAfrica, RegionMetadata.Create("North Africa", 650000) },
			{ RegionType.SouthernAfrica, RegionMetadata.Create("Southern Africa", 550000) },
			{ RegionType.CentralAsia, RegionMetadata.Create("Central Asia", 500000) },
			{ RegionType.SouthEastAsia, RegionMetadata.Create("South East Asia", 750000) },
			{ RegionType.Siberia, RegionMetadata.Create("Siberia", 800000) },
			{ RegionType.Australia, RegionMetadata.Create("Australia", 750000) },
			{ RegionType.Pacific, RegionMetadata.Create("Pacific", 600000) },
			{ RegionType.NorthAtlantic, RegionMetadata.Create("North Atlantic", 500000) },
			{ RegionType.SouthAtlantic, RegionMetadata.Create("South Atlantic", 500000) },
			{ RegionType.IndianOcean, RegionMetadata.Create("Indian Ocean", 500000) }
		};
	}
}
