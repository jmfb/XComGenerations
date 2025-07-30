using System.Drawing;
using XCom.Graphics;

namespace XCom.Controls;

public class Bar(
	int topRow,
	int leftColumn,
	int width,
	int height,
	int position,
	Color borderColor,
	Color fillColor,
	Color? unfilledColor = null
) : Drawable
{
	public Bar(
		int topRow,
		int leftColumn,
		int width,
		int height,
		int position,
		int borderColor,
		int fillColor
	)
		: this(
			topRow,
			leftColumn,
			width,
			height,
			position,
			Palette.GetPalette(1).GetColor(borderColor),
			Palette.GetPalette(1).GetColor(fillColor)
		) { }

	public void Render(GraphicsBuffer buffer)
	{
		buffer.DrawHorizontalLine(topRow, leftColumn, width, borderColor);
		buffer.DrawHorizontalLine(topRow + height - 1, leftColumn, width, borderColor);
		buffer.DrawVerticalLine(topRow, leftColumn + width, height, borderColor);
		buffer.FillRect(topRow + 1, leftColumn, position, height - 2, fillColor);
		if (unfilledColor != null)
			buffer.FillRect(
				topRow + 1,
				leftColumn + position,
				width - position,
				height - 2,
				unfilledColor.Value
			);
	}
}
