using XCom.Content.Maps.ImageGroups;
using XCom.Content.Maps.ImageTables;
using BattlescapeImageGroups = XCom.Content.Battlescape.ImageGroups.ImageGroups;
using BattlescapeImages = XCom.Content.Battlescape.Images.Images;
using BattlescapeImageTables = XCom.Content.Battlescape.ImageTables.ImageTables;
using UnitImageGroups = XCom.Content.Units.ImageGroups.ImageGroups;
using UnitImageTables = XCom.Content.Units.ImageTables.ImageTables;

namespace XCom.Battlescape.Tiles;

public class ImageGroup
{
	public byte[][] Images { get; }

	private ImageGroup(byte[] tableData, IReadOnlyCollection<byte> imageData)
	{
		var table = new ImageTable(tableData);
		var lastIndex = table.Offsets.Length - 1;
		Images = table
			.Offsets.Select(
				(offset, index) =>
					imageData
						.Skip(offset)
						.Take(
							(index == lastIndex ? imageData.Count : table.Offsets[index + 1])
								- offset
						)
						.ToArray()
			)
			.ToArray();
	}

	private ImageGroup(IReadOnlyCollection<byte> imageData, int width, int height)
	{
		var imageSize = width * height;
		var imageCount = imageData.Count / imageSize;
		Images = Enumerable
			.Range(0, imageCount)
			.Select(index => imageData.Skip(index * imageSize).Take(imageSize).ToArray())
			.ToArray();
	}

	public static readonly ImageGroup Common = new(ImageTables.Common, ImageGroups.Common);

	public static readonly ImageGroup Skyranger = new(ImageTables.Skyranger, ImageGroups.Skyranger);
	public static readonly ImageGroup Lightning = new(ImageTables.Lightning, ImageGroups.Lightning);
	public static readonly ImageGroup Avenger = new(ImageTables.Avenger, ImageGroups.Avenger);

	public static readonly ImageGroup XcomBase = new(ImageTables.XcomBase, ImageGroups.XcomBase);
	public static readonly ImageGroup XcomFacilities = new(
		ImageTables.XcomFacilities,
		ImageGroups.XcomFacilities
	);

	public static readonly ImageGroup AlienBase = new(ImageTables.AlienBase, ImageGroups.AlienBase);
	public static readonly ImageGroup Brain = new(ImageTables.Brain, ImageGroups.Brain);
	public static readonly ImageGroup UfoSmallScout = new(
		ImageTables.UfoSmallScout,
		ImageGroups.UfoSmallScout
	);
	public static readonly ImageGroup UfoExterior = new(
		ImageTables.UfoExterior,
		ImageGroups.UfoExterior
	);
	public static readonly ImageGroup UfoBits = new(ImageTables.UfoBits, ImageGroups.UfoBits);
	public static readonly ImageGroup UfoComponents = new(
		ImageTables.UfoComponents,
		ImageGroups.UfoComponents
	);
	public static readonly ImageGroup UfoEquipment = new(
		ImageTables.UfoEquipment,
		ImageGroups.UfoEquipment
	);
	public static readonly ImageGroup UfoExaminationRoom = new(
		ImageTables.UfoExaminationRoom,
		ImageGroups.UfoExaminationRoom
	);
	public static readonly ImageGroup UfoOperatingTable = new(
		ImageTables.UfoOperatingTable,
		ImageGroups.UfoOperatingTable
	);

	public static readonly ImageGroup City = new(ImageTables.City, ImageGroups.City);
	public static readonly ImageGroup CityBits = new(ImageTables.CityBits, ImageGroups.CityBits);
	public static readonly ImageGroup Roads = new(ImageTables.Roads, ImageGroups.Roads);
	public static readonly ImageGroup Furniture = new(ImageTables.Furniture, ImageGroups.Furniture);

