namespace XCom.Data
{
	public class ResearchProject
	{
		public ResearchType ResearchType { get; set; }
		public int ScientistsAllocated { get; set; }
		public int HoursToComplete { get; set; }
		public int HoursCompleted { get; set; }

		public string GetName()
		{
			return ResearchType.Metadata().Name;
		}

		public ResearchProgress GetProgress()
		{
			if (ScientistsAllocated == 0)
				return ResearchProgress.None;
			var averageHoursToComplete = ResearchType.Metadata().AverageHoursToComplete;
			var knownAt = averageHoursToComplete * 2 / 3;
			if (HoursCompleted < knownAt)
				return ResearchProgress.Unknown;
			var remainingHours = HoursToComplete - HoursCompleted;
			var averageProgress = remainingHours * 8 / 100;
			if (ScientistsAllocated < averageProgress)
				return ResearchProgress.Poor;
			var goodProgress = remainingHours * 14 / 100;
			if (ScientistsAllocated < goodProgress)
				return ResearchProgress.Average;
			var excellentProgress = remainingHours * 26 / 100;
			if (ScientistsAllocated < excellentProgress)
				return ResearchProgress.Good;
			return ResearchProgress.Excellent;
		}

		public static ResearchProject Create(ResearchType researchType)
		{
			var averageHoursToComplete = researchType.Metadata().AverageHoursToComplete;
			var deviation = averageHoursToComplete / 2;
			var hoursToComplete = GameState.Current.Random.Next(
				averageHoursToComplete - deviation,
				averageHoursToComplete + deviation);
			return new ResearchProject
			{
				ResearchType = researchType,
				ScientistsAllocated = 0,
				HoursToComplete = hoursToComplete,
				HoursCompleted = 0
			};
		}
	}
}
