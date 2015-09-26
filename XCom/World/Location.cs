namespace XCom.World
{
	public class Location
	{
		public int Longitude { get; set; }
		public int Latitude { get; set; }

		public bool Is(Location location)
		{
			return Longitude == location.Longitude && Latitude == location.Latitude;
		}
	}
}
