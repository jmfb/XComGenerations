using System.Drawing;
using System.Linq;
using XCom.Graphics;

namespace XCom.World
{
	public class WorldObject
	{
		public WorldObjectType WorldObjectType { get; set; }
		public Point Location { get; set; }

		public void Render(GraphicsBuffer buffer, bool flash)
		{
			var metadata = WorldObjectType.Metadata();
			var color = Palette.GetPalette(0).GetColor(metadata.PaletteIndex + (flash ? 1 : 0));
			foreach (var x in Enumerable.Range(0, 3))
				foreach (var y in Enumerable.Range(0, 3))
					if (metadata.Mask[x][y])
						buffer.SetPixel(Location.Y + y - 1, Location.X + x - 1, color);
		}
	}
}
