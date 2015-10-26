using System.Linq;
using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class Map
	{
		public Level[] Levels { get; set; }
		public int RowOffset { get; set; }
		public int ColumnOffset { get; set; }
		public int SelectedLevelIndex { get; set; }

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
	}
}
