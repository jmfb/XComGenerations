using System.Collections.Generic;
using System.Linq;

namespace XCom.Data
{
	public class ResearchMetadata
	{
		public string Name { get; set; }
		public int AverageHoursToComplete { get; set; }
		public ResearchType[][] RequiredResearch { get; set; }
		public ItemType? RequiredItem { get; set; }
		public ResearchType[] AdditionalResearchResults { get; set; }
		public ResearchType[] LotteryResearchResults { get; set; }

		public bool IsRequiredResearchCompleted(List<ResearchType> completedResearch)
		{
			return RequiredResearch == null || RequiredResearch.Any(researchPath => researchPath.All(completedResearch.Contains));
		}
	}
}
