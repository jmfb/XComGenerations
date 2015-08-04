using System.Collections.Generic;

namespace XCom.Data
{
	public enum ResearchType
	{
		LaserWeapons,
		LaserPistol,
		LaserRifle,
		HeavyLaser
	}

	public static class ResearchTypeExtensions
	{
		public static ResearchTypeMetadata Metadata(this ResearchType researchType)
		{
			return metadata[researchType];
		}

		private static readonly ResearchTypeMetadata laserWeapons = new ResearchTypeMetadata
		{
			Name = "Laser Weapons",
			AverageHoursToComplete = 50,
			RequiredResearch = new ResearchType[0]
		};

		private static readonly ResearchTypeMetadata laserPistol = new ResearchTypeMetadata
		{
			Name = "Laser Pistol",
			AverageHoursToComplete = 100,
			RequiredResearch = new[]
			{
				ResearchType.LaserWeapons
			}
		};

		private static readonly ResearchTypeMetadata laserRifle = new ResearchTypeMetadata
		{
			Name = "Laser Rifle",
			AverageHoursToComplete = 300,
			RequiredResearch = new[]
			{
				ResearchType.LaserWeapons
			}
		};

		private static readonly ResearchTypeMetadata heavyLaser = new ResearchTypeMetadata
		{
			Name = "Heavy Laser",
			AverageHoursToComplete = 460,
			RequiredResearch = new[]
			{
				ResearchType.LaserWeapons
			}
		};

		private static readonly Dictionary<ResearchType, ResearchTypeMetadata> metadata = new Dictionary<ResearchType,ResearchTypeMetadata>
 		{
			{ ResearchType.LaserWeapons, laserWeapons },
			{ ResearchType.LaserPistol, laserPistol },
			{ ResearchType.LaserRifle, laserRifle },
			{ ResearchType.HeavyLaser, heavyLaser }
		};
	}
}
