using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class BaseTransfers : Screen
	{
		public BaseTransfers()
		{
			AddControl(new Border(10, 16, 288, 180, ColorScheme.Purple, Backgrounds.Funds, 6));
			AddControl(new Label(18, Label.Center, "Transfers", Font.Large, ColorScheme.Purple));
			AddControl(new Label(34, 26, "ITEM", Font.Normal, ColorScheme.Purple));
			AddControl(new Label(34, 141, "QUANTITY", Font.Normal, ColorScheme.Purple));
			AddControl(new Label(34, 186, "Arrival Time (hours)", Font.Normal, ColorScheme.Purple));

			var transfers =
				GameState.SelectedBase.TransferredSoldiers.Cast<object>()
				.Concat(GameState.SelectedBase.TransferredCrafts)
				.Concat(GameState.SelectedBase.TransferredStores)
				.ToList();
			AddControl(new ListView<object>(50, 24, 14, transfers, ColorScheme.Blue, Palette.GetPalette(6).GetColor(230), transfer => EndModal())
				.AddColumn(2, Alignment.Left, transfer => "")
				.AddColumn(155, Alignment.Left, GetTransferName)
				.AddColumn(55, Alignment.Left, transfer => GetQuantity(transfer).FormatNumber())
				.AddColumn(45, Alignment.Left, transfer => GetArrivalTime(transfer).FormatNumber()));

			AddControl(new Button(166, 24, 272, 16, "OK", ColorScheme.Purple, Font.Normal, EndModal));
		}

		private static string GetTransferName(object transfer)
		{
			return (transfer as TransferItem<Soldier>)?.Item.Name ??
				(transfer as TransferItem<Craft>)?.Item.Name ??
				((TransferItem<StoreItem>)transfer).Item.ItemType.Metadata().Name;
		}

		private static int GetQuantity(object transfer)
		{
			if (transfer is TransferItem<Soldier> || transfer is TransferItem<Craft>)
				return 1;
			return ((TransferItem<StoreItem>)transfer).Item.Count;
		}

		private static int GetArrivalTime(object transfer)
		{
			return (transfer as TransferItem<Soldier>)?.HoursRemaining ??
				(transfer as TransferItem<Craft>)?.HoursRemaining ??
				((TransferItem<StoreItem>)transfer).HoursRemaining;
		}
	}
}
