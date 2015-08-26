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

			var totalCost = 0;
			var selectedBase = GameState.SelectedBase;
			totalCost += CreateCostRow(56, "SKYRANGER", 500000, selectedBase.CountCrafts(CraftType.Skyranger));
			totalCost += CreateCostRow(64, "INTERCEPTOR", 600000, selectedBase.CountCrafts(CraftType.Interceptor));
			totalCost += CreateCostRow(88, "Soldiers", 20000, selectedBase.Soldiers.Count);
			totalCost += CreateCostRow(96, "Engineers", 25000, selectedBase.EngineerCount);
			totalCost += CreateCostRow(104, "Scientists", 30000, selectedBase.ScientistCount);

			AddControl(new ExtendedLabel(120, 10, 240, "Base maintenance", Font.Normal, ColorScheme.LightMagenta, ColorScheme.Blue));
			var maintenance = selectedBase.TotalMaintenance;
			totalCost += maintenance;
			AddControl(new Label(120, 250, $"${maintenance.FormatNumber()}", Font.Normal, ColorScheme.Blue));

			var income = $"Income=${GameState.Current.Data.TotalFunding.FormatNumber()}";
			AddControl(new Label(136, 10, income, Font.Normal, ColorScheme.Blue));

			AddControl(new ExtendedLabel(136, 205, 45, "Total", Font.Normal, ColorScheme.White));
			AddControl(new Label(136, 250, $"${totalCost.FormatNumber()}", Font.Normal, ColorScheme.White));

			AddControl(new Button(176, 10, 300, 16, "OK", ColorScheme.LightMagenta, Font.Normal, OnOk));
		}

		private int CreateCostRow(int topRow, string label, int cost, int quantity)
		{
			AddControl(new ExtendedLabel(topRow, 10, 125, label, Font.Normal, ColorScheme.Blue));
			AddControl(new ExtendedLabel(topRow, 135, 70, $"${cost.FormatNumber()}", Font.Normal, ColorScheme.Blue));
			AddControl(new ExtendedLabel(topRow, 205, 45, quantity.FormatNumber(), Font.Normal, ColorScheme.Blue));
			var total = cost * quantity;
			AddControl(new Label(topRow, 250, $"${total.FormatNumber()}", Font.Normal, ColorScheme.Blue));
			return total;
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(new BaseInformation());
		}
	}
}
