using XCom.Graphics;

namespace XCom.Controls;

public class Background(byte[] background, int paletteIndex) : Drawable
{
	public void Render(GraphicsBuffer buffer)
	{
		buffer.DrawBackground(
			background,
			0,
			0,
			GraphicsBuffer.GameWidth,
			GraphicsBuffer.GameHeight,
			paletteIndex
		);
	}
}
