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
		private readonly Action<int, int> onClick;
		private readonly Stopwatch stopwatch = new Stopwatch();
		private bool flashWorldObjects;
		private const int centerX = 128;
		private const int centerY = 100;

		public WorldView(Action<int, int> onClick)
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
				.Select(sphereTerrain => sphereTerrain.Scale(Radius, centerX, centerY))
				.ToList();
		}

		private static int Radius => zoomRadius[Zoom];

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

		private static Point? ScreenToLongitudeLatitude(int row, int column)
		{
			var x = (double)(column - 128);
			var y = (double)(row - 100);
			var r = (double)Radius;
			var z2 = r * r - x * x - y * y;
			if (z2 < 0)
				return null;
			var z = Math.Sqrt(z2);

			var pitchRadians = Pitch * Trigonometry.RadiansPerEighthDegree;
			var rollRadians = LongitudeOffset * Trigonometry.RadiansPerEighthDegree;

			var unitX = x / r;
			var unitY = y / r;
			var unitZ = z / r;

			var rotatedX = unitX;
			var rotatedY = unitY * Math.Cos(pitchRadians) + unitZ * Math.Sin(pitchRadians);
			var rotatedZ = unitZ * Math.Cos(pitchRadians) - unitY * Math.Sin(pitchRadians);

			var latitude = Math.Asin(rotatedY);
			var longitude = Math.Atan2(rotatedX, rotatedZ) - rollRadians;

			var latitudeEighthDegrees = (int)(latitude / Trigonometry.RadiansPerEighthDegree);
			var longitudeEighthDegrees = (int)(longitude / Trigonometry.RadiansPerEighthDegree);

			return new Point
			{
				X = Trigonometry.AddEighthDegrees(longitudeEighthDegrees, 0),
				Y = latitudeEighthDegrees
			};
		}

		public override bool HitTest(int row, int column)
		{
			return row >= 0 && column >= 0 && row < 200 && column < 256;
		}

		public override void OnLeftButtonDown(int row, int column)
		{
			var latitudeLongitude = ScreenToLongitudeLatitude(row, column);
			if (latitudeLongitude != null)
				onClick(latitudeLongitude.Value.X, latitudeLongitude.Value.Y);
		}

		public override void OnRightButtonDown(int row, int column)
		{
			var latitudeLongitude = ScreenToLongitudeLatitude(row, column);
			if (latitudeLongitude == null)
				return;
			LongitudeOffset = Trigonometry.AddEighthDegrees(-latitudeLongitude.Value.X, 0);
			GameState.Current.Data.Pitch = Trigonometry.AddEighthDegrees(latitudeLongitude.Value.Y, 0);
			Initialize();
		}

		private void DrawTerrain(GraphicsBuffer buffer)
		{
			foreach (var terrain in scaledFrontTerrain)
				buffer.DrawTerrain(terrain, Radius, 0, Zoom);
		}

		private void UpdateFlashWorldObjects()
		{
			if (stopwatch.ElapsedMilliseconds < 100)
				return;
			flashWorldObjects = !flashWorldObjects;
			stopwatch.Restart();
		}

		private static IEnumerable<WorldObject> VisibleXcomBases => GameState.Current.Data.Bases
			.Select(@base => Trigonometry.MapPointToScreen(@base.Longitude, @base.Latitude, LongitudeOffset, Pitch, Radius, centerX, centerY))
			.OfType<Point>()
			.Select(point => new WorldObject
			{
				WorldObjectType = WorldObjectType.XcomBase,
				Location = point
			});

		private static IEnumerable<WorldObject> VisibleWorldObjects =>
			VisibleXcomBases;

		private void DrawWorldObjects(GraphicsBuffer buffer)
		{
			UpdateFlashWorldObjects();
			foreach (var worldObject in VisibleWorldObjects)
				worldObject.Render(buffer, flashWorldObjects);
		}
	}
}
