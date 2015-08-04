using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls
{
	public class Label : Drawable
	{
		protected int TopRow { get; private set; }
		protected int LeftColumn { get; private set; }
		public string Text { protected get; set; }
		protected Font Font { get; private set; }
		private readonly ColorScheme scheme;

		public const int Center = -1;
		public class CenterParameters
		{
			public int LeftColumn { private get; set; }
			public int Width { private get; set; }

			public int CalculateTextColumn(string text, Font font)
			{
				var textWidth = font.MeasureString(text);
				return LeftColumn + (Width - textWidth) / 2;
			}
		}

		public static CenterParameters CenterOf(int leftColumn, int width)
		{
			return new CenterParameters
			{
				LeftColumn = leftColumn,
				Width = width
			};
		}

		public Label(
			int topRow,
			int leftColumn,
			string text,
			Font font,
			ColorScheme scheme)
		{
			TopRow = topRow;
			LeftColumn = leftColumn == Center ?
				(GraphicsBuffer.GameWidth - font.MeasureString(text)) / 2 :
				leftColumn;
			Text = text;
			Font = font;
			this.scheme = scheme;
		}

		public Label(
			int topRow,
			CenterParameters centerOf,
			string text,
			Font font,
			ColorScheme scheme)
			: this(topRow, centerOf.CalculateTextColumn(text, font), text, font, scheme)
		{
		}

		public virtual void Render(GraphicsBuffer buffer)
		{
			Font.DrawString(buffer, TopRow, LeftColumn, Text, scheme);
		}
	}
}
