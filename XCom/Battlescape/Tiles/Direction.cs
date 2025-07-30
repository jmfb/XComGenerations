namespace XCom.Battlescape.Tiles;

public enum Direction
{
	North,
	NorthEast,
	East,
	SouthEast,
	South,
	SouthWest,
	West,
	NorthWest,
}

public static class DirectionExtensions
{
	public static DirectionMetadata Metadata(this Direction direction) => metadata[direction];

	private static readonly DirectionMetadata north = new()
	{
		DrawOrder =
		[
			SpritePart.LeftArm,
			SpritePart.OneHandedWeapon,
			SpritePart.TwoHandedWeapon,
			SpritePart.Head,
			SpritePart.Legs,
			SpritePart.RightArm,
		],
	};

	private static readonly DirectionMetadata northEast = new()
	{
		DrawOrder =
		[
			SpritePart.LeftArm,
			SpritePart.TwoHandedWeapon,
			SpritePart.Head,
			SpritePart.Legs,
			SpritePart.RightArm,
			SpritePart.OneHandedWeapon,
		],
	};

	private static readonly DirectionMetadata east = new()
	{
		DrawOrder =
		[
			SpritePart.LeftArm,
			SpritePart.Head,
			SpritePart.Legs,
			SpritePart.TwoHandedWeapon,
			SpritePart.RightArm,
			SpritePart.OneHandedWeapon,
		],
	};

	private static readonly DirectionMetadata southEast = new()
	{
		DrawOrder =
		[
			SpritePart.Head,
			SpritePart.Legs,
			SpritePart.LeftArm,
			SpritePart.TwoHandedWeapon,
			SpritePart.RightArm,
			SpritePart.OneHandedWeapon,
		],
	};

	private static readonly DirectionMetadata south = new()
	{
		DrawOrder =
		[
			SpritePart.RightArm,
			SpritePart.Head,
			SpritePart.Legs,
			SpritePart.LeftArm,
			SpritePart.OneHandedWeapon,
			SpritePart.TwoHandedWeapon,
		],
	};

	private static readonly DirectionMetadata southWest = new()
	{
		DrawOrder =
		[
			SpritePart.RightArm,
			SpritePart.Head,
			SpritePart.Legs,
			SpritePart.OneHandedWeapon,
			SpritePart.TwoHandedWeapon,
			SpritePart.LeftArm,
		],
	};

	private static readonly DirectionMetadata west = new()
	{
		DrawOrder =
		[
			SpritePart.RightArm,
			SpritePart.OneHandedWeapon,
			SpritePart.TwoHandedWeapon,
			SpritePart.Head,
			SpritePart.Legs,
			SpritePart.LeftArm,
		],
	};

	private static readonly DirectionMetadata northWest = new()
	{
		DrawOrder =
		[
			SpritePart.RightArm,
			SpritePart.OneHandedWeapon,
			SpritePart.TwoHandedWeapon,
			SpritePart.LeftArm,
			SpritePart.Head,
			SpritePart.Legs,
		],
	};

	private static readonly Dictionary<Direction, DirectionMetadata> metadata = new()
	{
		{ Direction.North, north },
		{ Direction.NorthEast, northEast },
		{ Direction.East, east },
		{ Direction.SouthEast, southEast },
		{ Direction.South, south },
		{ Direction.SouthWest, southWest },
		{ Direction.West, west },
		{ Direction.NorthWest, northWest },
	};
}
