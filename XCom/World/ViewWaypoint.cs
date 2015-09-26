using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.World
{
	public class ViewWaypoint : Screen
	{
		public ViewWaypoint(Waypoint waypoint)
		{
			AddControl(new Border(40, 32, 192, 120, ColorScheme.Yellow, Backgrounds.Title, 0));
			AddControl(new Label(54, Label.CenterOf(32, 192), waypoint.Name, Font.Large, ColorScheme.Yellow));
			AddControl(new Label(74, Label.CenterOf(32, 192), "TARGETED BY:", Font.Normal, ColorScheme.Green));
			AddControl(new Label(84, Label.CenterOf(32, 192), waypoint.TargetedBy.Name, Font.Normal, ColorScheme.Green));
			AddControl(new Button(135, 48, 160, 16, "OK", ColorScheme.Aqua, Font.Normal, EndModal));
		}
	}
}
