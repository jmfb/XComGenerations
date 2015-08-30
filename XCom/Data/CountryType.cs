using System.Collections.Generic;

namespace XCom.Data
{
	public enum CountryType
	{
		UnitedStates,
		Russia,
		UnitedKingdom,
		France,
		Germany,
		Italy,
		Spain,
		China,
		Japan,
		India,
		Brazil,
		Australia,
		Nigeria,
		SouthAfrica,
		Egypt,
		Canada
	}

	public static class CountryTypeExtensions
	{
		public static CountryMetadata Metadata(this CountryType countryType)
		{
			return metadata[countryType];
		}

		private static CountryMetadata Create(string name, int minStartingFunding, int maxStartingFunding, int maxFunding)
		{
			return new CountryMetadata
			{
				Name = name,
				MinStartingFunding = minStartingFunding,
				MaxStartingFunding = maxStartingFunding,
				MaxFunding = maxFunding
			};
		}

		private static readonly Dictionary<CountryType, CountryMetadata> metadata = new Dictionary<CountryType, CountryMetadata>
		{
			{ CountryType.UnitedStates, Create("USA", 900, 1200, 10000) },
			{ CountryType.Russia, Create("RUSSIA", 400, 600, 8000) },
			{ CountryType.UnitedKingdom, Create("UK", 200, 500, 7000) },
			{ CountryType.France, Create("FRANCE", 400, 600, 8000) },
			{ CountryType.Germany, Create("GERMANY", 200, 400, 9000) },
			{ CountryType.Italy, Create("ITALY", 100, 200, 6000) },
			{ CountryType.Spain, Create("SPAIN", 100, 200, 5000) },
			{ CountryType.China, Create("CHINA", 300, 400, 7000) },
			{ CountryType.Japan, Create("JAPAN", 500, 700, 10000) },
			{ CountryType.India, Create("INDIA", 100, 300, 5000) },
			{ CountryType.Brazil, Create("BRAZIL", 400, 600, 4000) },
			{ CountryType.Australia, Create("AUSTRALIA", 300, 400, 5000) },
			{ CountryType.Nigeria, Create("NIGERIA", 200, 300, 2000) },
			{ CountryType.SouthAfrica, Create("SOUTH AFRICA", 300, 400, 3000) },
			{ CountryType.Egypt, Create("EGYPT", 100, 200, 2000) },
			{ CountryType.Canada, Create("CANADA", 100, 200, 4000) }
		};
	}
}
