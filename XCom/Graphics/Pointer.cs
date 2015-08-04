using System.Linq;

namespace XCom.Graphics
{
	public static class Pointer
	{
		public static void Render(int topRow, int leftColumn, GraphicsBuffer buffer)
		{
			buffer.DrawMaskedImage(topRow, leftColumn, image, Width, Height, PaletteIndex);
		}

		private const int Height = 13;
		private const int Width = 9;
		private const int PaletteIndex = 2;

		private static readonly byte[] imageMask =
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 1, 0, 0, 0, 0, 0, 0, 0,
			1, 2, 1, 0, 0, 0, 0, 0, 0,
			1, 2, 2, 1, 0, 0, 0, 0, 0,
			1, 2, 3, 2, 1, 0, 0, 0, 0,
			1, 2, 3, 3, 2, 1, 0, 0, 0,
			1, 2, 3, 4, 3, 2, 1, 0, 0,
			1, 2, 3, 4, 4, 3, 2, 1, 0,
			1, 2, 3, 4, 4, 4, 3, 2, 1,
			1, 2, 3, 4, 0, 0, 0, 0, 0,
			1, 2, 3, 0, 0, 0, 0, 0, 0,
			1, 2, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0, 0, 0, 0, 0
		};

		private static byte[] GetImage()
		{
			return imageMask
				.Select(colorIndex => colorIndex == 0 ? (byte)0 : (byte)(colorIndex + 251))
				.ToArray();
		}

		private static readonly byte[] image = GetImage();
	}
}
