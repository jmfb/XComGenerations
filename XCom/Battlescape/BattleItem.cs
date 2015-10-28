using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
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

		[JsonIgnore]
		public string Name => NameOf((dynamic)Item);
		private static string NameOf(WeaponType weaponType) => weaponType.Metadata().Name;
		private static string NameOf(AmmunitionType ammunitionType) => ammunitionType.Metadata().Name;
		private static string NameOf(EquipmentType equipmentType) => equipmentType.Metadata().Name;
		private static string NameOf(GrenadeType grenadeType) => grenadeType.Metadata().Name;

		[JsonIgnore]
		public byte[] Image => ImageOf((dynamic)Item);
		private static byte[] ImageOf(WeaponType weaponType) => weaponType.Metadata().Image;
		private static byte[] ImageOf(AmmunitionType ammunitionType) => ammunitionType.Metadata().Image;
		private static byte[] ImageOf(EquipmentType equipmentType) => equipmentType.Metadata().Image;
		private static byte[] ImageOf(GrenadeType grenadeType) => grenadeType.Metadata().Image;

		[JsonIgnore]
		public int Width => WidthOf((dynamic)Item);
		private static int WidthOf(WeaponType weaponType) => weaponType.Metadata().Width;
		private static int WidthOf(AmmunitionType ammunitionType) => ammunitionType.Metadata().Width;
		private static int WidthOf(EquipmentType equipmentType) => equipmentType.Metadata().Width;
		private static int WidthOf(GrenadeType grenadeType) => grenadeType.Metadata().Width;

		[JsonIgnore]
		public int Height => HeightOf((dynamic)Item);
		private static int HeightOf(WeaponType weaponType) => weaponType.Metadata().Height;
		private static int HeightOf(AmmunitionType ammunitionType) => ammunitionType.Metadata().Height;
		private static int HeightOf(EquipmentType equipmentType) => equipmentType.Metadata().Height;
		private static int HeightOf(GrenadeType grenadeType) => grenadeType.Metadata().Height;

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
