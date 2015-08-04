using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class NotEnoughMoney : Screen
	{
		public NotEnoughMoney(ColorScheme colorScheme, byte[] background)
		{
			AddControl(new Border(20, 32, 256, 160, colorScheme, background, 6));
			AddControl(new Label(82, Label.Center, "NOT ENOUGH MONEY!", Font.Large, colorScheme));
			AddControl(new Button(154, 100, 120, 18, "OK", colorScheme, Font.Normal, EndModal));
		}
	}
}
