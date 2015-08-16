using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using XCom.Graphics;
using Font = XCom.Fonts.Font;

namespace XCom.Controls
{
	public class ListView<T> : InteractiveContainer
	{
		private class Column
		{
			public int Width { get; set; }
			public Alignment Alignment { get; set; }
			public Func<T, string> Display { get; set; }
			public Func<T, ColorScheme> Scheme { get; set; }
		}

		private readonly List<Column> columns = new List<Column>();
		private readonly int topRow;
		private readonly int leftColumn;
		private readonly int maxRowsToDisplay;
		private readonly List<T> data;
		private readonly ColorScheme defaultScheme;
		private readonly Color selectionColor;
		private readonly Action<T> action;
		private int scrollPosition;
		private readonly Repeater up;
		private readonly Repeater down;
		private const int RowHeight = 8;

		public ListView(
			int topRow,
			int leftColumn,
			int maxRowsToDisplay,
			List<T> data,
			ColorScheme scheme,
			Color selectionColor,
			Action<T> action)
		{
			this.topRow = topRow;
			this.leftColumn = leftColumn;
			this.maxRowsToDisplay = maxRowsToDisplay;
			this.data = data;
			defaultScheme = scheme;
			this.selectionColor = selectionColor;
			this.action = action;

			up = new Repeater(0, 0, 13, 15, "U", scheme, Font.Arrow, OnUp, 100);
			down = new Repeater(0, 0, 13, 15, "D", scheme, Font.Arrow, OnDown, 100);
			AddControl(up);
			AddControl(down);
			UpdateButtons();
		}

		public ListView<T> AddColumn(
			int width,
			Alignment alignment,
			Func<T, string> display,
			Func<T, ColorScheme> scheme = null)
		{
			columns.Add(new Column
			{
				Width = width,
				Alignment = alignment,
				Display = display,
				Scheme = scheme
			});
			MoveButtons();
			return this;
		}

		private int Height => maxRowsToDisplay * RowHeight;

		private int Width => ColumnWidths + 16;

		private int ColumnWidths
		{
			get { return columns.Sum(column => column.Width); }
		}

		public override bool HitTest(int row, int column)
		{
			return row >= topRow &&
				row < (topRow + Height) &&
				column >= leftColumn &&
				column < (leftColumn + Width);
		}

		public override void OnLeftButtonDown(int row, int column)
		{
			var rowIndex = (row - topRow) / RowHeight;
			if (IsCursorBetweenListColumns(column) && IsValidRowIndex(rowIndex))
			{
				action(data[rowIndex + scrollPosition]);
			}
			else
			{
				base.OnLeftButtonDown(row, column);
			}
		}

		public override void Render(GraphicsBuffer buffer)
		{
			var pointerPosition = GameState.Current.PointerPosition;
			var pointerRowIndex = (pointerPosition.Y - topRow) / RowHeight;
			if (IsCursorBetweenListColumns(pointerPosition.X) && IsValidRowIndex(pointerRowIndex))
				RenderSelectedRow(buffer, pointerRowIndex);
			var visibleRowCount = Math.Min(maxRowsToDisplay, data.Count - scrollPosition);
			foreach (var rowIndex in Enumerable.Range(0, visibleRowCount))
			{
				var rowData = data[rowIndex + scrollPosition];
				var textTopRow = topRow + rowIndex * RowHeight;
				var nextLeftColumn = leftColumn;
				foreach (var column in columns)
				{
					var columnText = column.Display(rowData);
					var textLeftColumn = nextLeftColumn;
					switch (column.Alignment)
					{
					case Alignment.Center:
						textLeftColumn = nextLeftColumn + (column.Width - Font.Normal.MeasureString(columnText)) / 2;
						break;
					case Alignment.Right:
						textLeftColumn = nextLeftColumn + column.Width - Font.Normal.MeasureString(columnText);
						break;
					}
					var columnScheme = column.Scheme == null ? defaultScheme : column.Scheme(rowData);
					Font.Normal.DrawString(buffer, textTopRow, textLeftColumn, columnText, columnScheme);

					nextLeftColumn += column.Width;
				}
			}
			base.Render(buffer);
		}

		private void RenderSelectedRow(GraphicsBuffer buffer, int rowIndex)
		{
			buffer.FillRect(
				topRow + rowIndex * RowHeight,
				leftColumn,
				ColumnWidths,
				RowHeight,
				selectionColor,
				CopyPixelOperation.SourcePaint);
		}

		private void OnUp()
		{
			if (scrollPosition <= 0)
				return;
			--scrollPosition;
			UpdateButtons();
		}

		private int MaxScrollPosition => data.Count - maxRowsToDisplay;

		private void OnDown()
		{
			if (scrollPosition >= MaxScrollPosition)
				return;
			++scrollPosition;
			UpdateButtons();
		}

		private void MoveButtons()
		{
			var buttonLeftColumn = leftColumn + ColumnWidths + 3;
			up.Move(topRow, buttonLeftColumn);
			down.Move(topRow + Height - 15, buttonLeftColumn); 
		}

		private void UpdateButtons()
		{
			up.Visible = scrollPosition > 0;
			down.Visible = scrollPosition < MaxScrollPosition;
		}

		private bool IsCursorBetweenListColumns(int column)
		{
			return column >= leftColumn &&
				column < (leftColumn + ColumnWidths);
		}

		private bool IsValidRowIndex(int rowIndex)
		{
			return rowIndex >= 0 &&
				rowIndex < maxRowsToDisplay &&
				(rowIndex + scrollPosition) < data.Count;
		}
	}
}
