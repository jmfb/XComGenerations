using System.Linq;
using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class BattleLocationPart
	{
		private readonly TilePropertyPage tile;
		private readonly byte[][] images;

		public BattleLocationPart(TilePropertyPage tile, ImageGroup imageGroup)
		{
			this.tile = tile;
			images = tile.Images.Select(index => index == 0 && imageGroup == ImageGroup.Common ? null : imageGroup.Images[index]).ToArray();
		}

		public void Render(GraphicsBuffer buffer, int topRow, int leftColumn)
		{
			//TODO: cycle through animated frames (but control cycling through door frames)
			var image = images[0];
			if (image == null)
				return;
			buffer.DrawItem(topRow - tile.VerticalImageOffset, leftColumn, image);
		}
	}
}
