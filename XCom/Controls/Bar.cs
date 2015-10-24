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
		private readonly int position;
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
			this.position = position;
			this.borderColor = borderColor;
			this.fillColor = fillColor;
			this.unfilledColor = unfilledColor;
		}

		public Bar(
			int topRow,
			int leftColumn,
			int width,
			int height,
			int position,
			int borderColor,
			int fillColor)
			: this(
				topRow,
				leftColumn,
				width,
				height,
				position,
				Palette.GetPalette(1).GetColor(borderColor),
				Palette.GetPalette(1).GetColor(fillColor))
		{
		}

		public void Render(GraphicsBuffer buffer)
		{
			buffer.DrawHorizontalLine(topRow, leftColumn, width, borderColor);
			buffer.DrawHorizontalLine(topRow + height - 1, leftColumn, width, borderColor);
			buffer.DrawVerticalLine(topRow, leftColumn + width, height, borderColor);
			buffer.FillRect(topRow + 1, leftColumn, position, height - 2, fillColor);
			if (unfilledColor != null)
				buffer.FillRect(topRow + 1, leftColumn + position, width - position, height - 2, unfilledColor.Value);
		}
	}
}
