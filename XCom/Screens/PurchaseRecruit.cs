using System;
using System.Collections.Generic;
using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Modals;

namespace XCom.Screens
{
	public class PurchaseRecruit : Screen
	{
		private readonly Dictionary<ItemType, int> itemsToPurchase = Enum
			.GetValues(typeof(ItemType))
			.Cast<ItemType>()
			.Where(item => item.Metadata().AvailableToBuy)
			.ToDictionary(item => item, item => 0);

		public PurchaseRecruit()
		{
			AddControl(new Border(0, 0, 320, 200, ColorScheme.Blue, Backgrounds.Funds, 6));
			AddControl(new Label(8, Label.Center, "Purchase/Hire Personnel", Font.Large, ColorScheme.Blue));
			AddControl(new Label(24, 10, "Current Funds>", Font.Normal, ColorScheme.Blue));
			AddControl(new DynamicLabel(24, 78, () => $"${GameState.Current.Data.Funds.FormatNumber()}", Font.Normal, ColorScheme.White));
			AddControl(new Label(24, 160, "Cost of Purcahses>", Font.Normal, ColorScheme.Blue));
			AddControl(new DynamicLabel(24, 246, () => $"${TotalCost.FormatNumber()}", Font.Normal, ColorScheme.White));
			AddControl(new Label(32, 10, "ITEM", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(32, 152, "COST PER UNIT", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(32, 256, "QUANTITY", Font.Normal, ColorScheme.Blue));

			AddControl(new ListView<ItemType>(40, 10, 16, itemsToPurchase.Keys.ToList(), ColorScheme.Blue, Palette.GetPalette(6).GetColor(230), OnPurchaseItem)
				.ConfigureUpDown(234, OnCancelPurchaseItem)
				.AddColumn(162, Alignment.Left, item => item.Metadata().Name)
				.AddColumn(92, Alignment.Left, item => item.Metadata().Cost.FormatNumber())
				.AddColumn(32, Alignment.Left, item => itemsToPurchase[item].FormatNumber()));

			AddControl(new Button(176, 8, 148, 16, "OK", ColorScheme.Blue, Font.Normal, OnOk));
			AddControl(new Button(176, 164, 148, 16, "Cancel", ColorScheme.Blue, Font.Normal, OnCancel));
		}

		private int TotalCost => itemsToPurchase.Sum(item => item.Key.Metadata().Cost * item.Value);
		private int TotalItemSpaceRequired => itemsToPurchase.Sum(item => item.Key.Metadata().StorageSpace * item.Value);
		private int TotalHangarSpaceRequired => itemsToPurchase.Sum(item => item.Key.Metadata().HangarSpace * item.Value);
		private int TotalLivingSpaceRequired => itemsToPurchase.Sum(item => item.Key.Metadata().LivingSpace * item.Value);

		private void OnPurchaseItem(ItemType item)
		{
			if (itemsToPurchase[item] == 255)
				return;

			var metadata = item.Metadata();
			if (TotalCost + metadata.Cost > GameState.Current.Data.Funds)
			{
				AbortPurchaseItem();
				new NotEnoughMoney(ColorScheme.LightMagenta, Backgrounds.Funds).DoModal(this);
				return;
			}

			if (TotalLivingSpaceRequired + metadata.LivingSpace > GameState.SelectedBase.LivingSpaceAvailable)
			{
				AbortPurchaseItem();
				new NotEnoughLivingSpace(ColorScheme.LightMagenta, Backgrounds.Funds).DoModal(this);
				return;
			}

			if (TotalHangarSpaceRequired + metadata.HangarSpace > GameState.SelectedBase.HangarSpaceAvailable)
			{
				AbortPurchaseItem();
				new NoFreeHangars(ColorScheme.LightMagenta, Backgrounds.Funds, "PURCHASE").DoModal(this);
				return;
			}

			if (TotalItemSpaceRequired + metadata.StorageSpace > GameState.SelectedBase.ItemSpaceAvailable)
			{
				AbortPurchaseItem();
				new NotEnoughStoreSpace(ColorScheme.LightMagenta, Backgrounds.Funds).DoModal(this);
				return;
			}

			++itemsToPurchase[item];
		}

		private void AbortPurchaseItem()
		{
			GetChildControls<ListView<ItemType>>().Single().AbortUpDown();
		}

		private void OnCancelPurchaseItem(ItemType item)
		{
			if (itemsToPurchase[item] > 0)
				--itemsToPurchase[item];
		}

		private void OnOk()
		{
			GameState.Current.Data.Funds -= TotalCost;
			foreach (var item in itemsToPurchase.Where(itemToPurchase => itemToPurchase.Value > 0))
			{
				var purchaseHours = item.Key.Metadata().PurchaseHours;
				var count = item.Value;
				switch (item.Key)
				{
				case ItemType.Soldier:
					PurchaseSoldiers(count, purchaseHours);
					break;
				case ItemType.Skyranger:
					PurchaseSkyrangers(count, purchaseHours);
					break;
				case ItemType.Interceptor:
					PurchaseInterceptors(count, purchaseHours);
					break;
				default:
					PurchaseItems(item, count, purchaseHours);
					break;
				}
			}
			GameState.Current.SetScreen(new Base());
		}

		private static void PurchaseSoldiers(int count, int purchaseHours)
		{
			foreach (var index in Enumerable.Range(0, count))
				GameState.SelectedBase.TransferredSoldiers.Add(new TransferItem<Soldier>
				{
					Item = Soldier.Create(GameState.Current.Data.NextSoldierId++),
					HoursRemaining = purchaseHours
				});
		}

		private static void PurchaseSkyrangers(int count, int purchaseHours)
		{
			foreach (var index in Enumerable.Range(0, count))
				GameState.SelectedBase.TransferredCrafts.Add(new TransferItem<Craft>
				{
					Item = Craft.CreateNew(CraftType.Skyranger, GameState.Current.Data.NextSkyrangerNumber++),
					HoursRemaining = purchaseHours
				});
		}

		private static void PurchaseInterceptors(int count, int purchaseHours)
		{
			foreach (var index in Enumerable.Range(0, count))
				GameState.SelectedBase.TransferredCrafts.Add(new TransferItem<Craft>
				{
					Item = Craft.CreateNew(CraftType.Interceptor, GameState.Current.Data.NextInterceptorNumber++),
					HoursRemaining = purchaseHours
				});
		}

		private static void PurchaseItems(KeyValuePair<ItemType, int> item, int count, int purchaseHours)
		{
			GameState.SelectedBase.TransferredStores.Add(new TransferItem<StoreItem>
			{
				Item = new StoreItem {ItemType = item.Key, Count = count},
				HoursRemaining = purchaseHours
			});
		}

		private static void OnCancel()
		{
			GameState.Current.SetScreen(new Base());
		}
	}
}
