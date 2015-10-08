using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;
using XCom.World;
using Base = XCom.Data.Base;

namespace XCom.Modals
{
	public class NewBaseLocation : Screen
	{
		private readonly MapLocation location;

		public NewBaseLocation(MapLocation location)
		{
			this.location = location;
			AddControl(new Border(64, 16, 224, 72, ColorScheme.Green, Backgrounds.Title, 0));
			AddControl(new Label(80, 68, "Cost>$", Font.Normal, ColorScheme.Green));
			AddControl(new Label(90, 68, "Area>", Font.Normal, ColorScheme.Green));
			AddControl(new Label(80, 97, location.RegionType.Metadata().BaseCost.FormatNumber(), Font.Normal, ColorScheme.Yellow));
			AddControl(new Label(90, 92, location.RegionType.Metadata().Name, Font.Normal, ColorScheme.Yellow));
			AddControl(new Button(104, 68, 50, 12, "OK", ColorScheme.Green, Font.Normal, OnOk));
			AddControl(new Button(104, 138, 50, 12, "CANCEL", ColorScheme.Green, Font.Normal, EndModal));
		}

		private void OnOk()
		{
			var cost = location.RegionType.Metadata().BaseCost;
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
			var newBase = Base.Create(name, location.Location, location.RegionType);
			var data = GameState.Current.Data;
			if (name == "Research") //TODO: remove research hack
				data.CompletedResearch = EnumEx.GetValues<ResearchType>().ToList();
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

			var skyranger = Craft.CreateRefueled(CraftType.Skyranger, data.NextSkyrangerNumber++);
			originalBase.Crafts.Add(skyranger);
			
			for (var index = 0; index < 2; ++index)
			{
				var interceptor = Craft.CreateRefueled(CraftType.Interceptor, data.NextInterceptorNumber++);
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
				Facility.CreateConstructed(2, 2, FacilityType.AccessLift),
				Facility.CreateConstructed(0, 2, FacilityType.Hangar),
				Facility.CreateConstructed(4, 0, FacilityType.Hangar),
				Facility.CreateConstructed(4, 4, FacilityType.Hangar),
				Facility.CreateConstructed(2, 3, FacilityType.LivingQuarters),
				Facility.CreateConstructed(3, 1, FacilityType.SmallRadarSystem),
				Facility.CreateConstructed(3, 2, FacilityType.GeneralStores),
				Facility.CreateConstructed(3, 3, FacilityType.Laboratory),
				Facility.CreateConstructed(3, 4, FacilityType.Workshop)
			});
		}
	}
}
