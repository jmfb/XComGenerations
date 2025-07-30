using XCom.Graphics;

namespace XCom.Battlescape.Tiles;

public class LargeSprite
{
	private readonly Direction direction;
	private readonly byte[] topLeft;
	private readonly byte[] topRight;
	private readonly byte[] bottomLeft;
	private readonly byte[] bottomRight;
	private readonly byte[][] animateTopLeft;
	private readonly byte[][] animateTopRight;
	private readonly byte[][] animateBottomLeft;
	private readonly byte[][] animateBottomRight;

	private LargeSprite(
		ImageGroup imageGroup,
		Direction direction,
		int topLeftIndex,
		int topRightIndex,
		int bottomLeftIndex,
		int bottomRightIndex,
		int animateTopLeftIndex,
		int animateTopRightIndex,
		int animateBottomLeftIndex,
		int animateBottomRightIndex
	)
	{
		this.direction = direction;
		topLeft = imageGroup.Images[topLeftIndex];
		topRight = imageGroup.Images[topRightIndex];
		bottomLeft = imageGroup.Images[bottomLeftIndex];
		bottomRight = imageGroup.Images[bottomRightIndex];
		animateTopLeft = imageGroup.Images.Skip(animateTopLeftIndex).Take(FrameCount).ToArray();
		animateTopRight = imageGroup.Images.Skip(animateTopRightIndex).Take(FrameCount).ToArray();
		animateBottomLeft = imageGroup
			.Images.Skip(animateBottomLeftIndex)
			.Take(FrameCount)
			.ToArray();
		animateBottomRight = imageGroup
			.Images.Skip(animateBottomRightIndex)
			.Take(FrameCount)
			.ToArray();
	}

	public void Render(GraphicsBuffer buffer, int topRow, int leftColumn)
	{
		DrawSprite(buffer, topRow, leftColumn, false, 0);
	}

	public void Animate(GraphicsBuffer buffer, int topRow, int leftColumn, int frame)
	{
		DrawSprite(buffer, topRow, leftColumn, true, frame);
	}

	public int FrameCount => 4;

	private void DrawSprite(
		GraphicsBuffer buffer,
		int topRow,
		int leftColumn,
		bool animating,
		int frame
	)
	{
		var topLeftFrame = animating ? animateTopLeft[frame] : topLeft;
		var topRightFrame = animating ? animateTopRight[frame] : topRight;
		var bottomLeftFrame = animating ? animateBottomLeft[frame] : bottomLeft;
		var bottomRightFrame = animating ? animateBottomRight[frame] : bottomRight;
		buffer.DrawItem(topRow, leftColumn, topLeftFrame);
		buffer.DrawItem(topRow + 8, leftColumn + 16, topRightFrame);
		buffer.DrawItem(topRow + 8, leftColumn - 16, bottomLeftFrame);
		buffer.DrawItem(topRow + 16, leftColumn, bottomRightFrame);
	}

	private static Dictionary<Direction, LargeSprite> LoadSprites(ImageGroup imageGroup) =>
		Enum.GetValues<Direction>()
			.Select(
				(direction, index) =>
					new LargeSprite(
						imageGroup,
						direction,
						0 + index,
						8 + index,
						16 + index,
						24 + index,
						32 + index * 16,
						36 + index * 16,
						40 + index * 16,
						44 + index * 16
					)
			)
			.ToDictionary(sprite => sprite.direction, sprite => sprite);

	public static readonly Dictionary<Direction, LargeSprite> Reaper = LoadSprites(
		ImageGroup.Reaper
	);
	public static readonly Dictionary<Direction, LargeSprite> Sectopod = LoadSprites(
		ImageGroup.Sectopod
	);
}
