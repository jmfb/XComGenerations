using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Modals;

namespace XCom.Screens
{
	public class BuildNewBase : Screen
	{
		public BuildNewBase()
		{
			AddControl(new Border(0, 0, 256, 28, ColorScheme.Green, Backgrounds.Title, 0));
			AddControl(new Label(10, 8, "SELECT SITE FOR NEW BASE", Font.Normal, ColorScheme.Green));
			if (GameState.Current.Data.Bases.Count > 0)
				AddControl(new Button(8, 186, 53, 12, "CANCEL", ColorScheme.Green, Font.Normal, OnCancel));

			AddControl(new Button(0, 257, 63, 11, "INTERCEPT", ColorScheme.Blue, Font.Small, () => {}));
			AddControl(new Button(12, 257, 63, 11, "BASES", ColorScheme.Blue, Font.Small, () => {}));
			AddControl(new Button(24, 257, 63, 11, "GRAPHS", ColorScheme.Blue, Font.Small, () => {}));
			AddControl(new Button(36, 257, 63, 11, "UFOPAEDIA", ColorScheme.Blue, Font.Small, () => {}));
			AddControl(new Button(48, 257, 63, 11, "OPTIONS", ColorScheme.Blue, Font.Small, () => {}));
			AddControl(new Button(60, 257, 63, 11, "FUNDING", ColorScheme.Blue, Font.Small, () => {}));

			AddControl(new TimeDisplay());
			AddControl(new GameSpeed());

			//TODO: replace this with real geoscape location selection
			AddControl(new Button(100, 88, 80, 14, "Press Me", ColorScheme.Green, Font.Normal, OnChooseLocation));
		}

		private void OnChooseLocation()
		{
			//TODO: get location from geoscape click, get cost from lookup
			new NewBaseLocation("Central Asia", 500000).DoModal(this);
		}

		private static void OnCancel()
		{
			GameState.Current.SetScreen(new Base());
		}
	}
}
