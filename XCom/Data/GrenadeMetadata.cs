﻿namespace XCom.Data
{
	public class GrenadeMetadata
	{
		public ItemType ItemType { get; set; }
		public DamageType DamageType { get; set; }
		public int Damage { get; set; }
		public int Weight { get; set; }
		public byte[] Image { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public string[] DescriptionLines { get; set; }

		public string Name => ItemType.Metadata().Name;
	}
}