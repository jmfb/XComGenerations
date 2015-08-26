using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class Funding : Screen
	{
		public Funding()
		{
			AddControl(new Border(0, 0, 320, 200, ColorScheme.Green, Backgrounds.Funds, 6));
			AddControl(new Label(8, 32, "International Relations", Font.Large, ColorScheme.Green));
			AddControl(new Label(24, 32, "Country", Font.Large, ColorScheme.Green));
			AddControl(new Label(24, 140, "Funding", Font.Large, ColorScheme.Green));
			AddControl(new Label(24, 240, "Change", Font.Large, ColorScheme.Green));
			
			var nextTopRow = 40;
			var totalFunding = 0;
			foreach (var country in GameState.Current.Data.Countries)
			{
				totalFunding += country.Funding;

				var topRow = nextTopRow;
				nextTopRow += 8;

				AddControl(new ExtendedLabel(topRow, 32, 108, country.Name, Font.Normal, ColorScheme.Green));
				AddControl(new Label(topRow, 140, "$", Font.Normal, ColorScheme.Green));
				
				var fundingColor = country.Funding == 0 ? ColorScheme.Green : ColorScheme.Yellow;
				var funding = country.Funding.FormatNumber();
				AddControl(new ExtendedLabel(topRow, 146, 94, funding, Font.Normal, fundingColor, ColorScheme.Green));

				var changeColor = country.FundingChange == 0 ? ColorScheme.Green : ColorScheme.Yellow;
				var change = country.FundingChange.FormatNumber();
				if (country.FundingChange > 0)
					change = $"+{change}";
				AddControl(new Label(topRow, 240, change, Font.Normal, changeColor));
			}

			AddControl(new ExtendedLabel(168, 32, 108, "TOTAL", Font.Normal, ColorScheme.Aqua));
			AddControl(new Label(168, 140, $"${totalFunding.FormatNumber()}", Font.Normal, ColorScheme.Aqua));

			AddControl(new Button(180, 135, 50, 12, "OK", ColorScheme.Green, Font.Normal, OnOk));
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(Geoscape);
		}
	}
}
