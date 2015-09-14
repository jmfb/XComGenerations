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
		private const int BytesPerRow = GameWidth * BytesPerPixel;
		private const int ByteCount = BytesPerRow * GameHeight;
		private readonly byte[] data = new byte[ByteCount];

		public byte[] Buffer
		{
			get { return data; }
		}

		public void Clear()
		{
			Array.Clear(data, 0, data.Length);
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
			var index = invertedRow * BytesPerRow + column * BytesPerPixel;
			var function = GetPixelFunction(operation);
			var source = new[] { color.R, color.G, color.B };
			foreach (var part in Enumerable.Range(0, BytesPerPixel))
				data[index + part] = function(source[part], data[index + part]);
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

		//TODO: implement this completely differently
		public void DrawTerrain(
			Terrain terrain,
			int shading, //0-8
			int zoom) //0-5
		{
			var mask = terrain.TerrainType.Metadata().Image(zoom);
			DrawTerrainTriangle(mask, shading, terrain.Vertices[0], terrain.Vertices[1], terrain.Vertices[2]);
			if (terrain.Vertices.Length == 4)
				DrawTerrainTriangle(mask, shading, terrain.Vertices[0], terrain.Vertices[2], terrain.Vertices[3]);
		}

		private void DrawTerrainTriangle(byte[] mask, int shading, params Point[] vertices)
		{
			//http://www.sunshine2k.de/coding/java/Bresenham/RasterisingLinesCircles.pdf
			//http://www.sunshine2k.de/coding/java/TriangleRasterization/TriangleRasterization.html#algo2
			var sortedVertices = vertices.OrderBy(vertex => vertex.Y).ToArray();
			if (sortedVertices[1].Y == sortedVertices[2].Y)
			{
				DrawTerrainTriangleFlatBottom(mask, shading, sortedVertices);
			}
			else if (sortedVertices[0].Y == sortedVertices[1].Y)
			{
				DrawTerrainTriangleFlatTop(mask, shading, sortedVertices);
			}
			else
			{
				var y10 = (float)(sortedVertices[1].Y - sortedVertices[0].Y);
				var y20 = (float)(sortedVertices[2].Y - sortedVertices[0].Y);
				var x20 = (float)(sortedVertices[2].X - sortedVertices[0].X);
				var midVertex = new Point
				{
					X = (int)(sortedVertices[0].X + (y10 /  y20) * x20),
					Y = sortedVertices[1].Y
				};
				DrawTerrainTriangleFlatBottom(mask, shading, new[] { sortedVertices[0], sortedVertices[1], midVertex });
				DrawTerrainTriangleFlatTop(mask, shading, new[] { sortedVertices[1], midVertex, sortedVertices[2] });
			}
		}

		private void DrawTerrainTriangleFlatBottom(byte[] mask, int shading, Point[] vertices)
		{
			var inverseSlope1 = (float)(vertices[1].X - vertices[0].X) / (vertices[1].Y - vertices[0].Y);
			var inverseSlope2 = (float)(vertices[2].X - vertices[0].X) / (vertices[2].Y - vertices[0].Y);
			var currentX1 = (float)vertices[0].X;
			var currentX2 = (float)vertices[0].X;
			foreach (var row in Enumerable.Range(vertices[0].Y, vertices[1].Y - vertices[0].Y + 1))
			{
				var x1 = (int)Math.Min(currentX1, currentX2);
				var x2 = (int)Math.Max(currentX1, currentX2);
				DrawTerrainLine(row, x1, x2 - x1 + 1, mask, shading);
				currentX1 += inverseSlope1;
				currentX2 += inverseSlope2;
			}
		}

		private void DrawTerrainTriangleFlatTop(byte[] mask, int shading, Point[] vertices)
		{
			var inverseSlope1 = (float)(vertices[2].X - vertices[0].X) / (vertices[2].Y - vertices[0].Y);
			var inverseSlope2 = (float)(vertices[2].X - vertices[1].X) / (vertices[2].Y - vertices[1].Y);
			var currentX1 = (float)vertices[2].X;
			var currentX2 = (float)vertices[2].X;
			foreach (var row in Enumerable.Range(0, vertices[2].Y - vertices[0].Y + 1).Select(index => vertices[2].Y - index))
			{
				currentX1 -= inverseSlope1;
				currentX2 -= inverseSlope2;
				var x1 = (int)Math.Min(currentX1, currentX2);
				var x2 = (int)Math.Max(currentX1, currentX2);
				DrawTerrainLine(row, x1, x2 - x1 + 1, mask, shading);
			}
		}

		private void DrawTerrainLine(int row, int leftColumn, int width, byte[] mask, int shading)
		{
			var palette = Palette.GetPalette(0);
			var maskRow = (row % 32 + 32) % 32;
			foreach (var column in Enumerable.Range(leftColumn, width))
			{
				var maskColumn = (column % 32 + 32) % 32;
				var maskIndex = maskRow * 32 + maskColumn;
				SetPixel(row, column, palette.GetColor(mask[maskIndex] + shading));
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
