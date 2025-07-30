using XCom.Graphics;

namespace XCom.Controls;

public class Overlay(byte[] overlay, int paletteIndex = 3) : Drawable
{
	public void Render(GraphicsBuffer buffer)
	{
		buffer.DrawOverlay(overlay, paletteIndex);
	}
}
