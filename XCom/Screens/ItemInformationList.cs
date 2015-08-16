using System.Collections.Generic;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class ItemInformationList : Screen
	{
		public ItemInformationList()
		{
			AddControl(new Border(10, 32, 256, 180, ColorScheme.Green, Backgrounds.Title, 0));
			AddControl(new Label(24, Label.Center, "SELECT ITEM", Font.Large, ColorScheme.Yellow));

			var items = new List<ItemType>{ ItemType.LaserPistol }; //TODO: full list of researched/available items
			AddControl(new ListView<ItemType>(50, 40, 14, items, ColorScheme.Aqua, Palette.GetPalette(12).GetColor(230), OnSelectItem)
				.AddColumn(224, Alignment.Center, item => item.Metadata().Name));

			AddControl(new Button(166, 48, 224, 16, "OK", ColorScheme.Green, Font.Normal, OnOk));
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(new Information());
		}

		private void OnSelectItem(ItemType item)
		{
			GameState.Current.SetScreen(new ItemInformation(this, item));
		}
	}
}
