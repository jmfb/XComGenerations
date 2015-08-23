using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Modals;

namespace XCom.Screens
{
	public class Geoscape : Screen
	{
		private readonly Stopwatch stopwatch = new Stopwatch();
		private readonly GameSpeed gameSpeed = new GameSpeed();

		public Geoscape()
		{
			AddControl(new Button(0, 257, 63, 11, "INTERCEPT", ColorScheme.Blue, Font.Small, OnIntercept));
			AddControl(new Button(12, 257, 63, 11, "BASES", ColorScheme.Blue, Font.Small, OnBases));
			AddControl(new Button(24, 257, 63, 11, "GRAPHS", ColorScheme.Blue, Font.Small, OnGraphs));
			AddControl(new Button(36, 257, 63, 11, "UFOPAEDIA", ColorScheme.Blue, Font.Small, OnUfoPaedia));
			AddControl(new Button(48, 257, 63, 11, "OPTIONS", ColorScheme.Blue, Font.Small, OnOptions));
			AddControl(new Button(60, 257, 63, 11, "FUNDING", ColorScheme.Blue, Font.Small, OnFunding));
			AddControl(new TimeDisplay());
			AddControl(gameSpeed);
			//TODO: GeoscapeView
			//TODO: Miniature GeoscapeView
		}

		public void ResetGameSpeed()
		{
			gameSpeed.Reset();
		}

		public override void OnSetFocus()
		{
			GameState.Current.OnIdle += OnIdle;
			stopwatch.Restart();
		}

		private static void ProcessNextNotification()
		{
			if (GameState.Current.Notifications.Any())
				GameState.Current.Notifications.Dequeue()();
		}

		public override void OnKillFocus()
		{
			GameState.Current.OnIdle -= OnIdle;
			stopwatch.Stop();
		}

		private static void OnIntercept()
		{
			//TODO:
		}

		private static void OnBases()
		{
			GameState.Current.SetScreen(new Base());
		}

		private static void OnGraphs()
		{
			//TODO:
		}

		private static void OnUfoPaedia()
		{
			GameState.Current.SetScreen(new Information());
		}

		private void OnOptions()
		{
			new Options().DoModal(this);
		}

		private static void OnFunding()
		{
			GameState.Current.SetScreen(new Funding());
		}

		private void OnIdle()
		{
			if (stopwatch.ElapsedMilliseconds < 10)
				return;
			var elapsedMillisecondsInGame = stopwatch.ElapsedMilliseconds * gameSpeed.Multiplier;
			stopwatch.Restart();
			var oldGameTime = GameState.Current.Data.Time;
			var newGameTime = oldGameTime.AddMilliseconds(elapsedMillisecondsInGame);
			GameState.Current.Data.Time = newGameTime;

			var elapsedHours = GetElapsedHours(oldGameTime, newGameTime);
			foreach (var hour in Enumerable.Range(0, elapsedHours))
				PerformHourlyUpdates();

			var isNewDay = oldGameTime.Date != newGameTime.Date;
			if (isNewDay)
				PerformDailyUpdates();

			//TODO: check for new day, month, and other time based triggers
			ProcessNextNotification();
		}

		private static int GetElapsedHours(DateTime oldGameTime, DateTime newGameTime)
		{
			var oldHour = GetHour(oldGameTime);
			var newHour = GetHour(newGameTime);
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

		private static void PerformHourlyUpdates()
		{
			AdvanceManufactureProjects();
		}

		private static void PerformDailyUpdates()
		{
			//TODO: perform other daily actions
			AdvanceResearchProjects();
			AdvanceFacilityConstruction();
		}

		private static void AdvanceManufactureProjects()
		{
			foreach (var @base in GameState.Current.Data.Bases)
			{
				var activeProjects = @base.ManufactureProjects.Where(project => project.EngineersAllocated > 0).ToList();
				foreach (var project in activeProjects)
					AdvanceManufactureProject(@base, project);
			}
		}

		private static void AdvanceManufactureProject(Data.Base @base, ManufactureProject project)
		{
			var previousUnitsProduced = project.UnitsProduced;
			project.HoursCompleted += project.EngineersAllocated;
			var totalUnitsProduced = Math.Min(project.UnitsToProduce,
				project.HoursCompleted / project.ManufactureType.Metadata().HoursToProduce);
			var newUnitsProduced = totalUnitsProduced - previousUnitsProduced;

			foreach (var unit in Enumerable.Range(0, newUnitsProduced))
			{
				project.CompleteUnit(@base);
				++project.UnitsProduced;
				if (project.UnitsProduced == project.UnitsToProduce)
					break;
				var status = project.BeginUnitProduction(@base);
				if (status == ManufactureStatus.UnitStarted)
					continue;
				@base.ManufactureProjects.Remove(project);
				NotifyProductionStopped(@base, project, status);
				return;
			}

			if (project.UnitsProduced != project.UnitsToProduce)
				return;
			@base.ManufactureProjects.Remove(project);
			NotifyProductionCompleted(@base, project);
		}

		private static void NotifyProductionStopped(Data.Base @base, ManufactureProject project, ManufactureStatus status)
		{
			GameState.Current.Notifications.Enqueue(() =>
			{
				Geoscape.ResetGameSpeed();
				new ProductionStopped(@base.Name, project.ManufactureType.Metadata().Name, status).DoModal(GameState.Current.ActiveScreen);
			});
		}

		private static void NotifyProductionCompleted(Data.Base @base, ManufactureProject project)
		{
			GameState.Current.Notifications.Enqueue(() =>
			{
				Geoscape.ResetGameSpeed();
				new ProductionCompleted(@base.Name, project.ManufactureType.Metadata().Name).DoModal(GameState.Current.ActiveScreen);
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

		private static void NotifyFacilityConstructionComplete(Data.Base @base, Facility facility)
		{
			GameState.Current.Notifications.Enqueue(() =>
			{
				Geoscape.ResetGameSpeed();
				new FacilityConstructionCompleted(@base.Name, facility.FacilityType.Metadata().Name).DoModal(GameState.Current.ActiveScreen);
			});
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

		private static void CompleteResearch(Data.Base @base, ResearchType research)
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

		private static void NotifyWeCanNowResearch(Data.Base @base, List<ResearchType> newResearchTypes)
		{
			GameState.Current.Notifications.Enqueue(() =>
			{
				Geoscape.ResetGameSpeed();
				GameState.Current.Data.SelectBase(@base);
				new WeCanNowResearch(newResearchTypes).DoModal(GameState.Current.ActiveScreen);
			});
		}

		private static void NotifyWeCanNowProduce(Data.Base @base, List<ManufactureType> newProduction)
		{
			GameState.Current.Notifications.Enqueue(() =>
			{
				Geoscape.ResetGameSpeed();
				GameState.Current.Data.SelectBase(@base);
				new WeCanNowProduce(newProduction).DoModal(GameState.Current.ActiveScreen);
			});
		}
	}
}
