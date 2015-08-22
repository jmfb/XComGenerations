using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class SellSack : Screen
	{
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

			//TODO: list of shit in stores

			AddControl(new Button(176, 8, 148, 16, "Sell/Sack", ColorScheme.Blue, Font.Normal, OnSellSack));
			AddControl(new Button(176, 164, 148, 16, "Cancel", ColorScheme.Blue, Font.Normal, OnCancel));
		}

		private int TotalSalePrice => 0; //TODO:

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
