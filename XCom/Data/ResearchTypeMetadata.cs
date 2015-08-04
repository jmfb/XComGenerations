namespace XCom.Data
{
	public class ResearchTypeMetadata
	{
		public string Name { get; set; }
		public int AverageHoursToComplete { get; set; }
		public ResearchType[] RequiredResearch { get; set; }
	}
}
