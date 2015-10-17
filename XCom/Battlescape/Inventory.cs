using System;
using System.Drawing;
using XCom.Content.Overlays;
using XCom.Controls;
using XCom.Graphics;
using XCom.Screens;
using Font = XCom.Fonts.Font;

namespace XCom.Battlescape
{
	public class Inventory : Screen
	{
		private readonly Battle battle;
		private readonly BattleSoldier soldier;

		public Inventory(Battle battle, BattleSoldier soldier)
		{
			this.battle = battle;
			this.soldier = soldier;
			AddControl(new Overlay(Overlays.Tactical, 4));
			AddControl(new ClickArea(1, 238, 35, 23, OnOk));
			AddControl(new ClickArea(1, 274, 23, 23, OnPreviousSoldier));
			AddControl(new ClickArea(1, 298, 23, 23, OnNextSoldier));
			AddControl(new ClickArea(32, 288, 33, 26, OnUnloadWeapon));
			AddControl(new ClickArea(137, 288, 33, 15, OnNextEquipment));

			AddControl(new Label(0, 0, soldier.Soldier.Name, Font.Large, ColorScheme.Green));
			AddControl(new Label(32, 16, "RIGHT SHOULDER", Font.Normal, ColorScheme.Green));
			AddControl(new Label(32, 112, "LEFT SHOULDER", Font.Normal, ColorScheme.Green));
			AddControl(new Label(56, 0, "RIGHT HAND", Font.Normal, ColorScheme.Green));
			AddControl(new Label(56, 128, "LEFT HAND", Font.Normal, ColorScheme.Green));
			AddControl(new Label(112, 0, "RIGHT LEG", Font.Normal, ColorScheme.Green));
			AddControl(new Label(112, 128, "LEFT LEG", Font.Normal, ColorScheme.Green));
			AddControl(new Label(32, 192, "BACK PACK", Font.Normal, ColorScheme.Green));
			AddControl(new Label(96, 192, "BELT", Font.Normal, ColorScheme.Green));
			AddControl(new Label(143, 0, "GROUND", Font.Normal, ColorScheme.Green));

			AddControl(new Overlay(soldier.Soldier.Paperdoll, 4));
		}

		public override void Render(GraphicsBuffer buffer)
		{
			base.Render(buffer);
			DrawGridLines(buffer);
		}

		private static void DrawGridLines(GraphicsBuffer buffer)
		{
			buffer.DrawFrame(40, 16, 32, 16, Color.Gray);
			buffer.DrawVerticalLine(40, 32, 16, Color.Gray);
			buffer.DrawFrame(40, 112, 32, 16, Color.Gray);
			buffer.DrawVerticalLine(40, 128, 16, Color.Gray);
			buffer.DrawFrame(64, 0, 32, 48, Color.Gray);
			buffer.DrawFrame(64, 128, 32, 48, Color.Gray);
			buffer.DrawFrame(120, 0, 32, 16, Color.Gray);
			buffer.DrawVerticalLine(120, 16, 16, Color.Gray);
			buffer.DrawFrame(120, 128, 32, 16, Color.Gray);
			buffer.DrawVerticalLine(120, 144, 16, Color.Gray);
			buffer.DrawFrame(40, 192, 48, 48, Color.Gray);
			buffer.DrawVerticalLine(40, 208, 48, Color.Gray);
			buffer.DrawVerticalLine(40, 224, 48, Color.Gray);
			buffer.DrawHorizontalLine(56, 192, 48, Color.Gray);
			buffer.DrawHorizontalLine(72, 192, 48, Color.Gray);
			buffer.DrawFrame(104, 192, 64, 16, Color.Gray);
			buffer.DrawFrame(119, 192, 17, 16, Color.Gray);
			buffer.DrawFrame(119, 240, 16, 16, Color.Gray);
			buffer.DrawVerticalLine(104, 208, 16, Color.Gray);
			buffer.DrawVerticalLine(104, 224, 16, Color.Gray);
			buffer.DrawVerticalLine(104, 240, 16, Color.Gray);
			buffer.DrawFrame(152, 0, 320, 48, Color.Gray);
			buffer.DrawHorizontalLine(168, 0, 320, Color.Gray);
			buffer.DrawHorizontalLine(184, 0, 320, Color.Gray);
			for (var column = 16; column < 320; column += 16)
				buffer.DrawVerticalLine(152, column, 48, Color.Gray);
		}

		private static void OnOk()
		{
			//TODO:
			Environment.Exit(0);
		}

		private void OnPreviousSoldier()
		{
			GameState.Current.SetScreen(new Inventory(battle, battle.PreviousSoldier(soldier)));
		}

		private void OnNextSoldier()
		{
			GameState.Current.SetScreen(new Inventory(battle, battle.NextSoldier(soldier)));
		}

		private static void OnUnloadWeapon()
		{
			//TODO:
		}

		private static void OnNextEquipment()
		{
			//TODO:
		}
	}
}
