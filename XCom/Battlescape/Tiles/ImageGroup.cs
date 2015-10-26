using System.Collections.Generic;
using System.Linq;
using XCom.Content.Maps.ImageGroups;
using XCom.Content.Maps.ImageTables;

namespace XCom.Battlescape.Tiles
{
	public class ImageGroup
	{
		public byte[][] Images { get; }

		private ImageGroup(byte[] tableData, IReadOnlyCollection<byte> imageData)
		{
			var table = new ImageTable(tableData);
			var lastIndex = table.Offsets.Length - 1;
			Images = table.Offsets
				.Select((offset, index) => imageData
					.Skip(offset)
					.Take((index == lastIndex ? imageData.Count : table.Offsets[index + 1]) - offset)
					.ToArray())
				.ToArray();
		}

		public static readonly ImageGroup Common = new ImageGroup(ImageTables.Common, ImageGroups.Common);

		public static readonly ImageGroup Skyranger = new ImageGroup(ImageTables.Skyranger, ImageGroups.Skyranger);
		public static readonly ImageGroup Lightning = new ImageGroup(ImageTables.Lightning, ImageGroups.Lightning);
		public static readonly ImageGroup Avenger = new ImageGroup(ImageTables.Avenger, ImageGroups.Avenger);

		public static readonly ImageGroup XcomBase = new ImageGroup(ImageTables.XcomBase, ImageGroups.XcomBase);
		public static readonly ImageGroup XcomFacilities = new ImageGroup(ImageTables.XcomFacilities, ImageGroups.XcomFacilities);

		public static readonly ImageGroup AlienBase = new ImageGroup(ImageTables.AlienBase, ImageGroups.AlienBase);
		public static readonly ImageGroup Brain = new ImageGroup(ImageTables.Brain, ImageGroups.Brain);
		public static readonly ImageGroup UfoSmallScout = new ImageGroup(ImageTables.UfoSmallScout, ImageGroups.UfoSmallScout);
		public static readonly ImageGroup UfoExterior = new ImageGroup(ImageTables.UfoExterior, ImageGroups.UfoExterior);
		public static readonly ImageGroup UfoBits = new ImageGroup(ImageTables.UfoBits, ImageGroups.UfoBits);
		public static readonly ImageGroup UfoComponents = new ImageGroup(ImageTables.UfoComponents, ImageGroups.UfoComponents);
		public static readonly ImageGroup UfoEquipment = new ImageGroup(ImageTables.UfoEquipment, ImageGroups.UfoEquipment);
		public static readonly ImageGroup UfoExaminationRoom = new ImageGroup(ImageTables.UfoExaminationRoom, ImageGroups.UfoExaminationRoom);
		public static readonly ImageGroup UfoOperatingTable = new ImageGroup(ImageTables.UfoOperatingTable, ImageGroups.UfoOperatingTable);

		public static readonly ImageGroup City = new ImageGroup(ImageTables.City, ImageGroups.City);
		public static readonly ImageGroup CityBits = new ImageGroup(ImageTables.CityBits, ImageGroups.CityBits);
		public static readonly ImageGroup Roads = new ImageGroup(ImageTables.Roads, ImageGroups.Roads);
		public static readonly ImageGroup Furniture = new ImageGroup(ImageTables.Furniture, ImageGroups.Furniture);

		public static readonly ImageGroup Barn = new ImageGroup(ImageTables.Barn, ImageGroups.Barn);
		public static readonly ImageGroup Cultivation = new ImageGroup(ImageTables.Cultivation, ImageGroups.Cultivation);
		public static readonly ImageGroup Desert = new ImageGroup(ImageTables.Desert, ImageGroups.Desert);
		public static readonly ImageGroup Forest = new ImageGroup(ImageTables.Forest, ImageGroups.Forest);
		public static readonly ImageGroup Jungle = new ImageGroup(ImageTables.Jungle, ImageGroups.Jungle);
		public static readonly ImageGroup Mountain = new ImageGroup(ImageTables.Mountain, ImageGroups.Mountain);
		public static readonly ImageGroup Polar = new ImageGroup(ImageTables.Polar, ImageGroups.Polar);

		public static readonly ImageGroup Mars = new ImageGroup(ImageTables.Mars, ImageGroups.Mars);
	}
}
