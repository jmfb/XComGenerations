using System.Collections.Generic;
using System.Linq;
using XCom.Modals;
using XCom.Screens;

namespace XCom.Data
{
	public partial class GameData
	{
		private static void PerformDailyUpdates()
		{
			AdvanceResearchProjects();
			AdvanceFacilityConstruction();
		}

		private static void AdvanceResearchProjects()
		{
			foreach (var @base in GameState.Current.Data.Bases)
			{
				foreach (var research in @base.ResearchProjects.ToList())
				{
					research.HoursCompleted += research.ScientistsAllocated;
					if (research.HoursCompleted < research.HoursToComplete)
						continue;
					CompleteResearch(@base, research.ResearchType);
					@base.ResearchProjects.Remove(research);
				}
			}
		}

		private static void CompleteResearch(Base @base, ResearchType research)
		{
			var previouslyAvailableResearch = @base.AvailableResearchProjects;
			var previouslyAvailableProduction = @base.AvailableManufactureProjects;
			RecordCompletedResearch(research);
			NotfiyResearchCompleted(research);

			var newResearchTypes = @base.AvailableResearchProjects.Except(previouslyAvailableResearch).ToList();
			NotifyWeCanNowResearch(@base, newResearchTypes);

			var newProduction = @base.AvailableManufactureProjects.Except(previouslyAvailableProduction).ToList();
			if (newProduction.Any())
				NotifyWeCanNowProduce(@base, newProduction);
		}

		private static void RecordCompletedResearch(ResearchType research)
		{
			var completedResearch = GameState.Current.Data.CompletedResearch;
			var newlyCompletedResearch = GatherCompletedResearch(research).Except(completedResearch);
			completedResearch.AddRange(newlyCompletedResearch);
		}

		private static IEnumerable<ResearchType> GatherCompletedResearch(ResearchType research)
		{
			yield return research;
			var metadata = research.Metadata();
			if (metadata.AdditionalResearchResults != null)
				foreach (var additionalResearch in metadata.AdditionalResearchResults)
					yield return additionalResearch;
			if (metadata.LotteryResearchResults == null)
				yield break;
			var remainingLotteryResults = metadata.LotteryResearchResults.Except(GameState.Current.Data.CompletedResearch).ToList();
			if (remainingLotteryResults.Count == 0)
				yield break;
			var randomIndex = GameState.Current.Random.Next(0, remainingLotteryResults.Count);
			yield return remainingLotteryResults[randomIndex];
		}

		private static void NotfiyResearchCompleted(ResearchType research)
		{
			//TODO: Potentially show information about extra research (researched medic, learned about other alien race...)
			GameState.Current.Notifications.Enqueue(() => new ResearchCompleted(research).DoModal(GameState.Current.ActiveScreen));
		}

		private static void NotifyWeCanNowResearch(Base @base, List<ResearchType> newResearchTypes)
		{
			GameState.Current.Notifications.Enqueue(() =>
			{
				Screen.Geoscape.ResetGameSpeed();
				GameState.Current.Data.SelectBase(@base);
				new WeCanNowResearch(newResearchTypes).DoModal(GameState.Current.ActiveScreen);
			});
		}

		private static void NotifyWeCanNowProduce(Base @base, List<ManufactureType> newProduction)
		{
			GameState.Current.Notifications.Enqueue(() =>
			{
				Screen.Geoscape.ResetGameSpeed();
				GameState.Current.Data.SelectBase(@base);
				new WeCanNowProduce(newProduction).DoModal(GameState.Current.ActiveScreen);
			});
		}

		private static void AdvanceFacilityConstruction()
		{
			foreach (var @base in GameState.Current.Data.Bases)
			{
				var facilitiesUnderConstruction = @base.Facilities.Where(facility => facility.DaysUntilConstructionComplete > 0).ToList();
				foreach (var facility in facilitiesUnderConstruction)
				{
					--facility.DaysUntilConstructionComplete;
					if (facility.DaysUntilConstructionComplete == 0)
						NotifyFacilityConstructionComplete(@base, facility);
				}
			}
		}

		private static void NotifyFacilityConstructionComplete(Base @base, Facility facility)
		{
			GameState.Current.Notifications.Enqueue(() =>
			{
				Screen.Geoscape.ResetGameSpeed();
				new FacilityConstructionCompleted(@base.Name, facility.FacilityType.Metadata().Name).DoModal(GameState.Current.ActiveScreen);
			});
		}
	}
}
