using System.Collections.Generic;
using System.Linq;
using XCom.Content.Maps.ImageGroups;
using XCom.Content.Maps.ImageTables;
using UnitImageGroups = XCom.Content.Units.ImageGroups.ImageGroups;
using UnitImageTables = XCom.Content.Units.ImageTables.ImageTables;

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

		public static readonly ImageGroup SoldierCoveralls = new ImageGroup(UnitImageTables.SoldierCoveralls, UnitImageGroups.SoldierCoveralls);
		public static readonly ImageGroup SoldierPersonalArmor = new ImageGroup(UnitImageTables.SoldierPersonalArmor, UnitImageGroups.SoldierPersonalArmor);
		public static readonly ImageGroup SoldierPowerSuit = new ImageGroup(UnitImageTables.SoldierPowerSuit, UnitImageGroups.SoldierPowerSuit);
		public static readonly ImageGroup Tanks = new ImageGroup(UnitImageTables.Tanks, UnitImageGroups.Tanks);
		public static readonly ImageGroup CivilianMale = new ImageGroup(UnitImageTables.CivilianMale, UnitImageGroups.CivilianMale);
		public static readonly ImageGroup CivilianFemale = new ImageGroup(UnitImageTables.CivilianFemale, UnitImageGroups.CivilianFemale);

		public static readonly ImageGroup Sectoid = new ImageGroup(UnitImageTables.Sectoid, UnitImageGroups.Sectoid);
		public static readonly ImageGroup Snakeman = new ImageGroup(UnitImageTables.Snakeman, UnitImageGroups.Snakeman);
		public static readonly ImageGroup Muton = new ImageGroup(UnitImageTables.Muton, UnitImageGroups.Muton);
		public static readonly ImageGroup Floater = new ImageGroup(UnitImageTables.Floater, UnitImageGroups.Floater);
		public static readonly ImageGroup Ethereal = new ImageGroup(UnitImageTables.Ethereal, UnitImageGroups.Ethereal);
		public static readonly ImageGroup Celatid = new ImageGroup(UnitImageTables.Celatid, UnitImageGroups.Celatid);
		public static readonly ImageGroup Silacoid = new ImageGroup(UnitImageTables.Silacoid, UnitImageGroups.Silacoid);
		public static readonly ImageGroup Chryssalid = new ImageGroup(UnitImageTables.Chryssalid, UnitImageGroups.Chryssalid);
		public static readonly ImageGroup Reaper = new ImageGroup(UnitImageTables.Reaper, UnitImageGroups.Reaper);
		public static readonly ImageGroup Cyberdisc = new ImageGroup(UnitImageTables.Cyberdisc, UnitImageGroups.Cyberdisc);
		public static readonly ImageGroup Sectopod = new ImageGroup(UnitImageTables.Sectopod, UnitImageGroups.Sectopod);
		public static readonly ImageGroup Zombie = new ImageGroup(UnitImageTables.Zombie, UnitImageGroups.Zombie);

		public static readonly ImageGroup Ground = new ImageGroup(UnitImageTables.Ground, UnitImageGroups.Ground);
		public static readonly ImageGroup Hand = new ImageGroup(UnitImageTables.Hand, UnitImageGroups.Hand);
	}
}
