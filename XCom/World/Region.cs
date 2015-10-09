namespace XCom.World
{
	public class Region
	{
		public int Left { get; }
		public int Top { get; }
		public int Width { get; }
		public int Height { get; }

		public Region(int left, int top, int width, int height)
		{
			Left = left;
			//Top argument is given where +720 is north pole and -719 is south pole.
			//Need to invert the top to convert top into latitude values matching world coordinates.
			Top = -top;
			Width = width;
			Height = height;
		}

		public bool Contains(Location location)
		{
			return location.Longitude >= Left &&
				location.Longitude < (Left + Width) &&
				location.Latitude >= Top &&
				location.Latitude < (Top + Height);
		}
	}
}
