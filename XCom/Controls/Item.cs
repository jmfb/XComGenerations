using XCom.Graphics;

namespace XCom.Controls
{
	public class Item : Drawable
	{
		private readonly int topRow;
		private readonly int leftColumn;
		private readonly byte[] item;

		public Item(int topRow, int leftColumn, byte[] item)
		{
			this.topRow = topRow;
			this.leftColumn = leftColumn;
			this.item = item;
		}

		public void Render(GraphicsBuffer buffer)
		{
			buffer.DrawItem(topRow, leftColumn, item);
		}
	}
}
