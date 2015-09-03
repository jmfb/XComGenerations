using System.Collections.Generic;
using XCom.Graphics;

namespace XCom.Data
{
	public class TopicMetadata
	{
		public string Name { get; set; }
		public TopicCategory Category { get; set; }
		public byte[] Background { get; set; }
		public ColorScheme Scheme { get; set; }
		public ResearchType? RequiredResearch { private get; set; }
		public CraftType? Craft { get; set; }
		public CraftWeaponType? CraftWeapon { get; set; }

		public bool IsRequiredResearchCompleted(List<ResearchType> completedResearch)
		{
			return RequiredResearch == null || completedResearch.Contains(RequiredResearch.Value);
		}
	}
}
