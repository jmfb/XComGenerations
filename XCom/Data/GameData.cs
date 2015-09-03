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
		public int ThisMonthsScore { get; set; }
		public int LastMonthsScore { get; set; }

		public int TotalFunding => Countries.Sum(country => country.Funding);
		public int TotalMonthlyCosts => Bases.Sum(@base => @base.TotalMonthlyCost);

		private static IEnumerable<FacilityType> AllFacilityTypes => Enum.GetValues(typeof(FacilityType)).Cast<FacilityType>();
		private static IEnumerable<FacilityType> BuildableFacilityTypes => AllFacilityTypes.Except(new[] { FacilityType.AccessLift });
		public List<FacilityType> AvailableFacilityTypes => BuildableFacilityTypes
			.Where(facilityType => facilityType.Metadata().IsRequiredResearchCompleted(CompletedResearch))
			.ToList();

		private static IEnumerable<TopicType> AllTopics => Enum.GetValues(typeof(TopicType)).Cast<TopicType>();
		private List<TopicType> AvailableTopics => AllTopics.Where(topic => topic.Metadata().IsRequiredResearchCompleted(CompletedResearch)).ToList();
		public TopicType GetNextTopic(TopicType topic)
		{
			var availableTopics = AvailableTopics;
			var index = availableTopics.IndexOf(topic);
			var nextIndex = (index + 1) % availableTopics.Count;
			return availableTopics[nextIndex];
		}
		public TopicType GetPreviousTopic(TopicType topic)
		{
			var availableTopics = AvailableTopics;
			var index = availableTopics.IndexOf(topic);
			var previousIndex = (index + availableTopics.Count - 1) % availableTopics.Count;
			return availableTopics[previousIndex];
		}
		public List<TopicType> GetTopics(TopicCategory category)
		{
			return AvailableTopics.Where(topic => topic.Metadata().Category == category).ToList();
		}

		public static GameData Create(int difficulty)
		{
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
				Countries = Enum.GetValues(typeof(CountryType)).Cast<CountryType>().Select(Country.Create).ToList()
			};
		}

		private void SelectBase(Base @base)
		{
			SelectedBase = Bases.IndexOf(@base);
		}

		public void AdvanceGameTime(long milliseconds)
		{
			var oldGameTime = Time;
			Time = oldGameTime.AddMilliseconds(milliseconds);

			var isNewMonth = oldGameTime.Month != Time.Month;
			if (isNewMonth)
				PerformMonthlyUpdates();

			var elapsedHalfHours = GetElapsedHalfHours(oldGameTime);
			var nextHalfHourIsTopOfTheHour = !IsTopOfTheHour(oldGameTime);
			foreach (var halfHour in Enumerable.Range(0, elapsedHalfHours))
			{
				if (nextHalfHourIsTopOfTheHour)
					PerformHourlyUpdates();
				else
					PerformBiHourlyUpdates();
				nextHalfHourIsTopOfTheHour = !nextHalfHourIsTopOfTheHour;
			}

			var isNewDay = oldGameTime.Date != Time.Date;
			if (isNewDay)
				PerformDailyUpdates();
		}

		private int GetElapsedHalfHours(DateTime oldGameTime)
		{
			var oldHalfHour = GetHalfHour(oldGameTime);
			var newHalfHour = GetHalfHour(Time);
			var timeSpan = newHalfHour - oldHalfHour;
			return (int)timeSpan.TotalMinutes / 30;
		}

		private static bool IsTopOfTheHour(DateTime gameTime)
		{
			return GetHalfHour(gameTime).Minute == 0;
		}

		private static DateTime GetHalfHour(DateTime gameTime)
		{
			return gameTime
				.AddMinutes(-(gameTime.Minute % 30))
				.AddSeconds(-gameTime.Second)
				.AddMilliseconds(-gameTime.Millisecond);
		}
	}
}
