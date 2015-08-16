using System;
using System.Collections.Generic;
using System.Linq;

namespace XCom.Data
{
	public class Store<T>
	{
		public List<StoreItem<T>> Items { get; set; }

		public static Store<T> Create()
		{
			return new Store<T>
			{
				Items = new List<StoreItem<T>>()
			};
		}

		public int CountOf(T itemType)
		{
			return Find(itemType)?.Count ?? 0;
		}

		public void Remove(T itemType)
		{
			var item = Find(itemType);
			if (item == null)
				throw new InvalidOperationException("Item not in store.");
			--item.Count;
			if (item.Count == 0)
				Items.Remove(item);
		}

		public void Add(T itemType)
		{
			var item = Find(itemType);
			if (item == null)
			{
				item = new StoreItem<T>
				{
					ItemType = itemType,
					Count = 0
				};
				Items.Add(item);
			}
			++item.Count;
		}

		private StoreItem<T> Find(T itemType)
		{
			return Items.FirstOrDefault(item => item.ItemType.Equals(itemType));
		}
	}
}
