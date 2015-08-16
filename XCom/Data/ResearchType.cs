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
		public static ResearchMetadata Metadata(this ResearchType researchType)
		{
			return metadata[researchType];
		}

		private static readonly ResearchMetadata laserWeapons = new ResearchMetadata
		{
			Name = "Laser Weapons",
			AverageHoursToComplete = 50,
			RequiredResearch = new ResearchType[0]
		};

		private static readonly ResearchMetadata laserPistol = new ResearchMetadata
		{
			Name = "Laser Pistol",
			AverageHoursToComplete = 100,
			RequiredResearch = new[]
			{
				ResearchType.LaserWeapons
			},
			Item = ItemType.LaserPistol
		};

		private static readonly ResearchMetadata laserRifle = new ResearchMetadata
		{
			Name = "Laser Rifle",
			AverageHoursToComplete = 300,
			RequiredResearch = new[]
			{
				ResearchType.LaserWeapons
			}
		};

		private static readonly ResearchMetadata heavyLaser = new ResearchMetadata
		{
			Name = "Heavy Laser",
			AverageHoursToComplete = 460,
			RequiredResearch = new[]
			{
				ResearchType.LaserWeapons
			}
		};

		private static readonly Dictionary<ResearchType, ResearchMetadata> metadata = new Dictionary<ResearchType,ResearchMetadata>
 		{
			{ ResearchType.LaserWeapons, laserWeapons },
			{ ResearchType.LaserPistol, laserPistol },
			{ ResearchType.LaserRifle, laserRifle },
			{ ResearchType.HeavyLaser, heavyLaser }
		};
	}
}
