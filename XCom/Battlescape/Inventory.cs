using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using XCom.Content.Overlays;
using XCom.Controls;
using XCom.Data;
using XCom.Graphics;
using XCom.Music;
using XCom.Screens;
using Font = XCom.Fonts.Font;

namespace XCom.Battlescape
{
	public class Inventory : Screen
	{
		private readonly Battle battle;
		private readonly BattleSoldier soldier;
		private readonly List<BattleItem> ground;
		private readonly List<BattleItem[,]> groundViews = new List<BattleItem[,]>();
		private int groundViewIndex;
		private BattleItem selection;
		private InventoryLocation selectionSource;

		public Inventory(Battle battle, BattleSoldier soldier, List<BattleItem> ground)
		{
			this.battle = battle;
			this.soldier = soldier;
			this.ground = ground;
			CalculateGroundViews();

			AddControl(new Overlay(Overlays.Tactical, 4));
			AddControl(new ClickArea(1, 238, 35, 23, OnOk));
			AddControl(new ClickArea(1, 274, 23, 23, OnPreviousSoldier));
			AddControl(new ClickArea(1, 298, 23, 23, OnNextSoldier));
			AddControl(new ClickArea(32, 288, 33, 26, OnUnloadWeapon));
			AddControl(new ClickArea(137, 288, 33, 15, OnNextGroundView));

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

			AddControl(new ClickGridArea(40, 16, 2, 1, OnClickRightShoulder));
			AddControl(new ClickGridArea(40, 112, 2, 1, OnClickLeftShoulder));
			AddControl(new ClickArea(64, 0, 32, 48, OnClickRightHand));
			AddControl(new ClickArea(64, 128, 32, 48, OnClickLeftHand));
			AddControl(new ClickGridArea(120, 0, 2, 1, OnClickRightLeg));
			AddControl(new ClickGridArea(120, 128, 2, 1, OnClickLeftLeg));
			AddControl(new ClickGridArea(40, 192, 3, 3, OnClickBackPack));
			AddControl(new ClickGridArea(104, 192, 4, 2, OnClickBelt));
			AddControl(new ClickGridArea(152, 0, 20, 3, OnClickGround));

			//TODO: When in battle, show TUs
			//AddControl(new Label(24, 250, "TUs>", Font.Normal, ColorScheme.Green));
			//AddControl(new DynamicLabel(24, 270, () => $"{soldier.TimeUnits}", Font.Normal, ColorScheme.Orange));

			AddControl(new Overlay(soldier.Soldier.Paperdoll, 4));
		}

		private BattleItem[,] CurrentGroundView => groundViews[groundViewIndex];

		private void CalculateGroundViews()
		{
			groundViews.Clear();
			groundViewIndex = 0;
			var remainingItems = ground.ToList();
			while (remainingItems.Any())
				groundViews.Add(CreateGroundView(remainingItems));
			var emptyView = CreateGroundView(remainingItems);
			groundViews.Add(emptyView);
		}

		private static BattleItem[,] CreateGroundView(List<BattleItem> items)
		{
			var groundView = new BattleItem[3, 20];
			FillGroundView(groundView, items, 0, 0, 20, 3);
			return groundView;
		}

		private static void FillGroundView(BattleItem[,] groundView, List<BattleItem> items, int row, int column, int maxWidth, int maxHeight)
		{
			if (maxWidth == 0 || maxHeight == 0 || !items.Any())
				return;
			for (var width = maxWidth; width > 0; --width)
			{
				for (var height = maxHeight; height > 0; --height)
				{
					var matchingItem = items.FirstOrDefault(item => item.Width == width && item.Height == height);
					if (matchingItem == null)
						continue;
					groundView[row, column] = matchingItem;
					items.Remove(matchingItem);
					FillGroundView(groundView, items, row + height, column, width, maxHeight - height);
					FillGroundView(groundView, items, row, column + width, maxWidth - width, maxHeight);
					return;
				}
			}
		}

