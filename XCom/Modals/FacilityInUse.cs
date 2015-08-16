using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class FacilityInUse : Screen
	{
		public FacilityInUse()
		{
			AddControl(new Border(20, 32, 256, 160, ColorScheme.LightMagenta, Backgrounds.Funds, 6));
			AddControl(new Label(82, Label.Center, "FACILITY IN USE", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Button(154, 100, 120, 18, "OK", ColorScheme.LightMagenta, Font.Normal, EndModal));
		}
	}
}
