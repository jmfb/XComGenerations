using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class NoMoreEquipmentAllowed : Screen
	{
		public NoMoreEquipmentAllowed()
		{
			AddControl(new Border(20, 32, 256, 160, ColorScheme.LightMagenta, Backgrounds.Battle, 8));
			AddControl(new Label(66, Label.Center, "NO MORE EQUIPMENT", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(82, Label.Center, "ALLOWED ON BOARD!", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(98, Label.Center, "You are only allowed to take a maximum of 80 items", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(106, Label.Center, "of equipment on missions.", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Button(155, 100, 120, 16, "OK", ColorScheme.LightMagenta, Font.Normal, EndModal));
		}
	}
}
