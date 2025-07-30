using XCom.Graphics;

namespace XCom.Controls;

public class Picture(int topRow, int leftColumn, Image image) : Drawable
{
	public void Render(GraphicsBuffer buffer)
	{
		image.Render(buffer, topRow, leftColumn);
	}
}
