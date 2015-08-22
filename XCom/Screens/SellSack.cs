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
		private readonly Dictionary<ItemType, int> itemsToSell = Enum.GetValues(typeof(ItemType)).Cast<ItemType>().ToDictionary(item => item, item => 0);

		public SellSack()
		{
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

			var data = new List<ItemType> { ItemType.PersonalArmor, ItemType.PowerSuit, ItemType.FlyingSuit }; //TODO: real items in stores

			AddControl(new ListView<ItemType>(45, 10, 24, data, ColorScheme.Blue, Palette.GetPalette(6).GetColor(230), OnSellItem)
				.ConfigureUpDown(195, OnCancelSellItem)
				.AddColumn(155, Alignment.Left, item => item.Metadata().Name)
				.AddColumn(64, Alignment.Left, item => GetRemaining(item).FormatNumber())
				.AddColumn(28, Alignment.Left, item => itemsToSell[item].FormatNumber())
				.AddColumn(40, Alignment.Left, item => "$" + item.Metadata().SalePrice.FormatNumber()));

			AddControl(new Button(176, 8, 148, 16, "Sell/Sack", ColorScheme.Blue, Font.Normal, OnSellSack));
			AddControl(new Button(176, 164, 148, 16, "Cancel", ColorScheme.Blue, Font.Normal, OnCancel));
		}

		private int GetRemaining(ItemType item)
		{
			return GameState.SelectedBase.Stores[item] - itemsToSell[item];
		}

		private void OnSellItem(ItemType item)
		{
			if (GetRemaining(item) > 0)
				++itemsToSell[item];
		}

		private void OnCancelSellItem(ItemType item)
		{
			if (itemsToSell[item] > 0)
				--itemsToSell[item];
		}

		private int TotalSalePrice => itemsToSell.Sum(item => item.Key.Metadata().SalePrice * item.Value);

		private void OnSellSack()
		{
			//TODO:
		}

		private static void OnCancel()
		{
			GameState.Current.SetScreen(new Base());
		}
	}
}
