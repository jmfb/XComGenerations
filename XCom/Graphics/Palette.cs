using System;
using System.Drawing;
using System.Linq;

namespace XCom.Graphics
{
	public class Palette
	{
		private const int PaletteEntries = 256;
		private const int PaletteSize = PaletteEntries * GraphicsBuffer.BytesPerPixel;

		private readonly byte[] data = new byte[PaletteSize];

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

		private static Palette[] LoadPalettes()
		{
			var palettes = new Palette[14];
			palettes[0] = palette0;
			palettes[1] = palette1;
			palettes[2] = palette2;
			palettes[3] = palette3;
			palettes[4] = palette4;
			palettes[5] = background;
			foreach (var index in Enumerable.Range(0, 8))
				palettes[6 + index] = background.MoveRange(index * 16, 16, 224);
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
