using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class SelectArmor : Screen
	{
		private readonly Soldier soldier;

		public SelectArmor(Soldier soldier)
		{
			this.soldier = soldier;
			AddControl(new Border(40, 64, 192, 134, ColorScheme.Blue, Backgrounds.EquipCraft, 10));
			AddControl(new Label(48, Label.Center, "SELECT ARMOR FOR", Font.Normal, ColorScheme.DarkYellow));
			AddControl(new Label(56, Label.Center, soldier.Name, Font.Normal, ColorScheme.DarkYellow));
			AddControl(new Label(72, 96, "TYPE", Font.Normal, ColorScheme.DarkYellow));
			AddControl(new Label(72, 176, "QUANTITY", Font.Normal, ColorScheme.DarkYellow));
			AddControl(new Button(88, 80, 100, 14, "NONE", ColorScheme.DarkYellow, Font.Normal, OnNone));

			var nextTopRow = 104;
			foreach (var armorType in new[]{ ArmorType.PersonalArmor, ArmorType.PowerSuit, ArmorType.FlyingSuit })
			{
				var count = GameState.SelectedBase.Stores.Armor.CountOf(armorType);
				if (count <= 0)
					continue;
				var localArmorType = armorType;
				var topRow = nextTopRow;
				nextTopRow += 16;
				AddControl(new Button(topRow, 80, 100, 14, armorType.Metadata().Name, ColorScheme.DarkYellow, Font.Normal, () => OnEquipArmor(localArmorType)));
				AddControl(new Label(topRow, 216, count.FormatNumber(), Font.Large, ColorScheme.White));
			}

			AddControl(new Button(154, 135, 50, 12, "CANCEL", ColorScheme.DarkYellow, Font.Normal, EndModal));
		}

		private void OnNone()
		{
			ReturnSoldierArmor();
			soldier.Armor = null;
			EndModal();
		}

		private void OnEquipArmor(ArmorType armorType)
		{
			ReturnSoldierArmor();
			GameState.SelectedBase.Stores.Armor.Remove(armorType);
			soldier.Armor = armorType;
			EndModal();
		}

		private void ReturnSoldierArmor()
		{
			if (soldier.Armor != null)
				GameState.SelectedBase.Stores.Armor.Add(soldier.Armor.Value);
		}
	}
}
