using System.Linq;
using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class BattleLevel
	{
		public BattleLocation[,] Locations { get; set; }

		public void LoadTileset(Tileset tileset, int level, int topRow, int leftColumn)
		{
			foreach (var row in Enumerable.Range(0, tileset.RowCount))
				foreach (var column in Enumerable.Range(0, tileset.ColumnCount))
					Locations[topRow + row, leftColumn + column] = tileset.CreateBattleLocation(level, row, column);
		}

		public void Render(GraphicsBuffer buffer, int topRow, int leftColumn)
		{
			foreach (var row in Enumerable.Range(0, Locations.GetLength(0)))
				foreach (var column in Enumerable.Range(0, Locations.GetLength(1)))
				{
					var top = topRow + column * 8 + row * 8;
					var left = leftColumn + column * 16 - row * 16;
					var bottom = top + 40;
					var right = left + 32;
					if (bottom < 0 || right < 0 || top >= 144 || left >= 320)
						continue;
					Locations[row, column].Render(buffer, top, left);
				}
		}
	}
}
