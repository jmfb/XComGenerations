using System.Collections.Generic;

namespace XCom.Fonts
{
	public static class UpDownButtons
	{
		public const int Height = 8;

		private static readonly byte[] up =
		{
			1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 5,
			2, 5, 5, 5, 5, 4, 5, 5, 5, 5, 6,
			2, 5, 5, 5, 4, 1, 4, 5, 5, 5, 6,
			2, 5, 5, 4, 1, 1, 1, 4, 5, 5, 6,
			2, 5, 4, 1, 1, 1, 1, 1, 4, 5, 6,
			2, 4, 1, 1, 1, 1, 1, 1, 1, 4, 6,
			2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6,
			5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6
		};

		private static readonly byte[] down =
		{
			1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 5,
			2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6,
			2, 4, 1, 1, 1, 1, 1, 1, 1, 4, 6,
			2, 5, 4, 1, 1, 1, 1, 1, 4, 5, 6,
			2, 5, 5, 4, 1, 1, 1, 4, 5, 5, 6,
			2, 5, 5, 5, 4, 1, 4, 5, 5, 5, 6,
			2, 5, 5, 5, 5, 4, 5, 5, 5, 5, 6,
			5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6
		};

		public static readonly Dictionary<char, byte[]> Characters = new Dictionary<char, byte[]>
		{
			{ 'U', up },
			{ 'D', down }
		};
	}
}
