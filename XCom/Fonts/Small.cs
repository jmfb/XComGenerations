using System.Collections.Generic;

namespace XCom.Fonts
{
	public static class Small
	{
		public const int Height = 5;

		private static readonly byte[] uppercaseA =
		{
			2, 1, 2, 0, 0,
			1, 0, 1, 0, 0,
			1, 1, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0
		};
		private static readonly byte[] uppercaseB =
		{
			1, 1, 2, 0, 0,
			1, 0, 1, 0, 0,
			1, 1, 2, 0, 0,
			1, 0, 1, 0, 0,
			1, 1, 2, 0, 0
		};
		private static readonly byte[] uppercaseC =
		{
			2, 1, 0, 0,
			1, 0, 0, 0,
			1, 0, 0, 0,
			1, 0, 0, 0,
			2, 1, 0, 0
		};
		private static readonly byte[] uppercaseD =
		{
			1, 1, 2, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 1, 2, 0, 0
		};
		private static readonly byte[] uppercaseE =
		{
			1, 1, 0, 0,
			1, 0, 0, 0,
			1, 1, 0, 0,
			1, 0, 0, 0,
			1, 1, 0, 0
		};
		private static readonly byte[] uppercaseF =
		{
			1, 1, 1, 0, 0,
			1, 0, 0, 0, 0,
			1, 1, 0, 0, 0,
			1, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseG =
		{
			2, 1, 1, 0, 0,
			1, 0, 0, 0, 0,
			1, 0, 0, 0, 0,
			1, 0, 1, 0, 0,
			2, 1, 1, 0, 0
		};
		private static readonly byte[] uppercaseH =
		{
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 1, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0
		};
		private static readonly byte[] uppercaseI =
		{
			1, 0, 0,
			1, 0, 0,
			1, 0, 0,
			1, 0, 0,
			1, 0, 0
		};
		private static readonly byte[] uppercaseN =
		{
			1, 0, 0, 1, 0, 0,
			1, 1, 0, 1, 0, 0,
			1, 0, 1, 1, 0, 0,
			1, 0, 0, 1, 0, 0,
			1, 0, 0, 1, 0, 0
		};
		private static readonly byte[] uppercaseO =
		{
			2, 1, 2, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			2, 1, 2, 0, 0
		};
		private static readonly byte[] uppercaseP =
		{
			1, 1, 2, 0, 0,
			1, 0, 1, 0, 0,
			1, 1, 2, 0, 0,
			1, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseR =
		{
			1, 1, 2, 0, 0,
			1, 0, 1, 0, 0,
			1, 1, 2, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0
		};
		private static readonly byte[] uppercaseS =
		{
			2, 1, 1, 0, 0,
			1, 0, 0, 0, 0,
			2, 1, 2, 0, 0,
			0, 0, 1, 0, 0,
			1, 1, 2, 0, 0
		};
		private static readonly byte[] uppercaseT =
		{
			1, 1, 1, 0, 0,
			0, 1, 0, 0, 0,
			0, 1, 0, 0, 0,
			0, 1, 0, 0, 0,
			0, 1, 0, 0, 0
		};
		private static readonly byte[] uppercaseU =
		{
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			2, 1, 2, 0, 0
		};

		private static readonly byte[] zero =
		{
			1, 1, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 1, 1, 0, 0
		};
		private static readonly byte[] one =
		{
			0, 1, 0, 0, 0,
			1, 1, 0, 0, 0,
			0, 1, 0, 0, 0,
			0, 1, 0, 0, 0,
			1, 1, 1, 0, 0
		};
		private static readonly byte[] two =
		{
			1, 1, 1, 0, 0,
			0, 0, 1, 0, 0,
			1, 1, 1, 0, 0,
			1, 0, 0, 0, 0,
			1, 1, 1, 0, 0
		};
		private static readonly byte[] three =
		{
			1, 1, 1, 0, 0,
			0, 0, 1, 0, 0,
			0, 1, 1, 0, 0,
			0, 0, 1, 0, 0,
			1, 1, 1, 0, 0
		};
		private static readonly byte[] four =
		{
			1, 0, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 1, 1, 0, 0,
			0, 0, 1, 0, 0,
			0, 0, 1, 0, 0
		};
		private static readonly byte[] five =
		{
			1, 1, 1, 0, 0,
			1, 0, 0, 0, 0,
			1, 1, 1, 0, 0,
			0, 0, 1, 0, 0,
			1, 1, 1, 0, 0
		};
		private static readonly byte[] six =
		{
			1, 1, 1, 0, 0,
			1, 0, 0, 0, 0,
			1, 1, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 1, 1, 0, 0
		};
		private static readonly byte[] seven =
		{
			1, 1, 1, 0, 0,
			0, 0, 1, 0, 0,
			0, 0, 1, 0, 0,
			0, 0, 1, 0, 0,
			0, 0, 1, 0, 0
		};
		private static readonly byte[] eight =
		{
			1, 1, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 1, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 1, 1, 0, 0
		};
		private static readonly byte[] nine =
		{
			1, 1, 1, 0, 0,
			1, 0, 1, 0, 0,
			1, 1, 1, 0, 0,
			0, 0, 1, 0, 0,
			0, 0, 1, 0, 0
		};

		public static readonly Dictionary<char, byte[]> Characters = new Dictionary<char, byte[]>
		{
			{ 'A', uppercaseA },
			{ 'B', uppercaseB },
			{ 'C', uppercaseC },
			{ 'D', uppercaseD },
			{ 'E', uppercaseE },
			{ 'F', uppercaseF },
			{ 'G', uppercaseG },
			{ 'H', uppercaseH },
			{ 'I', uppercaseI },
			{ 'N', uppercaseN },
			{ 'O', uppercaseO },
			{ 'P', uppercaseP },
			{ 'R', uppercaseR },
			{ 'S', uppercaseS },
			{ 'T', uppercaseT },
			{ 'U', uppercaseU },
			{ '0', zero },
			{ '1', one },
			{ '2', two },
			{ '3', three },
			{ '4', four },
			{ '5', five },
			{ '6', six },
			{ '7', seven },
			{ '8', eight },
			{ '9', nine }
		};
	}
}
