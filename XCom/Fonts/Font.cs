using System;
using System.Collections.Generic;
using System.Linq;
using XCom.Graphics;

namespace XCom.Fonts
{
	public class Font
	{
		public int Height { get; private set; }
		private readonly Dictionary<char, Character> characters;

		private Font(int height, Dictionary<char, byte[]> characters)
		{
			Height = height;
			this.characters = characters.ToDictionary(
				keyValue => keyValue.Key,
				keyValue => new Character(keyValue.Value, height));
		}

		private Character GetCharacter(char value)
		{
			Character character;
			if (!characters.TryGetValue(value, out character))
				throw new InvalidOperationException("Invalid character for font.");
			return character;
		}

		public int MeasureString(string value)
		{
			var width = value.Sum(character => GetCharacter(character).Width - 1);
			return width == 0 ? 0 : width + 1;
		}

		public void DrawString(
			GraphicsBuffer buffer,
			int topRow,
			int leftColumn,
			string value,
			ColorScheme scheme)
		{
			var column = leftColumn;
			foreach (var character in value.Select(GetCharacter))
			{
				character.Render(buffer, topRow, column, scheme);
				column += character.Width - 1;
			}
		}

		public static readonly Font Normal = new Font(Fonts.Normal.Height, Fonts.Normal.Characters);
		public static readonly Font Large = new Font(Fonts.Large.Height, Fonts.Large.Characters);
		public static readonly Font Small = new Font(Fonts.Small.Height, Fonts.Small.Characters);
		public static readonly Font Arrow = new Font(Fonts.Arrow.Height, Fonts.Arrow.Characters);
		public static readonly Font Time = new Font(Fonts.Time.Height, Fonts.Time.Characters);
		public static readonly Font UpDownButtons  = new Font(Fonts.UpDownButtons.Height, Fonts.UpDownButtons.Characters);
	}
}
