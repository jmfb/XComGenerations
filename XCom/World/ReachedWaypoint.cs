using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.World
{
	public class ReachedWaypoint : Screen
	{
		private readonly Craft craft;

		public ReachedWaypoint(Craft craft, Waypoint waypoint)
		{
			this.craft = craft;
			AddControl(new Border(16, 16, 224, 168, ColorScheme.Green, Backgrounds.Craft, 10));
			AddControl(new Label(48, Label.CenterOf(16, 224), craft.Name, Font.Large, ColorScheme.Green));
			AddControl(new Label(64, Label.CenterOf(16, 224), "has reached", Font.Large, ColorScheme.Green));
			AddControl(new Label(80, Label.CenterOf(16, 224), "Destination", Font.Large, ColorScheme.Green));
			AddControl(new Label(96, Label.CenterOf(16, 224), waypoint.Name, Font.Large, ColorScheme.Green));
			AddControl(new Label(120, Label.CenterOf(16, 224), "Now patrolling", Font.Large, ColorScheme.Green));
			AddControl(new Button(144, 58, 140, 12, "OK", ColorScheme.Aqua, Font.Normal, EndModal));
			AddControl(new Button(160, 58, 140, 12, "REDIRECT CRAFT", ColorScheme.Aqua, Font.Normal, OnRedirectCraft));
		}

		private void OnRedirectCraft()
		{
			SwitchToModal(new RedirectCraft(craft));
		}
	}
}
