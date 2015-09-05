using System;
using System.Collections.Generic;
using System.Linq;

namespace XCom
{
	public static class EnumEx
	{
		public static IEnumerable<T> GetValues<T>()
		{
			return Enum.GetValues(typeof(T)).Cast<T>();
		}
	}
}