		public override void Render(GraphicsBuffer buffer)
		{
			base.Render(buffer);
			DrawGridLines(buffer);
			DrawSoldierItems(buffer);
			DrawBattleItems(buffer, CurrentGroundView, 152, 0);
			DrawSelection(buffer);
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

		private void DrawSoldierItems(GraphicsBuffer buffer)
		{
			DrawBattleItems(buffer, soldier.RightShoulder, 40, 16);
			DrawBattleItems(buffer, soldier.LeftShoulder, 40, 112);
			DrawCenteredBattleItem(buffer, soldier.RightHand, 64, 0);
			DrawCenteredBattleItem(buffer, soldier.LeftHand, 64, 128);
			DrawBattleItems(buffer, soldier.RightLeg, 120, 0);
			DrawBattleItems(buffer, soldier.LeftLeg, 120, 128);
			DrawBattleItems(buffer, soldier.BackPack, 40, 192);
			DrawBattleItems(buffer, soldier.Belt, 104, 192);
		}

		private static void DrawCenteredBattleItem(GraphicsBuffer buffer, BattleItem item, int topRow, int leftColumn)
		{
			if (item == null)
				return;
			var top = topRow + (3 - item.Height) * 16 / 2;
			var left = leftColumn + (2 - item.Width) * 16 / 2;
			buffer.DrawItem(top, left, item.Image);
		}

		private static void DrawBattleItems(GraphicsBuffer buffer, BattleItem[,] items, int topRow, int leftColumn)
		{
			foreach (var row in Enumerable.Range(0, items.GetLength(0)))
				foreach (var column in Enumerable.Range(0, items.GetLength(1)))
				{
					var item = items[row, column];
					if (item != null)
						buffer.DrawItem(topRow + row * 16, leftColumn + column * 16, item.Image);
				}
		}

		private static void DrawBattleItems(GraphicsBuffer buffer, BattleItem[] items, int topRow, int leftColumn)
		{
			foreach (var column in Enumerable.Range(0, items.Length))
			{
				var item = items[column];
				if (item != null)
					buffer.DrawItem(topRow, leftColumn + column * 16, item.Image);
			}
		}

		private void DrawSelection(GraphicsBuffer buffer)
		{
			if (selection == null)
				return;

			Font.Normal.DrawString(buffer, 20, 0, selection.Name, ColorScheme.Green);

			if (selection.Rounds > 0)
			{
				Font.Normal.DrawString(buffer, 64, 272, "AMMO:", ColorScheme.Green);
				Font.Normal.DrawString(buffer, 72, 272, "ROUNDS", ColorScheme.Green);
				Font.Normal.DrawString(buffer, 80, 272, "LEFT=", ColorScheme.Green);
				Font.Normal.DrawString(buffer, 80, 298, $"{selection.Rounds}", ColorScheme.Orange);
				buffer.DrawFrame(88, 272, 32, 48, Color.Gray);
				var ammunitionItem = selection.Ammunition == null ? selection : new BattleItem { Item = selection.Ammunition };
				DrawCenteredBattleItem(buffer, ammunitionItem, 88, 272);
			}

			var cursor = GameState.Current.PointerPosition;
			var width = selection.Width * 16;
			var height = selection.Height * 16;
			buffer.DrawItem(cursor.Y - height / 2, cursor.X - width / 2, selection.Image);
		}

		private static void OnOk()
		{
			//TODO:
			Environment.Exit(0);
		}

		private void OnPreviousSoldier()
		{
			//TODO: when in battle, use ground items at soldiers position
			GameState.Current.SetScreen(new Inventory(battle, battle.PreviousSoldier(soldier), ground));
		}

		private void OnNextSoldier()
		{
			//TODO: when in battle, use ground items at soldiers position
			GameState.Current.SetScreen(new Inventory(battle, battle.NextSoldier(soldier), ground));
		}

		private void OnUnloadWeapon()
		{
			var selectionIsLoadedWeapon = selection?.Ammunition != null;
			var bothHandsAreEmpty = soldier.RightHand == null && soldier.LeftHand == null;
			var canUnloadWeapon = selectionIsLoadedWeapon && bothHandsAreEmpty;
			if (!canUnloadWeapon)
				return;

			//TODO: when in battle, check remaining TUs and consume them if enough

			soldier.LeftHand = new BattleItem
			{
				Item = selection.Ammunition,
				Ammunition = null,
				Rounds = selection.Rounds
			};

			soldier.RightHand = selection;
			selection.Ammunition = null;
			selection.Rounds = 0;
			selection = null;

			BattlescapeSoundEffect.Reload.Play();
		}

		private void OnNextGroundView()
		{
			var currentIndex = groundViewIndex;
			CalculateGroundViews();
			groundViewIndex = (currentIndex + 1) % groundViews.Count;
		}

		private void OnClickRightShoulder(int row, int column)
		{
		}

		private void OnClickLeftShoulder(int row, int column)
		{
		}

		private void OnClickRightHand()
		{
			if (selection == null && soldier.RightHand != null)
			{
				selection = soldier.RightHand;
				selectionSource = InventoryLocation.RightHand;
				soldier.RightHand = null;
			}
			else if (selection != null && soldier.RightHand == null)
			{
				//TODO: check TUs in battle
				soldier.RightHand = selection;
				selection = null;
				BattlescapeSoundEffect.ItemDrop.Play();
			}
			else if (selection != null && soldier.RightHand != null)
			{
				//TODO: check TUs in battle
				if (!soldier.RightHand.CanLoadWith(selection))
					return;
				soldier.RightHand.Ammunition = (AmmunitionType)selection.Item;
				soldier.RightHand.Rounds = selection.Rounds;
				selection = null;
				BattlescapeSoundEffect.Reload.Play();
			}
		}

		private void OnClickLeftHand()
		{
			if (selection == null && soldier.LeftHand != null)
			{
				selection = soldier.LeftHand;
				selectionSource = InventoryLocation.LeftHand;
				soldier.LeftHand = null;
			}
			else if (selection != null && soldier.LeftHand == null)
			{
				//TODO: check TUs in battle
				soldier.LeftHand = selection;
				selection = null;
				BattlescapeSoundEffect.ItemDrop.Play();
			}
			else if (selection != null && soldier.LeftHand != null)
			{
				//TODO: check TUs in battle
				if (!soldier.LeftHand.CanLoadWith(selection))
					return;
				soldier.LeftHand.Ammunition = (AmmunitionType)selection.Item;
				soldier.LeftHand.Rounds = selection.Rounds;
				selection = null;
				BattlescapeSoundEffect.Reload.Play();
			}
		}

		private void OnClickRightLeg(int row, int column)
		{
		}

		private void OnClickLeftLeg(int row, int column)
		{
		}

		private void OnClickBackPack(int row, int column)
		{
			if (selection == null)
			{
				selectionSource = InventoryLocation.BackPack;
				selection = SelectItem(soldier.BackPack, row, column);
			}
			else
			{
				var dropLocation = GetDropLocation(soldier.BackPack, row, column, selection);
				if (dropLocation == null)
					return;
				soldier.BackPack[dropLocation.Value.Y, dropLocation.Value.X] = selection;
				selection = null;
				BattlescapeSoundEffect.ItemDrop.Play();
			}
		}

		private void OnClickBelt(int row, int column)
		{
		}

		private void OnClickGround(int row, int column)
		{
			if (selection == null)
			{
				selectionSource = InventoryLocation.Ground;
				selection = SelectItem(CurrentGroundView, row, column);
				if (selection != null)
					ground.Remove(selection);
			}
			else
			{
				var dropLocation = GetDropLocation(CurrentGroundView, row, column, selection);
				if (dropLocation == null)
					return;
				CurrentGroundView[dropLocation.Value.Y, dropLocation.Value.X] = selection;
				ground.Add(selection);
				selection = null;
				BattlescapeSoundEffect.ItemDrop.Play();
			}
		}

		private static Point?[,] GetClickTargets(BattleItem[,] items)
		{
			var rows = items.GetLength(0);
			var columns = items.GetLength(1);
			var targets = new Point?[rows, columns];
			foreach (var row in Enumerable.Range(0, rows))
			{
				foreach (var column in Enumerable.Range(0, columns))
				{
					var item = items[row, column];
					if (item == null)
						continue;
					foreach (var rowOffset in Enumerable.Range(0, item.Height))
						foreach (var columnOffset in Enumerable.Range(0, item.Width))
							targets[row + rowOffset, column + columnOffset] = new Point { X = column, Y = row };
				}
			}
			return targets;
		}

		private static Point? GetDropLocation(BattleItem[,] items, int row, int column, BattleItem item)
		{
			var targets = GetClickTargets(items);
			var itemWidth = item.Width;
			var itemHeight = item.Height;
			var width = items.GetLength(1);
			var height = items.GetLength(0);
			foreach (var rowOffset in Enumerable.Range(0, itemHeight))
				foreach (var columnOffset in Enumerable.Range(0, itemWidth))
				{
					var dropRow = row - rowOffset;
					var dropColumn = column - columnOffset;
					if (CanDropHere(targets, dropRow, dropColumn, itemWidth, itemHeight, width, height))
						return new Point { X = dropColumn, Y = dropRow };
				}
			return null;
		}

		private static bool CanDropHere(
			Point?[,] targets,
			int dropRow,
			int dropColumn,
			int itemWidth,
			int itemHeight,
			int width,
			int height)
		{
			if (dropRow < 0 ||
				dropColumn < 0 ||
				dropRow + itemHeight > height ||
				dropColumn + itemWidth > width)
				return false;
			return Enumerable.Range(dropRow, itemHeight).All(row =>
				Enumerable.Range(dropColumn, itemWidth).All(column =>
					targets[row, column] == null));
		}

		private static BattleItem SelectItem(BattleItem[,] items, int row, int column)
		{
			var target = GetClickTargets(items)[row, column];
			if (target == null)
				return null;
			var item = items[target.Value.Y, target.Value.X];
			items[target.Value.Y, target.Value.X] = null;
			return item;
		}
	}
}
