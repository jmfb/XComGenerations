using System;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls
{
	public class Toggle : Button
	{
		public Toggle(
			int topRow,
			int leftColumn,
			int width,
			int height,
			string text,
			ColorScheme scheme,
			Font font,
			Action action)
			: base(topRow, leftColumn, width, height, text, scheme, font, action)
		{
		}

		public bool Value
		{
			get { return Pushed; }
			set { Pushed = value; }
		}

		public override void OnMouseMove(int row, int column, bool leftButton, bool rightButton)
		{
		}

		public override void OnLeftButtonDown(int row, int column)
		{
			if (Pushed)
				return;
			Pushed = true;
			Action();
		}

		public override void OnLeftButtonUp(int row, int column)
		{
		}
	}
}
