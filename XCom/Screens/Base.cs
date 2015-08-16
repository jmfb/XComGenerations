using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class Base : Screen
	{
		public Base()
		{
			var data = GameState.Current.Data;
			var selectedBase = data.Bases[data.SelectedBase];

			AddControl(new ClickToEdit(0, 193, 127, selectedBase.Name, Font.Large, ColorScheme.LightMagenta, OnEditName));
			AddControl(new Label(16, 194, selectedBase.Area, Font.Normal, ColorScheme.Purple));
			AddControl(new Label(24, 194, "FUNDS> $" + data.Funds.FormatNumber(), Font.Normal, ColorScheme.Blue));
			AddControl(new BaseSelect(41, 192, OnSelectBase));
			AddControl(new Button(58, 192, 128, 12, "BUILD NEW BASE", ColorScheme.DarkYellow, Font.Normal, OnBuildNewBase));
			AddControl(new Button(71, 192, 128, 12, "BASE INFORMATION", ColorScheme.DarkYellow, Font.Normal, OnBaseInformation));
			AddControl(new Button(84, 192, 128, 12, "SOLDIERS", ColorScheme.DarkYellow, Font.Normal, OnSoldiers));
			AddControl(new Button(97, 192, 128, 12, "EQUIP CRAFT", ColorScheme.DarkYellow, Font.Normal, OnEquipCraft));
			AddControl(new Button(110, 192, 128, 12, "BUILD FACILITIES", ColorScheme.DarkYellow, Font.Normal, OnBuildFacilities));
			AddControl(new Button(123, 192, 128, 12, "RESEARCH", ColorScheme.DarkYellow, Font.Normal, OnResearch));
			AddControl(new Button(136, 192, 128, 12, "MANUFACTURE", ColorScheme.DarkYellow, Font.Normal, OnManufacture));
			AddControl(new Button(149, 192, 128, 12, "TRANSFER", ColorScheme.DarkYellow, Font.Normal, OnTransfer));
			AddControl(new Button(162, 192, 128, 12, "PURCHASE/RECRUIT", ColorScheme.DarkYellow, Font.Normal, OnPurchaseRecruit));
			AddControl(new Button(175, 192, 128, 12, "SELL/SACK", ColorScheme.DarkYellow, Font.Normal, OnSellSack));
			AddControl(new Button(188, 192, 128, 12, "GEOSCAPE", ColorScheme.DarkYellow, Font.Normal, OnGeoscape));
			AddControl(new BaseFacilities(BaseFacilities.Mode.ViewFacilities, OnClickFacility));
		}

		private static void OnEditName(string value)
		{
			GameState.SelectedBase.Name = value;
		}

		private static void OnSelectBase()
		{
			GameState.Current.SetScreen(new Base());
		}

		private static void OnBuildNewBase()
		{
			if (GameState.Current.Data.Bases.Count == 8)
				return;
			GameState.Current.SetScreen(new BuildNewBase());
		}

		private static void OnBaseInformation()
		{
			GameState.Current.SetScreen(new BaseInformation());
		}

		private static void OnSoldiers()
		{
			GameState.Current.SetScreen(new Soldiers());
		}

		private static void OnEquipCraft()
		{
			GameState.Current.SetScreen(new CraftList());
		}

		private static void OnBuildFacilities()
		{
			GameState.Current.SetScreen(new BuildFacilities());
		}

		private static void OnResearch()
		{
			GameState.Current.SetScreen(new Research());
		}

		private static void OnManufacture()
		{
			//TODO
		}

		private static void OnTransfer()
		{
			//TODO
		}

		private static void OnPurchaseRecruit()
		{
			//TODO
		}

		private static void OnSellSack()
		{
			//TODO
		}

		private static void OnGeoscape()
		{
			GameState.Current.SetScreen(Geoscape);
		}

		private static void OnClickFacility(int row, int column)
		{
			//TODO
		}
	}
}
