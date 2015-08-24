using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class NoFreeHangars : Screen
	{
		public NoFreeHangars(ColorScheme colorScheme, byte[] background)
		{
			AddControl(new Border(20, 32, 256, 160, colorScheme, background, 6));
			AddControl(new Label(58, Label.Center, "NO FREE HANGARS FOR", Font.Large, colorScheme));
			AddControl(new Label(74, Label.Center, "PURCHASE!", Font.Large, colorScheme));
			AddControl(new Label(90, Label.Center, "Each craft assigned to a base, transferred to a", Font.Normal, colorScheme));
			AddControl(new Label(100, Label.Center, "base, purchased or constructed uses one hangar.", Font.Normal, colorScheme));
			AddControl(new Label(110, Label.Center, "Build a new hangar or transfer a craft to another", Font.Normal, colorScheme));
			AddControl(new Label(120, Label.Center, "base.", Font.Normal, colorScheme));
			AddControl(new Button(154, 100, 120, 18, "OK", colorScheme, Font.Normal, EndModal));
		}
	}
}
