using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class NoAlienContainment : Screen
	{
		public NoAlienContainment()
		{
			AddControl(new Border(20, 32, 256, 160, ColorScheme.LightMagenta, Backgrounds.Funds, 6));
			AddControl(new Label(65, Label.Center, "NO ALIEN CONTAINMENT FOR", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(82, Label.Center, "TRANSFER!", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(98, Label.Center, "Live aliens need an alien containment facility in", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(106, Label.Center, "order to survive.", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Button(154, 100, 120, 18, "OK", ColorScheme.LightMagenta, Font.Normal, EndModal));
		}
	}
}
