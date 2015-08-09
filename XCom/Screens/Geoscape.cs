﻿using System.Collections.Generic;
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
			//TODO:
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
			var isNewDay = oldGameTime.Date != newGameTime.Date;
			if (isNewDay)
			{
				//TODO: perform other daily actions

				AdvanceResearchProjects();

				//TODO: notify user of completed research and allow them to re-allocated
			}
			//TODO: check for new day, month, and other time based triggers
		}

		private static void AdvanceResearchProjects()
		{
			var completedResearch = new List<ResearchProject>();
			foreach (var @base in GameState.Current.Data.Bases)
			{
				foreach (var research in @base.ResearchProjects.ToList())
				{
					research.HoursCompleted += research.ScientistsAllocated;
					if (research.HoursCompleted < research.HoursToComplete)
						continue;
					completedResearch.Add(research);
					GameState.Current.Data.CompletedResearch.Add(research.ResearchType);
					@base.ResearchProjects.Remove(research);
				}
			}
		}
	}
}