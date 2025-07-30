using XCom.Graphics;

namespace XCom.Controls;

public class ClickArea(int topRow, int leftColumn, int width, int height, Action action)
	: InteractiveControl
{
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
		action();
	}
}
