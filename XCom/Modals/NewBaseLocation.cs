using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;
using Base = XCom.Data.Base;

namespace XCom.Modals
{
	public class NewBaseLocation : Screen
	{
		private readonly string area;
		private readonly int cost;

		public NewBaseLocation(string area, int cost)
		{
			this.area = area;
			this.cost = cost;

			AddControl(new Border(64, 16, 224, 72, ColorScheme.Green, Backgrounds.Title, 0));
			AddControl(new Label(80, 68, "Cost>$", Font.Normal, ColorScheme.Green));
			AddControl(new Label(90, 68, "Area>", Font.Normal, ColorScheme.Green));
			AddControl(new Label(80, 97, cost.FormatNumber(), Font.Normal, ColorScheme.Yellow));
			AddControl(new Label(90, 92, area, Font.Normal, ColorScheme.Yellow));
			AddControl(new Button(104, 68, 50, 12, "OK", ColorScheme.Green, Font.Normal, OnOk));
			AddControl(new Button(104, 138, 50, 12, "CANCEL", ColorScheme.Green, Font.Normal, EndModal));
		}

		private void OnOk()
		{
			if (cost > GameState.Current.Data.Funds)
			{
				SwitchToModal(new NotEnoughMoney(ColorScheme.DarkYellow, Backgrounds.Title));
			}
			else
			{
				GameState.Current.Data.Funds -= cost;
				SwitchToModal(new NewBaseNamePrompt(OnNewBase));
			}
		}

		private Screen OnNewBase(string name)
		{
			var newBase = Base.Create(name, area);
			var data = GameState.Current.Data;
			var originalBase = data.Bases.Count == 0;
			if (originalBase)
				InitializeOriginalBase(newBase);
			data.Bases.Add(newBase);
			data.SelectedBase = data.Bases.Count - 1;
			return originalBase ? (Screen)Geoscape : new PlaceAccessLift();
		}

		private static void AddTestData(Base originalBase)
		{
			originalBase.Stores.Add(ItemType.PersonalArmor, 2);
			originalBase.Stores.Add(ItemType.PowerSuit, 2);
			originalBase.Stores.Add(ItemType.FlyingSuit, 2);
		}

		private static void InitializeOriginalBase(Base originalBase)
		{
			var data = GameState.Current.Data;
			originalBase.ScientistCount = 10;
			originalBase.EngineerCount = 10;
		
			AddTestData(originalBase);

			var skyranger = Craft.CreateRefueled(data.NextCraftId++, CraftType.Skyranger, data.NextSkyrangerNumber++);
			originalBase.Crafts.Add(skyranger);
			
			for (var index = 0; index < 2; ++index)
			{
				var interceptor = Craft.CreateRefueled(data.NextCraftId++, CraftType.Interceptor, data.NextInterceptorNumber++);
				interceptor.Weapons.Add(CraftWeapon.CreateLoaded(CraftWeaponType.Stingray));
				interceptor.Weapons.Add(CraftWeapon.CreateLoaded(CraftWeaponType.Cannon));
				originalBase.Crafts.Add(interceptor);
			}

			for (var index = 0; index < 8; ++index)
			{
				var soldier = Soldier.Create(data.NextSoldierId++);
				originalBase.Soldiers.Add(soldier);
				skyranger.SoldierIds.Add(soldier.Id);
			}

			originalBase.Facilities.AddRange(new[]
			{
				new Facility
				{
					FacilityType = FacilityType.AccessLift,
					Row = 2,
					Column = 2
				},
				new Facility
				{
					FacilityType = FacilityType.Hangar,
					Row = 0,
					Column = 2
				},
				new Facility
				{
					FacilityType = FacilityType.Hangar,
					Row = 4,
					Column = 0
				},
				new Facility
				{
					FacilityType = FacilityType.Hangar,
					Row = 4,
					Column = 4
				},
				new Facility
				{
					FacilityType = FacilityType.LivingQuarters,
					Row = 2,
					Column = 3
				},
				new Facility
				{
					FacilityType = FacilityType.SmallRadarSystem,
					Row = 3,
					Column = 1
				},
				new Facility
				{
					FacilityType = FacilityType.GeneralStores,
					Row = 3,
					Column = 2
				},
				new Facility
				{
					FacilityType = FacilityType.Laboratory,
					Row = 3,
					Column = 3
				},
				new Facility
				{
					FacilityType = FacilityType.Workshop,
					Row = 3,
					Column = 4
				}
			});
		}
	}
}
