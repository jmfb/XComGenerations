using System;
using System.Collections.Generic;
using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class SelectCraftWeapon : Screen
	{
		private readonly Craft craft;
		private readonly int weaponSlot;

		public SelectCraftWeapon(Craft craft, int weaponSlot)
		{
			this.craft = craft;
			this.weaponSlot = weaponSlot;
			AddControl(new Border(20, 50, 220, 160, ColorScheme.Purple, Backgrounds.EquipCraft, 10));
			AddControl(new Label(28, Label.Center, "Select Armament", Font.Large, ColorScheme.Purple));
			AddControl(new Label(52, 66, "ARMAMENT", Font.Normal, ColorScheme.Purple));
			AddControl(new Label(52, 145, "QUANTITY", Font.Normal, ColorScheme.Purple));
			AddControl(new Label(44, 195, "AMMUNITION", Font.Normal, ColorScheme.Purple));
			AddControl(new Label(52, 195, "AVAILABLE", Font.Normal, ColorScheme.Purple));
			AddControl(new ListView<CraftWeaponType>(68, 58, 10, AvailableCraftWeapons, ColorScheme.Blue, Palette.GetPalette(10).GetColor(230), OnSelectCraftWeapon)
				.AddColumn(8, Alignment.Left, item => "")
				.AddColumn(94, Alignment.Left, GetName)
				.AddColumn(50, Alignment.Left, item => GetAvailableQuantity(item).FormatNumber())
				.AddColumn(36, Alignment.Left, item => GetAvailableAmmo(item)?.FormatNumber() ?? "N.A."));
			AddControl(new Button(156, 90, 140, 16, "CANCEL", ColorScheme.Purple, Font.Normal, EndModal));
		}

		private static List<CraftWeaponType> AvailableCraftWeapons => Enum.GetValues(typeof(CraftWeaponType)).Cast<CraftWeaponType>()
			.Where(weapon => GameState.SelectedBase.Stores[weapon.Metadata().Item] > 0)
			.ToList();

		private static string GetName(CraftWeaponType weapon)
		{
			return weapon.Metadata().Name;
		}

		private static int GetAvailableQuantity(CraftWeaponType weapon)
		{
			return GameState.SelectedBase.Stores[weapon.Metadata().Item];
		}

		private static int? GetAvailableAmmo(CraftWeaponType weapon)
		{
			var ammo = weapon.Metadata().Ammo;
			if (ammo == null)
				return null;
			return GameState.SelectedBase.Stores[ammo.Value];
		}

		private void OnSelectCraftWeapon(CraftWeaponType weapon)
		{
			var stores = GameState.SelectedBase.Stores;
			stores.Remove(weapon.Metadata().Item);
			if (weaponSlot < craft.Weapons.Count)
			{
				var oldWeapon = craft.Weapons[weaponSlot];
				var oldWeaponMetadata = oldWeapon.WeaponType.Metadata();
				stores.Add(oldWeaponMetadata.Item);
				if (oldWeaponMetadata.Ammo != null)
					stores.Add(oldWeaponMetadata.Ammo.Value, oldWeapon.Ammunition / oldWeaponMetadata.RoundsInAmmo);
				craft.Weapons[weaponSlot] = CraftWeapon.CreateUnloaded(weapon);
			}
			else
			{
				craft.Weapons.Add(CraftWeapon.CreateUnloaded(weapon));
			}
			if (weapon != CraftWeaponType.LaserBeam && craft.Status == CraftStatus.Ready)
				craft.Status = CraftStatus.Rearming;
			EndModal();
		}
	}
}
