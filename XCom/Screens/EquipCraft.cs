using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Modals;

namespace XCom.Screens
{
	public class EquipCraft : Screen
	{
		private readonly Craft craft;

		public EquipCraft(Craft craft)
		{
			this.craft = craft;
			var metadata = craft.CraftType.Metadata();

			AddControl(new Border(0, 0, 320, 200, ColorScheme.Blue, Backgrounds.EquipCraft, 9));
			AddControl(new Label(8, Label.Center, craft.Name, Font.Large, ColorScheme.Blue));
			AddControl(new Label(24, 24, "DAMAGE>", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(24, 59, craft.GetDamagePercent().FormatPercent(), Font.Normal, ColorScheme.White));
			AddControl(new Label(24, 232, "FUEL>", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(24, 255, craft.GetFuelPercent().FormatPercent(), Font.Normal, ColorScheme.White));
			AddControl(new Picture(35 + metadata.RowOffset, 125 + metadata.ColumnOffset, metadata.Image));

			if (metadata.WeaponCount >= 1)
				AddControl(new Button(48, 24, 24, 36, "1", ColorScheme.Blue, Font.Normal, OnWeapon1));
			if (metadata.WeaponCount >= 2)
				AddControl(new Button(48, 271, 24, 36, "2", ColorScheme.Blue, Font.Normal, OnWeapon2));
			AddControl(new CraftWeaponPreview(craft));

			if (metadata.Space > 0)
			{
				AddControl(new Button(96, 24, 64, 16, "CREW", ColorScheme.Blue, Font.Normal, OnClickCrew));
				AddControl(new Button(120, 24, 64, 16, "EQUIPMENT", ColorScheme.Blue, Font.Normal, OnClickEquipment));
				AddControl(new Button(144, 24, 64, 16, "ARMOR", ColorScheme.Blue, Font.Normal, OnClickArmor));
			}
			AddControl(new CraftCargoPreview(craft));

			AddControl(new Button(168, 128, 64, 24, "OK", ColorScheme.Blue, Font.Normal, OnOk));
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(new CraftList());
		}

		private void OnWeapon1()
		{
			new SelectCraftWeapon(craft, 0).DoModal(this);
		}

		private void OnWeapon2()
		{
			new SelectCraftWeapon(craft, 1).DoModal(this);
		}

		private void OnClickCrew()
		{
			GameState.Current.SetScreen(new CraftSoldiers(craft));
		}

		private static void OnClickEquipment()
		{
			//TODO:
		}

		private void OnClickArmor()
		{
			GameState.Current.SetScreen(new CraftArmor(craft));
		}
	}
}
