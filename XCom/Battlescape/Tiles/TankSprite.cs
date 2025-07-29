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

	private TankSprite(ImageGroup imageGroup, Direction direction, int topLeftIndex, int topRightIndex, int bottomLeftIndex, int bottomRightIndex, int turretIndex, int animateRightIndex, int animateLeftIndex, int animateCenterIndex)
	{
		this.direction = direction;
		topLeft = imageGroup.Images[topLeftIndex];
		topRight = imageGroup.Images[topRightIndex];
		bottomLeft = imageGroup.Images[bottomLeftIndex];
		bottomRight = imageGroup.Images[bottomRightIndex];
		turret = turretIndex == -1 ? null : imageGroup.Images[turretIndex];
		animateRight = animateRightIndex == -1 ? null : imageGroup.Images.Skip(animateRightIndex).Take(FrameCount).ToArray();
		animateLeft = animateLeftIndex == -1 ? null : imageGroup.Images.Skip(animateLeftIndex).Take(FrameCount).ToArray();
		animateCenter = animateCenterIndex == -1 ? null : imageGroup.Images.Skip(animateCenterIndex).Take(FrameCount).ToArray();
	}

	public void Animate(GraphicsBuffer buffer, int topRow, int leftColumn, int frame)
	{
		DrawSprite(buffer, topRow, leftColumn, frame);
	}

	public int FrameCount => 8;

	private void DrawSprite(
		GraphicsBuffer buffer,
		int topRow,
		int leftColumn,
		int frame
	)
	{
		buffer.DrawItem(topRow, leftColumn, topLeft);
		buffer.DrawItem(topRow, leftColumn + 16, topRight);
		buffer.DrawItem(topRow, leftColumn - 16, bottomLeft);
		buffer.DrawItem(topRow + 8, leftColumn, bottomRight);
		if (turret != null)
			buffer.DrawItem(topRow, leftColumn, turret);
		if (animateRight != null && animateLeft != null && animateCenter != null)
		{
			buffer.DrawItem(topRow, leftColumn + 16, animateRight[frame]);
			buffer.DrawItem(topRow, leftColumn - 16, animateLeft[frame]);
			buffer.DrawItem(topRow + 8, leftColumn, animateCenter[frame]);
		}
	}

	private static Dictionary<Direction, TankSprite> LoadSprites(ImageGroup imageGroup, int topLeftIndex,
		int topRightIndex,
		int bottomLeftIndex,
		int bottomRightIndex,
		int turretIndex,
		int animateRightIndex,
		int animateLeftIndex,
		int animateCenterIndex
	) => Enum.GetValues<Direction>().Select((direction, index) => new TankSprite(imageGroup, direction, topLeftIndex + index, 		topRightIndex + index,
		bottomLeftIndex + index,
		bottomRightIndex + index,
		turretIndex + index,
		animateRightIndex,
		animateLeftIndex,
		animateCenterIndex)).ToDictionary(sprite => sprite.direction, sprite => sprite);

	public static readonly Dictionary<Direction, TankSprite> TankCannon =
		LoadSprites(ImageGroup.Tanks, 0, 8, 16, 24, 64, -1, -1, -1);
	public static readonly Dictionary<Direction, TankSprite> TankRocketLauncher =
		LoadSprites(ImageGroup.Tanks, 0, 8, 16, 24, 72, -1, -1, -1);
	public static readonly Dictionary<Direction, TankSprite> TankLaserCannon =
		LoadSprites(ImageGroup.Tanks, 0, 8, 16, 24, 80, -1, -1, -1);
	public static readonly Dictionary<Direction, TankSprite> HovertankPlasma =
		LoadSprites(ImageGroup.Tanks, 32, 40, 48, 56, 88, 104, 112, 120);
	public static readonly Dictionary<Direction, TankSprite> HovertankLauncher =
		LoadSprites(ImageGroup.Tanks, 32, 40, 48, 56, 96, 104, 112, 120);
	public static readonly Dictionary<Direction, TankSprite> Cyberdisk =
		LoadSprites(ImageGroup.Cyberdisc, 0, 8, 16, 24, -1, 32, 40, 48);

	public static readonly Dictionary<Direction, TankSprite>[] All = [
		TankCannon,
		TankRocketLauncher,
		TankLaserCannon,
		HovertankPlasma,
		HovertankLauncher,
		Cyberdisk
	];
}
