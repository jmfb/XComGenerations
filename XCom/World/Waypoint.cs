namespace XCom.World
{
	public class Waypoint
	{
		public int Number { get; set; }
		public Location Location { get; set; }

		public string Name => $"WAYPOINT-{Number}";
	}
}
