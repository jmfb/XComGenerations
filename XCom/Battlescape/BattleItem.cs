using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XCom.Battlescape.Tiles;
using XCom.Data;

namespace XCom.Battlescape
{
	public class BattleItem
	{
		public BattleItemType BattleItemType { get; set; }
		public long Value { get; set; }
		public AmmunitionType? Ammunition { get; set; }
		public int Rounds { get; set; }

		[JsonIgnore]
		public object Item
		{
			get
			{
				switch (BattleItemType)
				{
				case BattleItemType.Weapon:
					return (WeaponType)Value;
				case BattleItemType.Ammunition:
					return (AmmunitionType)Value;
				case BattleItemType.Grenade:
					return (GrenadeType)Value;
				case BattleItemType.Equipment:
					return (EquipmentType)Value;
				}
				throw new InvalidOperationException("Unsupported battle item type.");
			}
			set
			{
				if (value is WeaponType)
					BattleItemType = BattleItemType.Weapon;
				else if (value is AmmunitionType)
					BattleItemType = BattleItemType.Ammunition;
				else if (value is GrenadeType)
					BattleItemType = BattleItemType.Grenade;
				else if (value is EquipmentType)
					BattleItemType = BattleItemType.Equipment;
				else
					throw new InvalidOperationException("Unsupported battle item type.");
				Value = Convert.ToInt32(value);
			}
		}

		private BattleItemMetadata Metadata => MetadataOf((dynamic)Item);
		private static BattleItemMetadata MetadataOf(WeaponType weaponType) => weaponType.Metadata();
		private static BattleItemMetadata MetadataOf(AmmunitionType ammunitionType) => ammunitionType.Metadata();
		private static BattleItemMetadata MetadataOf(EquipmentType equipmentType) => equipmentType.Metadata();
		private static BattleItemMetadata MetadataOf(GrenadeType grenadeType) => grenadeType.Metadata();

		[JsonIgnore]
		public string Name => Metadata.Name;
		[JsonIgnore]
		public byte[] Image => Metadata.Image;
		[JsonIgnore]
		public int Width => Metadata.Width;
		[JsonIgnore]
		public int Height => Metadata.Height;
		[JsonIgnore]
		public Dictionary<Direction, byte[]> Sprites => Metadata.Sprites ?? BattleItemSprite.Grenade;
		[JsonIgnore]
		public bool IsTwoHanded => Metadata.IsTwoHanded;

		public static IEnumerable<BattleItem> Create(StoreItem item)
		{
			return Enumerable.Repeat(item.ItemType, item.Count).Select(Create);
		}

		private static BattleItem Create(ItemType item)
		{
			var weaponType = EnumEx.GetValues<WeaponType>()
				.Cast<WeaponType?>()
				.SingleOrDefault(weapon => weapon?.Metadata().ItemType == item);
			var ammunitionType = EnumEx.GetValues<AmmunitionType>()
				.Cast<AmmunitionType?>()
				.SingleOrDefault(ammunition => ammunition?.Metadata().ItemType == item);
			var equipmentType = EnumEx.GetValues<EquipmentType>()
				.Cast<EquipmentType?>()
				.SingleOrDefault(equipment => equipment?.Metadata().ItemType == item);
			var grenadeType = EnumEx.GetValues<GrenadeType>()
				.Cast<GrenadeType?>()
				.SingleOrDefault(grenade => grenade?.Metadata().ItemType == item);
			var battleItemType = weaponType ?? ammunitionType ?? (object)equipmentType ?? grenadeType;
			if (battleItemType == null)
				throw new InvalidOperationException($"Invalid item type {item}");
			return new BattleItem
			{
				Item = battleItemType,
				Ammunition = null,
				Rounds = ammunitionType?.Metadata().Rounds ?? 0
			};
		}

		public bool CanLoadWith(BattleItem item)
		{
			return Ammunition == null && (item.Item as AmmunitionType?)?.Metadata().Weapon == (WeaponType?)Item;
		}
	}
}
