using XCom.Fonts;
using XCom.Graphics;
using XCom.Music;

namespace XCom.Controls;

public class Button(
	int topRow,
	int leftColumn,
	int width,
	int height,
	string text,
	ColorScheme scheme,
	Font font,
	Action action
) : InteractiveControl
{
	protected Action Action { get; } = action;
	protected bool Pushed { get; set; }
	public bool Visible { protected get; set; } = true;

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
		buffer.DrawHorizontalLine(
			topRow + height - 1,
			leftColumn + 1,
			width - 1,
			colorScheme.Darker
		);
		buffer.DrawVerticalLine(topRow, leftColumn + width - 1, height, colorScheme.Darker);

		var textTopRow = topRow + (height - font.Height + 1) / 2;
		var textLeftColumn = leftColumn + (width - font.MeasureString(text)) / 2;
		font.DrawString(buffer, textTopRow, textLeftColumn, text, colorScheme);
	}

	public override bool HitTest(int row, int column)
	{
		return Visible
			&& row >= topRow
			&& row < (topRow + height)
			&& column >= leftColumn
			&& column < (leftColumn + width);
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
		WindowsSoundEffect.ButtonPush.Play();
		Action();
	}
}
