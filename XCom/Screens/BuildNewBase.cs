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
			var worldView = new WorldView(OnChooseLocation);
			AddControl(worldView);
			AddControl(new WorldControls(worldView));

			AddControl(new Border(0, 0, 256, 28, ColorScheme.Green, Backgrounds.Title, 0));
			AddControl(new Label(10, 8, "SELECT SITE FOR NEW BASE", Font.Normal, ColorScheme.Green));
			if (GameState.Current.Data.Bases.Count > 0)
				AddControl(new Button(8, 186, 53, 12, "CANCEL", ColorScheme.Green, Font.Normal, OnCancel));

			AddControl(new TimeDisplay());
		}

		private void OnChooseLocation(Location location)
		{
			var mapLocation = Map.Instance[location];
			if (mapLocation.TerrainType != null)
				new NewBaseLocation(mapLocation).DoModal(this);
		}

		private static void OnCancel()
		{
			GameState.Current.SetScreen(new Base());
		}
	}
}
