using System;
using XCom.Screens;

namespace XCom.Data
{
	public partial class GameData
	{
		private void PerformMonthlyUpdates()
		{
			Screen.Geoscape.ResetGameSpeed();

			if (LastMonthsScore <= BadScore && ThisMonthsScore <= BadScore)
			{
				//TODO: Lose game on score
				GameState.Current.SetScreen(new MainMenu());
				return;
			}

			var reportCard = MonthlyReportCard.ScoreMonth(LastMonth);
			Funds += TotalFunding - TotalMonthlyCosts;
			if (Funds < 0)
			{
				//TODO: Lose game on money (normal version gives you a second chance)
				GameState.Current.SetScreen(new MainMenu());
				return;
			}

			LastMonthsScore = ThisMonthsScore;
			ThisMonthsScore = 0;

			GameState.Current.SetScreen(new MonthlyReport(reportCard));
		}

		private DateTime LastMonth => new DateTime(Time.Year, Time.Month, 1).AddMonths(-1);

		private int BadScore => -900 + Difficulty * 100;
	}
}
