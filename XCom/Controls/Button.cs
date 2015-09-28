using System;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls
{
	public class Button : InteractiveControl
	{
		private int topRow;
		private int leftColumn;
		private readonly int width;
		private readonly int height;
		private readonly string text;
		private readonly ColorScheme scheme;
		private readonly Font font;
		protected Action Action { get; }
		protected bool Pushed { get; set; }
		public bool Visible { protected get; set; }

		public Button(
			int topRow,
			int leftColumn,
			int width,
			int height,
			string text,
			ColorScheme scheme,
			Font font,
			Action action)
		{
			this.topRow = topRow;
			this.leftColumn = leftColumn;
			this.width = width;
			this.height = height;
			this.text = text;
			this.scheme = scheme;
			this.font = font;
			Action = action;
			Visible = true;
		}

		public void Move(int newTopRow, int newLeftColumn)
		{
			topRow = newTopRow;
			leftColumn = newLeftColumn;
		}

		public override void Render(GraphicsBuffer buffer)
		{
			if (!Visible)
				return;

			var colorScheme = Pushed ? scheme.Inverse : scheme;

			buffer.DrawHorizontalLine(topRow, leftColumn, width - 1, colorScheme.Lighter);
			buffer.DrawVerticalLine(topRow, leftColumn, height, colorScheme.Lighter);
			buffer.DrawHorizontalLine(topRow + 1, leftColumn + 1, width - 3, colorScheme.Light);
			buffer.DrawVerticalLine(topRow + 1, leftColumn + 1, height - 2, colorScheme.Light);
			buffer.FillRect(topRow + 2, leftColumn + 2, width - 4, height - 4, colorScheme.LightDark);
			buffer.DrawHorizontalLine(topRow + height - 2, leftColumn + 2, width - 3, colorScheme.Dark);
			buffer.DrawVerticalLine(topRow + 1, leftColumn + width - 2, height - 2, colorScheme.Dark);
			buffer.DrawHorizontalLine(topRow + height - 1, leftColumn + 1, width - 1, colorScheme.Darker);
			buffer.DrawVerticalLine(topRow, leftColumn + width - 1, height, colorScheme.Darker);

			var textTopRow = topRow + (height - font.Height + 1) / 2;
			var textLeftColumn = leftColumn + (width - font.MeasureString(text)) / 2;
			font.DrawString(buffer, textTopRow, textLeftColumn, text, colorScheme);
		}

		public override bool HitTest(int row, int column)
		{
			return Visible &&
				row >= topRow &&
				row < (topRow + height) &&
				column >= leftColumn &&
				column < (leftColumn + width);
		}

		public override void OnLeftButtonDown(int row, int column)
		{
			if (Pushed)
				return;
			Pushed = true;
			GameState.Current.Dispatcher.CaptureFocus(this);
		}

		public override void OnLeftButtonUp(int row, int column)
		{
			if (!Pushed)
				return;
			Pushed = false;
			GameState.Current.Dispatcher.ReleaseFocus();
			Action();
		}
	}
}
