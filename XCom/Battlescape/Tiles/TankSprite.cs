using XCom.Graphics;

namespace XCom.Battlescape.Tiles;

public class TankSprite
{
	private readonly Direction direction;
	private readonly byte[] topLeft;
	private readonly byte[] topRight;
	private readonly byte[] bottomLeft;
	private readonly byte[] bottomRight;
	private readonly byte[] turret;
	private readonly byte[][] animateRight;
	private readonly byte[][] animateLeft;
	private readonly byte[][] animateCenter;
	private readonly int turretTopOffset;
	private readonly int turretLeftOffset;

	private static readonly Dictionary<
		Direction,
		(int TopOffset, int LeftOffset)
	> HoverTankTurretOffsets = new()
	{
		[Direction.North] = (-1, -1),
		[Direction.NorthEast] = (-2, -7),
		[Direction.East] = (-6, -6),
		[Direction.SouthEast] = (-6, 0),
		[Direction.South] = (-6, 6),
		[Direction.SouthWest] = (-2, 7),
		[Direction.West] = (-1, 1),
		[Direction.NorthWest] = (-1, 0),
	};

	private TankSprite(
		ImageGroup imageGroup,
		bool isHoverTank,
		Direction direction,
		int topLeftIndex,
		int topRightIndex,
		int bottomLeftIndex,
		int bottomRightIndex,
		int turretIndex,
		int animateRightIndex,
		int animateLeftIndex,
		int animateCenterIndex
	)
	{
		this.direction = direction;
		topLeft = imageGroup.Images[topLeftIndex];
		topRight = imageGroup.Images[topRightIndex];
		bottomLeft = imageGroup.Images[bottomLeftIndex];
		bottomRight = imageGroup.Images[bottomRightIndex];
		turret = turretIndex == -1 ? null : imageGroup.Images[turretIndex];
		animateRight =
			animateRightIndex == -1
				? null
				: imageGroup.Images.Skip(animateRightIndex).Take(FrameCount).ToArray();
		animateLeft =
			animateLeftIndex == -1
				? null
				: imageGroup.Images.Skip(animateLeftIndex).Take(FrameCount).ToArray();
		animateCenter =
			animateCenterIndex == -1
				? null
				: imageGroup.Images.Skip(animateCenterIndex).Take(FrameCount).ToArray();

		if (isHoverTank)
			(turretTopOffset, turretLeftOffset) = HoverTankTurretOffsets[direction];
	}

	public void Animate(GraphicsBuffer buffer, int topRow, int leftColumn, int frame)
	{
		DrawSprite(buffer, topRow, leftColumn, frame);
	}

	public int FrameCount => 8;

	private void DrawSprite(GraphicsBuffer buffer, int topRow, int leftColumn, int frame)
	{
		if (animateRight != null && animateLeft != null && animateCenter != null)
		{
			buffer.DrawItem(topRow + 8, leftColumn + 16, animateRight[frame]);
			buffer.DrawItem(topRow + 8, leftColumn - 16, animateLeft[frame]);
			buffer.DrawItem(topRow + 16, leftColumn, animateCenter[frame]);
		}
		buffer.DrawItem(topRow, leftColumn, topLeft);
		buffer.DrawItem(topRow + 8, leftColumn + 16, topRight);
		buffer.DrawItem(topRow + 8, leftColumn - 16, bottomLeft);
		buffer.DrawItem(topRow + 16, leftColumn, bottomRight);
		if (turret != null)
			buffer.DrawItem(topRow + 12 + turretTopOffset, leftColumn + turretLeftOffset, turret);
	}

	private static Dictionary<Direction, TankSprite> LoadSprites(
		ImageGroup imageGroup,
		bool isHoverTank,
		int topLeftIndex,
		int topRightIndex,
		int bottomLeftIndex,
		int bottomRightIndex,
		int turretIndex,
		int animateRightIndex,
		int animateLeftIndex,
		int animateCenterIndex
	) =>
		Enum.GetValues<Direction>()
			.Select(
				(direction, index) =>
					new TankSprite(
						imageGroup,
						isHoverTank,
						direction,
						topLeftIndex + index,
						topRightIndex + index,
						bottomLeftIndex + index,
						bottomRightIndex + index,
						turretIndex == -1 ? -1 : turretIndex + index,
						animateRightIndex,
						animateLeftIndex,
						animateCenterIndex
					)
			)
			.ToDictionary(sprite => sprite.direction, sprite => sprite);

	public static readonly Dictionary<Direction, TankSprite> TankCannon = LoadSprites(
		ImageGroup.Tanks,
		false,
		0,
		8,
		16,
		24,
		64,
		-1,
		-1,
		-1
	);
	public static readonly Dictionary<Direction, TankSprite> TankRocketLauncher = LoadSprites(
		ImageGroup.Tanks,
		false,
		0,
		8,
		16,
		24,
		72,
		-1,
		-1,
		-1
	);
	public static readonly Dictionary<Direction, TankSprite> TankLaserCannon = LoadSprites(
		ImageGroup.Tanks,
		false,
		0,
		8,
		16,
		24,
		80,
		-1,
		-1,
		-1
	);
	public static readonly Dictionary<Direction, TankSprite> HovertankPlasma = LoadSprites(
		ImageGroup.Tanks,
		true,
		32,
		40,
		48,
		56,
		88,
		104,
		112,
		120
	);
	public static readonly Dictionary<Direction, TankSprite> HovertankLauncher = LoadSprites(
		ImageGroup.Tanks,
		true,
		32,
		40,
		48,
		56,
		96,
		104,
		112,
		120
	);
	public static readonly Dictionary<Direction, TankSprite> Cyberdisk = LoadSprites(
		ImageGroup.Cyberdisc,
		false,
		0,
		8,
		16,
		24,
		-1,
		32,
		40,
		48
	);

	public static readonly Dictionary<Direction, TankSprite>[] All =
	[
		TankCannon,
		TankRocketLauncher,
		TankLaserCannon,
		HovertankPlasma,
		HovertankLauncher,
		Cyberdisk,
	];
}
