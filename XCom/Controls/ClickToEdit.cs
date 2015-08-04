using System;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls
{
	public class ClickToEdit : Edit
	{
		public ClickToEdit(
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

		public override bool HitTest(int row, int column)
		{
			return row >= TopRow &&
				row < (TopRow + Font.Height) &&
				column >= LeftColumn &&
				column < (LeftColumn + Width);
		}

		public override void OnLeftButtonDown(int row, int column)
		{
			if (!Editing)
				BeginEdit();
		}
	}
}
