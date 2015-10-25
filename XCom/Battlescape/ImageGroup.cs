using System.Collections.Generic;
using System.Linq;
using XCom.Content.Maps.ImageGroups;

namespace XCom.Battlescape
{
	public class ImageGroup
	{
		public byte[][] Images { get; }

		private ImageGroup(ImageTable table, IEnumerable<byte> data)
		{
			Images = table.Offsets
				.Select(offset => data
					.Skip(offset)
					.TakeWhile(index => index != 0xff)
					.ToArray())
				.ToArray();
		}

		public static readonly ImageGroup Common = new ImageGroup(ImageTable.Common, ImageGroups.Common);

		public static readonly ImageGroup Skyranger = new ImageGroup(ImageTable.Skyranger, ImageGroups.Skyranger);
		public static readonly ImageGroup Lightning = new ImageGroup(ImageTable.Lightning, ImageGroups.Lightning);
		public static readonly ImageGroup Avenger = new ImageGroup(ImageTable.Avenger, ImageGroups.Avenger);

		public static readonly ImageGroup XcomBase = new ImageGroup(ImageTable.XcomBase, ImageGroups.XcomBase);
		public static readonly ImageGroup XcomFacilities = new ImageGroup(ImageTable.XcomFacilities, ImageGroups.XcomFacilities);

		public static readonly ImageGroup AlienBase = new ImageGroup(ImageTable.AlienBase, ImageGroups.AlienBase);
		public static readonly ImageGroup Brain = new ImageGroup(ImageTable.Brain, ImageGroups.Brain);
		public static readonly ImageGroup UfoSmallScout = new ImageGroup(ImageTable.UfoSmallScout, ImageGroups.UfoSmallScout);
		public static readonly ImageGroup UfoExterior = new ImageGroup(ImageTable.UfoExterior, ImageGroups.UfoExterior);
		public static readonly ImageGroup UfoBits = new ImageGroup(ImageTable.UfoBits, ImageGroups.UfoBits);
		public static readonly ImageGroup UfoComponents = new ImageGroup(ImageTable.UfoComponents, ImageGroups.UfoComponents);
		public static readonly ImageGroup UfoEquipment = new ImageGroup(ImageTable.UfoEquipment, ImageGroups.UfoEquipment);
		public static readonly ImageGroup UfoExaminationRoom = new ImageGroup(ImageTable.UfoExaminationRoom, ImageGroups.UfoExaminationRoom);
		public static readonly ImageGroup UfoOperatingTable = new ImageGroup(ImageTable.UfoOperatingTable, ImageGroups.UfoOperatingTable);

		public static readonly ImageGroup City = new ImageGroup(ImageTable.City, ImageGroups.City);
		public static readonly ImageGroup CityBits = new ImageGroup(ImageTable.CityBits, ImageGroups.CityBits);
		public static readonly ImageGroup Roads = new ImageGroup(ImageTable.Roads, ImageGroups.Roads);
		public static readonly ImageGroup Furniture = new ImageGroup(ImageTable.Furniture, ImageGroups.Furniture);

		public static readonly ImageGroup Barn = new ImageGroup(ImageTable.Barn, ImageGroups.Barn);
		public static readonly ImageGroup Cultivation = new ImageGroup(ImageTable.Cultivation, ImageGroups.Cultivation);
		public static readonly ImageGroup Desert = new ImageGroup(ImageTable.Desert, ImageGroups.Desert);
		public static readonly ImageGroup Forest = new ImageGroup(ImageTable.Forest, ImageGroups.Forest);
		public static readonly ImageGroup Jungle = new ImageGroup(ImageTable.Jungle, ImageGroups.Jungle);
		public static readonly ImageGroup Mountain = new ImageGroup(ImageTable.Mountain, ImageGroups.Mountain);
		public static readonly ImageGroup Polar = new ImageGroup(ImageTable.Polar, ImageGroups.Polar);

		public static readonly ImageGroup Mars = new ImageGroup(ImageTable.Mars, ImageGroups.Mars);
	}
}
