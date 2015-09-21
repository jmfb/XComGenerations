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
			this.top = top;
			this.width = width;
			this.height = height;
		}

		public bool Contains(int longitude, int latitude)
		{
			return longitude >= left &&
				longitude < (left + width) &&
				latitude <= top &&
				latitude > (top - height);
		}
	}
}
