namespace XCom.Data
{
	public class AlienMetadata
	{
		public string Name { get; set; }
		public ResearchType RequiredResearch { get; set; }
		public byte[] Overlay { get; set; }
		public string[] DescriptionLines { get; set; }
	}
}
