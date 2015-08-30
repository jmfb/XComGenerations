using System;
using System.Collections.Generic;
using System.Linq;

namespace XCom.Data
{
	public class MonthlyReportCard
	{
		public DateTime Month { get; set; }
		public int Score { get; set; }
		public int FundingChange { get; set; }
		public List<Country> HappyCountries { get; set; }
		public List<Country> UnhappyCountries { get; set; }
		public List<Country> CountriesThatSignedPactsWithAliens { get; set; }

		public static MonthlyReportCard ScoreMonth(DateTime month)
		{
			var data = GameState.Current.Data;
			var happyCountries = data.Countries.Where(country => country.Satisfaction == CountrySatisfaction.Happy).ToList();
			var unhappyCountries = data.Countries.Where(country => country.Satisfaction == CountrySatisfaction.Unhappy).ToList();
			var countriesThatSignedPactsWithAliens = data.Countries
				.Where(country => country.Satisfaction == CountrySatisfaction.SignedAlienPact && !country.SignedAlienPact)
				.ToList();
			foreach (var country in data.Countries)
				country.UpdateFunding();
			return new MonthlyReportCard
			{
				Month = month,
				Score = data.ThisMonthsScore,
				FundingChange = data.Countries.Sum(country => country.FundingChange),
				HappyCountries = happyCountries,
				UnhappyCountries = unhappyCountries,
				CountriesThatSignedPactsWithAliens = countriesThatSignedPactsWithAliens
			};
		}

		public string Status =>
			Score <= -200 ? "Terrible" :
			Score <= 0 ? "Poor" :
			Score <= 200 ? "OK" :
			Score <= 500 ? "Good" :
			"Excellent";
	}
}
