namespace XCom.Data
{
	public class WeaponMetadata
	{
		public ItemType ItemType { get; set; }
		public Shot[] Shots { get; set; }
		public int Weight { get; set; }
		public bool IsTwoHanded { get; set; }
		public byte[] Image { get; set; }
		public int Width { get; set; }
		public int Height {get; set; }
		public string[] DescriptionLines { get; set; }

		public string Name => ItemType.Metadata().Name;
	}
}
