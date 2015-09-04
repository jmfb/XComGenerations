using System;
using System.Drawing;
using System.Linq;

namespace XCom.Graphics
{
	public class ColorScheme
	{
		private readonly Color[] colors;

		private ColorScheme(int paletteIndex, int firstColorIndex, int schemeSize)
		{
			if (schemeSize != 5 && schemeSize != 6)
				throw new InvalidOperationException("Invalid color scheme size.");
			var palette = Palette.GetPalette(paletteIndex);
			var indexes = schemeSize == 5 ?
				new[] { 0, 1, 2, 2, 3, 4 } :
				Enumerable.Range(0, schemeSize);
			colors = indexes.Select(index => palette.GetColor(firstColorIndex + index)).ToArray();
		}

		private ColorScheme(Color[] colors)
		{
			this.colors = colors;
		}

		public Color GetColor(int index)
		{
			//Schemes use 0 to indicate transparent,
			//so colors array indexed [1..N].
			var translatedIndex = index - 1;
			if (translatedIndex < 0 || translatedIndex >= colors.Length)
				throw new InvalidOperationException("Invalid color scheme index.");
			return colors[translatedIndex];
		}

		public Color Lighter => GetColor(1);
		public Color Light => GetColor(2);
		public Color Base => GetColor(3);
		public Color LightDark => GetColor(4);
		public Color Dark => GetColor(5);
		public Color Darker => GetColor(6);
		public ColorScheme Inverse => new ColorScheme(colors.Reverse().ToArray());

		public static readonly ColorScheme White = new ColorScheme(1, 209, 5);
		public static readonly ColorScheme Aqua = new ColorScheme(0, 134, 5);
		public static readonly ColorScheme Green = new ColorScheme(0, 240, 5);
		public static readonly ColorScheme Blue = new ColorScheme(1, 219, 5);
		public static readonly ColorScheme DarkYellow = new ColorScheme(1, 214, 5);
		public static readonly ColorScheme Purple = new ColorScheme(1, 247, 5);
		public static readonly ColorScheme Yellow = new ColorScheme(2, 16, 6);
		public static readonly ColorScheme LightMagenta = new ColorScheme(1, 242, 5);
		public static readonly ColorScheme LightPurple = new ColorScheme(3, 240, 5);
		public static readonly ColorScheme LightAqua = new ColorScheme(3, 245, 5);
		public static readonly ColorScheme Orange = new ColorScheme(1, 16, 5);

		public static readonly ColorScheme LightBlue = new ColorScheme(new[]
		{
			Color.FromArgb(130, 190, 231),
			Color.FromArgb(105, 162, 207),
			Color.FromArgb(89, 138, 186),
			Color.FromArgb(89, 138, 186),
			Color.FromArgb(69, 113, 166),
			Color.FromArgb(52, 93, 142)
		});
	}
}
