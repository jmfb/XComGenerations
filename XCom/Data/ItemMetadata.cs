using System.Linq;

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
		public int HwpSpace { get; set; }
		public bool IsLiveAlien { get; set; }
		public bool IsEquipment { get; set; }
		public ItemType? AmmoForWeapon { get; set; }
		public ResearchType[] RequiredResearch { get; set; }

		private bool IsRequiredResearchCompletedForThisItem => RequiredResearch == null || RequiredResearch.All(GameState.Current.Data.CompletedResearch.Contains);
		private bool IsRequiredResearchCompletedForWeapon => AmmoForWeapon == null || AmmoForWeapon.Value.Metadata().IsRequiredResearchCompleted;
		public bool IsRequiredResearchCompleted => IsRequiredResearchCompletedForThisItem && IsRequiredResearchCompletedForWeapon;
	}
}
