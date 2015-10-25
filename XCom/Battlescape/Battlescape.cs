using System.Collections.Generic;
using System.Linq;
using XCom.Content.Overlays;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Music;
using XCom.Screens;

namespace XCom.Battlescape
{
	public class Battlescape : Screen
	{
		private readonly Battle battle;

		public Battlescape(Battle battle)
		{
			this.battle = battle;
			AddControl(new Overlay(Overlays.BattlescapeControls, 4));
			AddControl(new ClickArea(144, 0, 48, 56, OnLeftWeapon));
			AddControl(new ClickArea(144, 272, 48, 56, OnRightWeapon));
			AddControl(new ClickArea(144, 48, 32, 16, OnMoveUp));
			AddControl(new ClickArea(160, 48, 32, 16, OnMoveDown));
			AddControl(new ClickArea(144, 80, 32, 16, OnLevelUp));
			AddControl(new ClickArea(160, 80, 32, 16, OnLevelDown));
			AddControl(new ClickArea(144, 112, 32, 16, OnMiniMap));
			AddControl(new ClickArea(160, 112, 32, 16, OnToggleCrouch));
			AddControl(new ClickArea(144, 144, 32, 16, OnInventory));
			AddControl(new ClickArea(160, 144, 32, 16, OnCenterOnActiveUnit));
			AddControl(new ClickArea(144, 176, 32, 16, OnNextUnit));
			AddControl(new ClickArea(160, 176, 32, 16, OnDoneAndNextUnit));
			AddControl(new ClickArea(144, 208, 32, 16, OnToggleLevelView));
			AddControl(new ClickArea(160, 208, 32, 16, OnOptions));
			AddControl(new ClickArea(144, 240, 32, 16, OnEndTurn));
			AddControl(new ClickArea(160, 240, 32, 16, OnAbortMission));
			AddControl(new ClickArea(176, 48, 30, 12, OnOptionNoReserve));
			AddControl(new ClickArea(188, 48, 30, 12, OnOptionReserveAimedShot));
			AddControl(new ClickArea(176, 78, 30, 12, OnOptionReserveSnapShot));
			AddControl(new ClickArea(188, 78, 30, 12, OnOptionReserveAutoShot));
			AddControl(new ClickArea(176, 108, 164, 24, OnUnitStatistics));
		}

		public override void OnSetFocus()
		{
			MidiFiles.Play(MusicType.Battlescape);
		}

		private static void OnLeftWeapon()
		{
			//TODO
		}

		private static void OnRightWeapon()
		{
			//TODO
		}

		private static void OnMoveUp()
		{
			//TODO
		}

		private static void OnMoveDown()
		{
			//TODO
		}

		private static void OnLevelUp()
		{
			//TODO
		}

		private static void OnLevelDown()
		{
			//TODO
		}

		private static void OnMiniMap()
		{
			//TODO
		}

		private static void OnToggleCrouch()
		{
			//TODO
		}

		private void OnInventory()
		{
			//TODO: detect if the active unit is a soldier, otherwise just return
			//TODO: use the ground of the active soldier
			var ground = battle.Stores ?? new List<BattleItem>();
			var activeSoldier = battle.SelectedSoldier;
			if (activeSoldier == null)
				return;
			GameState.Current.SetScreen(new Inventory(battle, activeSoldier, ground, false));
		}

		private static void OnCenterOnActiveUnit()
		{
			//TODO
		}

		private void OnNextUnit()
		{
			battle.SelectNextUnit(false);
			OnCenterOnActiveUnit();
		}

		private void OnDoneAndNextUnit()
		{
			battle.SelectNextUnit(true);
			OnCenterOnActiveUnit();
		}

		private static void OnToggleLevelView()
		{
			//TODO
		}

		private static void OnOptions()
		{
			GameState.Current.SetScreen(new GameOptions());
		}

		private void OnEndTurn()
		{
			//TODO: real end of turn logic
			battle.StartNextTurn();
			GameState.Current.SetScreen(new DisplayTurn(battle));
		}

