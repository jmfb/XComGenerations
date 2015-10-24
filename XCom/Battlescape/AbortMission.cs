using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Battlescape
{
	public class AbortMission : Screen
	{
		public AbortMission()
		{
			AddControl(new Border(0, 0, 320, 144, ColorScheme.White, Backgrounds.Turn, 1));
			//TODO: determine number of units in/out of exit area
			AddControl(new Label(25, 60, "8 Units in Exit Area", Font.Large, ColorScheme.White));
			AddControl(new Label(50, 60, "0 Units outside Exit Area", Font.Large, ColorScheme.White));
			AddControl(new Label(75, Label.Center, "Abort Mission ?", Font.Large, ColorScheme.White));
			AddControl(new Button(110, 16, 120, 18, "OK", ColorScheme.White, Font.Normal, OnOk));
			AddControl(new Button(110, 185, 120, 18, "CANCEL", ColorScheme.White, Font.Normal, EndModal));
		}

		private static void OnOk()
		{
			//TODO: EndModal, abort mission
		}
	}
}
