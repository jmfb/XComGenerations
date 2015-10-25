using System;
using System.Linq;
using XCom.Content.Maps.ImageTables;

namespace XCom.Battlescape
{
	public class ImageTable
	{
		public ushort[] Offsets { get; }

		private ImageTable(byte[] data)
		{
			var count = data.Length / sizeof(ushort);
			Offsets = Enumerable.Range(0, count)
				.Select(index => index * sizeof(ushort))
				.Select(offset => BitConverter.ToUInt16(data, offset))
				.ToArray();
		}

		public static readonly ImageTable Common = new ImageTable(ImageTables.Common);

		public static readonly ImageTable Skyranger = new ImageTable(ImageTables.Skyranger);
		public static readonly ImageTable Lightning = new ImageTable(ImageTables.Lightning);
		public static readonly ImageTable Avenger = new ImageTable(ImageTables.Avenger);

		public static readonly ImageTable XcomBase = new ImageTable(ImageTables.XcomBase);
		public static readonly ImageTable XcomFacilities = new ImageTable(ImageTables.XcomFacilities);

		public static readonly ImageTable AlienBase = new ImageTable(ImageTables.AlienBase);
		public static readonly ImageTable Brain = new ImageTable(ImageTables.Brain);
		public static readonly ImageTable UfoSmallScout = new ImageTable(ImageTables.UfoSmallScout);
		public static readonly ImageTable UfoExterior = new ImageTable(ImageTables.UfoExterior);
		public static readonly ImageTable UfoBits = new ImageTable(ImageTables.UfoBits);
		public static readonly ImageTable UfoComponents = new ImageTable(ImageTables.UfoComponents);
		public static readonly ImageTable UfoEquipment = new ImageTable(ImageTables.UfoEquipment);
		public static readonly ImageTable UfoExaminationRoom = new ImageTable(ImageTables.UfoExaminationRoom);
		public static readonly ImageTable UfoOperatingTable = new ImageTable(ImageTables.UfoOperatingTable);

		public static readonly ImageTable City = new ImageTable(ImageTables.City);
		public static readonly ImageTable CityBits = new ImageTable(ImageTables.CityBits);
		public static readonly ImageTable Roads = new ImageTable(ImageTables.Roads);
		public static readonly ImageTable Furniture = new ImageTable(ImageTables.Furniture);

		public static readonly ImageTable Barn = new ImageTable(ImageTables.Barn);
		public static readonly ImageTable Cultivation = new ImageTable(ImageTables.Cultivation);
		public static readonly ImageTable Desert = new ImageTable(ImageTables.Desert);
		public static readonly ImageTable Forest = new ImageTable(ImageTables.Forest);
		public static readonly ImageTable Jungle = new ImageTable(ImageTables.Jungle);
		public static readonly ImageTable Mountain = new ImageTable(ImageTables.Mountain);
		public static readonly ImageTable Polar = new ImageTable(ImageTables.Polar);

		public static readonly ImageTable Mars = new ImageTable(ImageTables.Mars);
	}
}
