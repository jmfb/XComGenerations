using XCom.Graphics;

namespace XCom.Controls;

public class ClickGridArea(
	int topRow,
	int leftColumn,
	int width,
	int height,
	Action<int, int> action
) : InteractiveControl
{
	private readonly int width = width * 16;
	private readonly int height = height * 16;

	public override void Render(GraphicsBuffer buffer) { }

	public override bool HitTest(int row, int column)
	{
		return row >= topRow
			&& row < topRow + height
			&& column >= leftColumn
			&& column < leftColumn + width;
	}

	public override void OnLeftButtonDown(int row, int column)
	{
		var gridRow = (row - topRow) / 16;
		var gridColumn = (column - leftColumn) / 16;
		action(gridRow, gridColumn);
	}
}
