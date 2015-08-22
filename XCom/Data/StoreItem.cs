namespace XCom.Data
{
	public class StoreItem
	{
		public ItemType ItemType { get; set; }
		public int Count { get; set; }

		public int TotalItemSpaceRequired => ItemType.Metadata().StorageSpace * Count;
		public int SpaceUsed => (TotalItemSpaceRequired + 99) / 100;
	}
}
