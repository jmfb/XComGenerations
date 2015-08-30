using System.Collections.Generic;

namespace XCom.Data
{
	public enum ScoreType
	{
		Terrible,
		Poor,
		Okay,
		Good,
		Excellent
	}

	public static class ScoreTypeExtensions
	{
		public static ScoreMetadata Metadata(this ScoreType scoreType)
		{
			return metadata[scoreType];
		}

		private static readonly ScoreMetadata terrible = new ScoreMetadata
		{
			Name = "TERRIBLE!",
			MaxMissionPoints = -200,
			MaxMonthlyPoints = -2000,
			Description = "The council of funding nations is dissatisfied with your performance. " +
				"You must improve your effectiveness in dealing with the alien menace or risk termination of the project."
		};

		private static readonly ScoreMetadata poor = new ScoreMetadata
		{
			Name = "POOR!",
			MaxMissionPoints = 0,
			MaxMonthlyPoints = -1000,
			Description = "The council of funding nations is generally satisfied with your progress so far."
		};

		private static readonly ScoreMetadata okay = new ScoreMetadata
		{
			Name = "OK",
			MaxMissionPoints = 200,
			MaxMonthlyPoints = 0,
			Description = "The council of funding nations is generally satisfied with your progress so far."
		};

		private static readonly ScoreMetadata good = new ScoreMetadata
		{
			Name = "GOOD!",
			MaxMissionPoints = 500,
			MaxMonthlyPoints = 500,
			Description = "The council of funding nations is generally satisfied with your progress so far."
		};

		private static readonly ScoreMetadata excellent = new ScoreMetadata
		{
			Name = "EXCELENT!",
			MaxMissionPoints = int.MaxValue,
			MaxMonthlyPoints = int.MaxValue,
			Description = "The council of funding nations is very pleased with your excellent progress. " +
				"Keep up the good work."
		};

		private static readonly Dictionary<ScoreType, ScoreMetadata> metadata = new Dictionary<ScoreType, ScoreMetadata>
		{
			{ ScoreType.Terrible, terrible },
			{ ScoreType.Poor, poor },
			{ ScoreType.Okay, okay },
			{ ScoreType.Good, good },
			{ ScoreType.Excellent, excellent }
		};
	}
}
