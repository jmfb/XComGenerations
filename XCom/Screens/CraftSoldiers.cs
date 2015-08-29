using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class CraftSoldiers : Screen
	{
		private readonly Craft craft;

		public CraftSoldiers(Craft craft)
		{
			this.craft = craft;
			AddControl(new Border(0, 0, 320, 200, ColorScheme.Purple, Backgrounds.Soldier, 8));
			AddControl(new Label(8, 16, $"Select Squad for {craft.Name}", Font.Large, ColorScheme.Purple));
			AddControl(new Label(24, 16, "SPACE AVAILABLE>", Font.Normal, ColorScheme.Purple));
			AddControl(new DynamicLabel(24, 94, () => craft.SpaceAvailable.FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(24, 130, "SPACE USED>", Font.Normal, ColorScheme.Purple));
			AddControl(new DynamicLabel(24, 183, () => craft.SpaceUsed.FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(32, 16, "NAME", Font.Normal, ColorScheme.Purple));
			AddControl(new Label(32, 130, "RANK", Font.Normal, ColorScheme.Purple));
			AddControl(new Label(32, 232, "CRAFT", Font.Normal, ColorScheme.Purple));
			var selectionColor = Palette.GetPalette(8).GetColor(230);
			AddControl(new ListView<Soldier>(40, 16, 16, GameState.SelectedBase.Soldiers, ColorScheme.Purple, selectionColor, OnClickSoldier)
				.AddColumn(114, Alignment.Left, soldier => soldier.Name, GetSoldierColor)
				.AddColumn(102, Alignment.Left, soldier => $"{soldier.Rank}", GetSoldierColor)
				.AddColumn(64, Alignment.Left, soldier => soldier.CraftName, GetSoldierColor));
			AddControl(new Button(176, 16, 288, 16, "OK", ColorScheme.Blue, Font.Normal, OnOk));
		}

		private void OnOk()
		{
			GameState.Current.SetScreen(new EquipCraft(craft));
		}

		private void OnClickSoldier(Soldier soldier)
		{
			if (soldier.IsWounded)
				return;
			if (soldier.Craft == null)
				AddSoldierToCraft(soldier);
			else if (!ReferenceEquals(craft, soldier.Craft))
				MoveSoldierToCraft(soldier, soldier.Craft);
			else
				RemoveSoldierFromCraft(soldier);
		}

		private void AddSoldierToCraft(Soldier soldier)
		{
			if (craft.SpaceAvailable > 0)
				craft.SoldierIds.Add(soldier.Id);
		}

		private void MoveSoldierToCraft(Soldier soldier, Craft soldierCraft)
		{
			if (craft.SpaceAvailable == 0)
				return;
			soldierCraft.SoldierIds.Remove(soldier.Id);
			craft.SoldierIds.Add(soldier.Id);
		}

		private void RemoveSoldierFromCraft(Soldier soldier)
		{
			craft.SoldierIds.Remove(soldier.Id);
		}

		private ColorScheme GetSoldierColor(Soldier soldier)
		{
			return soldier.Craft == null ? ColorScheme.Blue :
				ReferenceEquals(craft, soldier.Craft) ? ColorScheme.White :
				ColorScheme.Purple;
		}
	}
}
