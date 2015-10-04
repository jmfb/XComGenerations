using System.Web.Script.Serialization;

namespace XCom.Data
{
	public class ManufactureProject
	{
		public ManufactureType ManufactureType { get; set; }
		public int EngineersAllocated { get; set; }
		public int UnitsToProduce { get; set; }
		public int UnitsProduced { get; set; }
		public int HoursCompleted { get; set; }

		private int HoursToComplete => UnitsToProduce * ManufactureType.Metadata().HoursToProduce;
		private int TotalHoursRemaining => HoursToComplete > HoursCompleted ? HoursToComplete - HoursCompleted : 0;
		private int EffectiveHoursRemaining => EngineersAllocated == 0 ? 0 : TotalHoursRemaining / EngineersAllocated;
		private int DaysRemaining => EffectiveHoursRemaining / 24;
		private int HoursRemaining => EffectiveHoursRemaining % 24;
		[ScriptIgnore]
		public string TimeRemaining => EngineersAllocated == 0 ? "-" :  $"{DaysRemaining.FormatNumber()}\t/{HoursRemaining.FormatNumber()}";

		private bool ValidateRequiredFunds()
		{
			return GameState.Current.Data.Funds >= ManufactureType.Metadata().Cost;
		}

		private bool ValidateRequiredHangarSpace(Base @base)
		{
			return @base.HangarSpaceAvailable >= ManufactureType.Metadata().HangarSpaceRequired;
		}

		private bool ValidateRequiredStorageSpace(Base @base)
		{
			var newItemSpaceRequired = ManufactureType.Metadata().ItemProduced.Metadata().StorageSpace;
			var spaceUsedWithNewItem = (@base.Stores.TotalItemSpaceRequired + newItemSpaceRequired + 99) / 100;
			return spaceUsedWithNewItem <= @base.TotalStorageSpace;
		}

		private bool ValidateRequiredMaterials(Base @base)
		{
			var metadata = ManufactureType.Metadata();
			return @base.Stores[ItemType.AlienAlloys] >= metadata.AlienAlloysRequired &&
				@base.Stores[ItemType.Elerium115] >= metadata.EleriumRequired &&
				@base.Stores[ItemType.UfoPowerSource] >= metadata.PowerSourcesRequired &&
				@base.Stores[ItemType.UfoNavigation] >= metadata.NavigationRequired;
		}

		private void ConsumeRequiredFundsAndMaterials(Base @base)
		{
			var metadata = ManufactureType.Metadata();
			GameState.Current.Data.Funds -= metadata.Cost;
			@base.CraftUnderConstruction += metadata.HangarSpaceRequired;
			@base.Stores.Remove(ItemType.AlienAlloys, metadata.AlienAlloysRequired);
			@base.Stores.Remove(ItemType.Elerium115, metadata.EleriumRequired);
			@base.Stores.Remove(ItemType.UfoPowerSource, metadata.PowerSourcesRequired);
			@base.Stores.Remove(ItemType.UfoNavigation, metadata.NavigationRequired);
		}

		public ManufactureStatus BeginUnitProduction(Base @base)
		{
			if (!ValidateRequiredFunds())
				return ManufactureStatus.InsufficientFunds;
			if (!ValidateRequiredHangarSpace(@base))
				return ManufactureStatus.InsufficientHangarSpace;
			if (!ValidateRequiredMaterials(@base))
				return ManufactureStatus.InsufficientMaterials;
			if (!ValidateRequiredStorageSpace(@base))
				return ManufactureStatus.InfufficentStorageSpace;
			ConsumeRequiredFundsAndMaterials(@base);
			return ManufactureStatus.UnitStarted;
		}

		public void CompleteUnit(Base @base)
		{
			var metadata = ManufactureType.Metadata();
			@base.CraftUnderConstruction -= metadata.HangarSpaceRequired;
			var item = metadata.ItemProduced;
			switch (item)
			{
			case ItemType.Firestorm:
				@base.Crafts.Add(Craft.CreateNew(CraftType.Firestorm, GameState.Current.Data.NextFirestormNumber++));
				break;
			case ItemType.Lightning:
				@base.Crafts.Add(Craft.CreateNew(CraftType.Lightning, GameState.Current.Data.NextLightningNumber++));
				break;
			case ItemType.Avenger:
				@base.Crafts.Add(Craft.CreateNew(CraftType.Avenger, GameState.Current.Data.NextAvengerNumber++));
				break;
			default:
				@base.Stores.Add(item);
				break;
			}
		}

		public bool CanProduce(Base selectedBase)
		{
			return ValidateRequiredFunds() &&
				ValidateRequiredHangarSpace(selectedBase) &&
				ValidateRequiredMaterials(selectedBase) &&
				ValidateRequiredStorageSpace(selectedBase);
		}
	}
}
