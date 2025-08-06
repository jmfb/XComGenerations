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
		int levelIndex,
		MapLocation cursorLocation
	)
	{
		var isAlternateFrame = AnimationFrame.GetCurrent(2) == 1;

		var soldierByLocation = soldiers.ToDictionary(soldier =>
			(soldier.Location.Row, soldier.Location.Column)
		);
		foreach (var row in Enumerable.Range(0, Tiles.GetLength(0)))
		foreach (var column in Enumerable.Range(0, Tiles.GetLength(1)))
		{
			var soldier = soldierByLocation.GetValueOrDefault((row, column));
			// TODO: Take into account HWP, civilian, alien units
			var hasUnit = soldier != null;

			var top = topRow + column * 8 + row * 8;
			var left = leftColumn + column * 16 - row * 16;
			var bottom = top + 40;
			var right = left + 32;
			if (bottom < 0 || right < 0 || top >= 144 || left >= 320)
				continue;

			var tile = Tiles[row, column];
			tile.Ground.Render(buffer, top, left);
			tile.NorthWall.Render(buffer, top, left);
			tile.WestWall.Render(buffer, top, left);

			var showCursor =
				cursorLocation != null
				&& cursorLocation.Row == row
				&& cursorLocation.Column == column
				&& levelIndex <= cursorLocation.Level;
			var cursorIndex =
				levelIndex < (cursorLocation?.Level ?? 0) ? 2
				: hasUnit && isAlternateFrame ? 1
				: 0;
			if (showCursor)
				buffer.DrawItem(top, left, ImageGroup.Cursors.Images[cursorIndex]);
			tile.Entity.Render(buffer, top, left);
			soldier?.Render(buffer, top, left);
			if (showCursor)
				buffer.DrawItem(top, left, ImageGroup.Cursors.Images[cursorIndex + 3]);
			if (GameState.Current.Data.Battle.SelectedUnit == soldier)
				SelectedUnit.Render(top - 8 - (isAlternateFrame ? 1 : 0), left + 8, buffer);
		}
	}
}
