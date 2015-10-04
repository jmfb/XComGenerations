using System.Web.Script.Serialization;

namespace XCom.Data
{
	public class StoreItem
	{
		public ItemType ItemType { get; set; }
		public int Count { get; set; }

		[ScriptIgnore]
		public int TotalItemSpaceRequired => ItemType.Metadata().StorageSpace * Count;
		[ScriptIgnore]
		public int SpaceUsed => (TotalItemSpaceRequired + 99) / 100;
	}
}
