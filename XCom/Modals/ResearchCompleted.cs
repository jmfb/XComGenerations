using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class ResearchCompleted : Screen
	{
		private readonly ResearchType research;

		public ResearchCompleted(ResearchType research)
		{
			this.research = research;
			AddControl(new Border(30, 48, 224, 140, ColorScheme.Green, Backgrounds.Research, 0));
			AddControl(new Label(88, Label.Center, "Research Completed", Font.Large, ColorScheme.Green));
			AddControl(new Label(105, Label.Center, research.Metadata().Name, Font.Large, ColorScheme.White));
			AddControl(new Button(146, 64, 80, 14, "OK", ColorScheme.Green, Font.Normal, OnOk));
			AddControl(new Button(146, 176, 80, 14, "VIEW REPORTS", ColorScheme.Green, Font.Normal, OnViewReports));
		}

		private void OnOk()
		{
			SwitchToModal(new WeCanNowResearch(research));
		}

		private void OnViewReports()
		{
			EndModal();
			var item = research.Metadata().Item;
			if (item != null)
				GameState.Current.SetScreen(new ItemInformation(new Geoscape(), item.Value));
		}
	}
}
