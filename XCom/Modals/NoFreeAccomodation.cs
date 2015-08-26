using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class NoFreeAccomodation : Screen
	{
		public NoFreeAccomodation()
		{
			AddControl(new Border(20, 32, 256, 160, ColorScheme.LightMagenta, Backgrounds.Funds, 6));
			AddControl(new Label(75, Label.Center, "NO FREE ACCOMODATOIN!", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(90, Label.Center, "The destination base does not have enough space", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(100, Label.Center, "in living quarters.", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Button(154, 100, 120, 18, "OK", ColorScheme.LightMagenta, Font.Normal, EndModal));
		}
	}
}
