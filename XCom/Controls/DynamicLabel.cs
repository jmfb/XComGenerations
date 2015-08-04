using System;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls
{
	public class DynamicLabel : Label
	{
		private readonly Func<string> textAction;

		public DynamicLabel(
			int topRow,
			int leftColumn,
			Func<string> textAction,
			Font font,
			ColorScheme scheme)
			: base(topRow, leftColumn, textAction(), font, scheme)
		{
			this.textAction = textAction;
		}

		public override void Render(GraphicsBuffer buffer)
		{
			Text = textAction();
			base.Render(buffer);
		}
	}
}
