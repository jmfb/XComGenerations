using XCom.Graphics;

namespace XCom.Data
{
	public class CraftMetadata
	{
		public string Name { get; set; }
		public int Damage { get; set; }
		public int Fuel { get; set; }
		public int WeaponCount { get; set; }
		public int Space { get; set; }
		public int HwpCount { get; set; }
		public int Speed { get; set; }
		public int Acceleration { get; set; }
		public Image Image { get; set; }
		public int RowOffset { get; set; }
		public int ColumnOffset { get; set; }
	}
}
