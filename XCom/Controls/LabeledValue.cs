using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls
{
	public class LabeledValue : Drawable
	{
		private readonly int topRow;
		private readonly int leftColumn;
		private readonly string labelText;
		private readonly string valueText;
		private readonly Font font;
		private readonly ColorScheme labelScheme;
		private readonly ColorScheme valueScheme;

		public LabeledValue(
			int topRow,
			int leftColumn,
			string labelText,
			string valueText,
			Font font,
			ColorScheme labelScheme,
			ColorScheme valueScheme)
		{
			this.topRow = topRow;
			this.leftColumn = leftColumn;
			this.labelText = labelText;
			this.valueText = valueText;
			this.font = font;
			this.labelScheme = labelScheme;
			this.valueScheme = valueScheme;
		}

		public virtual void Render(GraphicsBuffer buffer)
		{
			font.DrawString(buffer, topRow, leftColumn, labelText, labelScheme);
			var valueLeft = leftColumn + font.MeasureString(labelText) - 1;
			font.DrawString(buffer, topRow, valueLeft, valueText, valueScheme);
		}
	}
}
