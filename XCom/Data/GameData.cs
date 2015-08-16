using System;
using System.Collections.Generic;
using System.Linq;

namespace XCom.Data
{
	public class GameData
	{
		public string Name { get; set; }
		public DateTime Time { get; set; }
		public int Difficulty { get; set; }
		public int Funds { get; set; }
		public IEnumerable<Country> Countries { get; set; }
		public int SelectedBase { get; set; }
		public List<Base> Bases { get; set; }
		public int NextCraftId { get; set; }
		public int NextSoldierId { get; set; }
		public int NextSkyrangerNumber { get; set; }
		public int NextInterceptorNumber { get; set; }
		public List<ResearchType> CompletedResearch { get; set; }

		public int GetTotalFunding()
		{
			return Countries.Sum(country => country.Funding);
		}

		public List<ResearchType> GetAvailableResearchProjects()
		{
			var allResearch = Enum.GetValues(typeof(ResearchType)).Cast<ResearchType>().ToList();
			var remainingResearch = allResearch
				.Except(CompletedResearch)
				.Except(Bases.SelectMany(b => b.ResearchProjects.Select(p => p.ResearchType)))
				.ToList();
			return remainingResearch
				.Where(research => research.Metadata().RequiredResearch.All(required => CompletedResearch.Contains(required)))
				.ToList();
		}

		public List<FacilityType> GetAvailableFacilityTypes()
		{
			//TODO: enable more facility types as research projects are completed
			return new List<FacilityType>
			{
				FacilityType.LivingQuarters,
				FacilityType.Laboratory,
				FacilityType.Workshop,
				FacilityType.SmallRadarSystem,
				FacilityType.LargeRadarSystem,
				FacilityType.MissileDefences,
				FacilityType.GeneralStores,
				FacilityType.AlienContainment,
				FacilityType.Hangar
			};
		}

		public static GameData Create(int difficulty)
		{
			var random = GameState.Current.Random;
			return new GameData
			{
				Name = "",
				Time = new DateTime(1999, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc),
				Difficulty = difficulty,
				Funds = 5000000,
				Bases = new List<Base>(),
				SelectedBase = 0,
				NextSkyrangerNumber = 1,
				NextInterceptorNumber = 1,
				CompletedResearch = new List<ResearchType>(),
				Countries = new[]
				{
					new Country
					{
						Name = "USA",
						Funding = random.Next(900, 1200) * 1000
					},
					new Country
					{
						Name = "RUSSIA",
						Funding = random.Next(400, 600) * 1000
					},
					new Country
					{
						Name = "UK",
						Funding = random.Next(200, 500) * 1000
					},
					new Country
					{
						Name = "FRANCE",
						Funding = random.Next(400, 600) * 1000
					},
					new Country
					{
						Name = "GERMANY",
						Funding = random.Next(200, 400) * 1000
					},
					new Country
					{
						Name = "ITALY",
						Funding = random.Next(100, 200) * 1000
					},
					new Country
					{
						Name = "SPAIN",
						Funding = random.Next(100, 200) * 1000
					},
					new Country
					{
						Name = "CHINA",
						Funding = random.Next(300, 400) * 1000
					},
					new Country
					{
						Name = "JAPAN",
						Funding = random.Next(500, 700) * 1000
					},
					new Country
					{
						Name = "INDIA",
						Funding = random.Next(100, 300) * 1000
					},
					new Country
					{
						Name = "BRAZIL",
						Funding = random.Next(400, 600) * 1000
					},
					new Country
					{
						Name = "AUSTRALIA",
						Funding = random.Next(300, 400) * 1000
					},
					new Country
					{
						Name = "NIGERIA",
						Funding = random.Next(200, 300) * 1000
					},
					new Country
					{
						Name = "SOUTH AFRICA",
						Funding = random.Next(300, 400) * 1000
					},
					new Country
					{
						Name = "EGYPT",
						Funding = random.Next(100, 200) * 1000
					},
					new Country
					{
						Name = "CANADA",
						Funding = random.Next(100, 200) * 1000
					}
				}
			};
		}

		public void SelectBase(Base @base)
		{
			SelectedBase = Bases.IndexOf(@base);
		}
	}
}
