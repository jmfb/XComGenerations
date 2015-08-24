using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class NotEnoughLivingSpace : Screen
	{
		public NotEnoughLivingSpace(ColorScheme colorScheme, byte[] background)
		{
			AddControl(new Border(20, 32, 256, 160, colorScheme, background, 6));
			AddControl(new Label(75, Label.Center, "NOT ENOUGH LIVING SPACE!", Font.Large, colorScheme));
			AddControl(new Label(90, Label.Center, "Build new living quarters or transfer personnel to", Font.Normal, colorScheme));
			AddControl(new Label(100, Label.Center, "other bases.", Font.Normal, colorScheme));
			AddControl(new Button(154, 100, 120, 18, "OK", colorScheme, Font.Normal, EndModal));
		}
	}
}
