using System;
using System.Collections.Generic;
using System.Linq;

namespace XCom.Data
{
	public partial class GameData
	{
		public string Name { get; set; }
		public DateTime Time { get; set; }
		public int Difficulty { get; set; }
		public int Funds { get; set; }
		public IEnumerable<Country> Countries { get; set; }
		public int SelectedBase { get; set; }
		public List<Base> Bases { get; set; }
		public int NextSoldierId { get; set; }
		public int NextSkyrangerNumber { get; set; }
		public int NextInterceptorNumber { get; set; }
		public int NextFirestormNumber { get; set; }
		public int NextLightningNumber { get; set; }
		public int NextAvengerNumber { get; set; }
		public List<ResearchType> CompletedResearch { get; set; }

		public int TotalFunding => Countries.Sum(country => country.Funding);

		private static IEnumerable<FacilityType> AllFacilityTypes => Enum.GetValues(typeof(FacilityType)).Cast<FacilityType>();
		private static IEnumerable<FacilityType> BuildableFacilityTypes => AllFacilityTypes.Except(new[] { FacilityType.AccessLift });
		public List<FacilityType> AvailableFacilityTypes => BuildableFacilityTypes
			.Where(facilityType => facilityType.Metadata().IsRequiredResearchCompleted(CompletedResearch))
			.ToList();

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
				NextFirestormNumber = 1,
				NextLightningNumber = 1,
				NextAvengerNumber = 1,
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

		public void AdvanceGameTime(long milliseconds)
		{
			var oldGameTime = Time;
			Time = oldGameTime.AddMilliseconds(milliseconds);

			//TODO: minute based events?

			var elapsedHours = GetElapsedHours(oldGameTime);
			foreach (var hour in Enumerable.Range(0, elapsedHours))
				PerformHourlyUpdates();

			var isNewDay = oldGameTime.Date != Time.Date;
			if (isNewDay)
				PerformDailyUpdates();

			//TODO: monthly events
		}

		private int GetElapsedHours(DateTime oldGameTime)
		{
			var oldHour = GetHour(oldGameTime);
			var newHour = GetHour(Time);
			var timeSpan = newHour - oldHour;
			return (int)timeSpan.TotalHours;
		}

		private static DateTime GetHour(DateTime gameTime)
		{
			return gameTime
				.AddMinutes(-gameTime.Minute)
				.AddSeconds(-gameTime.Second)
				.AddMilliseconds(-gameTime.Millisecond);
		}
	}
}
