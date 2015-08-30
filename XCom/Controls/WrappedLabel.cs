using System.Collections.Generic;
using System.Linq;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls
{
	public class WrappedLabel : InteractiveContainer
	{
		public int Bottom { get; }

		public WrappedLabel(int topRow, int leftColumn, int width, string text, Font font, ColorScheme scheme)
		{
			var nextTopRow = topRow;
			foreach (var lineOfText in WrapText(text, width, font))
			{
				AddControl(new Label(nextTopRow, leftColumn, lineOfText, font, scheme));
				nextTopRow += font.Height;
			}
			Bottom = nextTopRow;
		}

		private static IEnumerable<string> WrapText(string text, int width, Font font)
		{
			var wordsOnLine = new List<string>();
			foreach (var word in text.Split(' '))
			{
				var lineWithoutWord = string.Join(" ", wordsOnLine);
				wordsOnLine.Add(word);
				var lineWithWord = string.Join(" ", wordsOnLine);
				if (font.MeasureString(lineWithWord) <= width)
					continue;
				yield return lineWithoutWord;
				wordsOnLine.Clear();
				wordsOnLine.Add(word);
			}
			if (wordsOnLine.Any())
				yield return string.Join(" ", wordsOnLine);
		}
	}
}
