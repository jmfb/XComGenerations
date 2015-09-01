using XCom.Graphics;

namespace XCom.Controls
{
	public class Overlay : Drawable
	{
		private readonly byte[] overlay;

		public Overlay(byte[] overlay)
		{
			this.overlay = overlay;
		}

		public void Render(GraphicsBuffer buffer)
		{
			buffer.DrawOverlay(overlay);
		}
	}
}
