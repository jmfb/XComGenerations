using XCom.Graphics;

namespace XCom.Data
{
	public class FacilityMetadata
	{
		public string Name { get; set; }
		public FacilityShape Shape { get; set; }
		public int DaysToConstruct { get; set; }
		public int Cost { get; set; }
		public int Maintenance { get; set; }
		public Image Image { get; set; }
		public int RowOffset { get; set; }
		public int ColumnOffset { get; set; }
	}
}
