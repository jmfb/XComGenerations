using System.Collections.Generic;

namespace XCom.Fonts
{
	public static class Arrow
	{
		public const int Height = 8;

		private static readonly byte[] up =
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 1, 1, 1, 0, 0, 0,
			0, 0, 1, 1, 1, 1, 1, 0, 0,
			0, 1, 1, 1, 1, 1, 1, 1, 0,
			1, 1, 1, 1, 1, 1, 1, 1, 1,
			0, 0, 0, 1, 1, 1, 0, 0, 0,
			0, 0, 0, 1, 1, 1, 0, 0, 0,
			0, 0, 0, 1, 1, 1, 0, 0, 0
		};
		private static readonly byte[] down =
		{
			0, 0, 0, 1, 1, 1, 0, 0, 0,
			0, 0, 0, 1, 1, 1, 0, 0, 0,
			0, 0, 0, 1, 1, 1, 0, 0, 0,
			1, 1, 1, 1, 1, 1, 1, 1, 1,
			0, 1, 1, 1, 1, 1, 1, 1, 0,
			0, 0, 1, 1, 1, 1, 1, 0, 0,
			0, 0, 0, 1, 1, 1, 0, 0, 0,
			0, 0, 0, 0, 1, 0, 0, 0, 0
		};

		public static readonly Dictionary<char, byte[]> Characters = new Dictionary<char, byte[]>
		{
			{ 'U', up },
			{ 'D', down }
		};
	}
}
