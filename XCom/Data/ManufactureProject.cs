namespace XCom.Data
{
	public class ManufactureProject
	{
		public ManufactureType ManufactureType { get; set; }
		public int EngineersAllocated { get; set; }
		public int UnitsToProduce { get; set; }
		public int UnitsProduced { get; set; }
		public int HoursCompleted { get; set; }
		public int HoursToComplete => UnitsToProduce * ManufactureType.Metadata().HoursToProduce;
		public int TotalHoursRemaining => HoursToComplete > HoursCompleted ? HoursToComplete - HoursCompleted : 0;
		public int EffectiveHoursRemaining => EngineersAllocated == 0 ? 0 : TotalHoursRemaining / EngineersAllocated;
		public int DaysRemaining => EffectiveHoursRemaining / 24;
		public int HoursRemaining => EffectiveHoursRemaining % 24;
		public string TimeRemaining => EngineersAllocated == 0 ? "-" :  DaysRemaining.FormatNumber() + "\t/" + HoursRemaining.FormatNumber();
	}
}
