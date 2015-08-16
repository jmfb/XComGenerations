using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class CannotBuildHere : Screen
	{
		public CannotBuildHere()
		{
			AddControl(new Border(20, 32, 256, 160, ColorScheme.LightMagenta, Backgrounds.Title, 12));
			AddControl(new Label(78, Label.Center, "CANNOT BUILD HERE!", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(94, Label.Center, "You must build next to an existing base facility.", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Button(154, 100, 120, 16, "OK", ColorScheme.LightMagenta, Font.Normal, EndModal));
		}
	}
}
