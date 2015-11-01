﻿using System.Diagnostics;
using XCom.Battlescape;
using XCom.Battlescape.Tiles;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Graphics;
using XCom.Music;
using XCom.Fonts;

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

		public override void OnSetFocus()
		{
			MidiFiles.Play(MusicType.Story);
			stopwatch.Restart();
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

		private readonly Stopwatch stopwatch = new Stopwatch();
		private int frame;

		public override void Render(GraphicsBuffer buffer)
		{
			//base.Render(buffer);
			var item = new BattleItem { Item = EquipmentType.PsiAmp };
			var sprites = Sprite.SoldierPersonalArmorFemale;

			sprites[Direction.North].Render(buffer, 0, 144, item);
			sprites[Direction.NorthEast].Render(buffer, 0, 176, item);
			sprites[Direction.East].Render(buffer, 0, 208, item);
			sprites[Direction.SouthEast].Render(buffer, 0, 240, item);
			sprites[Direction.South].Render(buffer, 80, 240, item);
			sprites[Direction.SouthWest].Render(buffer, 80, 208, item);
			sprites[Direction.West].Render(buffer, 80, 176, item);
			sprites[Direction.NorthWest].Render(buffer, 80, 144, item);

			if (stopwatch.ElapsedMilliseconds > 100)
			{
				frame = (frame + 1) % 8;
				stopwatch.Restart();
			}

			sprites[Direction.North].Animate(buffer, 40, 144, item, frame);
			sprites[Direction.NorthEast].Animate(buffer, 40, 176, item, frame);
			sprites[Direction.East].Animate(buffer, 40, 208, item, frame);
			sprites[Direction.SouthEast].Animate(buffer, 40, 240, item, frame);
			sprites[Direction.South].Animate(buffer, 120, 240, item, frame);
			sprites[Direction.SouthWest].Animate(buffer, 120, 208, item, frame);
			sprites[Direction.West].Animate(buffer, 120, 176, item, frame);
			sprites[Direction.NorthWest].Animate(buffer, 120, 144, item, frame);
		}
	}
}
