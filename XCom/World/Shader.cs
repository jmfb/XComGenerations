namespace XCom.World
{
	public static class Shader
	{
		private static int ShadeToIndex(int shade)
		{
			if (shade < 44)
				return 8;
			if (shade < 52)
				return 52 - shade;
			if (shade < 140)
				return 0;
			if (shade < 148)
				return shade - 140;
			return 8;
		}

		private static int GetShade(int longitude, int secondOfDay)
		{
			const int secondsInDay = 60 * 60 * 24;
			const int secondsPerEighthDegree = secondsInDay / Trigonometry.EighthDegreesCount;
			const int secondsPerShade = 450;
			var localSecondOfDay = (longitude * secondsPerEighthDegree + secondsInDay + secondOfDay) % secondsInDay;
			return localSecondOfDay / secondsPerShade;
		}

		public static int GetShadeIndex(int longitude, int secondOfDay)
		{
			var shade = GetShade(longitude, secondOfDay);
			return ShadeToIndex(shade);
		}
	}
}
