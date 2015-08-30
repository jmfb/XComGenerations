using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class MonthlyCosts : Screen
	{
		public MonthlyCosts()
		{
			AddControl(new Border(0, 0, 320, 200, ColorScheme.LightMagenta, Backgrounds.Funds, 0));
			AddControl(new Label(12, Label.Center, "Monthly Costs", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(32, 115, "Cost per unit", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(32, 195, "Quantity", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(32, 250, "Total", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(48, 10, "Craft Rental", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(80, 10, "Salaries", Font.Normal, ColorScheme.LightMagenta));

			var selectedBase = GameState.SelectedBase;
			CreateCostRow(56, ItemType.Skyranger, selectedBase.TotalSkyrangerCount);
			CreateCostRow(64, ItemType.Interceptor, selectedBase.TotalInterceptorCount);
			CreateCostRow(88, ItemType.Soldier, selectedBase.TotalSoldierCount);
			CreateCostRow(96, ItemType.Engineer, selectedBase.TotalEngineerCount);
			CreateCostRow(104, ItemType.Scientist, selectedBase.TotalScientistCount);

			AddControl(new ExtendedLabel(120, 10, 240, "Base maintenance", Font.Normal, ColorScheme.LightMagenta, ColorScheme.Blue));
			AddControl(new Label(120, 250, $"${selectedBase.TotalMaintenance.FormatNumber()}", Font.Normal, ColorScheme.Blue));

			var income = $"Income=${GameState.Current.Data.TotalFunding.FormatNumber()}";
			AddControl(new Label(136, 10, income, Font.Normal, ColorScheme.Blue));

			AddControl(new ExtendedLabel(136, 205, 45, "Total", Font.Normal, ColorScheme.White));
			AddControl(new Label(136, 250, $"${selectedBase.TotalMonthlyCost.FormatNumber()}", Font.Normal, ColorScheme.White));

			AddControl(new Button(176, 10, 300, 16, "OK", ColorScheme.LightMagenta, Font.Normal, OnOk));
		}

		private void CreateCostRow(int topRow, ItemType itemType, int quantity)
		{
			var metadata = itemType.Metadata();
			AddControl(new ExtendedLabel(topRow, 10, 125, metadata.Name, Font.Normal, ColorScheme.Blue));
			AddControl(new ExtendedLabel(topRow, 135, 70, $"${metadata.MonthlyCost.FormatNumber()}", Font.Normal, ColorScheme.Blue));
			AddControl(new ExtendedLabel(topRow, 205, 45, quantity.FormatNumber(), Font.Normal, ColorScheme.Blue));
			AddControl(new Label(topRow, 250, $"${(metadata.MonthlyCost * quantity).FormatNumber()}", Font.Normal, ColorScheme.Blue));
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(new BaseInformation());
		}
	}
}
