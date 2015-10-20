using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace XCom.Data
{
	public class Stores
	{
		public List<StoreItem> Items { get; set; }

		[JsonIgnore]
		public int TotalItemSpaceRequired => Items.Sum(item => item.TotalItemSpaceRequired);
		[JsonIgnore]
		public int SpaceUsed => (TotalItemSpaceRequired + 99) / 100;

		public int this[ItemType itemType]
		{
			get { return Items.Single(item => item.ItemType == itemType).Count; }
			private set { Items.Single(item => item.ItemType == itemType).Count = value; }
		}

		public void Add(ItemType item, int count = 1)
		{
			this[item] += count;
		}

		public void Remove(ItemType item, int count = 1)
		{
			if (count > this[item])
				throw new InvalidOperationException("Not enough items in store.");
			this[item] -= count;
		}

		public static Stores Create()
		{
			return new Stores
			{
				Items = EnumEx.GetValues<ItemType>()
					.Select(item => new StoreItem { ItemType = item })
					.ToList()
			};
		}
	}
}
