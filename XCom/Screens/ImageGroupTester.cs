using XCom.Battlescape.Tiles;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens;

public class ImageGroupTester : Screen
{
	private readonly ImageGroup imageGroup = ImageGroup.SpecialActionIcons;
	private int imageIndex;

	public ImageGroupTester()
	{
		AddControl(
			new Label(10, Label.Center, "Image Group Tester", Font.Large, ColorScheme.Yellow)
		);
		AddControl(new Button(30, 0, 32, 20, "Prev", ColorScheme.Aqua, Font.Normal, OnPrevious));
		AddControl(new Button(30, 32, 32, 20, "Next", ColorScheme.Aqua, Font.Normal, OnNext));
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

	private void OnClose()
	{
		GameState.Current.SetScreen(new MainMenu());
	}

	public override void Render(GraphicsBuffer buffer)
	{
		base.Render(buffer);
		var top = 120;
		var left = 0;
		for (var index = imageIndex; index < imageGroup.Images.Length; ++index)
		{
			buffer.DrawMaskedImage(top, left, imageGroup.Images[index], 32, 24, 14);
			left += 32;
			if (left > 320)
				break;
		}
		Font.Normal.DrawString(buffer, 50, 0, $"{imageIndex}", ColorScheme.White);
	}
}
