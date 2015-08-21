namespace XCom.Data
{
	public class ManufactureMetadata
	{
		public string Name { get; set; }
		public string Category { get; set; }
		public int Cost { get; set; }
		public int SpaceRequired { get; set; }
		public int HoursToProduce { get; set; }
		public int AlienAlloysRequired { get; set; }
		public int EleriumRequired { get; set; }
		public int PowerSourcesRequired { get; set; }
		public int NavigationRequired { get; set; }
		public ItemType ItemProduced { get; set; }
		public ResearchType[] RequiredResearch { get; set; }
	}
}
