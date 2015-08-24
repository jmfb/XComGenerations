using System;
using System.Globalization;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Modals;

namespace XCom.Screens
{
	public class SoldierView : Screen
	{
		private readonly Soldier soldier;
		private readonly Label armor;

		public SoldierView(Soldier soldier)
		{
			this.soldier = soldier;

			AddControl(new Background(Backgrounds.InfoSoldier, 1));
			AddControl(new Picture(4, 4, soldier.Rank.Image()));
			AddControl(new ClickToEdit(9, 40, 176, soldier.Name, Font.Large, ColorScheme.Blue, OnEditName));
			AddControl(new Button(33, 0, 28, 14, "<<", ColorScheme.Purple, Font.Normal, OnPreviousSoldier));
			AddControl(new Button(33, 30, 48, 14, "OK", ColorScheme.Purple, Font.Normal, OnOk));
			AddControl(new Button(33, 80, 28, 14, ">>", ColorScheme.Purple, Font.Normal, OnNextSoldier));
			AddControl(new Button(33, 130, 60, 14, "ARMOR", ColorScheme.Purple, Font.Normal, OnEditArmor));
			armor = new Label(38, 194, soldier.GetArmorName(), Font.Normal, ColorScheme.Purple);
			AddControl(armor);
			AddControl(new Label(48, 0, "RANK>", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(48, 29, soldier.Rank.ToString(), Font.Normal, ColorScheme.White));
			AddControl(new Label(48, 130, "MISSIONS>", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(48, 178, soldier.MissionCount.ToString(CultureInfo.InvariantCulture), Font.Normal, ColorScheme.White));
			AddControl(new Label(48, 230, "KILLS>", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(48, 261, soldier.KillCount.ToString(CultureInfo.InvariantCulture), Font.Normal, ColorScheme.White));
			AddControl(new Label(56, 0, "CRAFT>", Font.Normal, ColorScheme.Blue));
			var craft = soldier.GetCraft();
			var craftName = craft == null ? "NONE" : craft.Name;
			AddControl(new Label(56, 34, craftName, Font.Normal, ColorScheme.White));
			if (soldier.DaysUntilRecovered > 0)
			{
				AddControl(new Label(56, 130, "WOUND RECOVERY>", Font.Normal, ColorScheme.Blue));
				AddControl(new Label(56, 211, soldier.DaysUntilRecovered.FormatNumber() + " days", Font.Normal, ColorScheme.White));
			}

			if (soldier.InPsiTraining)
				AddControl(new Label(66, 0, "In Psionic Training", Font.Normal, ColorScheme.LightMagenta));

			AddRow(82, "TIME UNITS", statistics => statistics.TimeUnits, 48);
			AddRow(94, "STAMINA", statistics => statistics.Stamina, 144);
			AddRow(106, "HEALTH", statistics => statistics.Health, 32);
			AddRow(118, "BRAVERY", statistics => statistics.Bravery, 64);
			AddRow(130, "REACTIONS", statistics => statistics.Reactions, 96);
			AddRow(142, "FIRING ACCURACY", statistics => statistics.FiringAccuracy, 128);
			AddRow(154, "THROWING ACCURACY", statistics => statistics.ThrowingAccuracy, 160);
			AddRow(166, "STRENGTH", statistics => statistics.Strength, 80);
			if (!soldier.HasPsiSkill)
				return;
			AddRow(178, "PSIONIC STRENGTH", statistics => statistics.PsionicStrength, 176);
			AddRow(190, "PSIONIC SKILL", statistics => statistics.PsionicSkill, 176);
		}

		public override void OnSetFocus()
		{
			armor.Text = soldier.GetArmorName();
		}

		private void AddRow(
			int topRow,
			string label,
			Func<SoldierStatistics, int> property,
			int colorIndex)
		{
			AddControl(new SoldierInformationRow(
				topRow,
				label,
				property(soldier.OriginalStatistics),
				property(soldier.Statistics),
				colorIndex));
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(new Soldiers());
		}

		private void OnPreviousSoldier()
		{
			var soldierIndex = GameState.SelectedBase.Soldiers.IndexOf(soldier);
			var previousSoldierIndex = soldierIndex == 0 ?
				GameState.SelectedBase.Soldiers.Count - 1 :
				soldierIndex - 1;
			var previousSoldier = GameState.SelectedBase.Soldiers[previousSoldierIndex];
			GameState.Current.SetScreen(new SoldierView(previousSoldier));
		}

		private void OnNextSoldier()
		{
			var soldierIndex = GameState.SelectedBase.Soldiers.IndexOf(soldier);
			var nextSoldierIndex = (soldierIndex + 1) % GameState.SelectedBase.Soldiers.Count;
			var nextSoldier = GameState.SelectedBase.Soldiers[nextSoldierIndex];
			GameState.Current.SetScreen(new SoldierView(nextSoldier));
		}

		private void OnEditName(string name)
		{
			soldier.Name = name;
		}

		private void OnEditArmor()
		{
			new SelectArmor(soldier).DoModal(this);
		}
	}
}
