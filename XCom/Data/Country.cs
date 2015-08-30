namespace XCom.Data
{
	public class Country
	{
		public CountryType CountryType { get; set; }
		public int Funding { get; set; }
		public int FundingChange { get; set; }
		public CountrySatisfaction Satisfaction { get; set; }
		public bool SignedAlienPact { get; set; }

		public string Name => CountryType.Metadata().Name;

		public static Country Create(CountryType countryType)
		{
			var metadata = countryType.Metadata();
			return new Country
			{
				CountryType = countryType,
				Funding = GameState.Current.Random.Next(metadata.MinStartingFunding, metadata.MaxStartingFunding) * 1000,
				Satisfaction = CountrySatisfaction.Average
			};
		}

		public void UpdateFunding()
		{
			Funding += FundingChange;
			switch (Satisfaction)
			{
			case CountrySatisfaction.Happy:
				IncreaseFunding();
				break;
			case CountrySatisfaction.Average:
				RetainFunding();
				break;
			case CountrySatisfaction.Unhappy:
				DecreaseFunding();
				break;
			case CountrySatisfaction.SignedAlienPact:
				SignAlienPact();
				break;
			}
		}

		private void IncreaseFunding()
		{
			Satisfaction = CountrySatisfaction.Average;
			FundingChange = GameState.Current.Random.Next(5, 20) * Funding / 100;
			var maxFunding = CountryType.Metadata().MaxFunding;
			if (Funding + FundingChange > maxFunding)
				FundingChange = maxFunding - Funding;
		}

		private void RetainFunding()
		{
			FundingChange = 0;
		}

		private void DecreaseFunding()
		{
			Satisfaction = CountrySatisfaction.Average;
			FundingChange = -GameState.Current.Random.Next(5, 20) * Funding / 100;
		}

		private void SignAlienPact()
		{
			FundingChange = -Funding;
			SignedAlienPact = true;
		}
	}
}
