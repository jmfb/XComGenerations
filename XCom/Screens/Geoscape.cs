using System.Diagnostics;
using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Modals;
using XCom.Music;
using XCom.World;

namespace XCom.Screens
{
	public class Geoscape : Screen
	{
		private readonly Stopwatch stopwatch = new Stopwatch();
		private readonly GameSpeed gameSpeed = new GameSpeed();
		private readonly WorldView worldView;

		public Geoscape()
		{
			AddControl(new Background(Backgrounds.Geoscape, 0));
			AddControl(new Button(0, 257, 63, 11, "INTERCEPT", ColorScheme.Blue, Font.Small, OnIntercept));
			AddControl(new Button(12, 257, 63, 11, "BASES", ColorScheme.Blue, Font.Small, OnBases));
			AddControl(new Button(24, 257, 63, 11, "GRAPHS", ColorScheme.Blue, Font.Small, OnGraphs));
			AddControl(new Button(36, 257, 63, 11, "UFOPAEDIA", ColorScheme.Blue, Font.Small, OnUfoPaedia));
			AddControl(new Button(48, 257, 63, 11, "OPTIONS", ColorScheme.Blue, Font.Small, OnOptions));
			AddControl(new Button(60, 257, 63, 11, "FUNDING", ColorScheme.Blue, Font.Small, OnFunding));
			AddControl(new TimeDisplay());
			AddControl(gameSpeed);
			worldView = new WorldView(OnClick);
			AddControl(worldView);
			AddControl(new WorldControls(worldView));
		}

		public void ResetGameSpeed()
		{
			gameSpeed.Reset();
		}

		public override void OnSetFocus()
		{
			MidiFiles.Play(MusicType.Geoscape);
			worldView.Initialize();
			GameState.Current.OnIdle += OnIdle;
			stopwatch.Restart();
		}

		private static void ProcessNextNotification()
		{
			if (GameState.Current.Notifications.Any())
				GameState.Current.Notifications.Dequeue()();
		}

		public override void OnKillFocus()
		{
			GameState.Current.OnIdle -= OnIdle;
			stopwatch.Stop();
		}

		private void OnIntercept()
		{
			new LaunchInterception().DoModal(this);
		}

		private static void OnBases()
		{
			GameState.Current.SetScreen(new Base());
		}

		private static void OnGraphs()
		{
			//TODO:
		}

		private static void OnUfoPaedia()
		{
			GameState.Current.SetScreen(new Information());
		}

		private void OnOptions()
		{
			new Options().DoModal(this);
		}

		private static void OnFunding()
		{
			GameState.Current.SetScreen(new Funding());
		}

		private void OnIdle()
		{
			if (stopwatch.ElapsedMilliseconds < 10)
				return;
			var elapsedMillisecondsInGame = stopwatch.ElapsedMilliseconds * gameSpeed.Multiplier;
			stopwatch.Restart();
			GameState.Current.Data.AdvanceGameTime(elapsedMillisecondsInGame);
			ProcessNextNotification();
		}

		private void OnClick(Location location)
		{
			var data = GameState.Current.Data;
			var bases = data.Bases.Where(@base => Trigonometry.HitTestCoordinate(@base.Location, location));
			var waypoints = data.Waypoints.Where(waypoint => Trigonometry.HitTestCoordinate(waypoint.Location, location));
			var crafts = data.ActiveInterceptors.Where(craft => Trigonometry.HitTestCoordinate(craft.Location, location));
			var ufos = data.VisibleUfos.Where(ufo => Trigonometry.HitTestCoordinate(ufo.Location, location));
			var worldObjects = bases.Cast<object>()
				.Concat(waypoints)
				.Concat(crafts)
				.Concat(ufos)
				.ToList();
			if (!worldObjects.Any())
				return;
			if (worldObjects.Count > 1)
				new SelectWorldObject(worldObjects, OnSelectWorldObject).DoModal(this);
			else
				OnSelectWorldObject(worldObjects[0]);
		}

		private void OnSelectWorldObject(object worldObject)
		{
			SelectWorldObject((dynamic)worldObject);
		}

		private void SelectWorldObject(Data.Base @base)
		{
			new LaunchInterception(@base).DoModal(this);
		}

		private void SelectWorldObject(Waypoint waypoint)
		{
			new ViewWaypoint(waypoint).DoModal(this);
		}

		private void SelectWorldObject(Craft craft)
		{
			new RedirectCraft(craft).DoModal(this);
		}

		private void SelectWorldObject(Ufo ufo)
		{
			new UfoDetected(ufo).DoModal(this);
		}
	}
}
