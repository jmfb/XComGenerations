using XCom.Graphics;

namespace XCom.Controls;

public class UfoPreview(int topRow, int leftColumn, byte[] image) : Drawable
{
	public void Render(GraphicsBuffer buffer)
	{
		buffer.DrawImage(image, topRow, leftColumn, 160, 0);
	}
}
