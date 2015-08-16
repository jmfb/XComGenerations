using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class WeCanNowResearch : Screen
	{
		private readonly ResearchType research;

		public WeCanNowResearch(ResearchType research)
		{
			this.research = research;
			AddControl(new Border(10, 16, 288, 180, ColorScheme.Green, Backgrounds.Research, 7));
			DisplayNewlyAvailableResearch();
			AddControl(new Button(148, 80, 160, 14, "OK", ColorScheme.Green, Font.Normal, OnOk));
			AddControl(new Button(164, 80, 160, 14, "Allocate Research", ColorScheme.Green, Font.Normal, OnAllocateResearch));
		}

		private void DisplayNewlyAvailableResearch()
		{
			var newResearchTypes = GameState.Current.Data.GetAvailableResearchProjects()
				.Where(project => project.Metadata().RequiredResearch.Contains(research))
				.ToList();
			if (!newResearchTypes.Any())
				return;

			AddControl(new Label(20, Label.Center, "We can now research", Font.Large, ColorScheme.Green));
			var nextTop = 56;
			foreach (var newResearchType in newResearchTypes)
			{
				AddControl(new Label(nextTop, Label.Center, newResearchType.Metadata().Name, Font.Large, ColorScheme.DarkYellow));
				nextTop += 16;
			}
		}

		private void OnOk()
		{
			EndModal();
		}

		private void OnAllocateResearch()
		{
			//EndModal();
			//TODO: transition to research screen but return to potential manufacturer side-effects
		}
	}
}
