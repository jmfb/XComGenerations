using System;
using XCom.Graphics;

namespace XCom.Controls
{
	public class ClickGridArea : InteractiveControl
	{
		private readonly int topRow;
		private readonly int leftColumn;
		private readonly int width;
		private readonly int height;
		private readonly Action<int, int> action;

		public ClickGridArea(int topRow, int leftColumn, int width, int height, Action<int, int> action)
		{
			this.topRow = topRow;
			this.leftColumn = leftColumn;
			this.width = width * 16;
			this.height = height * 16;
			this.action = action;
		}

		public override void Render(GraphicsBuffer buffer)
		{
		}

		public override bool HitTest(int row, int column)
		{
			return row >= topRow &&
				row < topRow + height &&
				column >= leftColumn &&
				column < leftColumn + width;
		}

		public override void OnLeftButtonDown(int row, int column)
		{
			var gridRow = (row - topRow) / 16;
			var gridColumn = (column - leftColumn) / 16;
			action(gridRow, gridColumn);
		}
	}
}
