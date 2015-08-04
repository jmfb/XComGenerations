using System.Drawing;
using XCom.Graphics;

namespace XCom.Controls
{
	public class Bar : Drawable
	{
		private readonly int topRow;
		private readonly int leftColumn;
		private readonly int width;
		private readonly int height;
		public int Position { get; set; }
		private readonly Color borderColor;
		private readonly Color fillColor;
		private readonly Color? unfilledColor;

		public Bar(
			int topRow,
			int leftColumn,
			int width,
			int height,
			int position,
			Color borderColor,
			Color fillColor,
			Color? unfilledColor = null)
		{
			this.topRow = topRow;
			this.leftColumn = leftColumn;
			this.width = width;
			this.height = height;
			Position = position;
			this.borderColor = borderColor;
			this.fillColor = fillColor;
			this.unfilledColor = unfilledColor;
		}

		public void Render(GraphicsBuffer buffer)
		{
			buffer.DrawHorizontalLine(topRow, leftColumn, width, borderColor);
			buffer.DrawHorizontalLine(topRow + height - 1, leftColumn, width, borderColor);
			buffer.DrawVerticalLine(topRow, leftColumn + width, height, borderColor);
			buffer.FillRect(topRow + 1, leftColumn, Position, height - 2, fillColor);
			if (unfilledColor != null)
				buffer.FillRect(topRow + 1, leftColumn + Position, width - Position, height - 2, unfilledColor.Value);
		}
	}
}
