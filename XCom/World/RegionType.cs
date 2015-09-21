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

		private static readonly RegionMetadata northAmerica = new RegionMetadata
		{
			Name = "North America",
			BaseCost = 800000,
			Regions = new[]
			{
				new Region(1560, 560, 880, 120),
				new Region(1840, 440, 600, 200),
				new Region(1920, 240, 480, 160)
			}
		};

		private static readonly RegionMetadata arctic = new RegionMetadata
		{
			Name = "Arctic",
			BaseCost = 950000,
			Regions = new[]
			{
				new Region(0, 720, 2880, 160)
			}
		};

		private static readonly RegionMetadata antarctica = new RegionMetadata
		{
			Name = "Antarctica",
			BaseCost = 900000,
			Regions = new[]
			{
				new Region(0, -480, 2880, 240)
			}
		};

		private static readonly RegionMetadata southAmerica = new RegionMetadata
		{
			Name = "South America",
			BaseCost = 600000,
			Regions = new[]
			{
				new Region(2160, 80, 360, 80),
				new Region(2200, 0, 440, 120),
				new Region(2200, -120, 400, 360)
			}
		};

		private static readonly RegionMetadata europe = new RegionMetadata
		{
			Name = "Europe",
			BaseCost = 1000000,
			Regions = new[]
			{
				new Region(0, 560, 480, 280),
				new Region(2680, 560, 200, 280)
			}
		};

		private static readonly RegionMetadata northAfrica = new RegionMetadata
		{
			Name = "North Africa",
			BaseCost = 650000,
			Regions = new[]
			{
				new Region(0, 280, 320, 160),
				new Region(0, 120, 440, 120),
				new Region(2680, 280, 200, 280)
			}
		};

		private static readonly RegionMetadata southernAfrica = new RegionMetadata
		{
			Name = "Southern Africa",
			BaseCost = 550000,
			Regions = new[]
			{
				new Region(40, 0, 400, 320)
			}
		};

		private static readonly RegionMetadata centralAsia = new RegionMetadata
		{
			Name = "Central Asia",
			BaseCost = 500000,
			Regions = new[]
			{
				new Region(480, 400, 240, 120),
				new Region(320, 280, 240, 160),
				new Region(560, 280, 160, 240)
			}
		};

		private static readonly RegionMetadata southEastAsia = new RegionMetadata
		{
			Name = "South East Asia",
			BaseCost = 750000,
			Regions = new[]
			{
				new Region(720, 400, 120, 480),
				new Region(840, 400, 360, 360)
			}
		};

		private static readonly RegionMetadata siberia = new RegionMetadata
		{
			Name = "Siberia",
			BaseCost = 800000,
			Regions = new[]
			{
				new Region(480, 560, 960, 160)
			}
		};

		private static readonly RegionMetadata australia = new RegionMetadata
		{
			Name = "Australia",
			BaseCost = 750000,
			Regions = new[]
			{
				new Region(840, 40, 600, 520)
			}
		};

		private static readonly RegionMetadata pacific = new RegionMetadata
		{
			Name = "Pacific",
			BaseCost = 600000,
			Regions = new[]
			{
				new Region(1440, 560, 120, 120),
				new Region(1200, 400, 240, 360),
				new Region(1440, 440, 400, 200),
				new Region(1440, 240, 480, 160),
				new Region(1440, 80, 720, 80),
				new Region(1440, 0, 760, 480)
			}
		};

		private static readonly RegionMetadata northAtlantic = new RegionMetadata
		{
			Name = "North Atlantic",
			BaseCost = 500000,
			Regions = new[]
			{
				new Region(2440, 560, 240, 320),
				new Region(2400, 240, 280, 160),
				new Region(2520, 80, 160, 80)
			}
		};

		private static readonly RegionMetadata southAtlantic = new RegionMetadata
		{
			Name = "South Atlantic",
			BaseCost = 500000,
			Regions = new[]
			{
				new Region(0, 0, 40, 480),
				new Region(40, -320, 400, 160),
				new Region(2640, 0, 240, 120),
				new Region(2600, -120, 280, 360)
			}
		};

		private static readonly RegionMetadata indianOcean = new RegionMetadata
		{
			Name = "Indian Ocean",
			BaseCost = 500000,
			Regions = new[]
			{
				new Region(440, 120, 120, 200),
				new Region(560, 40, 160, 120),
				new Region(440, -80, 400, 400)
			}
		};

		private static readonly Dictionary<RegionType, RegionMetadata> metadata = new Dictionary<RegionType, RegionMetadata>
		{
			{ RegionType.NorthAmerica, northAmerica },
			{ RegionType.Arctic, arctic },
			{ RegionType.Antarctica, antarctica },
			{ RegionType.SouthAmerica, southAmerica },
			{ RegionType.Europe, europe },
			{ RegionType.NorthAfrica, northAfrica },
			{ RegionType.SouthernAfrica, southernAfrica },
			{ RegionType.CentralAsia, centralAsia },
			{ RegionType.SouthEastAsia, southEastAsia },
			{ RegionType.Siberia, siberia },
			{ RegionType.Australia, australia },
			{ RegionType.Pacific, pacific },
			{ RegionType.NorthAtlantic, northAtlantic },
			{ RegionType.SouthAtlantic, southAtlantic },
			{ RegionType.IndianOcean, indianOcean }
		};
	}
}
