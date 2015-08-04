using System;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class ConfirmNewResearchProject : Screen
	{
		private readonly ResearchType researchType;
		private readonly Action<ResearchProject> action;

		public ConfirmNewResearchProject(ResearchType researchType, Action<ResearchProject> action)
		{
			this.researchType = researchType;
			this.action = action;
			AddControl(new Border(30, 45, 230, 140, ColorScheme.LightMagenta, Backgrounds.Research, 7));
			AddControl(new Label(72, Label.Center, researchType.Metadata().Name, Font.Large, ColorScheme.LightMagenta));
			AddControl(new Button(145, 61, 82, 16, "START PROJECT", ColorScheme.Purple, Font.Normal, OnStartProject));
			AddControl(new Button(145, 176, 82, 16, "CANCEL", ColorScheme.Purple, Font.Normal, EndModal));
		}

		private void OnStartProject()
		{
			var research = ResearchProject.Create(researchType);
			GameState.SelectedBase.ResearchProjects.Add(research);
			EndModal();
			action(research);
		}
	}
}
