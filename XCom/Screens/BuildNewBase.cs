using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Modals;
using XCom.World;

namespace XCom.Screens
{
	public class BuildNewBase : Screen
	{
		public BuildNewBase()
		{
			AddControl(new Background(Backgrounds.Geoscape, 0));
			var worldView = new WorldView();
			AddControl(worldView);
			AddControl(new WorldControls(worldView));

			AddControl(new Border(0, 0, 256, 28, ColorScheme.Green, Backgrounds.Title, 0));
			AddControl(new Label(10, 8, "SELECT SITE FOR NEW BASE", Font.Normal, ColorScheme.Green));
			if (GameState.Current.Data.Bases.Count > 0)
				AddControl(new Button(8, 186, 53, 12, "CANCEL", ColorScheme.Green, Font.Normal, OnCancel));

			AddControl(new TimeDisplay());

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
