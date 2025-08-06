using System.Drawing;
using XCom.Controls;
using XCom.Graphics;
using XCom.Music;
using XCom.Screens;
using Font = XCom.Fonts.Font;

namespace XCom.Battlescape;

public class SetTimerModal(Action<int> action) : Screen
{
	private const int topRow = 40;
	private const int leftColumn = 64;
	private const int width = 192;
	private const int height = 96;
	private const int buttonSize = 24;
	private const int headerHeight = 24;
	private const int topButtonRow = topRow + headerHeight;
	private const int buttonRows = 3;
	private const int buttonRowsHeight = buttonRows * buttonSize;
	private const int buttonColumns = width / buttonSize;
	private const int totalButtons = buttonRows * buttonColumns;
	private const int buttonPadding = 1;

	public override bool IsSilentModal => true;

	public override void Render(GraphicsBuffer buffer)
	{
		var scheme = ColorScheme.DarkOrange;
		var palette = Palette.GetPalette(14);
		const int colorIndex = 16;
		buffer.FillRect(topRow, leftColumn, width, height, palette.GetColor(colorIndex + 8));
		buffer.DrawFrame(
			topRow + 1,
			leftColumn + 1,
			width - 2,
			headerHeight - 2,
			palette.GetColor(colorIndex + 6)
		);
		buffer.FillRect(
			topRow + 3,
			leftColumn + 3,
			width - 6,
			headerHeight - 6,
			palette.GetColor(colorIndex + 10)
		);
		var label = new Label(topRow + 5, Label.Center, "Set Timer", Font.Large, scheme);
		label.Render(buffer);
		foreach (var buttonRow in Enumerable.Range(0, buttonRows))
		foreach (var buttonColumn in Enumerable.Range(0, buttonColumns))
		{
			var top = topButtonRow + buttonSize * buttonRow;
			var left = leftColumn + buttonSize * buttonColumn;
			buffer.DrawFrame(
				top + buttonPadding,
				left + buttonPadding,
				buttonSize - 2 * buttonPadding,
				buttonSize - 2 * buttonPadding,
				Color.Black
			);
			buffer.FillRect(
				top + buttonPadding + 1,
				left + buttonPadding + 1,
				buttonSize - 2 * buttonPadding - 2,
				buttonSize - 2 * buttonPadding - 2,
				palette.GetColor(colorIndex + 12)
			);
			var timer = buttonColumn + buttonRow * buttonColumns;
			Font.Large.DrawString(buffer, top + 6, left + 2, $"{timer}", scheme);
		}
	}

	public override bool HitTest(int row, int column) => true;

	public override void OnLeftButtonDown(int row, int column)
	{
		var buttonRow = (row - topButtonRow) / buttonSize;
		var buttonColumn = (column - leftColumn) / buttonSize;
		if (
			row >= topButtonRow
			&& buttonRow < buttonRows
			&& column >= leftColumn
			&& buttonColumn < buttonColumns
		)
		{
			var timer = buttonColumn + buttonRow * buttonColumns;
			WindowsSoundEffect.ButtonPush.Play();
			action(timer);
		}
		EndModal();
	}

	public override void OnRightButtonDown(int row, int column)
	{
		EndModal();
	}
}
