using System.Collections.Generic;
using System.Linq;

namespace XCom.Data
{
	public class ResearchMetadata
	{
		public string Name { get; set; }
		public int AverageHoursToComplete { get; set; }
		public int Points { get; set; }
		public ResearchType[][] RequiredResearch { get; set; }
		public ItemType? RequiredItem { get; set; }
		public ResearchType[] AdditionalResearchResults { get; set; }
		public ResearchType[] LotteryResearchResults { get; set; }

		public bool IsRequiredResearchCompleted(List<ResearchType> completedResearch)
		{
			return RequiredResearch == null || RequiredResearch.Any(researchPath => researchPath.All(completedResearch.Contains));
		}

		public bool AreRequiredItemsInStores(Stores stores)
		{
			if (RequiredItem == null)
				return true;
			return stores[RequiredItem.Value] > 0;
		}

		public bool IsExhausted(List<ResearchType> completedResearch)
		{
			if (AdditionalResearchResults != null && !AdditionalResearchResults.All(completedResearch.Contains))
				return false;
			return LotteryResearchResults == null || LotteryResearchResults.All(completedResearch.Contains);
		}
	}
}
