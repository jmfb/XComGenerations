using System;
using System.Collections.Generic;
using System.Linq;

namespace XCom.Data
{
	public class MonthlyReportCard
	{
		public DateTime Month { get; private set; }
		public int Score { get; private set; }
		public int FundingChange { get; private set; }
		private List<Country> HappyCountries { get; set; }
		private List<Country> UnhappyCountries { get; set; }
		private List<Country> CountriesThatSignedPactsWithAliens { get; set; }

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

		private ScoreType ScoreType => Enum.GetValues(typeof(ScoreType)).Cast<ScoreType>().First(scoreType => Score < scoreType.Metadata().MaxMonthlyPoints);
		public string Status => ScoreType.Metadata().Name;
		private string Description => ScoreType.Metadata().Description;

		private static string GetCountryList(IReadOnlyList<Country> countries)
		{
			if (!countries.Any())
				return "";
			if (countries.Count == 1)
				return countries[0].Name;
			var commaSeparatedCountries = string.Join(", ", countries.Take(countries.Count - 1).Select(country => country.Name));
			return $"{commaSeparatedCountries} and {countries.Last().Name}";
		}

		private static string PluralizeText(IReadOnlyList<Country> countries, string singularText, string pluralText)
		{
			if (!countries.Any())
				return "";
			return countries.Count == 1 ?
				$"{countries[0]}{singularText}" :
				$"{GetCountryList(countries)}{pluralText}";
		}

		private const string singularHappyText = " is particularly pleased with your ability to deal with the localized threat and has agreed to increase its funding.";
		private const string pluralHappyText = " are particularly happy with your progress in dealing with local alien incursion and have agreed to increase their funding.";
		private string HappyText => PluralizeText(HappyCountries, singularHappyText, pluralHappyText);

		private const string singularUnhappyText = " is unhappy with your ability to deal with alien activity in its territory and has decided to reduce its financial commitment.";
		private const string pluralUnhappyText = " are unhappy with your ability to deal with alien activity in their territory and have decided to reduce their funding.";
		private string UnhappyText => PluralizeText(UnhappyCountries, singularUnhappyText, pluralUnhappyText);

		private const string singularAlienPactText = " has signed a secret pact with unknown alien forces and has withdrawn from the project.";
		private const string pluralAlienPactText = " have signed a secret pact with unknown alien forces and have withdrawn from the project.";
		private string AlienPactText => PluralizeText(CountriesThatSignedPactsWithAliens, singularAlienPactText, pluralAlienPactText);

		public IEnumerable<string> ReportParagraphs
		{
			get
			{
				yield return Description;
				if (HappyCountries.Any())
					yield return HappyText;
				if (UnhappyCountries.Any())
					yield return UnhappyText;
				if (CountriesThatSignedPactsWithAliens.Any())
					yield return AlienPactText;
			}
		}
	}
}
