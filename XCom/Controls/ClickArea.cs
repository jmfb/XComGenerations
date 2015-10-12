using System;
using XCom.Graphics;

namespace XCom.Controls
{
	public class ClickArea : InteractiveControl
	{
		private readonly int topRow;
		private readonly int leftColumn;
		private readonly int width;
		private readonly int height;
		private readonly Action action;

		public ClickArea(int topRow, int leftColumn, int width, int height, Action action)
		{
			this.topRow = topRow;
			this.leftColumn = leftColumn;
			this.width = width;
			this.height = height;
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
			action();
		}
	}
}
