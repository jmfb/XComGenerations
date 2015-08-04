using System;
using System.Linq;
using XCom.Graphics;

namespace XCom.Fonts
{
	public class Character
	{
		private readonly int height;
		private readonly byte[] data;

		public Character(byte[] data, int height)
		{
			if ((data.Length % height) != 0)
				throw new InvalidOperationException("Invalid character data size.");
			this.data = data;
			this.height = height;
		}

		public int Width
		{
			get
			{
				return data.Length / height;
			}
		}

		public void Render(GraphicsBuffer buffer, int topRow, int leftColumn, ColorScheme scheme)
		{
			foreach (var rowIndex in Enumerable.Range(0, height))
			{
				foreach (var columnIndex in Enumerable.Range(0, Width))
				{
					var colorIndex = data[rowIndex * Width + columnIndex];
					if (colorIndex != 0)
						buffer.SetPixel(
							topRow + rowIndex,
							leftColumn + columnIndex,
							scheme.GetColor(colorIndex));
				}
			}
		}
	}
}
