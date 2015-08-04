using XCom.Graphics;

namespace XCom.Controls
{
	public class Picture : Drawable
	{
		private readonly int topRow;
		private readonly int leftColumn;
		private readonly Image image;

		public Picture(
			int topRow,
			int leftColumn,
			Image image)
		{
			this.topRow = topRow;
			this.leftColumn = leftColumn;
			this.image = image;
		}

		public void Render(GraphicsBuffer buffer)
		{
			image.Render(buffer, topRow, leftColumn);
		}
	}
}
