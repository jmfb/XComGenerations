using XCom.Battlescape.Tiles;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens;

public class ImageGroupTester : Screen
{
	private readonly ImageGroup imageGroup = ImageGroup.InterceptionOtherIcons;
	private int imageIndex;
	private int paletteIndex = 14;

	public ImageGroupTester()
	{
		AddControl(
			new Label(10, Label.Center, "Image Group Tester", Font.Large, ColorScheme.Yellow)
		);
		AddControl(new Button(30, 0, 32, 20, "Prev", ColorScheme.Aqua, Font.Normal, OnPrevious));
		AddControl(new Button(30, 32, 32, 20, "Next", ColorScheme.Aqua, Font.Normal, OnNext));
		AddControl(
			new Button(60, 0, 32, 20, "Prev", ColorScheme.Yellow, Font.Normal, OnPreviousPalette)
		);
		AddControl(
			new Button(60, 32, 32, 20, "Next", ColorScheme.Yellow, Font.Normal, OnNextPalette)
		);
		AddControl(new Button(30, 64, 32, 20, "Close", ColorScheme.Aqua, Font.Normal, OnClose));
	}

	private void OnPrevious()
	{
		if (imageIndex > 0)
			--imageIndex;
	}

	private void OnNext()
	{
		if (imageIndex < imageGroup.Images.Length - 1)
			++imageIndex;
	}

	private void OnPreviousPalette()
	{
		if (paletteIndex > 0)
			--paletteIndex;
	}

	private void OnNextPalette()
	{
		if (paletteIndex < 14)
			++paletteIndex;
	}

	private void OnClose()
	{
		GameState.Current.SetScreen(new MainMenu());
	}

	public override void Render(GraphicsBuffer buffer)
	{
		buffer.DrawOverlay(XCom.Content.Overlays.Overlays.GraphButtons, paletteIndex);
		base.Render(buffer);

		const int top = 120;
		var left = 0;
		for (var index = imageIndex; index < imageGroup.Images.Length; ++index)
		{
			buffer.DrawItem(top, left, imageGroup.Images[index], 32, paletteIndex);
			left += 32;
			if (left > 320)
				break;
		}
		Font.Normal.DrawString(buffer, 50, 0, $"{imageIndex}", ColorScheme.White);
		Font.Normal.DrawString(buffer, 50, 100, $"Palette {paletteIndex}", ColorScheme.White);

		SelectedUnit.Render(112, 8, buffer);
	}
}
