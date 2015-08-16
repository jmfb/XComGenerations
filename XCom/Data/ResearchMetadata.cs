namespace XCom.Data
{
	public class ResearchMetadata
	{
		public string Name { get; set; }
		public int AverageHoursToComplete { get; set; }
		public ResearchType[] RequiredResearch { get; set; }
		public ItemType? Item { get; set; }
	}
}
