using System;
using System.Linq;
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
				//You have not succeeded in dealing with the alien invasion and the council of funding nations has regrettably decided to terminate the project. Each nation shall deal with the problem as they see fit. We can only hope that we can come to some accommodation with these apparently hostile forces, and that the general population will come to terms with the alien visitors.
				GameState.Current.SetScreen(new MainMenu());
				return;
			}

			//TODO: remove this test code
			Countries.Single(country => country.CountryType == CountryType.UnitedStates).Satisfaction = CountrySatisfaction.Happy;
			Countries.Single(country => country.CountryType == CountryType.UnitedKingdom).Satisfaction = CountrySatisfaction.Happy;
			Countries.Single(country => country.CountryType == CountryType.China).Satisfaction = CountrySatisfaction.Happy;
			Countries.Single(country => country.CountryType == CountryType.Germany).Satisfaction = CountrySatisfaction.Unhappy;
			Countries.Single(country => country.CountryType == CountryType.Russia).Satisfaction = CountrySatisfaction.Unhappy;
			Countries.Single(country => country.CountryType == CountryType.Australia).Satisfaction = CountrySatisfaction.SignedAlienPact;

			Funds += TotalFunding - TotalMonthlyCosts;
			if (Funds < 0)
			{
				//TODO: Lose game on money (normal version gives you a second chance)
				//The funding council is not happy with your financial position. You must reduce your debts below $2million or the project will be terminated.
				GameState.Current.SetScreen(new MainMenu());
				return;
			}

			var reportCard = MonthlyReportCard.ScoreMonth(LastMonth);

			LastMonthsScore = ThisMonthsScore;
			ThisMonthsScore = 0;

			GameState.Current.SetScreen(new MonthlyReport(reportCard));
		}

		private DateTime LastMonth => new DateTime(Time.Year, Time.Month, 1).AddMonths(-1);

		private int BadScore => -900 + Difficulty * 100;
	}
}
