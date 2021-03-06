﻿using System;
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
			public Func<T, ColoredText>[] Parts { get; set; }
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
		private bool isUpDownList;
		private Action<T> downAction;
		private const int rowHeight = 8;

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

		public ListView<T> ConfigureUpDown(int left, Action<T> theDownAction)
		{
			isUpDownList = true;
			downAction = theDownAction;
			var displayedRowCount = Math.Min(maxRowsToDisplay, data.Count);
			foreach (var index in Enumerable.Range(0, displayedRowCount))
			{
				var localIndex = index;
				AddControl(new UpDown(topRow + index * rowHeight, left, defaultScheme, () => OnUp(localIndex), () => OnDown(localIndex)));
			}
			return this;
		}

		private void OnUp(int index)
		{
			action(data[index + scrollPosition]);
		}

		private void OnDown(int index)
		{
			downAction(data[index + scrollPosition]);
		}

		public ListView<T> AddColumn(
			int width,
			Alignment alignment,
			Func<T, string> display,
			Func<T, ColorScheme> scheme = null)
		{
			return AddColumn(
				width,
				alignment,
				value => new ColoredText
				{
					Text = display(value),
					Scheme = scheme?.Invoke(value) ?? defaultScheme
				});
		}

		public ListView<T> AddColumn(
			int width,
			Alignment alignment,
			params Func<T, ColoredText>[] parts)
		{
			columns.Add(new Column
			{
				Width = width,
				Alignment = alignment,
				Parts = parts
			});
			MoveButtons();
			return this;
		}

		public void AbortUpDown()
		{
			foreach (var upDown in GetChildControls<UpDown>())
				upDown.Abort();
		}

		private int Height => maxRowsToDisplay * rowHeight;

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
			var rowIndex = (row - topRow) / rowHeight;
			if (IsCursorBetweenListColumns(column) && IsValidRowIndex(rowIndex) && !isUpDownList)
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
			var pointerRowIndex = (pointerPosition.Y - topRow) / rowHeight;
			if (IsCursorBetweenListColumns(pointerPosition.X) && IsValidRowIndex(pointerRowIndex))
				RenderSelectedRow(buffer, pointerRowIndex);
			var visibleRowCount = Math.Min(maxRowsToDisplay, data.Count - scrollPosition);
			foreach (var rowIndex in Enumerable.Range(0, visibleRowCount))
			{
				var rowData = data[rowIndex + scrollPosition];
				var textTopRow = topRow + rowIndex * rowHeight;
				var nextLeftColumn = leftColumn;
				foreach (var column in columns)
				{
					var parts = column.Parts.Select(part => part(rowData)).ToList();
					var textLeftColumn = nextLeftColumn;
					var textWidth = parts.Sum(part => Font.Normal.MeasureString(part.Text)) - parts.Count;
					switch (column.Alignment)
					{
					case Alignment.Center:
						textLeftColumn = nextLeftColumn + (column.Width - textWidth) / 2;
						break;
					case Alignment.Right:
						textLeftColumn = nextLeftColumn + column.Width - textWidth;
						break;
					}
					var nextPartLeft = textLeftColumn;
					foreach (var part in parts)
					{
						var left = nextPartLeft;
						nextPartLeft += Font.Normal.MeasureString(part.Text) - 1;
						Font.Normal.DrawString(buffer, textTopRow, left, part.Text, part.Scheme);
					}

					nextLeftColumn += column.Width;
				}
			}
			base.Render(buffer);
		}

		private void RenderSelectedRow(GraphicsBuffer buffer, int rowIndex)
		{
			buffer.FillRect(
				topRow + rowIndex * rowHeight,
				leftColumn,
				ColumnWidths,
				rowHeight,
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
