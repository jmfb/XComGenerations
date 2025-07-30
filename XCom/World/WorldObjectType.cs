namespace XCom.World;

public enum WorldObjectType
{
	AlienBase,
	XcomBase,
	TerrorSite,
	CrashSite,
	LandingSite,
	Interceptor,
	Waypoint,
	Ufo,
}

public static class WorldObjectTypeExtensions
{
	public static WorldObjectMetadata Metadata(this WorldObjectType worldObjectType) =>
		metadata[worldObjectType];

	private static readonly WorldObjectMetadata alienBase = new()
	{
		Name = "Alien Base",
		PaletteIndex = 1,
		Mask =
		[
			[true, true, true],
			[true, false, true],
			[true, true, true],
		],
	};

	private static readonly WorldObjectMetadata xcomBase = new()
	{
		Name = "XCom Base",
		PaletteIndex = 9,
		Mask =
		[
			[true, true, true],
			[true, false, true],
			[true, true, true],
		],
	};

	private static readonly WorldObjectMetadata terrorSite = new()
	{
		Name = "Terror Site",
		PaletteIndex = 1,
		Mask =
		[
			[false, true, false],
			[true, true, true],
			[false, true, false],
		],
	};

	private static readonly WorldObjectMetadata crashSite = new()
	{
		Name = "Crash Site",
		PaletteIndex = 5,
		Mask =
		[
			[true, false, true],
			[false, true, false],
			[true, false, true],
		],
	};

	private static readonly WorldObjectMetadata landingSite = new()
	{
		Name = "Landing Site",
		PaletteIndex = 7,
		Mask =
		[
			[true, false, true],
			[false, true, false],
			[true, false, true],
		],
	};

	private static readonly WorldObjectMetadata interceptor = new()
	{
		Name = "Interceptor",
		PaletteIndex = 11,
		Mask =
		[
			[false, true, false],
			[true, false, true],
			[false, true, false],
		],
	};

	private static readonly WorldObjectMetadata waypoint = new()
	{
		Name = "Waypoint",
		PaletteIndex = 3,
		Mask =
		[
			[true, false, true],
			[false, true, false],
			[true, false, true],
		],
	};

	private static readonly WorldObjectMetadata ufo = new()
	{
		Name = "UFO",
		PaletteIndex = 13,
		Mask =
		[
			[false, true, false],
			[true, true, true],
			[false, true, false],
		],
	};

	private static readonly Dictionary<WorldObjectType, WorldObjectMetadata> metadata = new()
	{
		{ WorldObjectType.AlienBase, alienBase },
		{ WorldObjectType.XcomBase, xcomBase },
		{ WorldObjectType.TerrorSite, terrorSite },
		{ WorldObjectType.CrashSite, crashSite },
		{ WorldObjectType.LandingSite, landingSite },
		{ WorldObjectType.Interceptor, interceptor },
		{ WorldObjectType.Waypoint, waypoint },
		{ WorldObjectType.Ufo, ufo },
	};
}
