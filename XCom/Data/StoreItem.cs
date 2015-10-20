using Newtonsoft.Json;

namespace XCom.Data
{
	public class StoreItem
	{
		public ItemType ItemType { get; set; }
		public int Count { get; set; }

		[JsonIgnore]
		public int TotalItemSpaceRequired => ItemType.Metadata().StorageSpace * Count;
		[JsonIgnore]
		public int SpaceUsed => (TotalItemSpaceRequired + 99) / 100;
	}
}
