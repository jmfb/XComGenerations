using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class Tile
	{
		public Part Ground { get; set; }
		public Part WestWall { get; set; }
		public Part NorthWall { get; set; }
		public Part Entity { get; set; }

		public void Render(GraphicsBuffer buffer, int topRow, int leftColumn)
		{
			Ground.Render(buffer, topRow, leftColumn);
			NorthWall.Render(buffer, topRow, leftColumn);
			WestWall.Render(buffer, topRow, leftColumn);
			Entity.Render(buffer, topRow, leftColumn);
		}
	}
}
