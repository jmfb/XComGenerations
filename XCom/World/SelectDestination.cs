using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.World
{
	public class SelectDestination : Screen
	{
		private readonly Craft craft;

		public SelectDestination(Craft craft)
		{
			this.craft = craft;
			AddControl(new Background(Backgrounds.Geoscape, 0));
			var worldView = new WorldView(OnChooseDestination);
			AddControl(worldView);
			AddControl(new WorldControls(worldView));

			AddControl(new Border(0, 0, 256, 28, ColorScheme.Green, Backgrounds.Title, 0));
			AddControl(new Label(10, 8, "SELECT DESTINATION", Font.Normal, ColorScheme.Green));
			AddControl(new Button(8, 110, 53, 12, "CANCEL", ColorScheme.Aqua, Font.Normal, OnCancel));

			AddControl(new TimeDisplay());
		}

		private void OnChooseDestination(int longitude, int latitude)
		{
			//TODO: Hit test for intereption, landed ufo, crash site, terror site, alien base.  Otherwise waypoint.
			//TODO: If multiple results, show popup for choice
			new ConfirmDestination(craft, longitude, latitude).DoModal(this);
		}

		private static void OnCancel()
		{
			GameState.Current.SetScreen(Geoscape);
		}
	}
}
