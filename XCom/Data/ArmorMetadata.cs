namespace XCom.Data
{
	public class ArmorMetadata
	{
		public string Name { get; set; }
		public int FrontArmor { get; set; }
		public int LeftArmor { get; set; }
		public int RightArmor { get; set; }
		public int RearArmor { get; set; }
		public int UnderArmor { get; set; }
		public bool FireResistant { get; set; }
		public bool SmokeResistant { get; set; }
		public int StunResistance { get; set; }
	}
}
