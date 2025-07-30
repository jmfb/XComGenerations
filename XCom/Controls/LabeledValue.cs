using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls;

public class LabeledValue(
	int topRow,
	int leftColumn,
	string labelText,
	string valueText,
	Font font,
	ColorScheme labelScheme,
	ColorScheme valueScheme
) : Drawable
{
	public virtual void Render(GraphicsBuffer buffer)
	{
		font.DrawString(buffer, topRow, leftColumn, labelText, labelScheme);
		var valueLeft = leftColumn + font.MeasureString(labelText) - 1;
		font.DrawString(buffer, topRow, valueLeft, valueText, valueScheme);
	}
}
