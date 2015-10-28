using XCom.Battlescape.Tiles;

namespace XCom.Data
{
	public class UfoMetadata
	{
		public string Name { get; set; }
		public ResearchType RequiredResearch { get; set; }
		public string Size { get; set; }
		public int Points { get; set; }
		public int DamageCapacity { get; set; }
		public int WeaponPower { get; set; }
		public int WeaponRange { get; set; }
		public int MaximumSpeed { get; set; }
		public byte[] Image { get; set; }
		public string Description { get; set; }
		public Tileset Tileset { get; set; }
	}
}
