using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class Tile
	{
		public Part Ground { get; set; }
		public Part WestWall { get; set; }
		public Part NorthWall { get; set; }
		public Part Entity { get; set; }

		//TODO: Optional Unit (Hwp - takes up 4 spots, soldier, civilian, alien)
		//TODO: Battle items on ground (including dead/unconscious aliens/soldiers/civilians)
		//TODO: State of tile (fire, smoke, open door, etc.)
		//TODO: Selection state (selected, special icon, below selection, active selection, etc.)
		//TODO: Fog of war state
		//TODO: Brightness

		public void Render(GraphicsBuffer buffer, int topRow, int leftColumn)
		{
			Ground.Render(buffer, topRow, leftColumn);
			NorthWall.Render(buffer, topRow, leftColumn);
			WestWall.Render(buffer, topRow, leftColumn);
			Entity.Render(buffer, topRow, leftColumn);
		}
	}
}
