using XCom.Graphics;

namespace XCom.Battlescape
{
	public class BattleLocation
	{
		private readonly BattleLocationPart ground;
		private readonly BattleLocationPart westWall;
		private readonly BattleLocationPart northWall;
		private readonly BattleLocationPart entity;

		public BattleLocation(
			BattleLocationPart ground,
			BattleLocationPart westWall,
			BattleLocationPart northWall,
			BattleLocationPart entity)
		{
			this.ground = ground;
			this.westWall = westWall;
			this.northWall = northWall;
			this.entity = entity;
		}

		public void Render(GraphicsBuffer buffer, int topRow, int leftColumn)
		{
			ground.Render(buffer, topRow, leftColumn);
			northWall.Render(buffer, topRow, leftColumn);
			westWall.Render(buffer, topRow, leftColumn);
			entity.Render(buffer, topRow, leftColumn);
		}
	}
}
