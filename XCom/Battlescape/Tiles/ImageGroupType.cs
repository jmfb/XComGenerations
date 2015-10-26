using System.Collections.Generic;

namespace XCom.Battlescape.Tiles
{
	public enum ImageGroupType
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

	public static class ImageGroupTypeExtensions
	{
		public static byte[] Image(this ImageGroupType imageGroupType, int index)
		{
			var isBlankImage = imageGroupType == ImageGroupType.Common && index == 0;
			return isBlankImage ? null : metadata[imageGroupType].Images[index];
		}

		private static readonly Dictionary<ImageGroupType, ImageGroup> metadata = new Dictionary<ImageGroupType, ImageGroup>
		{
			{ ImageGroupType.Common, ImageGroup.Common },
			{ ImageGroupType.Skyranger, ImageGroup.Skyranger },
			{ ImageGroupType.Lightning, ImageGroup.Lightning },
			{ ImageGroupType.Avenger, ImageGroup.Avenger },
			{ ImageGroupType.XcomBase, ImageGroup.XcomBase },
			{ ImageGroupType.XcomFacilities, ImageGroup.XcomFacilities },
			{ ImageGroupType.AlienBase, ImageGroup.AlienBase },
			{ ImageGroupType.Brain, ImageGroup.Brain },
			{ ImageGroupType.UfoSmallScout, ImageGroup.UfoSmallScout },
			{ ImageGroupType.UfoExterior, ImageGroup.UfoExterior },
			{ ImageGroupType.UfoBits, ImageGroup.UfoBits },
			{ ImageGroupType.UfoComponents, ImageGroup.UfoComponents },
			{ ImageGroupType.UfoEquipment, ImageGroup.UfoEquipment },
			{ ImageGroupType.UfoExaminationRoom, ImageGroup.UfoExaminationRoom },
			{ ImageGroupType.UfoOperatingTable, ImageGroup.UfoOperatingTable },
			{ ImageGroupType.City, ImageGroup.City },
			{ ImageGroupType.CityBits, ImageGroup.CityBits },
			{ ImageGroupType.Roads, ImageGroup.Roads },
			{ ImageGroupType.Furniture, ImageGroup.Furniture },
			{ ImageGroupType.Barn, ImageGroup.Barn },
			{ ImageGroupType.Cultivation, ImageGroup.Cultivation },
			{ ImageGroupType.Desert, ImageGroup.Desert },
			{ ImageGroupType.Forest, ImageGroup.Forest },
			{ ImageGroupType.Jungle, ImageGroup.Jungle },
			{ ImageGroupType.Mountain, ImageGroup.Mountain },
			{ ImageGroupType.Polar, ImageGroup.Polar },
			{ ImageGroupType.Mars, ImageGroup.Mars }
		};
	}
}
