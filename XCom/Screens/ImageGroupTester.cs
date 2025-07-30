using XCom.Battlescape.Tiles;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens;

public class ImageGroupTester : Screen
{
	private int offset1;
	private int offset2;
	private readonly byte[][] images1 = ImageGroup.Reaper.Images;
	private readonly byte[][] images2 = ImageGroup.Sectopod.Images;

	const int ImageWidth = 32;
	const int ImageHeight = 48;
	const int ImagesPerRow = GraphicsBuffer.GameWidth / ImageWidth;

	public ImageGroupTester()
	{
		AddControl(
			new Button(
				180,
				256,
				64,
				20,
				"Main Menu",
				ColorScheme.Aqua,
				Font.Normal,
				OnBackToMainMenu
			)
		);
		AddControl(new UpDown(170, 0, ColorScheme.Aqua, OnNextOffset1, OnPrevOffset1));
		AddControl(new UpDown(180, 0, ColorScheme.Aqua, OnNextOffset2, OnPrevOffset2));
	}

	private static void OnBackToMainMenu()
	{
		GameState.Current.SetScreen(new MainMenu());
	}

	private static int AdjustOffset(int currentOffset, int count, int delta)
	{
		var offset = currentOffset + delta;
		if (offset < 0)
			offset = 0;
		if (offset >= count)
			offset = count - 1;
		return offset;
	}

	private void OnNextOffset1() => offset1 = AdjustOffset(offset1, images1.Length, 1);

	private void OnPrevOffset1() => offset1 = AdjustOffset(offset1, images1.Length, -1);

	private void OnNextOffset2() => offset2 = AdjustOffset(offset2, images2.Length, 1);

	private void OnPrevOffset2() => offset2 = AdjustOffset(offset2, images2.Length, -1);

	public override void Render(GraphicsBuffer buffer)
	{
		base.Render(buffer);

		for (var index = offset1; index < images1.Length; ++index)
		{
			var position = index - offset1;
			var row = position / ImagesPerRow;
			if (row > 0)
				break;
			var column = position % ImagesPerRow;
			var top = row * ImageHeight;
			var left = column * ImageWidth;
			buffer.DrawItem(top, left, images1[index]);
		}

		for (var index = offset2; index < images2.Length; ++index)
		{
			var position = index - offset2;
			var row = position / ImagesPerRow;
			if (row > 0)
				break;
			var column = position % ImagesPerRow;
			var top = (row + 1) * ImageHeight;
			var left = column * ImageWidth;
			buffer.DrawItem(top, left, images2[index]);
		}

		Font.Normal.DrawString(
			buffer,
			170,
			32,
			$"{offset1} of {images1.Length}",
			ColorScheme.White
		);
		Font.Normal.DrawString(
			buffer,
			180,
			32,
			$"{offset2} of {images2.Length}",
			ColorScheme.White
		);
	}
}
