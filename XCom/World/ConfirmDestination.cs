using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.World
{
	public class ConfirmDestination : Screen
	{
		private readonly Craft craft;
		private readonly Location location;

		public ConfirmDestination(Craft craft, Location location)
		{
			this.craft = craft;
			this.location = location;
			AddControl(new Border(64, 16, 224, 72, ColorScheme.Green, Backgrounds.Craft, 0));
			AddControl(new Label(80, Label.CenterOf(16, 224), "TARGET: WAY POINT", Font.Large, ColorScheme.Green));
			AddControl(new Button(104, 68, 50, 12, "OK", ColorScheme.Aqua, Font.Normal, OnOk));
			AddControl(new Button(104, 138, 50, 12, "CANCEL", ColorScheme.Aqua, Font.Normal, EndModal));
		}

		private void OnOk()
		{
			var waypointNumber = GameState.Current.Data.CreateWaypoint(location);
			craft.Status = CraftStatus.Out;
			craft.Location = craft.BaseLocation;
			craft.Destination = new Destination
			{
				WorldObjectType = WorldObjectType.Waypoint,
				Number = waypointNumber
			};

			EndModal();
			GameState.Current.SetScreen(Geoscape);
		}
	}
}
