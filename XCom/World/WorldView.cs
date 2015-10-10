using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using XCom.Controls;
using XCom.Graphics;

namespace XCom.World
{
	public class WorldView : InteractiveControl
	{
		private readonly MapLocation[,] screen = new MapLocation[256, 200];
		private static readonly int[] zoomRadius = { 90, 120, 180, 270, 440, 720 };
		private readonly Action<Location> onClick;
		private readonly Stopwatch stopwatch = new Stopwatch();
		private bool flashWorldObjects;
		public const int CenterX = 128;
		public const int CenterY = 100;

		public WorldView(Action<Location> onClick)
		{
			this.onClick = onClick;
			stopwatch.Restart();
		}

		public void Initialize()
		{
			CalculateScreen();
		}

		private static int LongitudeOffset
		{
			get { return GameState.Current?.Data?.LongitudeOffset ?? 0; }
			set { GameState.Current.Data.LongitudeOffset = value; }
		}

		private static int Pitch
		{
			get { return GameState.Current?.Data?.Pitch ?? 0; }
			set { GameState.Current.Data.Pitch = value; }
		}

		private static int Zoom
		{
			get { return GameState.Current?.Data?.Zoom ?? 0; }
			set { GameState.Current.Data.Zoom = value; }
		}

		public void ChangeLongitudeOffset(int delta)
		{
			LongitudeOffset = Trigonometry.AddEighthDegrees(LongitudeOffset, delta);
			CalculateScreen();
		}

		public void ChangePitch(int delta)
		{
			Pitch = Trigonometry.AddEighthDegrees(Pitch, delta);
			CalculateScreen();
		}

		public void IncreaseZoom()
		{
			if (Zoom == 5)
				return;
			++Zoom;
			CalculateScreen();
		}

		public void DecreaseZoom()
		{
			if (Zoom == 0)
				return;
			--Zoom;
			CalculateScreen();
		}

		private void CalculateScreen()
		{
			foreach (var row in Enumerable.Range(0, 200))
				foreach (var column in Enumerable.Range(0, 256))
					screen[column, row] = Map.Instance[Trigonometry.ScreenToLocation(row, column)];
		}

		public static int Radius => zoomRadius[Zoom];

		public override void Render(GraphicsBuffer buffer)
		{
			DrawWorld(buffer);
			DrawWorldObjects(buffer);
		}

		public override bool HitTest(int row, int column)
		{
			return row >= 0 && column >= 0 && row < 200 && column < 256;
		}

		public override void OnLeftButtonDown(int row, int column)
		{
			var location = Trigonometry.ScreenToLocation(row, column);
			if (location != null)
				onClick(location);
		}

		public override void OnRightButtonDown(int row, int column)
		{
			var location = Trigonometry.ScreenToLocation(row, column);
			if (location == null)
				return;
			GameState.Current.Data.CenterOn(location);
			Initialize();
		}

		private void DrawWorld(GraphicsBuffer buffer)
		{
			var secondOfDay = (int)GameState.Current.Data.Time.TimeOfDay.TotalSeconds;
			foreach (var row in Enumerable.Range(0, 200))
			{
				foreach (var column in Enumerable.Range(0, 256))
				{
					var mapLocation = screen[column, row];
					if (mapLocation == null)
						continue;
					var shadeIndex = Shader.GetShadeIndex(mapLocation.Location.Longitude, secondOfDay);
					var color = mapLocation.GetColor(row, column, shadeIndex, Zoom);
					buffer.SetPixel(row, column, color);
				}
			}
		}

		private void UpdateFlashWorldObjects()
		{
			if (stopwatch.ElapsedMilliseconds < 100)
				return;
			flashWorldObjects = !flashWorldObjects;
			stopwatch.Restart();
		}

		private static IEnumerable<WorldObject> GetVisibleWorldObjects<T>(
			IEnumerable<T> items,
			Func<T, Location> location,
			WorldObjectType worldObjectType)
		{
			return items
				.Select(item => Trigonometry.MapLocationToScreen(location(item)))
				.OfType<Point>()
				.Select(point => new WorldObject
				{
					WorldObjectType = worldObjectType,
					Location = point
				});
		}

		private static IEnumerable<WorldObject> VisibleXcomBases =>
			GetVisibleWorldObjects(GameState.Current.Data.Bases, @base => @base.Location, WorldObjectType.XcomBase);
		private static IEnumerable<WorldObject> VisibleWaypoints =>
			GetVisibleWorldObjects(GameState.Current.Data.Waypoints, waypoint => waypoint.Location, WorldObjectType.Waypoint);
		private static IEnumerable<WorldObject> VisibleInterceptors =>
			GetVisibleWorldObjects(GameState.Current.Data.ActiveInterceptors, interceptor => interceptor.Location, WorldObjectType.Interceptor);
		private static IEnumerable<WorldObject> VisibleUfos =>
			GetVisibleWorldObjects(FlyingUfos, ufo => ufo.Location, WorldObjectType.Ufo);
		private static IEnumerable<WorldObject> VisibleLandingSites =>
			GetVisibleWorldObjects(LandingSites, ufo => ufo.Location, WorldObjectType.LandingSite);
		private static IEnumerable<WorldObject> VisibleCrashSites =>
			GetVisibleWorldObjects(CrashSites, ufo => ufo.Location, WorldObjectType.CrashSite);

		private static IEnumerable<Ufo> FlyingUfos => GameState.Current.Data.VisibleUfos.Where(ufo => ufo.Status == UfoStatus.Flying);
		private static IEnumerable<Ufo> LandingSites => GameState.Current.Data.VisibleUfos.Where(ufo => ufo.Status == UfoStatus.Landed);
		private static IEnumerable<Ufo> CrashSites => GameState.Current.Data.VisibleUfos.Where(ufo => ufo.Status == UfoStatus.Crashed);

		private static IEnumerable<WorldObject> VisibleWorldObjects =>
			VisibleXcomBases
			.Concat(VisibleWaypoints)
			.Concat(VisibleInterceptors)
			.Concat(VisibleUfos)
			.Concat(VisibleLandingSites)
			.Concat(VisibleCrashSites);

		private void DrawWorldObjects(GraphicsBuffer buffer)
		{
			UpdateFlashWorldObjects();
			foreach (var worldObject in VisibleWorldObjects)
				worldObject.Render(buffer, flashWorldObjects);
		}
	}
}
