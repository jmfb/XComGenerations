namespace XCom.Data
{
	public class ItemMetadata
	{
		public string Name { get; set; }

		//http://ufopaedia.org/index.php?title=Buying/Selling/Transferring
		public bool AvailableToBuy { get; set; }
		public int PurchaseHours { get; set; }
		public int Cost { get; set; }
		public int SalePrice { get; set; }
		public int MonthlyCost { get; set; }

		//http://ufopaedia.org/index.php?title=Base_Stores
		public int StorageSpace { get; set; }
	}
}
