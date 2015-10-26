using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class BattleLocation
	{
		public BattleLocationPart Ground { get; set; }
		public BattleLocationPart WestWall { get; set; }
		public BattleLocationPart NorthWall { get; set; }
		public BattleLocationPart Entity { get; set; }

		public void Render(GraphicsBuffer buffer, int topRow, int leftColumn)
		{
			Ground.Render(buffer, topRow, leftColumn);
			NorthWall.Render(buffer, topRow, leftColumn);
			WestWall.Render(buffer, topRow, leftColumn);
			Entity.Render(buffer, topRow, leftColumn);
		}
	}
}
