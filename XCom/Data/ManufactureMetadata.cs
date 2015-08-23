using System.Collections.Generic;
using System.Linq;

namespace XCom.Data
{
	public class ManufactureMetadata
	{
		public string Name { get; set; }
		public string Category { get; set; }
		public int Cost { get; set; }
		public int SpaceRequired { get; set; }
		public int HangarSpaceRequired { get; set; }
		public int HoursToProduce { get; set; }
		public int AlienAlloysRequired { get; set; }
		public int EleriumRequired { get; set; }
		public int PowerSourcesRequired { get; set; }
		public int NavigationRequired { get; set; }
		public ItemType ItemProduced { get; set; }
		public ResearchType[] RequiredResearch { get; set; }

		public List<StoreItem> SpecialMaterials =>
			new[]
			{
				new StoreItem { ItemType = ItemType.Elerium115, Count = EleriumRequired },
				new StoreItem { ItemType = ItemType.AlienAlloys, Count = AlienAlloysRequired },
				new StoreItem { ItemType = ItemType.UfoPowerSource, Count = PowerSourcesRequired },
				new StoreItem { ItemType = ItemType.UfoNavigation, Count = NavigationRequired }
			}.Where(storeItem => storeItem.Count > 0).ToList();

		public bool IsRequiredResearchCompleted(List<ResearchType> completedResearch)
		{
			return RequiredResearch.All(completedResearch.Contains);
		}
	}
}
