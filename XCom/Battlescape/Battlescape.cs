using System;
using System.Linq;
using XCom.Content.Overlays;
using XCom.Controls;
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
			var ground = battle.Stores;
			//TODO: use active soldier (not first)
			var activeSoldier = battle.Soldiers.First();
			GameState.Current.SetScreen(new Inventory(battle, activeSoldier, ground, false));
		}

		private static void OnCenterOnActiveUnit()
		{
			//TODO
		}

		private static void OnNextUnit()
		{
			//TODO
		}

		private static void OnDoneAndNextUnit()
		{
			//TODO
		}

		private static void OnToggleLevelView()
		{
			//TODO
		}

		private static void OnOptions()
		{
			//TODO
		}

		private void OnEndTurn()
		{
			//TODO: real end of turn logic
			++battle.Turn;
			GameState.Current.SetScreen(new DisplayTurn(battle));
		}

		private static void OnAbortMission()
		{
			//TODO
			Environment.Exit(0);
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

		private static void OnUnitStatistics()
		{
			//TODO
		}
	}
}
