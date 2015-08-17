using System.Collections.Generic;

namespace XCom.Data
{
	public enum ManufactureType
	{
		LaserPistol
	}

	public static class ManufactureTypeExtensions
	{
		public static ManufactureMetadata Metadata(this ManufactureType manufactureType)
		{
			return metadata[manufactureType];
		}

		private static readonly ManufactureMetadata laserPistol = new ManufactureMetadata
		{
			Name = "Laser Pistol",
			Category = "EQUIPMENT",
			Cost = 25000,
			HoursToProduce = 420,
			SpaceRequired = 4
		};

		private static readonly Dictionary<ManufactureType, ManufactureMetadata> metadata = new Dictionary<ManufactureType, ManufactureMetadata>
		{
			{ ManufactureType.LaserPistol, laserPistol }
		};
	}
}
