using System.Collections.Generic;

namespace XCom.Data
{
	public enum ItemType
	{
		LaserPistol
	}

	public static class ItemTypeExtensions
	{
		public static ItemMetadata Metadata(this ItemType itemType)
		{
			return metadata[itemType];
		}

		private static readonly ItemMetadata laserPistol = new ItemMetadata
		{
			Name = "Laser Pistol"
		};

		private static readonly Dictionary<ItemType, ItemMetadata> metadata = new Dictionary<ItemType, ItemMetadata>
		{
			{ ItemType.LaserPistol, laserPistol }
		};
	}
}
