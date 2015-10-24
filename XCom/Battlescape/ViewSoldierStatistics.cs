using XCom.Content.Overlays;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Battlescape
{
	public class ViewSoldierStatistics : Screen
	{
		private readonly Battle battle;

		public ViewSoldierStatistics(Battle battle, BattleSoldier soldier)
		{
			this.battle = battle;
			AddControl(new Overlay(Overlays.SoldierStatistics, 4));
			AddControl(new Label(4, Label.Center, $"{soldier.Rank} {soldier.Name}", Font.Large, ColorScheme.Green));
			AddRow(31, "TIME UNITS", soldier.TimeUnits, soldier.MaxTimeUnits, 48);
			AddRow(41, "ENERGY", soldier.Energy, soldier.MaxEnergy, 144);
			AddRow(51, "HEALTH", soldier.Health, soldier.MaxHealth, 32);
			AddRow(61, "FATAL WOUNDS", soldier.TotalFatalWounds, soldier.TotalFatalWounds, 32);
			AddRow(71, "BRAVERY", soldier.Bravery, soldier.Soldier.Statistics.Bravery, 247, 249);
			AddRow(81, "MORALE", soldier.Morale, soldier.MaxMorale, 247, 249);
			AddRow(91, "REACTIONS", soldier.Reactions, soldier.Soldier.Statistics.Reactions, 96);
			AddRow(101, "FIRING ACCURACY", soldier.FiringAccuracy, soldier.Soldier.Statistics.FiringAccuracy, 128);
			AddRow(111, "THROWING ACCURACY", soldier.ThrowingAccuracy, soldier.Soldier.Statistics.ThrowingAccuracy, 160);
			AddRow(121, "STRENGTH", soldier.Strength, soldier.Soldier.Statistics.Strength, 147);
			if (soldier.Soldier.HasPsiSkill)
			{
				AddRow(131, "PSIONIC STRENGTH", soldier.PsionicStrength, soldier.Soldier.Statistics.PsionicStrength, 176);
				AddRow(141, "PSIONIC SKLIL", soldier.PsionicSkill, soldier.Soldier.Statistics.PsionicSkill, 176);
			}
			AddRow(151, "FRONT ARMOR", soldier.FrontArmor, soldier.Soldier.FrontArmor, 1);
			AddRow(161, "LEFT ARMOR", soldier.LeftArmor, soldier.Soldier.LeftArmor, 1);
			AddRow(171, "RIGHT ARMOR", soldier.RightArmor, soldier.Soldier.RightArmor, 1);
			AddRow(181, "REAR ARMOR", soldier.RearArmor, soldier.Soldier.RearArmor, 1);
			AddRow(191, "UNDER ARMOR", soldier.UnderArmor, soldier.Soldier.UnderArmor, 1);
		}

		private void AddRow(int topRow, string label, int value, int maxValue, int fillColor, int? borderColor = null)
		{
			AddControl(new Label(topRow, 9, label, Font.Normal, ColorScheme.Green));
			AddControl(new Label(topRow, 150, $"{value}", Font.Normal, ColorScheme.DarkYellow));
			AddControl(new Bar(topRow + 1, 170, maxValue, 5, value, borderColor ?? (fillColor + 7), fillColor));
		}

		public override bool HitTest(int row, int column)
		{
			return true;
		}

		public override void OnRightButtonDown(int row, int column)
		{
			GameState.Current.SetScreen(new Battlescape(battle));
		}
	}
}
