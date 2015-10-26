using System.Collections.Generic;

namespace XCom.Battlescape.Tiles
{
	public enum TileType
	{
		Common,

		Skyranger,
		Lightning,
		Avenger,

		XcomBase,
		XcomFacilities,

		AlienBase,
		Brain,
		UfoSmallScout,
		UfoExterior,
		UfoBits,
		UfoComponents,
		UfoEquipment,
		UfoExaminationRoom,
		UfoOperatingTable,

		City,
		CityBits,
		Roads,
		Furniture,

		Barn,
		Cultivation,
		Desert,
		Forest,
		Jungle,
		Mountain,
		Polar,

		Mars
	}

	public static class TileTypeExtensions
	{
		public static byte[] Image(this TileType tileType, int index)
		{
			var isBlankImage = tileType == TileType.Common && index == 0;
			return isBlankImage ? null : metadata[tileType].ImageGroup.Images[index];
		}

		public static PartData Part(this TileType tileType, int index)
		{
			return metadata[tileType].Parts[index];
		}

		public static int PartCount(this TileType tileType)
		{
			return metadata[tileType].Parts.Length;
		}

		private static TileMetadata Create(ImageGroup imageGroup, PartData[] parts)
		{
			return new TileMetadata
			{
				ImageGroup = imageGroup,
				Parts = parts
			};
		}

		private static readonly Dictionary<TileType, TileMetadata> metadata = new Dictionary<TileType, TileMetadata>
		{
			{ TileType.Common, Create(ImageGroup.Common, PartData.Common) },
			{ TileType.Skyranger, Create(ImageGroup.Skyranger, PartData.Skyranger) },
			{ TileType.Lightning, Create(ImageGroup.Lightning, PartData.Lightning) },
			{ TileType.Avenger, Create(ImageGroup.Avenger, PartData.Avenger) },
			{ TileType.XcomBase, Create(ImageGroup.XcomBase, PartData.XcomBase) },
			{ TileType.XcomFacilities, Create(ImageGroup.XcomFacilities, PartData.XcomFacilities) },
			{ TileType.AlienBase, Create(ImageGroup.AlienBase, PartData.AlienBase) },
			{ TileType.Brain, Create(ImageGroup.Brain, PartData.Brain) },
			{ TileType.UfoSmallScout, Create(ImageGroup.UfoSmallScout, PartData.UfoSmallScout) },
			{ TileType.UfoExterior, Create(ImageGroup.UfoExterior, PartData.UfoExterior) },
			{ TileType.UfoBits, Create(ImageGroup.UfoBits, PartData.UfoBits) },
			{ TileType.UfoComponents, Create(ImageGroup.UfoComponents, PartData.UfoComponents) },
			{ TileType.UfoEquipment, Create(ImageGroup.UfoEquipment, PartData.UfoEquipment) },
			{ TileType.UfoExaminationRoom, Create(ImageGroup.UfoExaminationRoom, PartData.UfoExaminationRoom) },
			{ TileType.UfoOperatingTable, Create(ImageGroup.UfoOperatingTable, PartData.UfoOperatingTable) },
			{ TileType.City, Create(ImageGroup.City, PartData.City) },
			{ TileType.CityBits, Create(ImageGroup.CityBits, PartData.CityBits) },
			{ TileType.Roads, Create(ImageGroup.Roads, PartData.Roads) },
			{ TileType.Furniture, Create(ImageGroup.Furniture, PartData.Furniture) },
			{ TileType.Barn, Create(ImageGroup.Barn, PartData.Barn) },
			{ TileType.Cultivation, Create(ImageGroup.Cultivation, PartData.Cultivation) },
			{ TileType.Desert, Create(ImageGroup.Desert, PartData.Desert) },
			{ TileType.Forest, Create(ImageGroup.Forest, PartData.Forest) },
			{ TileType.Jungle, Create(ImageGroup.Jungle, PartData.Jungle) },
			{ TileType.Mountain, Create(ImageGroup.Mountain, PartData.Mountain) },
			{ TileType.Polar, Create(ImageGroup.Polar, PartData.Polar) },
			{ TileType.Mars, Create(ImageGroup.Mars, PartData.Mars) }
		};
	}
}
