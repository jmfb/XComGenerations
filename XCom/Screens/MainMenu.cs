using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Graphics;
using XCom.Music;
using XCom.World;
using Font = XCom.Fonts.Font;

namespace XCom.Screens
{
	public class MainMenu : Screen
	{
		public MainMenu()
		{
			AddControl(new Border(20, 32, 256, 160, ColorScheme.Aqua, Backgrounds.Title, 0));
			AddControl(new Label(45, Label.Center, "X-Com", Font.Large, ColorScheme.Yellow));
			AddControl(new Label(61, Label.Center, "UFO Defense", Font.Normal, ColorScheme.Yellow));
			AddControl(new Button(90, 64, 192, 20, "New Game", ColorScheme.Aqua, Font.Normal, OnNewGame));
			AddControl(new Button(118, 64, 192, 20, "Load Saved Game", ColorScheme.Aqua, Font.Normal, OnLoadSavedGame));
			AddControl(new Button(146, 64, 192, 20, "Quit", ColorScheme.Aqua, Font.Normal, OnQuit));
		}

		//private int xOffset;
		//private int yOffset;

		//public override void Render(GraphicsBuffer buffer)
		//{
		//	foreach (var row in Enumerable.Range(0, 200))
		//		foreach (var column in Enumerable.Range(0, 320))
		//		{
		//			var mapLocation = Map.Instance[new Location { Longitude = column + xOffset, Latitude = -720 + row + yOffset }];
		//			var terrain = mapLocation.TerrainType;
		//			var color = terrain == null ? Color.Blue : Color.Green;
		//			buffer.SetPixel(row, column, color);
		//		}
		//	Font.Normal.DrawString(buffer, 0, 0, $"({lastLongitude}, {lastLatitude})", ColorScheme.White);
		//}

		//public override bool HitTest(int row, int column)
		//{
		//	return true;
		//}

		//public override void OnKeyPressed(char value)
		//{
		//	var offsets = new Dictionary<char, Tuple<int, int>>
		//	{
		//		{ 'a', Tuple.Create(-10, 0) },
		//		{ 'w', Tuple.Create(0, -10) },
		//		{ 's', Tuple.Create(0, 10) },
		//		{ 'd', Tuple.Create(10, 0) }
		//	};
		//	Tuple<int, int> offset;
		//	if (offsets.TryGetValue(value, out offset))
		//		ChangeOffset(offset.Item1, offset.Item2);
		//}

		//private void ChangeOffset(int deltaX, int deltaY)
		//{
		//	xOffset = Math.Max(0, Math.Min(2880 - 320, xOffset + deltaX));
		//	yOffset = Math.Max(0, Math.Min(1440 - 200, yOffset + deltaY));
		//}

		//private int lastLongitude;
		//private int lastLatitude;

		//public override void OnLeftButtonDown(int row, int column)
		//{
		//	lastLongitude = column + xOffset;
		//	lastLatitude = -720 + row + yOffset;
		//}

		public override void OnSetFocus()
		{
			MidiFiles.Play(MusicType.Story);
		}

		private static void OnNewGame()
		{
			GameState.Current.SetScreen(new Difficulty());
		}

		private void OnLoadSavedGame()
		{
			GameState.Current.SetScreen(new LoadGame(this));
		}

		private static void OnQuit()
		{
			GameState.Current.Quit();
		}
	}
}
