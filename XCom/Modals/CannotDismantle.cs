using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class CannotDismantle : Screen
	{
		public CannotDismantle()
		{
			AddControl(new Border(20, 32, 256, 160, ColorScheme.LightMagenta, Backgrounds.Funds, 6));
			AddControl(new Label(70, Label.Center, "CANNOT DISMANTLE", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(86, Label.Center, "FACILITY!", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(102, Label.Center, "All base facilities must be linked to the access lift.", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Button(154, 100, 120, 18, "OK", ColorScheme.LightMagenta, Font.Normal, EndModal));
		}
	}
}
