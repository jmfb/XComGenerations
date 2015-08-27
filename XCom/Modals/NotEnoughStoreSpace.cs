using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class NotEnoughStoreSpace : Screen
	{
		public NotEnoughStoreSpace(ColorScheme colorScheme, byte[] background, int palette = 6)
		{
			AddControl(new Border(20, 32, 256, 160, colorScheme, background, palette));
			AddControl(new Label(75, Label.Center, "NOT ENOUGH STORE SPACE!", Font.Large, colorScheme));
			AddControl(new Label(90, Label.Center, "Build a new store facility or transfer existing", Font.Normal, colorScheme));
			AddControl(new Label(100, Label.Center, "stores to other bases.", Font.Normal, colorScheme));
			AddControl(new Button(154, 100, 120, 18, "OK", colorScheme, Font.Normal, EndModal));
		}
	}
}
