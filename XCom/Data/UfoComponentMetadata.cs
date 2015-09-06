namespace XCom.Data
{
	public class UfoComponentMetadata
	{
		public string Name { get; set; }
		public ResearchType RequiredResearch { get; set; }
		public byte[] Overlay { get; set; }
		public int LabelWidth { get; set; }
		public string Description { get; set; }
	}
}
