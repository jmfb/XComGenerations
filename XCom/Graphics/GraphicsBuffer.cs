using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
