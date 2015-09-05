namespace XCom.Data
{
	public class HwpMetadata
	{
		public string Name { get; set; }
		public int TimeUnits { get; set; }
		public int Health { get; set; }
		public int FrontArmor { get; set; }
		public int LeftArmor { get; set; }
		public int RightArmor { get; set; }
		public int RearArmor { get; set; }
		public int UnderArmor { get; set; }
		public DamageType DamageType { get; set; }
		public int Damage { get; set; }
		public HwpAmmunitionType? Ammunition { get; set; }
		public int Rounds { get; set; }
		public string[] DescriptionLines { get; set; }
	}
}
