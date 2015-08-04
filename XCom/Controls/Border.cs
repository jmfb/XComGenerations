using System.Linq;
using XCom.Graphics;

namespace XCom.Controls
{
	public class Border : Drawable
	{
		private readonly int topRow;
		private readonly int leftColumn;
		private readonly int width;
		private readonly int height;
		private readonly ColorScheme scheme;
		private readonly byte[] background;
		private readonly int paletteIndex;

		public Border(
			int topRow,
			int leftColumn,
			int width,
			int height,
			ColorScheme scheme,
			byte[] background,
			int paletteIndex)
		{
			this.topRow = topRow;
			this.leftColumn = leftColumn;
			this.width = width;
			this.height = height;
			this.scheme = scheme;
			this.background = background;
			this.paletteIndex = paletteIndex;
		}

		public void Render(GraphicsBuffer buffer)
		{
			var pattern = new[]
			{
				scheme.Base,
				scheme.Light,
				scheme.Lighter,
				scheme.Light,
				scheme.Base
			};
			foreach (var index in Enumerable.Range(0, pattern.Length))
				buffer.DrawFrame(
					topRow + index,
					leftColumn + index,
					width - 2 * index,
					height - 2 * index,
					pattern[index]);
			buffer.DrawBackground(
				background,
				topRow + pattern.Length,
				leftColumn + pattern.Length,
				width - 2 * pattern.Length,
				height - 2 * pattern.Length,
				paletteIndex);
		}
	}
}
