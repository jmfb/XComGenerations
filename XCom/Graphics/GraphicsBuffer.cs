using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using XCom.World;

namespace XCom.Graphics
{
	public class GraphicsBuffer
	{
		public const int GameWidth = 320;
		public const int GameHeight = 200;
		public const int BytesPerPixel = 3;
		private const int bytesPerRow = GameWidth * BytesPerPixel;
		private const int byteCount = bytesPerRow * GameHeight;
		public byte[] Buffer { get; } = new byte[byteCount];

		public void Clear()
		{
			Array.Clear(Buffer, 0, Buffer.Length);
		}

		public void DrawHorizontalLine(
			int row,
			int leftColumn,
			int width,
			Color color,
			CopyPixelOperation operation = CopyPixelOperation.SourceCopy)
		{
			if (!IsValidRow(row) || width <= 0)
				return;
			foreach (var column in Enumerable.Range(leftColumn, width))
				SetPixel(row, column, color, operation);
		}

		public void DrawVerticalLine(
			int topRow,
			int column,
			int height,
			Color color,
			CopyPixelOperation operation = CopyPixelOperation.SourceCopy)
		{
			if (!IsValidColumn(column) || height <= 0)
				return;
			foreach (var row in Enumerable.Range(topRow, height))
				SetPixel(row, column, color, operation);
		}

		public void DrawFrame(
			int topRow,
			int leftColumn,
			int width,
			int height,
			Color color,
			CopyPixelOperation operation = CopyPixelOperation.SourceCopy)
		{
			if (width <= 0 || height <= 0)
				return;
			DrawHorizontalLine(topRow, leftColumn, width, color, operation);
			DrawHorizontalLine(topRow + height - 1, leftColumn, width, color, operation);
			DrawVerticalLine(topRow + 1, leftColumn, height - 2, color, operation);
			DrawVerticalLine(topRow + 1, leftColumn + width - 1, height - 2, color, operation);
		}

		public void FillRect(
			int topRow,
			int leftColumn,
			int width,
			int height,
			Color color,
			CopyPixelOperation operation = CopyPixelOperation.SourceCopy)
		{
			if (width <= 0 || height <= 0)
				return;
			foreach (var row in Enumerable.Range(topRow, height))
				DrawHorizontalLine(row, leftColumn, width, color, operation);
		}

		private static IEnumerable<Point> Circle(int centerLeft, int centerTop, int radius)
		{
			var x = radius;
			var decisionOver2 = 1 - x;
			for (var y = 0; y <= x; )
			{
				yield return new Point { X = x + centerLeft, Y = y + centerTop };
				yield return new Point { X = y + centerLeft, Y = x + centerTop };
				yield return new Point { X = -x + centerLeft, Y = y + centerTop };
				yield return new Point { X = -y + centerLeft, Y = x + centerTop };
				yield return new Point { X = -x + centerLeft, Y = -y + centerTop };
				yield return new Point { X = -y + centerLeft, Y = -x + centerTop };
				yield return new Point { X = x + centerLeft, Y = -y + centerTop };
				yield return new Point { X = y + centerLeft, Y = -x + centerTop };
				++y;
				if (decisionOver2 <= 0)
				{
					decisionOver2 += 2 * y + 1;
				}
				else
				{
					--x;
					decisionOver2 += 2 * (y - x) + 1;
				}
			}
		}

		public void FillCircle(int radius, Color color)
		{
			foreach (var group in Circle(128, 100, radius)
				.GroupBy(point => point.Y)
				.Where(group => group.Key >= 0 && group.Key < GameHeight))
			{
				var minX = group.Min(point => point.X);
				var maxX = group.Max(point => point.X);
				foreach (var column in Enumerable.Range(minX, maxX - minX + 1)
					.Where(column => column >= 0 && column < 256))
				{
					SetPixel(group.Key, column, color);
				}
			}
		}

