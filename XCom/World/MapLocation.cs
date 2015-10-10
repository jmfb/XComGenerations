using System.Drawing;
using XCom.Graphics;

namespace XCom.World
{
	public class MapLocation
	{
		public Location Location { get; set; }
		public TerrainType? TerrainType { get; set; }
		public RegionType RegionType { get; set; }

		public Color GetColor(int row, int column, int shadeIndex, int zoom)
		{
			var palette = Palette.GetPalette(0);
			if (TerrainType == null)
				return palette.GetColor(192 + shadeIndex);
			var mask = TerrainType.Value.Metadata().Image(zoom);
			var maskRow = row % 32;
			var maskColumn = column % 32;
			var maskIndex = maskRow * 32 + maskColumn;
			return palette.GetColor(mask[maskIndex] + shadeIndex);
		}
	}
}
