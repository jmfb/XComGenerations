using XCom.Graphics;

namespace XCom.Controls
{
	public class Picture2 : Drawable
	{
		private readonly int topRow;
		private readonly int leftColumn;
		private readonly int width;
		private readonly byte[] image;
		private readonly int paletteIndex;

		public Picture2(
			int topRow,
			int leftColumn,
			int width,
			byte[] image,
			int paletteIndex)
		{
			this.topRow = topRow;
			this.leftColumn = leftColumn;
			this.width = width;
			this.image = image;
			this.paletteIndex = paletteIndex;
		}

		public void Render(GraphicsBuffer buffer)
		{
			buffer.DrawImage(image, topRow, leftColumn, width, paletteIndex);
		}
	}
}