		public void SetPixel(
			int row,
			int column,
			Color color,
			CopyPixelOperation operation = CopyPixelOperation.SourceCopy)
		{
			if (!IsValidPixel(row, column))
				return;
			//OpenGL buffer has row 0 at the bottom
			//Row is inverted for normal window coordinates (0 at top).
			var invertedRow = GameHeight - row - 1;
			var index = invertedRow * bytesPerRow + column * BytesPerPixel;
			var function = GetPixelFunction(operation);
			var source = new[] { color.R, color.G, color.B };
			foreach (var part in Enumerable.Range(0, BytesPerPixel))
				Buffer[index + part] = function(source[part], Buffer[index + part]);
		}

		public void DrawBackground(
			byte[] background,
			int topRow,
			int leftColumn,
			int width,
			int height,
			int paletteIndex)
		{
			DrawPaletteImage(
				topRow,
				leftColumn,
				background,
				GameWidth,
				GameHeight,
				topRow,
				leftColumn,
				width,
				height,
				paletteIndex);
		}

		public void DrawImage(
			byte[] image,
			int topRow,
			int leftColumn,
			int width,
			int paletteIndex)
		{
			DrawPaletteImage(
				topRow,
				leftColumn,
				image,
				width,
				image.Length / width,
				0,
				0,
				width,
				image.Length / width,
				paletteIndex);
		}

		private static void Swap<T>(ref T value1, ref T value2)
		{
			var temp = value1;
			value1 = value2;
			value2 = temp;
		}

		private static IEnumerable<Point> Line(Point from, Point to)
		{
			var x0 = from.X;
			var y0 = from.Y;
			var x1 = to.X;
			var y1 = to.Y;
			var steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
			if (steep)
			{
				Swap(ref x0, ref y0);
				Swap(ref x1, ref y1);
			}
			if (x0 > x1)
			{
				Swap(ref x0, ref x1);
				Swap(ref y0, ref y1);
			}
			var dX = x1 - x0;
			var dY = Math.Abs(y1 - y0);
			var error = dX / 2;
			var yStep = y0 < y1 ? 1 : -1;
			var y = y0;

			for (var x = x0; x <= x1; ++x)
			{
				yield return steep ?
					new Point { X = y, Y = x } :
					new Point { X = x, Y = y };
				error = error - dY;
				if (error >= 0)
					continue;
				y += yStep;
				error += dX;
			}
		}

		private static IEnumerable<Point> Triangle(Point[] vertices)
		{
			foreach (var group in Line(vertices[0], vertices[1])
				.Concat(Line(vertices[1], vertices[2]))
				.Concat(Line(vertices[2], vertices[0]))
				.GroupBy(point => point.Y)
				.Where(group => group.Key >= 0 && group.Key < GameHeight))
			{
				var minX = group.Min(point => point.X);
				var maxX = group.Max(point => point.X);
				foreach (var column in Enumerable.Range(minX, maxX - minX + 1)
					.Where(column => column >= 0 && column < 256))
				{
					yield return new Point { X = column, Y = group.Key };
				}
			}
		}

		public void DrawTerrain(
			Terrain terrain,
			int radius,
			int shading, //0-8
			int zoom) //0-5
		{
			var mask = terrain.TerrainType.Metadata().Image(zoom);
			var palette = Palette.GetPalette(0);
			var radiusSquared = radius * radius;
			const int centerX = 128;
			const int centerY = 100;
			foreach (var point in Triangle(terrain.Vertices))
			{
				var x = point.X - centerX;
				var y = point.Y - centerY;
				//TODO: improve sphere clipping logic
				if ((x * x + y * y) > radiusSquared)
					continue;
				var maskRow = (point.Y % 32 + 32) % 32;
				var maskColumn = (point.X % 32 + 32) % 32;
				var maskIndex = maskRow * 32 + maskColumn;
				SetPixel(point.Y, point.X, palette.GetColor(mask[maskIndex] + shading));
			}
		}

