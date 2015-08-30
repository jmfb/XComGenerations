using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class MonthlyReport : Screen
	{
		public MonthlyReport(MonthlyReportCard reportCard)
		{
			AddControl(new Border(0, 0, 320, 200, ColorScheme.Green, Backgrounds.Funds, 9));
			AddControl(new Label(8, 16, "XCOM PROJECT MONTHLY REPORT", Font.Large, ColorScheme.Green));
			AddControl(new Label(24, 16, "Month>", Font.Normal, ColorScheme.Green));
			AddControl(new Label(24, 50, reportCard.Month.ToString("MMM yyyy"), Font.Normal, ColorScheme.DarkYellow));
			AddControl(new Label(24, 125, "Monthly Rating>", Font.Normal, ColorScheme.Green));
			AddControl(new Label(24, 200, reportCard.Score.FormatNumber(), Font.Normal, ColorScheme.DarkYellow));
			AddControl(new Label(24, 225, reportCard.Status, Font.Normal, ColorScheme.Green));
			AddControl(new Label(32, 16, "Funding change>", Font.Normal, ColorScheme.Green));
			AddControl(new Label(32, 90, reportCard.FundingChange.FormatNumber(), Font.Normal, ColorScheme.DarkYellow));
			//TODO: reportCard.Description
			//TODO: reportCard.HappyCountries
			//TODO: reportCard.UnhappyCountries
			//TODO: reportCard.SignedAlienPacts
			AddControl(new Button(180, 135, 50, 12, "OK", ColorScheme.DarkYellow, Font.Normal, OnOk));
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(Geoscape);
		}
	}
}
