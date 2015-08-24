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
		private readonly Label spaceAvailable;
		private readonly Label spaceUsed;

		public CraftSoldiers(Craft craft)
		{
			this.craft = craft;
			AddControl(new Border(0, 0, 320, 200, ColorScheme.Purple, Backgrounds.Soldier, 8));
			AddControl(new Label(8, 16, "Select Squad for " + craft.Name, Font.Large, ColorScheme.Purple));
			AddControl(new Label(24, 16, "SPACE AVAILABLE>", Font.Normal, ColorScheme.Purple));
			spaceAvailable = new Label(24, 94, "", Font.Normal, ColorScheme.White);
			AddControl(spaceAvailable);
			AddControl(new Label(24, 130, "SPACE USED>", Font.Normal, ColorScheme.Purple));
			spaceUsed = new Label(24, 183, "", Font.Normal, ColorScheme.White);
			AddControl(spaceUsed);
			AddControl(new Label(32, 16, "NAME", Font.Normal, ColorScheme.Purple));
			AddControl(new Label(32, 130, "RANK", Font.Normal, ColorScheme.Purple));
			AddControl(new Label(32, 232, "CRAFT", Font.Normal, ColorScheme.Purple));
			var selectionColor = Palette.GetPalette(8).GetColor(230);
			AddControl(new ListView<Soldier>(40, 16, 16, GameState.SelectedBase.Soldiers, ColorScheme.Purple, selectionColor, OnClickSoldier)
				.AddColumn(114, Alignment.Left, soldier => soldier.Name, GetSoldierColor)
				.AddColumn(102, Alignment.Left, soldier => soldier.Rank.ToString(), GetSoldierColor)
				.AddColumn(64, Alignment.Left, soldier => soldier.GetCraftName(), GetSoldierColor));
			AddControl(new Button(176, 16, 288, 16, "OK", ColorScheme.Blue, Font.Normal, OnOk));
			UpdateSpaceAvailableAndUsed();
		}

		private void OnOk()
		{
			GameState.Current.SetScreen(new EquipCraft(craft));
		}

		private void OnClickSoldier(Soldier soldier)
		{
			var soldierCraft = soldier.GetCraft();
			if (soldierCraft == null)
				AddSoldierToCraft(soldier);
			else if (!ReferenceEquals(craft, soldierCraft))
				MoveSoldierToCraft(soldier, soldierCraft);
			else
				RemoveSoldierFromCraft(soldier);
			UpdateSpaceAvailableAndUsed();
		}

		private void AddSoldierToCraft(Soldier soldier)
		{
			if (IsSpaceAvailable)
				craft.SoldierIds.Add(soldier.Id);
		}

		private void MoveSoldierToCraft(Soldier soldier, Craft soldierCraft)
		{
			if (!IsSpaceAvailable)
				return;
			soldierCraft.SoldierIds.Remove(soldier.Id);
			craft.SoldierIds.Add(soldier.Id);
		}

		private void RemoveSoldierFromCraft(Soldier soldier)
		{
			craft.SoldierIds.Remove(soldier.Id);
		}

		private bool IsSpaceAvailable
		{
			get { return SpaceUsed < craft.CraftType.Metadata().Space; }
		}

		private int SpaceUsed
		{
			get
			{
				return craft.SoldierIds.Count; //TODO: HWPs
			}
		}

		private void UpdateSpaceAvailableAndUsed()
		{
			var space = craft.CraftType.Metadata().Space;
			var used = SpaceUsed;
			var available = space - used;
			spaceAvailable.Text = available.FormatNumber();
			spaceUsed.Text = used.FormatNumber();
		}

		private ColorScheme GetSoldierColor(Soldier soldier)
		{
			var soldierCraft = soldier.GetCraft();
			if (soldierCraft == null)
				return ColorScheme.Blue;
			return ReferenceEquals(craft, soldierCraft) ?
				ColorScheme.White :
				ColorScheme.Purple;
		}
	}
}
