using System.Collections.Generic;
using XCom.Battlescape;
using XCom.Battlescape.Tiles;

namespace XCom.Data
{
	public class GrenadeMetadata : BattleItemMetadata
	{
		public ItemType ItemType { get; set; }
		public DamageType DamageType { get; set; }
		public int Damage { get; set; }
		public int Weight { get; set; }
		public byte[] Image { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public string[] DescriptionLines { get; set; }
		public Dictionary<Direction, byte[]> Sprites { get; set; }
		public bool IsTwoHanded => false;

		public string Name => ItemType.Metadata().Name;
	}
}
