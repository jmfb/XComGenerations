namespace XCom.Battlescape.Tiles
{
	public class TileGroup
	{
		public TilePropertyPage[] PropertyPages { get; }
		public ImageGroupType ImageGroupType { get; }

		public int TileCount => PropertyPages.Length;

		private TileGroup(TilePropertyPage[] propertyPages, ImageGroupType imageGroupType)
		{
			PropertyPages = propertyPages;
			ImageGroupType = imageGroupType;
		}

		public static readonly TileGroup Common = new TileGroup(TilePropertyPage.Common, ImageGroupType.Common);

		public static readonly TileGroup Skyranger = new TileGroup(TilePropertyPage.Skyranger, ImageGroupType.Skyranger);
		public static readonly TileGroup Lightning = new TileGroup(TilePropertyPage.Lightning, ImageGroupType.Lightning);
		public static readonly TileGroup Avenger = new TileGroup(TilePropertyPage.Avenger, ImageGroupType.Avenger);

		public static readonly TileGroup XcomBase = new TileGroup(TilePropertyPage.XcomBase, ImageGroupType.XcomBase);
		public static readonly TileGroup XcomFacilities = new TileGroup(TilePropertyPage.XcomFacilities, ImageGroupType.XcomFacilities);

		public static readonly TileGroup AlienBase = new TileGroup(TilePropertyPage.AlienBase, ImageGroupType.AlienBase);
		public static readonly TileGroup Brain = new TileGroup(TilePropertyPage.Brain, ImageGroupType.Brain);
		public static readonly TileGroup UfoSmallScout = new TileGroup(TilePropertyPage.UfoSmallScout, ImageGroupType.UfoSmallScout);
		public static readonly TileGroup UfoExterior = new TileGroup(TilePropertyPage.UfoExterior, ImageGroupType.UfoExterior);
		public static readonly TileGroup UfoBits = new TileGroup(TilePropertyPage.UfoBits, ImageGroupType.UfoBits);
		public static readonly TileGroup UfoComponents = new TileGroup(TilePropertyPage.UfoComponents, ImageGroupType.UfoComponents);
		public static readonly TileGroup UfoEquipment = new TileGroup(TilePropertyPage.UfoEquipment, ImageGroupType.UfoEquipment);
		public static readonly TileGroup UfoExaminationRoom = new TileGroup(TilePropertyPage.UfoExaminationRoom, ImageGroupType.UfoExaminationRoom);
		public static readonly TileGroup UfoOperatingTable = new TileGroup(TilePropertyPage.UfoOperatingTable, ImageGroupType.UfoOperatingTable);

		public static readonly TileGroup City = new TileGroup(TilePropertyPage.City, ImageGroupType.City);
		public static readonly TileGroup CityBits = new TileGroup(TilePropertyPage.CityBits, ImageGroupType.CityBits);
		public static readonly TileGroup Roads = new TileGroup(TilePropertyPage.Roads, ImageGroupType.Roads);
		public static readonly TileGroup Furniture = new TileGroup(TilePropertyPage.Furniture, ImageGroupType.Furniture);

		public static readonly TileGroup Barn = new TileGroup(TilePropertyPage.Barn, ImageGroupType.Barn);
		public static readonly TileGroup Cultivation = new TileGroup(TilePropertyPage.Cultivation, ImageGroupType.Cultivation);
		public static readonly TileGroup Desert = new TileGroup(TilePropertyPage.Desert, ImageGroupType.Desert);
		public static readonly TileGroup Forest = new TileGroup(TilePropertyPage.Forest, ImageGroupType.Forest);
		public static readonly TileGroup Jungle = new TileGroup(TilePropertyPage.Jungle, ImageGroupType.Jungle);
		public static readonly TileGroup Mountain = new TileGroup(TilePropertyPage.Mountain, ImageGroupType.Mountain);
		public static readonly TileGroup Polar = new TileGroup(TilePropertyPage.Polar, ImageGroupType.Polar);

		public static readonly TileGroup Mars = new TileGroup(TilePropertyPage.Mars, ImageGroupType.Mars);
	}
}
