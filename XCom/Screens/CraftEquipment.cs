using System;
using System.Collections.Generic;
using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Modals;

namespace XCom.Screens
{
	public class CraftEquipment : Screen
	{
		private readonly Craft craft;

		public CraftEquipment(Craft craft)
		{
			this.craft = craft;
			AddControl(new Border(0, 0, 320, 200, ColorScheme.LightMagenta, Backgrounds.Battle, 8));
			AddControl(new Label(8, 16, $"Equipment for {craft.Name}", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(24, 16, "SPACE AVAILABLE>", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new DynamicLabel(24, 94, () => craft.SpaceAvailable.FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(24, 130, "SPACE USED>", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new DynamicLabel(24, 184, () => craft.SpaceUsed.FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(32, 16, "ITEM", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(32, 160, "Stores", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new ListView<ItemType>(40, 8, 16, AvailableItems, ColorScheme.LightMagenta, Palette.GetPalette(8).GetColor(230), OnIncreaseItem)
				.ConfigureUpDown(210, OnDecreaseItem)
				.AddColumn(8, Alignment.Left, item => "")
				.AddColumn(154, Alignment.Left, GetName, GetColor)
				.AddColumn(86, Alignment.Left, item => GetStoreQuantity(item).FormatNumber(), GetColor)
				.AddColumn(40, Alignment.Left, item => GetCraftQuantity(item).FormatNumber(), GetColor));
			AddControl(new Button(176, 16, 288, 16, "OK", ColorScheme.LightMagenta, Font.Normal, OnOk));
		}

		private List<ItemType> AvailableItems => Enum.GetValues(typeof(ItemType)).Cast<ItemType>()
			.Where(item =>
				GameState.SelectedBase.Stores[item] + craft.Stores[item] > 0 &&
				(item.Metadata().HwpSpace > 0 || item.Metadata().IsEquipment) &&
				item.Metadata().IsRequiredResearchCompleted)
			.ToList();

		private void OnIncreaseItem(ItemType item)
		{
			if (GameState.SelectedBase.Stores[item] == 0)
				return;
			var hwpSpace = item.Metadata().HwpSpace;
			if (hwpSpace > craft.HwpSpaceAvailable || hwpSpace * 4 > craft.SpaceAvailable)
				return;
			if (craft.TotalItemCount == 80)
			{
				AbortEquipItem();
				new NoMoreEquipmentAllowed().DoModal(this);
				return;
			}
			GameState.SelectedBase.Stores.Remove(item);
			craft.Stores.Add(item);
		}

		private void OnDecreaseItem(ItemType item)
		{
			if (craft.Stores[item] == 0)
				return;
			if (item.Metadata().StorageSpace > GameState.SelectedBase.ItemSpaceAvailable)
			{
				AbortEquipItem();
				new NotEnoughStoreSpace(ColorScheme.LightMagenta, Backgrounds.Battle, 8).DoModal(this);
				return;
			}
			craft.Stores.Remove(item);
			GameState.SelectedBase.Stores.Add(item);
		}

		private void AbortEquipItem()
		{
			GetChildControls<ListView<ItemType>>().Single().AbortUpDown();
		}

		private ColorScheme GetColor(ItemType item)
		{
			if (craft.Stores[item] > 0)
				return ColorScheme.White;
			var isAmmo = item.Metadata().AmmoForWeapon != null;
			return isAmmo ? ColorScheme.Purple : ColorScheme.Blue;
		}

		private static string GetName(ItemType item)
		{
			var metadata = item.Metadata();
			var isAmmo = metadata.AmmoForWeapon != null;
			return isAmmo ? $" \t{metadata.Name}" : metadata.Name;
		}

		private static int GetStoreQuantity(ItemType item)
		{
			return GameState.SelectedBase.Stores[item];
		}

		private int GetCraftQuantity(ItemType item)
		{
			return craft.Stores[item];
		}

		private void OnOk()
		{
			GameState.Current.SetScreen(new EquipCraft(craft));
		}
	}
}
