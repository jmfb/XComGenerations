using System.Linq;
using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class BattleLevel
	{
		private readonly int width;
		private readonly int height;
		private readonly BattleLocation[,] locations;

		public BattleLevel(int width, int height)
		{
			this.width = width;
			this.height = height;
			locations = new BattleLocation[height, width];
		}

		public void LoadTileset(Tileset tileset, int level, int topRow, int leftColumn)
		{
			foreach (var row in Enumerable.Range(0, tileset.RowCount))
				foreach (var column in Enumerable.Range(0, tileset.ColumnCount))
					locations[topRow + row, leftColumn + column] = tileset.CreateBattleLocation(level, row, column);
		}

		public void Render(GraphicsBuffer buffer, int topRow, int leftColumn)
		{
			foreach (var row in Enumerable.Range(0, height))
				foreach (var column in Enumerable.Range(0, width))
				{
					var top = topRow + column * 8 + row * 8;
					var left = leftColumn + column * 16 - row * 16;
					var bottom = top + 40;
					var right = left + 32;
					if (bottom < 0 || right < 0 || top >= 144 || left >= 320)
						continue;
					locations[row, column].Render(buffer, top, left);
				}
		}
	}
}
