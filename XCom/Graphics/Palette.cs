using System;
using System.Drawing;
using System.Linq;

namespace XCom.Graphics
{
	public class Palette
	{
		private const int paletteEntries = 256;
		private const int paletteSize = paletteEntries * GraphicsBuffer.BytesPerPixel;

		private readonly byte[] data = new byte[paletteSize];

		private Palette(byte[] source)
		{
			Array.Clear(data, 0, data.Length);
			Array.Copy(source, data, Math.Min(data.Length, source.Length));
		}

		public Color GetColor(int colorIndex)
		{
			var index = colorIndex * GraphicsBuffer.BytesPerPixel;
			if (index < 0 || index >= data.Length)
				throw new InvalidOperationException("Invalid colorIndex");
			var red = data[index] << 2;
			var green = data[index + 1] << 2;
			var blue = data[index + 2] << 2;
			return Color.FromArgb(red, green, blue);
		}

		private void SetColor(int colorIndex, Color color)
		{
			var index = colorIndex * GraphicsBuffer.BytesPerPixel;
			if (index < 0 || index >= data.Length)
				throw new InvalidOperationException("Invalid colorIndex");
			data[index] = (byte)(color.R >> 2);
			data[index + 1] = (byte)(color.G >> 2);
			data[index + 2] = (byte)(color.B >> 2);
		}

		private void MoveColor(int sourceIndex, int destinationIndex)
		{
			var sourceColor = GetColor(sourceIndex);
			var destinationColor = GetColor(destinationIndex);
			SetColor(destinationIndex, sourceColor);
			SetColor(sourceIndex, destinationColor);
		}

		private Palette MoveRange(int sourceIndex, int count, int destinationIndex)
		{
			var newPalette = new Palette(data);
			foreach (var index in Enumerable.Range(0, count))
				newPalette.MoveColor(sourceIndex + index, destinationIndex + index);
			return newPalette;
		}

		private static readonly Palette background = new Palette(Content.Palettes.Palettes.Background);
		private static readonly Palette palette0 = new Palette(Content.Palettes.Palettes.Palette0);
		private static readonly Palette palette1 = new Palette(Content.Palettes.Palettes.Palette1);
		private static readonly Palette palette2 = new Palette(Content.Palettes.Palettes.Palette2);
		private static readonly Palette palette3 = new Palette(Content.Palettes.Palettes.Palette3);
		private static readonly Palette palette4 = new Palette(Content.Palettes.Palettes.Palette4);

		private static readonly Color[] greyscale =
		{
			Color.FromArgb(140, 150, 148),
			Color.FromArgb(132, 138, 140),
			Color.FromArgb(115, 125, 132),
			Color.FromArgb(107, 117, 123),
			Color.FromArgb(90, 105, 107),
			Color.FromArgb(82, 93, 99),
			Color.FromArgb(74, 81, 90),
			Color.FromArgb(57, 69, 82),
			Color.FromArgb(49, 56, 66),
			Color.FromArgb(41, 48, 57),
			Color.FromArgb(33, 36, 49),
			Color.FromArgb(24, 28, 33),
			Color.FromArgb(16, 20, 24),
			Color.FromArgb(8, 12, 16),
			Color.FromArgb(0, 4, 8),
			Color.FromArgb(0, 0, 0)
		};

		private static Palette[] LoadPalettes()
		{
			var palettes = new Palette[15];
			palettes[0] = palette0;
			palettes[1] = palette1;
			palettes[2] = palette2;
			palettes[3] = palette3;
			palettes[4] = palette4;
			palettes[5] = background;
			foreach (var index in Enumerable.Range(0, 8))
				palettes[6 + index] = background.MoveRange(index * 16, 16, 224);
			palettes[14] = new Palette(palette4.data);
			foreach (var index in Enumerable.Range(0, 16))
				palettes[14].SetColor(240 + index, greyscale[index]);
			return palettes;
		}

		private static readonly Palette[] allPalettes = LoadPalettes();

		public static Palette GetPalette(int paletteIndex)
		{
			if (paletteIndex < 0 || paletteIndex >= allPalettes.Length)
				throw new InvalidOperationException("Invalid paletteIndex");
			return allPalettes[paletteIndex];
		}
	}
}
