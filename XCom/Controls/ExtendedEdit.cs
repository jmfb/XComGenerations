using System;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls
{
	public class ExtendedEdit : Edit
	{
		public ExtendedEdit(
			int topRow,
			int leftColumn,
			int width,
			string text,
			Font font,
			ColorScheme scheme,
			Action<string> action)
			: base(topRow, leftColumn, width, text, font, scheme, action)
		{
		}

		public override void Render(GraphicsBuffer buffer)
		{
			base.Render(buffer);
			if (Editing)
				return;
			var textWidth = Font.MeasureString(Text);
			var textRightColumn = LeftColumn + textWidth;
			var fillWidth = Width - textWidth;
			var fillCount = fillWidth / (Font.MeasureString(".") - 1);
			var fillText = new string('.', fillCount);
			Font.DrawString(buffer, TopRow, textRightColumn - 1, fillText, Scheme);
		}
	}
}
