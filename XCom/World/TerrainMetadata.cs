using System;

namespace XCom.World
{
	public class TerrainMetadata
	{
		public TerrainCategory Category { get; set; }
		public byte[] ImageZoom1 { get; set; }
		public byte[] ImageZoom2 { get; set; }
		public byte[] ImageZoom3 { get; set; }

		public byte[] Image(int zoom)
		{
			switch (zoom / 2)
			{
			case 0:
				return ImageZoom1;
			case 1:
				return ImageZoom2;
			case 2:
				return ImageZoom3;
			}
			throw new InvalidOperationException("Invalid zoom");
		}
	}
}
