using XCom.Graphics;

namespace XCom.Controls
{
	public class Background : Drawable
	{
		private readonly byte[] background;
		private readonly int paletteIndex;

		public Background(
			byte[] background,
			int paletteIndex)
		{
			this.background = background;
			this.paletteIndex = paletteIndex;
		}

		public void Render(GraphicsBuffer buffer)
		{
			buffer.DrawBackground(
				background,
				0,
				0,
				GraphicsBuffer.GameWidth,
				GraphicsBuffer.GameHeight,
				paletteIndex);
		}
	}
}
