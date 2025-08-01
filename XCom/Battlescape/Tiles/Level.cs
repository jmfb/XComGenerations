using Newtonsoft.Json;
using XCom.Graphics;

namespace XCom.Battlescape.Tiles;

public class Level
{
	public Tile[,] Tiles { get; set; }

	[JsonIgnore]
	public int RowCount => Tiles.GetLength(0);

	[JsonIgnore]
	public int ColumnCount => Tiles.GetLength(1);

	public void LoadTileset(Tileset tileset, int level, int topRow, int leftColumn)
	{
		foreach (var row in Enumerable.Range(0, tileset.RowCount))
		foreach (var column in Enumerable.Range(0, tileset.ColumnCount))
			Tiles[topRow + row, leftColumn + column] = tileset.CreateTile(level, row, column);
	}

	public void Render(
		GraphicsBuffer buffer,
		int topRow,
		int leftColumn,
		IReadOnlyCollection<BattleSoldier> soldiers,
		int levelIndex = -1,
		SoldierIndicator soldierIndicator = null,
		BattleSoldier selectedSoldier = null
	)
	{
		var soldierByLocation = soldiers.ToDictionary(soldier =>
			(soldier.Location.Row, soldier.Location.Column)
		);
		foreach (var row in Enumerable.Range(0, Tiles.GetLength(0)))
		foreach (var column in Enumerable.Range(0, Tiles.GetLength(1)))
		{
			var soldier = soldierByLocation.GetValueOrDefault((row, column));
			var top = topRow + column * 8 + row * 8;
			var left = leftColumn + column * 16 - row * 16;
			var bottom = top + 40;
			var right = left + 32;
			if (bottom < 0 || right < 0 || top >= 144 || left >= 320)
				continue;

			// Render tile components in the correct order
			var tile = Tiles[row, column];
			
			// 1. Ground
			tile.Ground.Render(buffer, top, left);
			
			// 2. Soldier indicator (if it should appear here)
			if (soldierIndicator != null && selectedSoldier != null && levelIndex >= 0)
			{
				if (soldierIndicator.ShouldRenderAt(levelIndex, row, column, selectedSoldier))
				{
					soldierIndicator.Render(buffer, top, left);
				}
			}
			
			// 3. North Wall
			tile.NorthWall.Render(buffer, top, left);
			
			// 4. West Wall
			tile.WestWall.Render(buffer, top, left);
			
			// 5. Entity
			tile.Entity.Render(buffer, top, left);
			
			// 6. Unit (soldier)
			soldier?.Render(buffer, top, left);
		}
	}
}
