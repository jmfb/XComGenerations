using System.Collections.Generic;

namespace XCom.Fonts
{
	public static class Time
	{
		public const int Height = 7;

		private static readonly byte[] space =
		{
			0, 0,
			0, 0,
			0, 0,
			0, 0,
			0, 0,
			0, 0,
			0, 0
		};

		private static readonly byte[] zero =
		{
			2, 1, 1, 2, 0, 0,
			1, 0, 0, 1, 0, 0,
			1, 0, 0, 1, 0, 0,
			1, 0, 0, 1, 0, 0,
			1, 0, 0, 1, 0, 0,
			1, 0, 0, 1, 0, 0,
			2, 1, 1, 2, 0, 0
		};
		private static readonly byte[] one =
		{
			0, 1, 0, 0, 0,
			1, 1, 0, 0, 0,
			0, 1, 0, 0, 0,
			0, 1, 0, 0, 0,
			0, 1, 0, 0, 0,
			0, 1, 0, 0, 0,
			1, 1, 1, 0, 0
		};
		private static readonly byte[] three =
		{
			1, 1, 2, 0, 0,
			0, 0, 1, 0, 0,
			0, 0, 1, 0, 0,
			0, 1, 2, 0, 0,
			0, 0, 1, 0, 0,
			0, 0, 1, 0, 0,
			1, 1, 2, 0, 0
		};
		private static readonly byte[] five =
		{
			1, 1, 1, 1, 0, 0,
			1, 0, 0, 0, 0, 0,
			1, 1, 1, 2, 0, 0,
			0, 0, 0, 1, 0, 0,
			0, 0, 0, 1, 0, 0,
			0, 0, 0, 1, 0, 0,
			1, 1, 1, 2, 0, 0
		};

		private static readonly byte[] uppercaseD =
		{
			1, 1, 1, 2, 0, 0, 0,
			1, 0, 0, 0, 1, 0, 0,
			1, 0, 0, 0, 1, 0, 0,
			1, 0, 0, 0, 1, 0, 0,
			1, 0, 0, 0, 1, 0, 0,
			1, 0, 0, 0, 1, 0, 0,
			1, 1, 1, 2, 0, 0, 0
		};
		private static readonly byte[] uppercaseH =
		{
			1, 0, 0, 1, 0, 0,
			1, 0, 0, 1, 0, 0,
			1, 0, 0, 1, 0, 0,
			1, 1, 1, 1, 0, 0,
			1, 0, 0, 1, 0, 0,
			1, 0, 0, 1, 0, 0,
			1, 0, 0, 1, 0, 0
		};
		private static readonly byte[] uppercaseM =
		{
			1, 0, 0, 0, 1, 0, 0,
			1, 1, 0, 1, 1, 0, 0,
			1, 0, 1, 0, 1, 0, 0,
			1, 0, 0, 0, 1, 0, 0,
			1, 0, 0, 0, 1, 0, 0,
			1, 0, 0, 0, 1, 0, 0,
			1, 0, 0, 0, 1, 0, 0
		};
		private static readonly byte[] uppercaseS =
		{
			2, 1, 1, 1, 0, 0,
			1, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0, 0,
			2, 1, 1, 2, 0, 0,
			0, 0, 0, 1, 0, 0,
			0, 0, 0, 1, 0, 0,
			1, 1, 1, 2, 0, 0
		};

		private static readonly byte[] lowercaseA =
		{
			0, 0, 0, 0, 0,
			0, 0, 0, 0, 0,
			2, 1, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			2, 1, 1, 0, 0
		};
		private static readonly byte[] lowercaseC =
		{
			0, 0, 0, 0, 0,
			0, 0, 0, 0, 0,
			2, 1, 1, 0, 0,
			1, 0, 0, 0, 0,
			1, 0, 0, 0, 0,
			1, 0, 0, 0, 0,
			2, 1, 1, 0, 0
		};
		private static readonly byte[] lowercaseE =
		{
			0, 0, 0, 0, 0,
			0, 0, 0, 0, 0,
			2, 1, 2, 0, 0,
			1, 0, 1, 0, 0,
			1, 1, 2, 0, 0,
			1, 0, 0, 0, 0,
			2, 1, 1, 0, 0
		};
		private static readonly byte[] lowercaseI =
		{
			1, 0, 0,
			0, 0, 0,
			1, 0, 0,
			1, 0, 0,
			1, 0, 0,
			1, 0, 0,
			1, 0, 0
		};
		private static readonly byte[] lowercaseN =
		{
			0, 0, 0, 0, 0,
			0, 0, 0, 0, 0,
			1, 1, 2, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0
		};
		private static readonly byte[] lowercaseO =
		{
			0, 0, 0, 0, 0,
			0, 0, 0, 0, 0,
			2, 1, 2, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			2, 1, 2, 0, 0
		};
		private static readonly byte[] lowercaseR =
		{
			0, 0, 0, 0, 0,
			0, 0, 0, 0, 0,
			2, 1, 1, 0, 0,
			1, 0, 0, 0, 0,
			1, 0, 0, 0, 0,
			1, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseS =
		{
			0, 0, 0, 0, 0,
			0, 0, 0, 0, 0,
			2, 1, 1, 0, 0,
			1, 0, 0, 0, 0,
			2, 1, 2, 0, 0,
			0, 0, 1, 0, 0,
			1, 1, 2, 0, 0
		};
		private static readonly byte[] lowercaseU =
		{
			0, 0, 0, 0, 0,
			0, 0, 0, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			2, 1, 2, 0, 0
		};
		private static readonly byte[] lowercaseY =
		{
			0, 0, 0, 0, 0,
			0, 0, 0, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			2, 1, 1, 0, 0,
			0, 0, 1, 0, 0,
			1, 1, 2, 0, 0
		};

		public static readonly Dictionary<char, byte[]> Characters = new Dictionary<char, byte[]>
		{
			{ ' ', space },

			{ '0', zero },
			{ '1', one },
			{ '3', three },
			{ '5', five },

			{ 'D', uppercaseD },
			{ 'H', uppercaseH },
			{ 'M', uppercaseM },
			{ 'S', uppercaseS },

			{ 'a', lowercaseA },
			{ 'c', lowercaseC },
			{ 'e', lowercaseE },
			{ 'i', lowercaseI },
			{ 'n', lowercaseN },
			{ 'o', lowercaseO },
			{ 'r', lowercaseR },
			{ 's', lowercaseS },
			{ 'u', lowercaseU },
			{ 'y', lowercaseY }
		};
	}
}
