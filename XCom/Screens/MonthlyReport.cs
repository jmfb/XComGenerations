using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Music;

namespace XCom.Screens
{
	public class MonthlyReport : Screen
	{
		public MonthlyReport(MonthlyReportCard reportCard)
		{
			AddControl(new Border(0, 0, 320, 200, ColorScheme.Green, Backgrounds.Funds, 9));
			AddControl(new Label(8, 16, "XCOM PROJECT MONTHLY REPORT", Font.Large, ColorScheme.Green));
			AddControl(new Label(24, 16, "Month>", Font.Normal, ColorScheme.Green));
			AddControl(new Label(24, 50, reportCard.Month.ToString("MMM yyyy"), Font.Normal, ColorScheme.Yellow));
			AddControl(new Label(24, 125, "Monthly Rating>", Font.Normal, ColorScheme.Green));
			AddControl(new Label(24, 200, reportCard.Score.FormatNumber(), Font.Normal, ColorScheme.Yellow));
			AddControl(new Label(24, 225, reportCard.Status, Font.Normal, ColorScheme.Green));
			AddControl(new Label(32, 16, "Funding change>", Font.Normal, ColorScheme.Green));
			AddControl(new Label(32, 90, reportCard.FundingChange.FormatNumber(), Font.Normal, ColorScheme.Yellow));
			var nextTopRow = 40;
			foreach (var paragraph in reportCard.ReportParagraphs)
			{
				var label = new WrappedLabel(nextTopRow, 16, 288, paragraph, Font.Normal, ColorScheme.Yellow);
				AddControl(label);
				nextTopRow = label.Bottom + 4;
			}
			AddControl(new Button(180, 135, 50, 12, "OK", ColorScheme.Yellow, Font.Normal, OnOk));
		}

		public override void OnSetFocus()
		{
			MidiFiles.Play(MusicType.Month);
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(Geoscape);
		}
	}
}
