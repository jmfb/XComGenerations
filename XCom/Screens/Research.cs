using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Modals;

namespace XCom.Screens
{
	public class Research : Screen
	{
		public Research()
		{
			var selectedBase = GameState.SelectedBase;
			AddControl(new Border(0, 0, 320, 200, ColorScheme.Blue, Backgrounds.Research, 7));
			AddControl(new Label(8, Label.Center, "CURRENT RESEARCH", Font.Large, ColorScheme.Blue));
			AddControl(new Label(24, 8, "Scientists Available>", Font.Normal, ColorScheme.Blue));
			AddControl(new DynamicLabel(24, 97, () => selectedBase.GetScientistsAvailable().FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(24, 160, "Scientists Allocdated>", Font.Normal, ColorScheme.Blue));
			AddControl(new DynamicLabel(24, 255, () => selectedBase.GetScientistsAllocated().FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(34, 8, "Laboratory Space Available>", Font.Normal, ColorScheme.Blue));
			AddControl(new DynamicLabel(34, 133, () => selectedBase.GetLaboratorySpaceAvailable().FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(44, 8, "RESEARCH PROJECT", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(44, 115, "SCIENTISTS ALLOCATED", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(44, 250, "PROGRESS", Font.Normal, ColorScheme.Blue));
			var selectionColor = Palette.GetPalette(7).GetColor(230);
			AddControl(new ListView<ResearchProject>(54, 8, 15, GameState.SelectedBase.ResearchProjects, ColorScheme.Purple, selectionColor, OnClickResearch)
				.AddColumn(2, Alignment.Left, research => "")
				.AddColumn(158, Alignment.Left, research => research.GetName())
				.AddColumn(82, Alignment.Left, research => research.ScientistsAllocated.FormatNumber())
				.AddColumn(46, Alignment.Left, research => research.GetProgress().ToString()));
			AddControl(new Button(176, 8, 148, 16, "New Project", ColorScheme.Purple, Font.Normal, OnNewProject));
			AddControl(new Button(176, 164, 148, 16, "OK", ColorScheme.Purple, Font.Normal, OnOk));
		}

		private void OnNewProject()
		{
			new ChooseNewResearchProject().DoModal(this);
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(new Base());
		}

		private void OnClickResearch(ResearchProject research)
		{
			new EditResearchProject(research).DoModal(this);
		}
	}
}
