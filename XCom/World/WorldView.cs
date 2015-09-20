using System.Collections.Generic;
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

		public WorldView()
		{
			Initialize();
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
			const int centerX = 128;
			const int centerY = 100;
			scaledFrontTerrain = frontTerrain
				.Select(sphereTerrain => sphereTerrain.Scale(Radius, centerX, centerY))
				.ToList();
		}

		private static int Radius => zoomRadius[Zoom];

		public override void Render(GraphicsBuffer buffer)
		{
			DrawOcean(buffer);
			DrawTerrain(buffer);
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

		private void DrawTerrain(GraphicsBuffer buffer)
		{
			foreach (var terrain in scaledFrontTerrain)
				buffer.DrawTerrain(terrain, Radius, 0, Zoom);
		}
	}
}