		private void OnAbortMission()
		{
			new AbortMission().DoModal(this);
		}

		private static void OnOptionNoReserve()
		{
			//TODO
		}

		private static void OnOptionReserveSnapShot()
		{
			//TODO
		}

		private static void OnOptionReserveAimedShot()
		{
			//TODO
		}

		private static void OnOptionReserveAutoShot()
		{
			//TODO
		}

		private void OnUnitStatistics()
		{
			var activeSolider = battle.SelectedSoldier;
			if (activeSolider == null)
				return;
			GameState.Current.SetScreen(new ViewSoldierStatistics(battle, activeSolider));
		}

		private int rowOffset;
		private int columnOffset;
		private int levelCount = 4;
		private BattleLevel[] battleLevels;
		private int tilesetIndex;
		private readonly Tileset[] tilesets =
		{
			Tileset.Desert0,
			Tileset.Desert1,
			Tileset.Desert2,
			Tileset.Desert3,
			Tileset.Desert4,
			Tileset.Desert5,
			Tileset.Desert6,
			Tileset.Desert7,
			Tileset.Desert8,
			Tileset.Desert9,
			Tileset.Desert10,
			Tileset.Desert11
		};

		public override bool HitTest(int row, int column)
		{
			return true;
		}

		public override void OnLeftButtonDown(int row, int column)
		{
			battleLevels = CreateNextTileset();
		}

		public override void OnRightButtonDown(int row, int column)
		{
			--levelCount;
			if (levelCount == 0)
				levelCount = 4;
		}

		public override void OnKeyPressed(char value)
		{
			switch (value)
			{
			case 'a':
				columnOffset -= 32;
				break;
			case 'd':
				columnOffset += 32;
				break;
			case 'w':
				rowOffset -= 40;
				break;
			case 's':
				rowOffset += 40;
				break;
			}
		}

		private BattleLevel[] CreateNextTileset()
		{
			if (battleLevels != null)
				tilesetIndex = (tilesetIndex + 1) % tilesets.Length;
			var tileset = tilesets[tilesetIndex];
			var levels = new BattleLevel[4];
			foreach (var level in Enumerable.Range(0, 4))
			{
				levels[level] = new BattleLevel(tileset.ColumnCount, tileset.RowCount);
				levels[level].LoadTileset(tileset, level, 0, 0);
			}
			return levels;
		}

		public override void Render(GraphicsBuffer buffer)
		{
			if (battleLevels == null)
				battleLevels = CreateNextTileset();
			foreach (var level in Enumerable.Range(0, levelCount))
				battleLevels[level].Render(buffer, 0 - 24 * level + rowOffset, 140 + columnOffset);

			base.Render(buffer);
			DrawUnitInformation(buffer, battle.SelectedUnit);
		}

		private static void DrawUnitInformation(GraphicsBuffer buffer, Unit unit)
		{
			if (unit == null)
				return;
			Font.Normal.DrawString(buffer, 176, 134, unit.Name, ColorScheme.Blue);
			Font.Small.DrawString(buffer, 186, 136, $"{unit.TimeUnits}", ColorScheme.LightGreen);
			Font.Small.DrawString(buffer, 194, 136, $"{unit.Health}", ColorScheme.Red);
			Font.Small.DrawString(buffer, 186, 154, $"{unit.Energy}", ColorScheme.Orange);
			Font.Small.DrawString(buffer, 194, 154, $"{unit.Morale}", ColorScheme.Purple);
			new Bar(185, 170, unit.MaxTimeUnits, 3, unit.TimeUnits, 55, 48).Render(buffer);
			new Bar(189, 170, unit.MaxEnergy, 3, unit.Energy, 23, 16).Render(buffer);
			new Bar(193, 170, unit.MaxHealth, 3, unit.Health, 39, 32).Render(buffer);
			new Bar(197, 170, unit.MaxMorale, 3, unit.Morale, 249, 247).Render(buffer);
			unit.Rank?.Image().Render(buffer, 177, 107);
		}
	}
}
