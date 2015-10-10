using System.Linq;
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
		private readonly WorldView worldView;

		public SelectDestination(Craft craft)
		{
			this.craft = craft;
			AddControl(new Background(Backgrounds.Geoscape, 0));
			worldView = new WorldView(OnChooseDestination);
			AddControl(worldView);
			AddControl(new WorldControls(worldView));

			AddControl(new Border(0, 0, 256, 28, ColorScheme.Green, Backgrounds.Title, 0));
			AddControl(new Label(10, 8, "SELECT DESTINATION", Font.Normal, ColorScheme.Green));
			AddControl(new Button(8, 110, 53, 12, "CANCEL", ColorScheme.Aqua, Font.Normal, OnCancel));

			AddControl(new TimeDisplay());
		}

		public override void OnSetFocus()
		{
			worldView.Initialize();
		}

		private void OnChooseDestination(Location location)
		{
			//TODO: hit test for terror sites and alien bases
			var ufos = GameState.Current.Data.VisibleUfos.Where(ufo => Trigonometry.HitTestCoordinate(ufo.Location, location)).ToList();
			if (!ufos.Any())
				new ConfirmDestination("WAY POINT", () => SelectWaypoint(location)).DoModal(this);
			else if (ufos.Count == 1)
				new ConfirmDestination(ufos[0].Name, () => SelectUfo(ufos[0])).DoModal(this);
			else
			{
				var selector = new SelectWorldObject(
					ufos.Cast<object>().ToList(),
					ufo => new ConfirmDestination(((Ufo)ufo).Name, () => SelectUfo((Ufo)ufo)).DoModal(this));
				selector.DoModal(this);
			}
		}

		private static void OnCancel()
		{
			GameState.Current.SetScreen(Geoscape);
		}

		private void SelectUfo(Ufo ufo)
		{
			SelectWorldObject(ufo.WorldObjectType, ufo.Number);
		}

		private void SelectWaypoint(Location location)
		{
			SelectWorldObject(WorldObjectType.Waypoint, GameState.Current.Data.CreateWaypoint(location));
		}

		private void SelectWorldObject(WorldObjectType worldObjectType, int number)
		{
			if (craft.Status == CraftStatus.Ready)
			{
				craft.Status = CraftStatus.Out;
				craft.Location = craft.Base.Location;
			}
			else
			{
				craft.RemoveWaypoint();
			}
			craft.IsPatrolling = false;
			craft.Destination = new Destination
			{
				WorldObjectType = worldObjectType,
				Number = number
			};
		}
	}
}
