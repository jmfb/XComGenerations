using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class BattleLocationPart
	{
		public TilePropertyPage Tile { get; set; }
		public ImageGroupType ImageGroupType { get; set; }

		public void Render(GraphicsBuffer buffer, int topRow, int leftColumn)
		{
			//TODO: cycle through animated frames (but control cycling through door frames)
			var image = ImageGroupType.Image(Tile.Images[0]);
			if (image == null)
				return;
			buffer.DrawItem(topRow - Tile.VerticalImageOffset, leftColumn, image);
		}
	}
}
