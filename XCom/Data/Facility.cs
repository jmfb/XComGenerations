namespace XCom.Data
{
	public class Facility
	{
		public FacilityType FacilityType { get; set; }
		public int Row { get; set; }
		public int Column { get; set; }
		public int DaysUntilConstructionComplete { get; set; }
	}
}
