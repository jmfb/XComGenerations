using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Modals;

namespace XCom.Screens
{
	public class CraftArmor : Screen
	{
		private readonly Craft craft;

		public CraftArmor(Craft craft)
		{
			this.craft = craft;
			AddControl(new Border(0, 0, 320, 200, ColorScheme.Blue, Backgrounds.EquipCraft, 10));
			AddControl(new Label(8, 16, $"Select Armor for {craft.Name}", Font.Large, ColorScheme.Blue));
			AddControl(new Label(32, 16, "NAME", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(32, 130, "CRAFT", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(32, 200, "ARMOR", Font.Normal, ColorScheme.Blue));
			var selectionColor = Palette.GetPalette(10).GetColor(230);
			AddControl(new ListView<Soldier>(40, 8, 16, GameState.SelectedBase.Soldiers, ColorScheme.Blue, selectionColor, OnSelectSoldier)
				.AddColumn(8, Alignment.Left, soldier => "")
				.AddColumn(114, Alignment.Left, soldier => soldier.Name, GetSoldierColor)
				.AddColumn(70, Alignment.Left, soldier => soldier.CraftName, GetSoldierColor)
				.AddColumn(96, Alignment.Left, soldier => soldier.ArmorName, GetSoldierColor));
			AddControl(new Button(176, 16, 288, 16, "OK", ColorScheme.Blue, Font.Normal, OnOk));
		}

		private void OnOk()
		{
			GameState.Current.SetScreen(new EquipCraft(craft));
		}

		private void OnSelectSoldier(Soldier soldier)
		{
			new SelectArmor(soldier).DoModal(this);
		}
		
		private ColorScheme GetSoldierColor(Soldier soldier)
		{
			var soldierCraft = soldier.Craft;
			if (soldierCraft == null)
				return ColorScheme.Blue;
			return ReferenceEquals(craft, soldierCraft) ?
				ColorScheme.White :
				ColorScheme.Purple;
		}
	}
}
