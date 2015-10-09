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
		private IEnumerable<Trigonometry.SphereTerrain> frontTerrain;
		private IEnumerable<Terrain> scaledFrontTerrain;
		private static readonly int[] zoomRadius = { 90, 120, 180, 270, 440, 720 };
		private readonly Action<Location> onClick;
		private readonly Stopwatch stopwatch = new Stopwatch();
		private bool flashWorldObjects;
		public const int CenterX = 128;
		public const int CenterY = 100;

		public WorldView(Action<Location> onClick)
		{
			this.onClick = onClick;
			Initialize();
			stopwatch.Restart();
		}

		public void Initialize()
		{
			CalculateFrontTerrain();
			ScaleFrontTerrain();
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
			CalculateFrontTerrain();
			ScaleFrontTerrain();
		}

		public void ChangePitch(int delta)
		{
			Pitch = Trigonometry.AddEighthDegrees(Pitch, delta);
			CalculateFrontTerrain();
			ScaleFrontTerrain();
		}

		public void IncreaseZoom()
		{
			if (Zoom == 5)
				return;
			++Zoom;
			ScaleFrontTerrain();
		}

		public void DecreaseZoom()
		{
			if (Zoom == 0)
				return;
			--Zoom;
			ScaleFrontTerrain();
		}

		private void CalculateFrontTerrain()
		{
			frontTerrain = Terrain.Landscape
				.Select(terrain => Trigonometry.MapTerrainToSphere(terrain, LongitudeOffset, Pitch))
				.Where(sphereTerrain => sphereTerrain.IsFrontFacing)
				.ToList();
		}

		private void ScaleFrontTerrain()
		{
			scaledFrontTerrain = frontTerrain
				.Select(sphereTerrain => sphereTerrain.Scale(Radius, CenterX, CenterY))
				.ToList();
		}

		public static int Radius => zoomRadius[Zoom];

		public override void Render(GraphicsBuffer buffer)
		{
			DrawOcean(buffer);
			DrawTerrain(buffer);
			DrawWorldObjects(buffer);
		}

		private static void DrawOcean(GraphicsBuffer buffer)
		{
			var oceanColor = Palette.GetPalette(0).GetColor(192);
			switch (Zoom)
			{
			case 0:
			case 1:
				buffer.FillCircle(Radius, oceanColor);
				break;
			default:
				buffer.FillRect(0, 0, 256, 200, oceanColor);
				break;
			}
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

		private void DrawTerrain(GraphicsBuffer buffer)
		{
			var secondOfDay = (int)GameState.Current.Data.Time.TimeOfDay.TotalSeconds;
			foreach (var terrain in scaledFrontTerrain)
				buffer.DrawTerrain(terrain, Radius, Shader.GetShadeIndex(terrain.MiddleLongitude, secondOfDay), Zoom);
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