	public static readonly ImageGroup Barn = new(ImageTables.Barn, ImageGroups.Barn);
	public static readonly ImageGroup Cultivation = new(
		ImageTables.Cultivation,
		ImageGroups.Cultivation
	);
	public static readonly ImageGroup Desert = new(ImageTables.Desert, ImageGroups.Desert);
	public static readonly ImageGroup Forest = new(ImageTables.Forest, ImageGroups.Forest);
	public static readonly ImageGroup Jungle = new(ImageTables.Jungle, ImageGroups.Jungle);
	public static readonly ImageGroup Mountain = new(ImageTables.Mountain, ImageGroups.Mountain);
	public static readonly ImageGroup Polar = new(ImageTables.Polar, ImageGroups.Polar);

	public static readonly ImageGroup Mars = new(ImageTables.Mars, ImageGroups.Mars);

	public static readonly ImageGroup SoldierCoveralls = new(
		UnitImageTables.SoldierCoveralls,
		UnitImageGroups.SoldierCoveralls
	);
	public static readonly ImageGroup SoldierPersonalArmor = new(
		UnitImageTables.SoldierPersonalArmor,
		UnitImageGroups.SoldierPersonalArmor
	);
	public static readonly ImageGroup SoldierPowerSuit = new(
		UnitImageTables.SoldierPowerSuit,
		UnitImageGroups.SoldierPowerSuit
	);
	public static readonly ImageGroup Tanks = new(UnitImageTables.Tanks, UnitImageGroups.Tanks);
	public static readonly ImageGroup CivilianMale = new(
		UnitImageTables.CivilianMale,
		UnitImageGroups.CivilianMale
	);
	public static readonly ImageGroup CivilianFemale = new(
		UnitImageTables.CivilianFemale,
		UnitImageGroups.CivilianFemale
	);

	public static readonly ImageGroup Sectoid = new(
		UnitImageTables.Sectoid,
		UnitImageGroups.Sectoid
	);
	public static readonly ImageGroup Snakeman = new(
		UnitImageTables.Snakeman,
		UnitImageGroups.Snakeman
	);
	public static readonly ImageGroup Muton = new(UnitImageTables.Muton, UnitImageGroups.Muton);
	public static readonly ImageGroup Floater = new(
		UnitImageTables.Floater,
		UnitImageGroups.Floater
	);
	public static readonly ImageGroup Ethereal = new(
		UnitImageTables.Ethereal,
		UnitImageGroups.Ethereal
	);
	public static readonly ImageGroup Celatid = new(
		UnitImageTables.Celatid,
		UnitImageGroups.Celatid
	);
	public static readonly ImageGroup Silacoid = new(
		UnitImageTables.Silacoid,
		UnitImageGroups.Silacoid
	);
	public static readonly ImageGroup Chryssalid = new(
		UnitImageTables.Chryssalid,
		UnitImageGroups.Chryssalid
	);
	public static readonly ImageGroup Reaper = new(UnitImageTables.Reaper, UnitImageGroups.Reaper);
	public static readonly ImageGroup Cyberdisc = new(
		UnitImageTables.Cyberdisc,
		UnitImageGroups.Cyberdisc
	);
	public static readonly ImageGroup Sectopod = new(
		UnitImageTables.Sectopod,
		UnitImageGroups.Sectopod
	);
	public static readonly ImageGroup Zombie = new(UnitImageTables.Zombie, UnitImageGroups.Zombie);

	public static readonly ImageGroup Ground = new(UnitImageTables.Ground, UnitImageGroups.Ground);
	public static readonly ImageGroup Hand = new(UnitImageTables.Hand, UnitImageGroups.Hand);

	public static readonly ImageGroup Cursors = new(
		BattlescapeImageTables.Cursors,
		BattlescapeImageGroups.Cursors
	);
	public static readonly ImageGroup MeleeHit = new(
		BattlescapeImageTables.MeleeHit,
		BattlescapeImageGroups.MeleeHit
	);
	public static readonly ImageGroup MotionScannerIcons = new(
		BattlescapeImages.MotionScannerIcons,
		16,
		16
	);
	public static readonly ImageGroup MediKitBodyParts = new(
		BattlescapeImages.MediKitBodyParts,
		52,
		58
	);
	public static readonly ImageGroup SpecialActionIcons = new(
		BattlescapeImages.SpecialActionIcons,
		32,
		24
	);
}
