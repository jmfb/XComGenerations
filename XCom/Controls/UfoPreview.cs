using XCom.Graphics;

namespace XCom.Controls
{
	public class UfoPreview : Drawable
	{
		private readonly int topRow;
		private readonly int leftColumn;
		private readonly byte[] image;

		public UfoPreview(
			int topRow,
			int leftColumn,
			byte[] image)
		{
			this.topRow = topRow;
			this.leftColumn = leftColumn;
			this.image = image;
		}

		public void Render(GraphicsBuffer buffer)
		{
			buffer.DrawImage(image, topRow, leftColumn, 160, 0);
		}
	}
}
