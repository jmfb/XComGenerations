using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class Map
	{
		public Level[] Levels { get; set; }
		public int RowOffset { get; set; }
		public int ColumnOffset { get; set; }
		public int SelectedLevelIndex { get; set; }

		[JsonIgnore]
		public IEnumerable<MapLocation> EntryPoints
		{
			get
			{
				foreach (var levelIndex in Enumerable.Range(0, Levels.Length))
				{
					var level = Levels[levelIndex];
					foreach (var row in Enumerable.Range(0, level.RowCount))
						foreach (var column in Enumerable.Range(0, level.ColumnCount))
							if (level.Tiles[row, column].IsEntryPoint)
								yield return new MapLocation
								{
									Level = levelIndex,
									Row = row,
									Column = column
								};
				}
			}
		}

		public void SelectNextLevelUp()
		{
			if (SelectedLevelIndex + 1 < Levels.Length)
				++SelectedLevelIndex;
		}

		public void SelectNextLevelDown()
		{
			if (SelectedLevelIndex > 0)
				--SelectedLevelIndex;
		}

		public void ScrollUp(int offset)
		{
			RowOffset += offset;
		}

		public void ScrollDown(int offset)
		{
			RowOffset -= offset;
		}

		public void ScrollLeft(int offset)
		{
			ColumnOffset += offset;
		}

		public void ScrollRight(int offset)
		{
			ColumnOffset -= offset;
		}

		public void Render(GraphicsBuffer buffer)
		{
			foreach (var levelIndex in Enumerable.Range(0, SelectedLevelIndex + 1))
				Levels[levelIndex].Render(buffer, -24 * levelIndex + RowOffset, ColumnOffset);
		}

		public void CenterOn(MapLocation location)
		{
			SelectedLevelIndex = location.Level;
			var topRow = -24 * location.Level + location.Column * 8 + location.Row * 8;
			var leftColumn = location.Column * 16 - location.Row * 16;
			RowOffset = 52 - topRow;
			ColumnOffset = 144 - leftColumn;
		}
	}
}
