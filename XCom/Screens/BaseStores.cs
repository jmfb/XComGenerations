using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class BaseStores : Screen
	{
		public BaseStores()
		{
			AddControl(new Border(0, 0, 320, 200, ColorScheme.Blue, Backgrounds.Funds, 6));
			AddControl(new Label(8, Label.Center, "Stores", Font.Large, ColorScheme.Blue));
			AddControl(new Label(32, 10, "ITEM", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(32, 152, "QUANTITY", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(32, 240, "SPACE USED>", Font.Normal, ColorScheme.Blue));

			var data = GameState.SelectedBase.Stores.Items.Where(item => item.Count > 0).ToList();
			AddControl(new ListView<StoreItem>(40, 8, 16, data, ColorScheme.Blue, Palette.GetPalette(6).GetColor(230), OnSelectItem)
				.AddColumn(2, Alignment.Left, item => "")
				.AddColumn(162, Alignment.Left, item => item.ItemType.Metadata().Name)
				.AddColumn(92, Alignment.Left, item => item.Count.FormatNumber())
				.AddColumn(32, Alignment.Left, item => item.SpaceUsed.FormatNumber()));

			AddControl(new Button(176, 10, 300, 16, "OK", ColorScheme.Blue, Font.Normal, OnOk));
		}

		private static void OnSelectItem(StoreItem item)
		{
			GameState.Current.SetScreen(new BaseInformation());
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(new BaseInformation());
		}
	}
}
