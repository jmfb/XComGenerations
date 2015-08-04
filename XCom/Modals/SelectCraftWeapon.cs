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
			//TODO: New List View of Craft Weapons
			//(68, 58, 10, stores.CraftWeapons.Items, ColorShceme.Blue, Palette(10)(230), OnSelectCraftWeapon)
			//8, left, ""
			//79, left, craftWeapon.Name
			//50, center, quantity
			//50, center, ammo
			AddControl(new Button(156, 90, 140, 16, "CANCEL", ColorScheme.Purple, Font.Normal, EndModal));
		}

		private void OnSelectCraftWeapon()
		{
			//Remove the weapon from the stores
			if (weaponSlot < craft.Weapons.Count)
			{
				//Put the current weapon/ammo back in the stores
				//Replace the weapon in the slot on the ship
			}
			else
			{
				//Add the weapon to the ship
				//NOTE: a requested slot 2 may go in slot 1
			}
			EndModal();
		}
	}
}
