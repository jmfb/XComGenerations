using XCom.Graphics;

namespace XCom.Controls;

public class Item(int topRow, int leftColumn, byte[] item) : Drawable
{
	public void Render(GraphicsBuffer buffer)
	{
		buffer.DrawItem(topRow, leftColumn, item);
	}
}
