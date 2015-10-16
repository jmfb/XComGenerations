using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using XCom.World;

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
		public int NextBaseNumber { get; set; }
		public int NextSoldierId { get; set; }
		public int NextSkyrangerNumber { get; set; }
		public int NextInterceptorNumber { get; set; }
		public int NextFirestormNumber { get; set; }
		public int NextLightningNumber { get; set; }
		public int NextAvengerNumber { get; set; }
		public List<ResearchType> CompletedResearch { get; set; }
		public int ThisMonthsScore { get; set; }
		public int LastMonthsScore { get; set; }
		public int LongitudeOffset { get; set; }
		public int Pitch { get; set; }
		public int Zoom { get; set; }
		public int NextWaypointNumber { get; set; }
		public List<Waypoint> Waypoints { get; set; }
		public int NextUfoNumber { get; set; }
		public List<Ufo> Ufos { get; set; }
		public UfoFactory UfoFactory { get; set; }

		[ScriptIgnore]
		public int TotalFunding => Countries.Sum(country => country.Funding);
		[ScriptIgnore]
		public int TotalMonthlyCosts => Bases.Sum(@base => @base.TotalMonthlyCost);

		private static IEnumerable<FacilityType> AllFacilityTypes => EnumEx.GetValues<FacilityType>();
		private static IEnumerable<FacilityType> BuildableFacilityTypes => AllFacilityTypes.Except(new[] { FacilityType.AccessLift });
		[ScriptIgnore]
		public List<FacilityType> AvailableFacilityTypes => BuildableFacilityTypes
			.Where(facilityType => facilityType.Metadata().IsRequiredResearchCompleted(CompletedResearch))
			.ToList();

		private static IEnumerable<TopicType> AllTopics => EnumEx.GetValues<TopicType>();
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

		[ScriptIgnore]
		public IEnumerable<Craft> ActiveInterceptors => Bases.SelectMany(@base => @base.ActiveInterceptors);
		[ScriptIgnore]
		public IEnumerable<Ufo> VisibleUfos => Ufos.Where(ufo => ufo.IsDetected);

		public Soldier GetSoldier(int id)
		{
			return Bases.SelectMany(@base => @base.Soldiers).Single(soldier => soldier.Id == id);
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
				NextBaseNumber = 1,
				NextSkyrangerNumber = 1,
				NextInterceptorNumber = 1,
				NextFirestormNumber = 1,
				NextLightningNumber = 1,
				NextAvengerNumber = 1,
				CompletedResearch = new List<ResearchType>(),
				Countries = EnumEx.GetValues<CountryType>().Select(Country.Create).ToList(),
				NextWaypointNumber = 1,
				Waypoints = new List<Waypoint>(),
				NextUfoNumber = 1,
				Ufos = new List<Ufo>(),
				UfoFactory = new UfoFactory()
			};
		}

		public int CreateWaypoint(Location location)
		{
			var number = NextWaypointNumber++;
			Waypoints.Add(new Waypoint
			{
				Location = location,
				Number = number
			});
			return number;
		}

		public Waypoint RemoveWaypoint(int number)
		{
			var waypointToRemove = Waypoints.Single(waypoint => waypoint.Number == number);
			Waypoints.Remove(waypointToRemove);
			return waypointToRemove;
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

			var elapsedTenMinuteIntervals = GetElapsedTenMinuteIntervals(oldGameTime);
			var currentTenMinuteInterval = GetTenMinuteInterval(oldGameTime).Minute / 10;
			foreach (var tenMinuteInterval in Enumerable.Range(0, elapsedTenMinuteIntervals))
			{
				currentTenMinuteInterval = (currentTenMinuteInterval + 1) % 6;
				PerformTenMinuteUpdates();
				if (currentTenMinuteInterval == 0)
					PerformHourlyUpdates();
				else if (currentTenMinuteInterval == 3)
					PerformBiHourlyUpdates();
			}
			PerformInstantaneousUpdates(milliseconds);

			var isNewDay = oldGameTime.Date != Time.Date;
			if (isNewDay)
				PerformDailyUpdates();
		}

		private int GetElapsedTenMinuteIntervals(DateTime oldGameTime)
		{
			var oldTenMinuteInterval = GetTenMinuteInterval(oldGameTime);
			var newTenMinuteInterval = GetTenMinuteInterval(Time);
			var timeSpan = newTenMinuteInterval - oldTenMinuteInterval;
			return (int)timeSpan.TotalMinutes / 10;
		}

		private static DateTime GetTenMinuteInterval(DateTime gameTime)
		{
			return gameTime
				.AddMinutes(-(gameTime.Minute % 10))
				.AddSeconds(-gameTime.Second)
				.AddMilliseconds(-gameTime.Millisecond);
		}

		public void CenterOn(Location location)
		{
			LongitudeOffset = Trigonometry.AddEighthDegrees(-location.Longitude, 0);
			Pitch = Trigonometry.AddEighthDegrees(location.Latitude, 0);
		}
	}
}
