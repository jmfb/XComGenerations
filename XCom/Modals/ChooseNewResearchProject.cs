using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class ChooseNewResearchProject : Screen
	{
		public ChooseNewResearchProject()
		{
			AddControl(new Border(30, 45, 230, 140, ColorScheme.Blue, Backgrounds.Research, 7));
			AddControl(new Label(38, Label.Center, "NEW RESEARCH PROJECTS", Font.Normal, ColorScheme.Blue));
			var selectionColor = Palette.GetPalette(7).GetColor(230);
			AddControl(new ListView<ResearchType>(54, 53, 11, GameState.Current.Data.AvailableResearchProjects, ColorScheme.White, selectionColor, OnClickResearchType)
				.AddColumn(200, Alignment.Center, researchType => researchType.Metadata().Name));
			AddControl(new Button(146, 53, 214, 16, "OK", ColorScheme.Purple, Font.Normal, EndModal));
		}

		private void OnClickResearchType(ResearchType researchType)
		{
			new ConfirmNewResearchProject(researchType, OnNewResearchProject).DoModal(this);
		}

		private void OnNewResearchProject(ResearchProject research)
		{
			SwitchToModal(new EditResearchProject(research));
		}
	}
}
