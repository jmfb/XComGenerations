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
			AddControl(new Button(146, 64, 80, 14, "OK", ColorScheme.Green, Font.Normal, EndModal));
			AddControl(new Button(146, 176, 80, 14, "VIEW REPORTS", ColorScheme.Green, Font.Normal, OnViewReports));
		}

		private void OnViewReports()
		{
			EndModal();
			//TODO: Determine if there is a UfoPaedia page associated with the completed research
			//		Choose the first one and display the XxxInformation page for it.
			//		Return to the Geoscape.
			GameState.Current.SetScreen(new ItemInformation(Geoscape, ItemType.LaserPistol));
		}
	}
}