		public void DrawOverlay(byte[] overlay, int paletteIndex)
		{
			const ushort skipCode = 0xffff;
			const ushort drawCode = 0xfffe;
			const ushort doneCode = 0xfffd;
			var palette = Palette.GetPalette(paletteIndex);
			for (int overlayIndex = 0, screenIndex = 0; overlayIndex < overlay.Length; )
			{
				var code = BitConverter.ToUInt16(overlay, overlayIndex);
				overlayIndex += sizeof(ushort);
				switch (code)
				{
				case skipCode:
					screenIndex += 2 * BitConverter.ToInt16(overlay, overlayIndex);
					overlayIndex += sizeof(short);
					break;
				case drawCode:
					var pixelCount = 2 * BitConverter.ToInt16(overlay, overlayIndex);
					overlayIndex += sizeof(short);
					for (; pixelCount > 0; --pixelCount, ++overlayIndex, ++screenIndex)
						SetPixel(screenIndex / GameWidth, screenIndex % GameWidth, palette.GetColor(overlay[overlayIndex]));
					break;
				case doneCode:
					return;
				}
			}
		}

		public void DrawItem(int topRow, int leftColumn, byte[] item)
		{
			const int imageWidth = 32;
			const byte skipCode = 0xfe;
			const byte doneCode = 0xff;
			var skipRows = item[0];
			var palette = Palette.GetPalette(4);
			for (int itemIndex = 1, imageIndex = 0; itemIndex < item.Length; )
			{
				var code = item[itemIndex++];
				switch (code)
				{
				case skipCode:
					imageIndex += item[itemIndex++];
					break;
				case doneCode:
					return;
				default:
					SetPixel(topRow + skipRows + imageIndex / imageWidth, leftColumn + imageIndex % imageWidth, palette.GetColor(code));
					++imageIndex;
					break;
				}
			}
		}

		private void DrawPaletteImage(
			int topRow,
			int leftColumn,
			IList<byte> image,
			int imageWidth,
			int imageHeight,
			int topSourceRow,
			int leftSourceColumn,
			int sourceWidth,
			int sourceHeight,
			int paletteIndex,
			bool masked = false)
		{
			var palette = Palette.GetPalette(paletteIndex);
			foreach (var rowIndex in Enumerable.Range(0, sourceHeight))
			{
				var sourceRow = topSourceRow + rowIndex;
				if (sourceRow < 0 || sourceRow >= imageHeight)
					continue;
				foreach (var columnIndex in Enumerable.Range(0, sourceWidth))
				{
					var sourceColumn = leftSourceColumn + columnIndex;
					if (sourceColumn < 0 || sourceColumn >= imageWidth)
						continue;
					var sourceIndex = sourceRow * imageWidth + sourceColumn;
					var colorIndex = image[sourceIndex];
					if (!masked || colorIndex != 0)
						SetPixel(
							topRow + rowIndex,
							leftColumn + columnIndex,
							palette.GetColor(image[sourceIndex]));
				}
			}
		}

		public void DrawMaskedImage(
			int topRow,
			int leftColumn,
			byte[] image,
			int width,
			int height,
			int paletteIndex)
		{
			DrawPaletteImage(
				topRow,
				leftColumn,
				image,
				width,
				height,
				0,
				0,
				width,
				height,
				paletteIndex,
				true);
		}

		private static bool IsValidRow(int row)
		{
			return row >= 0 && row < GameHeight;
		}

		private static bool IsValidColumn(int column)
		{
			return column >= 0 && column < GameWidth;
		}

		private static bool IsValidPixel(int row, int column)
		{
			return IsValidRow(row) && IsValidColumn(column);
		}

		private static Func<byte, byte, byte> GetPixelFunction(
			CopyPixelOperation operation)
		{
			switch (operation)
			{
			case CopyPixelOperation.SourceCopy:
				return (source, destination) => source;
			case CopyPixelOperation.SourcePaint:
				return (source, destination) => (byte)(source | destination);
			default:
				throw new InvalidOperationException("Unsupported CopyPixelOperation");
			}
		}
	}
}
