using XCom.Graphics;

namespace XCom.Controls
{
	public class Overlay : Drawable
	{
		private readonly byte[] overlay;
		private readonly int paletteIndex;

		public Overlay(byte[] overlay, int paletteIndex = 3)
		{
			this.overlay = overlay;
			this.paletteIndex = paletteIndex;
		}

		public void Render(GraphicsBuffer buffer)
		{
			buffer.DrawOverlay(overlay, paletteIndex);
		}
	}
}
