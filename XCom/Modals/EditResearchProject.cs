using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class EditResearchProject : Screen
	{
		private readonly ResearchProject research;

		public EditResearchProject(ResearchProject research)
		{
			this.research = research;
			var selectedBase = GameState.SelectedBase;
			AddControl(new Border(30, 45, 230, 140, ColorScheme.DarkYellow, Backgrounds.Research, 7));
			AddControl(new Label(40, 61, research.GetName(), Font.Large, ColorScheme.DarkYellow));
			AddControl(new Label(60, 61, "SCIENTISTS AVAILABLE>", Font.Normal, ColorScheme.DarkYellow));
			AddControl(new DynamicLabel(60, 164, () => selectedBase.ScientistsAvailable.FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(70, 61, "LABORATORY SPACE AVAILABLE>", Font.Normal, ColorScheme.DarkYellow));
			AddControl(new DynamicLabel(70, 196, () => selectedBase.LaboratorySpaceAvailable.FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(80, 61, "Scientists Allocated>", Font.Large, ColorScheme.DarkYellow));
			AddControl(new DynamicLabel(80, 231, () => research.ScientistsAllocated.FormatNumber(), Font.Large, ColorScheme.White));
			AddControl(new Label(100, 85, "Increase", Font.Large, ColorScheme.DarkYellow));
			AddControl(new Repeater(100, 195, 13, 14, "U", ColorScheme.DarkYellow, Font.Arrow, OnIncrease, 50));
			AddControl(new Label(120, 85, "Decrease", Font.Large, ColorScheme.DarkYellow));
			AddControl(new Repeater(120, 195, 13, 14, "D", ColorScheme.DarkYellow, Font.Arrow, OnDecrease, 50));
			AddControl(new Button(145, 61, 198, 16, "OK", ColorScheme.Blue, Font.Normal, EndModal));
		}

		private void OnIncrease()
		{
			var selectedBase = GameState.SelectedBase;
			if (selectedBase.ScientistsAvailable > 0 && selectedBase.LaboratorySpaceAvailable > 0)
				++research.ScientistsAllocated;
		}

		private void OnDecrease()
		{
			if (research.ScientistsAllocated > 0)
				--research.ScientistsAllocated;
		}
	}
}
