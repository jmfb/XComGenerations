using System.Collections.Generic;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class ItemsArriving : Screen
	{
		public ItemsArriving(List<CompletedTransfer> completedTransfers)
		{
			AddControl(new Border(10, 0, 320, 180, ColorScheme.Aqua, Backgrounds.Funds, 6));
			AddControl(new Label(18, Label.Center, "Items Arriving", Font.Large, ColorScheme.Aqua));
			AddControl(new Label(34, 10, "ITEM", Font.Normal, ColorScheme.Aqua));
			AddControl(new Label(34, 150, "QUANTITY", Font.Normal, ColorScheme.Aqua));
			AddControl(new Label(34, 205, "Destination", Font.Normal, ColorScheme.Aqua));
			AddControl(new ListView<CompletedTransfer>(50, 10, 13, completedTransfers, ColorScheme.Aqua, Palette.GetPalette(6).GetColor(230), item => EndModal())
				.AddColumn(2, Alignment.Left, item => "")
				.AddColumn(175, Alignment.Left, item => item.Name, item => ColorScheme.DarkYellow)
				.AddColumn(25, Alignment.Left, item => item.Quantity.FormatNumber(), item => ColorScheme.DarkYellow)
				.AddColumn(95, Alignment.Left, item => item.Destination, item => ColorScheme.DarkYellow));
			AddControl(new Button(166, 8, 148, 16, "OK", ColorScheme.Aqua, Font.Normal, EndModal));
			AddControl(new Button(166, 160, 148, 16, "OK - 5 secs", ColorScheme.Aqua, Font.Normal, OnOkFiveSeconds));
		}

		private void OnOkFiveSeconds()
		{
			Geoscape.ResetGameSpeed();
			EndModal();
		}
	}
}
