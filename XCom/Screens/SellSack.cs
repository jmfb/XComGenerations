using System;
using System.Collections.Generic;
using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class SellSack : Screen
	{
		private readonly Dictionary<object, int> itemsToSell = new Dictionary<object, int>();

		public SellSack()
		{
			GatherItemsAvailableToSell();

			AddControl(new Border(0, 0, 320, 200, ColorScheme.Blue, Backgrounds.Funds, 6));
			AddControl(new Label(8, Label.Center, "Sell Items/Sack Personnel", Font.Large, ColorScheme.Blue));

			AddControl(new Label(24, 10, "VALUE OF SALES>", Font.Normal, ColorScheme.Blue));
			AddControl(new DynamicLabel(24, 88, () => "$" + TotalSalePrice.FormatNumber(), Font.Normal, ColorScheme.Blue));
			AddControl(new Label(24, 200, "FUNDS>", Font.Normal, ColorScheme.Blue));
			AddControl(new DynamicLabel(24, 234, () => "$" + GameState.Current.Data.Funds.FormatNumber(), Font.Normal, ColorScheme.Blue));

			AddControl(new Label(32, 10, "ITEM", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(32, 140, "QUANTITY", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(32, 184, "Sell/Sack", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(32, 280, "Value", Font.Normal, ColorScheme.Blue));

			AddControl(new ListView<object>(45, 10, 16, itemsToSell.Keys.ToList(), ColorScheme.Blue, Palette.GetPalette(6).GetColor(230), OnSellItem)
				.ConfigureUpDown(195, OnCancelSellItem)
				.AddColumn(155, Alignment.Left, GetName)
				.AddColumn(64, Alignment.Left, item => GetRemaining(item).FormatNumber())
				.AddColumn(28, Alignment.Left, item => itemsToSell[item].FormatNumber())
				.AddColumn(40, Alignment.Left, item => "$" + GetSalePrice(item).FormatNumber()));

			AddControl(new Button(176, 8, 148, 16, "Sell/Sack", ColorScheme.Blue, Font.Normal, OnSellSack));
			AddControl(new Button(176, 164, 148, 16, "Cancel", ColorScheme.Blue, Font.Normal, OnCancel));
		}

		private void GatherItemsAvailableToSell()
		{
			foreach (var soldier in GameState.SelectedBase.Soldiers.Where(soldier => soldier.GetCraft() == null))
				itemsToSell.Add(soldier, 0);
			if (GameState.SelectedBase.EngineersAvailable > 0)
				itemsToSell.Add(ItemType.Engineer, 0);
			if (GameState.SelectedBase.ScientistsAvailable > 0)
				itemsToSell.Add(ItemType.Scientist, 0);
			foreach (var craft in GameState.SelectedBase.Crafts.Where(craft => craft.Status != CraftStatus.Out))
				itemsToSell.Add(craft, 0);
			foreach (var item in GameState.SelectedBase.Stores.Items.Where(item => item.Count > 0))
				itemsToSell.Add(item, 0);
		}

		private static string GetName(object item)
		{
			var soldier = item as Soldier;
			if (soldier != null)
				return soldier.Name;
			if (item is ItemType)
				return ((ItemType)item).Metadata().Name;
			var craft = item as Craft;
			return craft != null ?
				craft.GetName() :
				((StoreItem)item).ItemType.Metadata().Name;
		}

		private int GetRemaining(object item)
		{
			var sellCount = itemsToSell[item];
			if (item is Soldier || item is Craft)
				return 1 - sellCount;
			if (item is ItemType && (ItemType)item == ItemType.Engineer)
				return GameState.SelectedBase.EngineersAvailable - sellCount;
			if (item is ItemType && (ItemType)item == ItemType.Scientist)
				return GameState.SelectedBase.ScientistsAvailable - sellCount;
			return ((StoreItem)item).Count - sellCount;
		}

		private static int GetSalePrice(object item)
		{
			return (item as StoreItem)?.ItemType.Metadata().SalePrice ?? 0;
		}

		private void OnSellItem(object item)
		{
			if (GetRemaining(item) > 0)
				++itemsToSell[item];
		}

		private void OnCancelSellItem(object item)
		{
			if (itemsToSell[item] > 0)
				--itemsToSell[item];
		}

		private int TotalSalePrice => itemsToSell.Sum(item => GetSalePrice(item.Key) * item.Value);

		private void OnSellSack()
		{
			var itemsBeingSold = itemsToSell.Where(item => item.Value > 0).Select(item => item.Key).ToList();
			foreach (var soldier in itemsBeingSold.OfType<Soldier>())
				GameState.SelectedBase.Soldiers.Remove(soldier);
			foreach (var craft in itemsBeingSold.OfType<Craft>())
				GameState.SelectedBase.Crafts.Remove(craft);
			foreach (var engineer in itemsBeingSold.OfType<ItemType>().Where(itemType => itemType == ItemType.Engineer))
				GameState.SelectedBase.EngineerCount -= itemsToSell[engineer];
			foreach (var scientist in itemsBeingSold.OfType<ItemType>().Where(itemType => itemType == ItemType.Scientist))
				GameState.SelectedBase.ScientistCount -= itemsToSell[scientist];
			foreach (var storeItem in itemsBeingSold.OfType<StoreItem>())
			{
				var sellCount = itemsToSell[storeItem];
				GameState.Current.Data.Funds += storeItem.ItemType.Metadata().SalePrice * sellCount;
				storeItem.Count -= sellCount;
			}
			GameState.Current.SetScreen(new Base());
		}

		private static void OnCancel()
		{
			GameState.Current.SetScreen(new Base());
		}
	}
}
