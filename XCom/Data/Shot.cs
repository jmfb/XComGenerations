namespace XCom.Data
{
	public class Shot
	{
		public ShotType ShotType { get; set; }
		public int Accuracy { get; set; }
		public int TimeUnits { get; set; }

		private static Shot Create(ShotType shotType, int accuracy, int timeUnits)
		{
			return new Shot
			{
				ShotType = shotType,
				Accuracy = accuracy,
				TimeUnits = timeUnits
			};
		}
		public static Shot Auto(int accuracy, int timeUnits) => Create(ShotType.Auto, accuracy, timeUnits);
		public static Shot Snap(int accuracy, int timeUnits) => Create(ShotType.Snap, accuracy, timeUnits);
		public static Shot Aimed(int accuracy, int timeUnits) => Create(ShotType.Aimed, accuracy, timeUnits);
	}
}
