using System.Globalization;

namespace XCom
{
	public static class Int32Extensions
	{
		public static string FormatNumber(this int value)
		{
			return value.ToString("N", new NumberFormatInfo
			{
				NumberGroupSeparator = "\t",
				NumberDecimalDigits = 0
			});
		}

		public static string FormatPercent(this int value)
		{
			return value.ToString(CultureInfo.InvariantCulture) + "\t%";
		}

		public static string FormatOrdinal(this int value)
		{
			var number = value.ToString(CultureInfo.InvariantCulture);
			var suffix =
				number.EndsWith("11") ? "th" :
				number.EndsWith("12") ? "th" :
				number.EndsWith("13") ? "th" :
				number.EndsWith("1") ? "st" :
				number.EndsWith("2") ? "nd" :
				number.EndsWith("3") ? "rd" :
				"th";
			return number + "\t" + suffix;
		}
	}
}
