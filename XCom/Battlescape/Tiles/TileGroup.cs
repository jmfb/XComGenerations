namespace XCom.Battlescape.Tiles
{
	public class TileGroup
	{
		public TilePropertyPage[] PropertyPages { get; }
		public ImageGroup ImageGroup { get; }

		public int TileCount => PropertyPages.Length;

		private TileGroup(TilePropertyPage[] propertyPages, ImageGroup imageGroup)
		{
			PropertyPages = propertyPages;
			ImageGroup = imageGroup;
		}

		public static readonly TileGroup Common = new TileGroup(TilePropertyPage.Common, ImageGroup.Common);

		public static readonly TileGroup Skyranger = new TileGroup(TilePropertyPage.Skyranger, ImageGroup.Skyranger);
		public static readonly TileGroup Lightning = new TileGroup(TilePropertyPage.Lightning, ImageGroup.Lightning);
		public static readonly TileGroup Avenger = new TileGroup(TilePropertyPage.Avenger, ImageGroup.Avenger);

		public static readonly TileGroup XcomBase = new TileGroup(TilePropertyPage.XcomBase, ImageGroup.XcomBase);
		public static readonly TileGroup XcomFacilities = new TileGroup(TilePropertyPage.XcomFacilities, ImageGroup.XcomFacilities);

		public static readonly TileGroup AlienBase = new TileGroup(TilePropertyPage.AlienBase, ImageGroup.AlienBase);
		public static readonly TileGroup Brain = new TileGroup(TilePropertyPage.Brain, ImageGroup.Brain);
		public static readonly TileGroup UfoSmallScout = new TileGroup(TilePropertyPage.UfoSmallScout, ImageGroup.UfoSmallScout);
		public static readonly TileGroup UfoExterior = new TileGroup(TilePropertyPage.UfoExterior, ImageGroup.UfoExterior);
		public static readonly TileGroup UfoBits = new TileGroup(TilePropertyPage.UfoBits, ImageGroup.UfoBits);
		public static readonly TileGroup UfoComponents = new TileGroup(TilePropertyPage.UfoComponents, ImageGroup.UfoComponents);
		public static readonly TileGroup UfoEquipment = new TileGroup(TilePropertyPage.UfoEquipment, ImageGroup.UfoEquipment);
		public static readonly TileGroup UfoExaminationRoom = new TileGroup(TilePropertyPage.UfoExaminationRoom, ImageGroup.UfoExaminationRoom);
		public static readonly TileGroup UfoOperatingTable = new TileGroup(TilePropertyPage.UfoOperatingTable, ImageGroup.UfoOperatingTable);

		public static readonly TileGroup City = new TileGroup(TilePropertyPage.City, ImageGroup.City);
		public static readonly TileGroup CityBits = new TileGroup(TilePropertyPage.CityBits, ImageGroup.CityBits);
		public static readonly TileGroup Roads = new TileGroup(TilePropertyPage.Roads, ImageGroup.Roads);
		public static readonly TileGroup Furniture = new TileGroup(TilePropertyPage.Furniture, ImageGroup.Furniture);

		public static readonly TileGroup Barn = new TileGroup(TilePropertyPage.Barn, ImageGroup.Barn);
		public static readonly TileGroup Cultivation = new TileGroup(TilePropertyPage.Cultivation, ImageGroup.Cultivation);
		public static readonly TileGroup Desert = new TileGroup(TilePropertyPage.Desert, ImageGroup.Desert);
		public static readonly TileGroup Forest = new TileGroup(TilePropertyPage.Forest, ImageGroup.Forest);
		public static readonly TileGroup Jungle = new TileGroup(TilePropertyPage.Jungle, ImageGroup.Jungle);
		public static readonly TileGroup Mountain = new TileGroup(TilePropertyPage.Mountain, ImageGroup.Mountain);
		public static readonly TileGroup Polar = new TileGroup(TilePropertyPage.Polar, ImageGroup.Polar);

		public static readonly TileGroup Mars = new TileGroup(TilePropertyPage.Mars, ImageGroup.Mars);
	}
}
