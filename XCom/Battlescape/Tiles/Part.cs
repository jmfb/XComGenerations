using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class Part
	{
		public TileType TileType { get; set; }
		public int Index { get; set; }

		public void Render(GraphicsBuffer buffer, int topRow, int leftColumn)
		{
			//TODO: cycle through animated frames (but control cycling through door frames)
			var tile = TileType.Part(Index);
			var image = TileType.Image(tile.Images[0]);
			if (image == null)
				return;
			buffer.DrawItem(topRow - tile.VerticalImageOffset, leftColumn, image);
		}
	}
}
