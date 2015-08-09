﻿using System.Collections.Generic;

namespace XCom.Fonts
{
	public static class Normal
	{
		public const int Height = 9;

		private static readonly byte[] space =
		{
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] tab =
		{
			0, 0, 0,
			0, 0, 0,
			0, 0, 0,
			0, 0, 0,
			0, 0, 0,
			0, 0, 0,
			0, 0, 0,
			0, 0, 0,
			0, 0, 0
		};

		private static readonly byte[] zero =
		{
			6, 5, 5, 5, 5, 6,
			5, 2, 1, 1, 2, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 2, 1, 1, 2, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] one =
		{
			6, 5, 5, 6, 0,
			5, 1, 1, 5, 0,
			6, 5, 1, 5, 0,
			6, 5, 1, 5, 0,
			6, 5, 1, 5, 0,
			6, 5, 1, 5, 0,
			5, 1, 1, 1, 5,
			6, 5, 5, 5, 6,
			0, 0, 0, 0, 0
		};
		private static readonly byte[] two =
		{
			6, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 2, 5,
			6, 5, 5, 5, 1, 5,
			6, 5, 5, 5, 1, 5,
			5, 2, 1, 1, 2, 5,
			5, 1, 5, 5, 5, 6,
			5, 1, 1, 1, 1, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] three =
		{
			6, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 2, 5,
			6, 5, 5, 5, 1, 5,
			0, 5, 1, 1, 2, 6,
			0, 6, 5, 5, 1, 5,
			6, 5, 5, 5, 1, 5,
			5, 1, 1, 1, 2, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] four =
		{
			6, 5, 6, 6, 5, 6,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 1, 1, 1, 5,
			6, 5, 5, 5, 1, 5,
			0, 0, 0, 5, 1, 5,
			0, 0, 0, 6, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] five =
		{
			6, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 1, 5,
			5, 1, 5, 5, 5, 6,
			5, 1, 1, 1, 2, 5,
			6, 5, 5, 5, 1, 5,
			6, 5, 5, 5, 1, 5,
			5, 1, 1, 1, 2, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] six =
		{
			6, 5, 5, 5, 5, 6,
			5, 2, 1, 1, 1, 5,
			5, 1, 5, 5, 5, 6,
			5, 1, 1, 1, 2, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 2, 1, 1, 2, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] seven =
		{
			6, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 1, 5,
			6, 5, 5, 5, 1, 5,
			0, 0, 0, 5, 1, 5,
			0, 0, 0, 5, 1, 5,
			0, 0, 0, 5, 1, 5,
			0, 0, 0, 5, 1, 5,
			0, 0, 0, 6, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] eight =
		{
			6, 5, 5, 5, 5, 6,
			5, 2, 1, 1, 2, 5,
			5, 1, 5, 5, 1, 5,
			6, 2, 1, 1, 2, 6,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 2, 1, 1, 2, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] nine =
		{
			6, 5, 5, 5, 5, 6,
			5, 2, 1, 1, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 2, 1, 1, 1, 5,
			6, 5, 5, 5, 1, 5,
			0, 0, 0, 5, 1, 5,
			0, 0, 0, 6, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseA =
		{
			6, 5, 5, 5, 5, 6,
			5, 2, 1, 1, 2, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 1, 1, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			6, 5, 6, 6, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseB =
		{
			6, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 2, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 1, 1, 2, 6,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 1, 1, 2, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseC =
		{
			6, 5, 5, 5, 6,
			5, 2, 1, 1, 5,
			5, 1, 5, 5, 6,
			5, 1, 5, 0, 0,
			5, 1, 5, 0, 0,
			5, 1, 5, 5, 6,
			5, 2, 1, 1, 5,
			6, 5, 5, 5, 6,
			0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseD =
		{
			6, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 2, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 1, 1, 2, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseE =
		{
			6, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 1, 5,
			5, 1, 5, 5, 5, 6,
			5, 1, 1, 1, 5, 0,
			5, 1, 5, 5, 6, 0,
			5, 1, 5, 5, 5, 6,
			5, 1, 1, 1, 1, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseF =
		{
			6, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 1, 5,
			5, 1, 5, 5, 5, 6,
			5, 1, 1, 1, 5, 0,
			5, 1, 5, 5, 6, 0,
			5, 1, 5, 0, 0, 0,
			5, 1, 5, 0, 0, 0,
			6, 5, 6, 0, 0, 0,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseG =
		{
			6, 5, 5, 5, 5, 6,
			5, 2, 1, 1, 1, 5,
			5, 1, 5, 5, 5, 6,
			5, 1, 5, 5, 5, 6,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 2, 1, 1, 1, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseH =
		{
			6, 5, 6, 6, 5, 6,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 1, 1, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			6, 5, 6, 6, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseI =
		{
			6, 5, 5, 5, 6,
			5, 1, 1, 1, 5,
			6, 5, 1, 5, 6,
			0, 5, 1, 5, 0,
			0, 5, 1, 5, 0,
			6, 5, 1, 5, 6,
			5, 1, 1, 1, 5,
			6, 5, 5, 5, 6,
			0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseJ =
		{
			6, 5, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 1, 1, 5,
			6, 5, 5, 5, 1, 5, 6,
			0, 0, 0, 5, 1, 5, 0,
			6, 5, 6, 5, 1, 5, 0,
			5, 1, 5, 5, 1, 5, 0,
			5, 2, 1, 1, 2, 5, 0,
			6, 5, 5, 5, 5, 6, 0,
			0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseK =
		{
			6, 5, 6, 6, 5, 6,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 1, 5, 6,
			5, 1, 1, 5, 6, 0,
			5, 1, 5, 1, 5, 6,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			6, 5, 6, 6, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseL =
		{
			6, 5, 6, 0, 0, 0,
			5, 1, 5, 0, 0, 0,
			5, 1, 5, 0, 0, 0,
			5, 1, 5, 0, 0, 0,
			5, 1, 5, 0, 0, 0,
			5, 1, 5, 5, 5, 6,
			5, 1, 1, 1, 1, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseM =
		{
			6, 5, 6, 0, 6, 5, 6,
			5, 1, 5, 6, 5, 1, 5,
			5, 1, 1, 5, 1, 1, 5,
			5, 1, 5, 1, 5, 1, 5,
			5, 1, 5, 5, 5, 1, 5,
			5, 1, 5, 0, 5, 1, 5,
			5, 1, 5, 0, 5, 1, 5,
			6, 5, 6, 0, 6, 5, 6,
			0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseN =
		{
			6, 5, 6, 6, 5, 6,
			5, 1, 5, 5, 1, 5,
			5, 1, 1, 5, 1, 5,
			5, 1, 5, 1, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			6, 5, 6, 6, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseO =
		{
			6, 5, 5, 5, 5, 6,
			5, 2, 1, 1, 2, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 2, 1, 1, 2, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseP =
		{
			6, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 2, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 1, 1, 2, 5,
			5, 1, 5, 5, 5, 6,
			5, 1, 5, 0, 0, 0,
			6, 5, 6, 0, 0, 0,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseQ =
		{
			6, 5, 5, 5, 5, 6,
			5, 2, 1, 1, 2, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 1, 2, 5,
			5, 2, 1, 2, 1, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseR =
		{
			6, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 2, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 1, 1, 2, 5,
			5, 1, 5, 5, 1, 5,
			5, 2, 5, 5, 1, 5,
			6, 5, 6, 6, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseS =
		{
			6, 5, 5, 5, 5, 6,
			5, 2, 1, 1, 1, 5,
			5, 1, 5, 5, 5, 5,
			5, 2, 1, 1, 2, 5,
			6, 5, 5, 5, 1, 5,
			6, 5, 5, 5, 1, 5,
			5, 1, 1, 1, 2, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseT =
		{
			6, 5, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 1, 1, 5,
			6, 5, 5, 1, 5, 5, 6,
			0, 0, 5, 1, 5, 0, 0,
			0, 0, 5, 1, 5, 0, 0,
			0, 0, 5, 1, 5, 0, 0,
			0, 0, 5, 1, 5, 0, 0,
			0, 0, 6, 5, 6, 0, 0,
			0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseU =
		{
			6, 5, 6, 6, 5, 6,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 2, 1, 1, 2, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseV =
		{
			6, 5, 6, 0, 6, 5, 6,
			5, 1, 5, 0, 5, 1, 5,
			5, 1, 5, 0, 5, 1, 5,
			5, 1, 5, 0, 5, 1, 5,
			5, 1, 5, 6, 5, 1, 5,
			6, 5, 1, 5, 1, 5, 6,
			0, 6, 5, 1, 5, 6, 0,
			0, 0, 6, 5, 6, 0, 0,
			0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseW =
		{
			6, 5, 6, 0, 6, 5, 6,
			5, 1, 5, 0, 5, 1, 5,
			5, 1, 5, 0, 5, 1, 5,
			5, 1, 5, 5, 5, 1, 5,
			5, 1, 5, 1, 5, 1, 5,
			5, 1, 1, 5, 1, 1, 5,
			5, 1, 5, 6, 5, 1, 5,
			6, 5, 6, 0, 6, 5, 6,
			0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseX =
		{
			6, 5, 6, 0, 6, 5, 6,
			5, 1, 5, 6, 5, 1, 5,
			6, 5, 1, 5, 1, 5, 6,
			0, 6, 5, 1, 5, 6, 0,
			0, 6, 5, 1, 5, 6, 0,
			6, 5, 1, 5, 1, 5, 6,
			5, 1, 5, 6, 5, 1, 5,
			6, 5, 6, 0, 6, 5, 6,
			0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseY =
		{
			6, 5, 6, 0, 6, 5, 6,
			5, 1, 5, 0, 5, 1, 5,
			5, 1, 5, 6, 5, 1, 5,
			6, 5, 1, 5, 1, 5, 6,
			0, 6, 5, 1, 5, 6, 0,
			0, 0, 5, 1, 5, 0, 0,
			0, 0, 5, 1, 5, 0, 0,
			0, 0, 6, 5, 6, 0, 0,
			0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] uppercaseZ =
		{
			6, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 1, 5,
			6, 5, 5, 5, 1, 5,
			0, 6, 5, 1, 5, 6,
			6, 5, 1, 5, 6, 0,
			5, 1, 5, 5, 5, 6,
			5, 1, 1, 1, 1, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};

		private static readonly byte[] lowercaseA =
		{
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			6, 5, 5, 5, 5, 6,
			5, 2, 1, 2, 2, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 2, 1, 2, 1, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseB =
		{
			6, 5, 6, 0, 0, 0,
			5, 1, 5, 0, 0, 0,
			5, 1, 5, 5, 5, 6,
			5, 1, 2, 1, 2, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 2, 1, 2, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseC =
		{
			0, 0, 0, 0, 0,
			0, 0, 0, 0, 0,
			6, 5, 5, 5, 6,
			5, 2, 1, 1, 5,
			5, 1, 5, 5, 6,
			5, 1, 5, 5, 6,
			5, 2, 1, 1, 5,
			6, 5, 5, 5, 6,
			0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseD =
		{
			0, 0, 0, 6, 5, 6,
			0, 0, 0, 5, 1, 5,
			6, 5, 5, 5, 1, 5,
			5, 2, 1, 2, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 2, 1, 2, 1, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseE =
		{
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			6, 5, 5, 5, 5, 6,
			5, 2, 1, 1, 2, 5,
			5, 1, 1, 1, 1, 5,
			5, 1, 5, 5, 5, 6,
			5, 2, 1, 1, 2, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseF =
		{
			6, 5, 5, 5, 6,
			5, 2, 1, 1, 5,
			5, 1, 5, 5, 6,
			5, 1, 1, 1, 5,
			5, 1, 5, 5, 6,
			5, 1, 5, 0, 0,
			5, 1, 5, 0, 0,
			6, 5, 6, 0, 0,
			0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseG =
		{
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			6, 5, 5, 5, 5, 6,
			5, 2, 1, 2, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 2, 1, 2, 1, 5,
			6, 5, 5, 5, 1, 5,
			5, 1, 1, 1, 2, 5,
			6, 5, 5, 5, 5, 6
		};
		private static readonly byte[] lowercaseH =
		{
			6, 5, 6, 0, 0, 0,
			5, 1, 5, 0, 0, 0,
			5, 1, 5, 5, 5, 6,
			5, 1, 2, 1, 2, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseI =
		{
			6, 5, 6,
			5, 1, 5,
			5, 5, 5,
			5, 1, 5,
			5, 1, 5,
			5, 1, 5,
			5, 1, 5,
			6, 5, 6,
			0, 0, 0
		};
		private static readonly byte[] lowercaseJ =
		{
			0, 0, 6, 5, 6,
			0, 0, 5, 1, 5,
			0, 6, 5, 5, 6,
			0, 5, 1, 1, 5,
			0, 6, 5, 1, 5,
			0, 0, 5, 1, 5,
			6, 5, 5, 1, 5,
			5, 1, 1, 2, 5,
			6, 5, 5, 5, 6
		};
		private static readonly byte[] lowercaseK =
		{
			6, 5, 6, 0, 0, 0,
			5, 1, 5, 6, 5, 6,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 1, 5, 6,
			5, 1, 1, 5, 6, 0,
			5, 1, 5, 1, 5, 6,
			5, 1, 5, 5, 1, 5,
			6, 5, 6, 6, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseL =
		{
			6, 5, 6,
			5, 1, 5,
			5, 1, 5,
			5, 1, 5,
			5, 1, 5,
			5, 1, 5,
			5, 1, 5,
			6, 5, 6,
			0, 0, 0
		};
		private static readonly byte[] lowercaseM =
		{
			0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0,
			6, 5, 5, 5, 5, 5, 6,
			5, 1, 1, 2, 1, 2, 5,
			5, 1, 5, 1, 5, 1, 5,
			5, 1, 5, 1, 5, 1, 5,
			5, 1, 5, 1, 5, 1, 5,
			6, 5, 6, 5, 6, 5, 6,
			0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseN =
		{
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			6, 5, 5, 5, 5, 6,
			5, 1, 2, 1, 2, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			6, 5, 6, 6, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseO =
		{
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			6, 5, 5, 5, 5, 6,
			5, 5, 1, 1, 5, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 5, 1, 1, 5, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseP =
		{
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			6, 5, 5, 5, 5, 6,
			5, 1, 2, 1, 2, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 2, 1, 2, 5,
			5, 1, 5, 5, 5, 6,
			6, 5, 6, 0, 0, 0
		};
		private static readonly byte[] lowercaseQ =
		{
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			6, 5, 5, 5, 5, 6,
			5, 2, 1, 2, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 2, 1, 2, 1, 5,
			6, 5, 5, 5, 1, 5,
			0, 0, 0, 6, 5, 6
		};
		private static readonly byte[] lowercaseR =
		{
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			6, 5, 5, 5, 5, 6,
			5, 1, 2, 1, 1, 5,
			5, 1, 5, 5, 5, 6,
			5, 1, 5, 0, 0, 0,
			5, 1, 5, 0, 0, 0,
			6, 5, 6, 0, 0, 0,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseS =
		{
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			6, 5, 5, 5, 5, 6,
			5, 2, 1, 1, 1, 5,
			5, 2, 1, 1, 2, 5,
			5, 5, 5, 5, 1, 5,
			5, 2, 1, 1, 2, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseT =
		{
			6, 5, 6, 0, 0, 0,
			5, 1, 5, 0, 0, 0,
			5, 1, 5, 5, 6, 0,
			5, 1, 1, 1, 5, 0,
			5, 1, 5, 5, 5, 6,
			5, 1, 5, 5, 6, 5,
			5, 2, 1, 1, 2, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseU =
		{
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			6, 5, 6, 6, 5, 6,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 2, 1, 1, 2, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseV =
		{
			0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0,
			6, 5, 6, 0, 6, 5, 6,
			5, 1, 5, 6, 5, 1, 5,
			5, 1, 5, 6, 5, 1, 5,
			6, 5, 1, 5, 1, 5, 6,
			0, 6, 5, 1, 5, 6, 0,
			0, 0, 6, 5, 6, 0, 0,
			0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseW =
		{
			0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0,
			6, 5, 6, 5, 6, 5, 6,
			5, 1, 5, 1, 5, 1, 5,
			5, 1, 5, 1, 5, 1, 5,
			5, 1, 5, 1, 5, 1, 5,
			5, 2, 1, 2, 1, 2, 5,
			6, 5, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseX =
		{
			0, 0, 0, 0, 0,
			0, 0, 0, 0, 0,
			6, 5, 6, 5, 6,
			5, 1, 5, 1, 5,
			6, 5, 1, 5, 6,
			6, 5, 1, 5, 6,
			5, 1, 5, 1, 5,
			6, 5, 6, 5, 6,
			0, 0, 0, 0, 0
		};
		private static readonly byte[] lowercaseY =
		{
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			6, 5, 6, 6, 5, 6,
			5, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 5,
			5, 2, 1, 1, 1, 5,
			5, 5, 5, 5, 1, 5,
			5, 1, 1, 1, 2, 5,
			6, 5, 5, 5, 5, 6
		};
		private static readonly byte[] lowercaseZ =
		{
			0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0,
			6, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 1, 5,
			6, 5, 5, 1, 5, 6,
			6, 5, 1, 5, 5, 6,
			5, 1, 1, 1, 1, 5,
			6, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0
		};

		private static readonly byte[] lessThan =
		{
			0, 0, 0, 0, 0,
			0, 0, 6, 5, 6,
			0, 6, 5, 1, 5,
			6, 5, 1, 2, 5,
			5, 1, 2, 2, 5,
			6, 5, 1, 2, 5,
			0, 6, 5, 1, 5,
			0, 0, 6, 5, 6,
			0, 0, 0, 0, 0
		};
		private static readonly byte[] greaterThan =
		{
			0, 0, 0, 0, 0,
			6, 5, 6, 0, 0,
			5, 1, 5, 6, 0,
			5, 2, 1, 5, 6,
			5, 2, 2, 1, 5,
			5, 2, 1, 5, 6,
			5, 1, 5, 6, 0,
			6, 5, 6, 0, 0,
			0, 0, 0, 0, 0
		};
		private static readonly byte[] comma =
		{
			0, 0, 0, 0,
			0, 0, 0, 0,
			0, 0, 0, 0,
			0, 0, 0, 0,
			6, 5, 5, 6,
			5, 1, 2, 5,
			6, 5, 1, 5,
			5, 1, 5, 6,
			6, 5, 6, 0
		};
		private static readonly byte[] period =
		{
			0, 0, 0,
			0, 0, 0,
			0, 0, 0,
			0, 0, 0,
			0, 0, 0,
			6, 5, 6,
			5, 1, 5,
			6, 5, 6,
			0, 0, 0
		};
		private static readonly byte[] forwardSlash =
		{
			0, 0, 0, 0, 0, 6, 5, 6,
			0, 0, 0, 0, 6, 5, 1, 5,
			0, 0, 0, 6, 5, 1, 5, 6,
			0, 0, 6, 5, 1, 5, 6, 0,
			0, 6, 5, 1, 5, 6, 0, 0,
			6, 5, 1, 5, 6, 0, 0, 0,
			5, 1, 5, 6, 0, 0, 0, 0,
			6, 5, 6, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] backSlash =
		{
			6, 5, 6, 0, 0, 0, 0, 0,
			5, 1, 5, 6, 0, 0, 0, 0,
			6, 5, 1, 5, 6, 0, 0, 0,
			0, 6, 5, 1, 5, 6, 0, 0,
			0, 0, 6, 5, 1, 5, 6, 0,
			0, 0, 0, 6, 5, 1, 5, 6,
			0, 0, 0, 0, 6, 5, 1, 5,
			0, 0, 0, 0, 0, 6, 5, 6,
			0, 0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] pipe =
		{
			6, 5, 6, 0, 0,
			5, 1, 5, 0, 0,
			5, 1, 5, 0, 0,
			5, 1, 5, 0, 0,
			5, 1, 5, 0, 0,
			5, 1, 5, 0, 0,
			5, 1, 5, 0, 0,
			5, 1, 5, 0, 0,
			6, 5, 6, 0, 0
		};
		private static readonly byte[] bang =
		{
			6, 5, 6,
			5, 1, 5,
			5, 1, 5,
			5, 1, 5,
			5, 1, 5,
			6, 5, 6,
			5, 1, 5,
			6, 5, 6,
			0, 0, 0
		};
		private static readonly byte[] at =
		{
			6, 6, 5, 5, 5, 5, 6, 0,
			6, 5, 1, 1, 1, 1, 5, 6,
			5, 1, 5, 5, 5, 5, 1, 5,
			6, 5, 2, 1, 1, 5, 1, 5,
			0, 5, 1, 5, 1, 5, 1, 5,
			0, 5, 1, 5, 1, 5, 1, 5,
			0, 5, 2, 1, 1, 1, 5, 6,
			0, 6, 5, 5, 5, 5, 6, 0,
			0, 0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] pound =
		{
			0, 6, 5, 6, 6, 5, 6, 0,
			6, 5, 1, 5, 5, 1, 5, 6,
			5, 1, 1, 1, 1, 1, 1, 5,
			6, 5, 1, 5, 5, 1, 5, 6,
			6, 5, 1, 5, 5, 1, 5, 6,
			5, 1, 1, 1, 1, 1, 1, 5,
			6, 5, 1, 5, 5, 1, 5, 6,
			0, 6, 5, 6, 6, 5, 6, 0,
			0, 0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] dollar =
		{
			0, 0, 6, 5, 6, 0, 0,
			6, 5, 5, 1, 5, 5, 6,
			5, 2, 1, 1, 1, 1, 5,
			5, 1, 5, 1, 5, 5, 6,
			5, 2, 1, 1, 1, 2, 5,
			6, 5, 5, 1, 5, 1, 5,
			5, 1, 1, 1, 1, 2, 5,
			6, 5, 5, 1, 5, 5, 6,
			0, 0, 6, 5, 6, 0, 0
		};
		private static readonly byte[] percent =
		{
			6, 5, 5, 6, 0, 6, 5, 6,
			5, 1, 1, 5, 6, 5, 1, 5,
			5, 1, 1, 5, 5, 1, 5, 6,
			6, 5, 5, 5, 1, 5, 6, 0,
			0, 6, 5, 1, 5, 5, 5, 6,
			6, 5, 1, 5, 5, 1, 1, 5,
			5, 1, 5, 6, 5, 1, 1, 5,
			6, 5, 6, 0, 6, 5, 5, 6,
			0, 0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] hat =
		{
			0, 0, 6, 5, 6, 0, 0,
			0, 6, 5, 1, 5, 6, 0,
			6, 5, 1, 1, 1, 5, 6,
			5, 1, 1, 1, 1, 1, 5,
			6, 5, 5, 1, 5, 5, 6,
			0, 0, 5, 1, 5, 0, 0,
			0, 0, 5, 1, 5, 0, 0,
			0, 0, 5, 1, 5, 0, 0,
			0, 0, 6, 5, 6, 0, 0
		};
		private static readonly byte[] and =
		{
			0, 6, 5, 5, 6, 0, 0, 0,
			6, 5, 1, 1, 5, 6, 0, 0,
			5, 1, 5, 5, 1, 5, 0, 0,
			6, 5, 1, 1, 5, 6, 5, 6,
			5, 1, 5, 5, 1, 5, 1, 5,
			5, 1, 5, 5, 5, 1, 5, 6,
			6, 5, 1, 1, 1, 5, 1, 5,
			0, 6, 5, 5, 5, 6, 5, 6,
			0, 0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] asterik =
		{
			0, 0, 0, 0, 0, 0, 0, 0,
			0, 6, 5, 6, 6, 5, 6, 0,
			0, 5, 1, 5, 5, 1, 5, 0,
			6, 5, 5, 1, 1, 5, 5, 6,
			5, 1, 1, 1, 1, 1, 1, 5,
			6, 5, 5, 1, 1, 5, 5, 6,
			0, 5, 1, 5, 5, 1, 5, 0,
			0, 6, 5, 6, 6, 5, 6, 0,
			0, 0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] openParenthesis =
		{
			6, 5, 5, 6,
			5, 2, 1, 5,
			5, 1, 5, 6,
			5, 1, 5, 0,
			5, 1, 5, 0,
			5, 1, 5, 0,
			5, 1, 5, 6,
			5, 2, 1, 5,
			6, 5, 5, 6
		};
		private static readonly byte[] closeParenthesis =
		{
			6, 5, 5, 6,
			5, 1, 2, 5,
			6, 5, 1, 5,
			0, 5, 1, 5,
			0, 5, 1, 5,
			0, 5, 1, 5,
			6, 5, 1, 5,
			5, 1, 2, 5,
			6, 5, 5, 6
		};
		private static readonly byte[] minus =
		{
			0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0,
			6, 5, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 1, 1, 5,
			6, 5, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] underscore =
		{
			0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0,
			6, 5, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 1, 1, 5,
			6, 5, 5, 5, 5, 5, 6
		};
		private static readonly byte[] equal =
		{
			0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0,
			6, 5, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 1, 1, 5,
			6, 5, 5, 5, 5, 5, 6,
			5, 1, 1, 1, 1, 1, 5,
			6, 5, 5, 5, 5, 5, 6,
			0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] plus =
		{
			0, 0, 0, 0, 0, 0, 0,
			0, 0, 6, 5, 6, 0, 0,
			0, 0, 5, 1, 5, 0, 0,
			6, 5, 5, 1, 5, 5, 6,
			5, 1, 1, 1, 1, 1, 5,
			6, 5, 5, 1, 5, 5, 6,
			0, 0, 5, 1, 5, 0, 0,
			0, 0, 6, 5, 6, 0, 0,
			0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] tilde =
		{
			0, 0, 0, 0, 0, 0, 0, 0,
			0, 6, 5, 5, 6, 6, 5, 6,
			6, 5, 1, 1, 5, 5, 1, 5,
			5, 1, 5, 5, 1, 1, 5, 6,
			6, 5, 6, 6, 5, 5, 6, 0,
			0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0
		};
		private static readonly byte[] openCurlyBrace =
		{
			0, 6, 5, 5, 6,
			0, 5, 2, 1, 5,
			0, 5, 1, 5, 6,
			6, 5, 1, 5, 0,
			5, 1, 2, 6, 0,
			6, 5, 1, 5, 0,
			0, 5, 1, 5, 6,
			0, 5, 2, 1, 5,
			0, 6, 5, 5, 6
		};
		private static readonly byte[] closeCurlyBrace =
		{
			6, 5, 5, 6, 0,
			5, 1, 2, 5, 0,
			6, 5, 1, 5, 0,
			0, 5, 1, 5, 6,
			0, 6, 2, 1, 5,
			0, 5, 1, 5, 6,
			6, 5, 1, 5, 0,
			5, 1, 2, 5, 0,
			6, 5, 5, 6, 0
		};
		private static readonly byte[] openSquareBracket =
		{
			6, 5, 5, 5, 6,
			5, 1, 1, 1, 5,
			5, 1, 5, 5, 6,
			5, 1, 5, 0, 0,
			5, 1, 5, 0, 0,
			5, 1, 5, 0, 0,
			5, 1, 5, 5, 6,
			5, 1, 1, 1, 5,
			6, 5, 5, 5, 6
		};
		private static readonly byte[] closeSquareBracket =
		{
			6, 5, 5, 5, 6,
			5, 1, 1, 1, 5,
			6, 5, 5, 1, 5,
			0, 0, 5, 1, 5,
			0, 0, 5, 1, 5,
			0, 0, 5, 1, 5,
			6, 5, 5, 1, 5,
			5, 1, 1, 1, 5,
			6, 5, 5, 5, 6
		};
		private static readonly byte[] question =
		{
			0, 6, 5, 5, 5, 6, 0,
			6, 5, 1, 1, 1, 5, 6,
			5, 1, 5, 5, 5, 1, 5,
			6, 5, 6, 6, 5, 1, 5,
			0, 0, 6, 5, 1, 5, 6,
			0, 0, 5, 1, 5, 6, 0,
			0, 0, 6, 5, 6, 0, 0,
			0, 0, 5, 1, 5, 0, 0,
			0, 0, 6, 5, 6, 0, 0
		};
		private static readonly byte[] colon =
		{
			0, 0, 0,
			0, 0, 0,
			6, 5, 6,
			5, 1, 5,
			6, 5, 6,
			6, 5, 6,
			5, 1, 5,
			6, 5, 6,
			0, 0, 0
		};
		private static readonly byte[] semicolon =
		{
			0, 0, 0, 0,
			0, 0, 0, 0,
			0, 6, 5, 6,
			0, 5, 1, 5,
			0, 6, 5, 6,
			0, 6, 5, 6,
			6, 5, 1, 5,
			5, 2, 5, 6,
			6, 5, 6, 0
		};
		private static readonly byte[] doubleQuote =
		{
			6, 5, 6, 5, 6,
			5, 1, 5, 1, 5,
			5, 1, 5, 1, 5,
			6, 5, 6, 5, 6,
			0, 0, 0, 0, 0,
			0, 0, 0, 0, 0,
			0, 0, 0, 0, 0,
			0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		};
		private static readonly byte[] singleQuote =
		{
			6, 5, 6,
			5, 1, 5,
			5, 1, 5,
			6, 5, 6,
			0, 0, 0,
			0, 0, 0,
			0, 0, 0,
			0, 0, 0,
			0, 0, 0
		};

		public static readonly Dictionary<char, byte[]> Characters = new Dictionary<char, byte[]>
		{
			{ ' ', space },
			{ '\t', tab },

			{ '0', zero },
			{ '1', one },
			{ '2', two },
			{ '3', three },
			{ '4', four },
			{ '5', five },
			{ '6', six },
			{ '7', seven },
			{ '8', eight },
			{ '9', nine },

			{ 'A', uppercaseA },
			{ 'B', uppercaseB },
			{ 'C', uppercaseC },
			{ 'D', uppercaseD },
			{ 'E', uppercaseE },
			{ 'F', uppercaseF },
			{ 'G', uppercaseG },
			{ 'H', uppercaseH },
			{ 'I', uppercaseI },
			{ 'J', uppercaseJ },
			{ 'K', uppercaseK },
			{ 'L', uppercaseL },
			{ 'M', uppercaseM },
			{ 'N', uppercaseN },
			{ 'O', uppercaseO },
			{ 'P', uppercaseP },
			{ 'Q', uppercaseQ },
			{ 'R', uppercaseR },
			{ 'S', uppercaseS },
			{ 'T', uppercaseT },
			{ 'U', uppercaseU },
			{ 'V', uppercaseV },
			{ 'W', uppercaseW },
			{ 'X', uppercaseX },
			{ 'Y', uppercaseY },
			{ 'Z', uppercaseZ },

			{ 'a', lowercaseA },
			{ 'b', lowercaseB },
			{ 'c', lowercaseC },
			{ 'd', lowercaseD },
			{ 'e', lowercaseE },
			{ 'f', lowercaseF },
			{ 'g', lowercaseG },
			{ 'h', lowercaseH },
			{ 'i', lowercaseI },
			{ 'j', lowercaseJ },
			{ 'k', lowercaseK },
			{ 'l', lowercaseL },
			{ 'm', lowercaseM },
			{ 'n', lowercaseN },
			{ 'o', lowercaseO },
			{ 'p', lowercaseP },
			{ 'q', lowercaseQ },
			{ 'r', lowercaseR },
			{ 's', lowercaseS },
			{ 't', lowercaseT },
			{ 'u', lowercaseU },
			{ 'v', lowercaseV },
			{ 'w', lowercaseW },
			{ 'x', lowercaseX },
			{ 'y', lowercaseY },
			{ 'z', lowercaseZ },

			{ '<', lessThan },
			{ '>', greaterThan },
			{ ',', comma },
			{ '.', period },
			{ '/', forwardSlash },
			{ '\\', backSlash },
			{ '|', pipe },
			{ '!', bang },
			{ '@', at },
			{ '#', pound },
			{ '$', dollar },
			{ '%', percent },
			{ '^', hat },
			{ '&', and },
			{ '*', asterik },
			{ '(', openParenthesis },
			{ ')', closeParenthesis },
			{ '-', minus },
			{ '_', underscore },
			{ '=', equal },
			{ '+', plus },
			{ '~', tilde },
			{ '{', openCurlyBrace },
			{ '}', closeCurlyBrace },
			{ '[', openSquareBracket },
			{ ']', closeSquareBracket },
			{ '?', question },
			{ ':', colon },
			{ ';', semicolon },
			{ '"', doubleQuote },
			{ '\'', singleQuote }
		};
	}
}