using System.Collections.Generic;
using System.Linq;
using XCom.Graphics;

namespace XCom.Data
{
	public class TopicMetadata
	{
		public string Name { get; set; }
		public TopicCategory Category { get; set; }
		public byte[] Background { get; set; }
		public int BackgroundPalette { get; set; }
		public ColorScheme Scheme { get; set; }
		public ResearchType[] RequiredResearch { private get; set; }
		public object Subject { get; set; }

		public bool IsRequiredResearchCompleted(List<ResearchType> completedResearch)
		{
			return RequiredResearch.All(completedResearch.Contains);
		}
	}
}
