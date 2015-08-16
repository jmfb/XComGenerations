using System.Collections.Generic;
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
		public WeCanNowResearch(List<ResearchType> newResearchTypes)
		{
			AddControl(new Border(10, 16, 288, 180, ColorScheme.Green, Backgrounds.Research, 7));
			if (newResearchTypes.Any())
				DisplayNewlyAvailableResearch(newResearchTypes);
			AddControl(new Button(148, 80, 160, 14, "OK", ColorScheme.Green, Font.Normal, EndModal));
			AddControl(new Button(164, 80, 160, 14, "Allocate Research", ColorScheme.Green, Font.Normal, OnAllocateResearch));
		}

		private void DisplayNewlyAvailableResearch(List<ResearchType> newResearchTypes)
		{
			AddControl(new Label(20, Label.Center, "We can now research", Font.Large, ColorScheme.Green));
			var nextTop = 56;
			foreach (var newResearchType in newResearchTypes)
			{
				AddControl(new Label(nextTop, Label.Center, newResearchType.Metadata().Name, Font.Large, ColorScheme.DarkYellow));
				nextTop += 16;
			}
		}

		private void OnAllocateResearch()
		{
			EndModal();
			GameState.Current.SetScreen(new Research(Geoscape));
		}
	}
}
