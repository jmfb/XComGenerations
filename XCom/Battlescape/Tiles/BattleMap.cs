using System.Linq;
using XCom.Data;
using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class BattleMap
	{
		private readonly BattleLevel[] levels;
		private int rowOffset;
		private int columnOffset;
		private int selectedLevelIndex;

		public BattleMap(BattleLevel[] levels)
		{
			this.levels = levels;
		}

		public void SelectNextLevelUp()
		{
			if (selectedLevelIndex + 1 < levels.Length)
				++selectedLevelIndex;
		}

		public void SelectNextLevelDown()
		{
			if (selectedLevelIndex > 0)
				--selectedLevelIndex;
		}

		public void ScrollUp(int offset)
		{
			rowOffset += offset;
		}

		public void ScrollDown(int offset)
		{
			rowOffset -= offset;
		}

		public void ScrollLeft(int offset)
		{
			columnOffset += offset;
		}

		public void ScrollRight(int offset)
		{
			columnOffset -= offset;
		}

		public void Render(GraphicsBuffer buffer)
		{
			foreach (var levelIndex in Enumerable.Range(0, selectedLevelIndex + 1))
				levels[levelIndex].Render(buffer, -24 * levelIndex + rowOffset, columnOffset);
		}
	}
}
