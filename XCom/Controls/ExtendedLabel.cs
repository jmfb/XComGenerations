using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls
{
	public class ExtendedLabel : Label
	{
		private readonly int width;
		private readonly ColorScheme fillScheme;

		public ExtendedLabel(
			int topRow,
			int leftColumn,
			int width,
			string text,
			Font font,
			ColorScheme scheme)
			: base(topRow, leftColumn, text, font, scheme)
		{
			this.width = width;
			fillScheme = scheme;
		}

		public ExtendedLabel(
			int topRow,
			int leftColumn,
			int width,
			string text,
			Font font,
			ColorScheme scheme,
			ColorScheme fillScheme)
			: base(topRow, leftColumn, text, font, scheme)
		{
			this.width = width;
			this.fillScheme = fillScheme;
		}

		public override void Render(GraphicsBuffer buffer)
		{
			base.Render(buffer);
			var textWidth = Font.MeasureString(Text);
			var textRightColumn = LeftColumn + textWidth;
			var fillWidth = width - textWidth;
			var fillCount = fillWidth / (Font.MeasureString(".") - 1);
			var fillText = new string('.', fillCount);
			Font.DrawString(buffer, TopRow, textRightColumn - 1, fillText, fillScheme);
		}
	}
}
