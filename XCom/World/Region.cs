namespace XCom.World
{
	public class Region
	{
		private readonly int left;
		private readonly int top;
		private readonly int width;
		private readonly int height;

		public Region(int left, int top, int width, int height)
		{
			this.left = left;
			//Top argument is given where +720 is north pole and -719 is south pole.
			//Need to invert the top to convert top into latitude values matching world coordinates.
			this.top = -top + 1;
			this.width = width;
			this.height = height;
		}

		public bool Contains(Location location)
		{
			return location.Longitude >= left &&
				location.Longitude < (left + width) &&
				location.Latitude >= top &&
				location.Latitude < (top + height);
		}
	}
}
