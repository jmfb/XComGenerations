namespace XCom.Data
{
	public class ItemMetadata
	{
		public string Name { get; set; }
		public bool AvailableToBuy { get; set; }
		public int PurchaseHours { get; set; }
		public int Cost { get; set; }
		public int SalePrice { get; set; }
		public int MonthlyCost { get; set; }
		public int StorageSpace { get; set; }
		public int HangarSpace { get; set; }
		public int LivingSpace { get; set; }
	}
}
