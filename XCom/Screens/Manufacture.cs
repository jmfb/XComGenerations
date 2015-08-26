using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Modals;

namespace XCom.Screens
{
	public class Manufacture : Screen
	{
		private readonly Screen returnToScreen;

		public Manufacture(Screen returnToScreen)
		{
			this.returnToScreen = returnToScreen;
			var selectedBase = GameState.SelectedBase;
			AddControl(new Border(0, 0, 320, 200, ColorScheme.Purple, Backgrounds.Workshop, 1));
			AddControl(new Label(8, Label.Center, "CURRENT PRODUCTION", Font.Large, ColorScheme.Purple));
			AddControl(new Label(24, 8, "Engineers Available>", Font.Normal, ColorScheme.Purple));
			AddControl(new DynamicLabel(24, 96, () => selectedBase.EngineersAvailable.FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(24, 160, "Engineers Allocated>", Font.Normal, ColorScheme.Purple));
			AddControl(new DynamicLabel(24, 249, () => selectedBase.EngineersAllocated.FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(34, 8, "Workshop Space Available>", Font.Normal, ColorScheme.Purple));
			AddControl(new DynamicLabel(34, 124, () => selectedBase.WorkshopSpaceAvailable.FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(34, 160, "Current Funds>", Font.Normal, ColorScheme.Purple));
			AddControl(new DynamicLabel(34, 228, () => $"${GameState.Current.Data.Funds.FormatNumber()}", Font.Normal, ColorScheme.White));
			AddControl(new Label(52, 10, "ITEM", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(44, 90, "Engineers", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(52, 90, "Allocated", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(44, 137, "Units", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(52, 137, "Produced", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(44, 180, "Total to", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(52, 180, "Produce", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(44, 223, "Cost", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(52, 223, "per", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(60, 223, "Unit", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(44, 265, "Days/Hours", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(52, 265, "Left", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new ListView<ManufactureProject>(80, 8, 11, selectedBase.ManufactureProjects, ColorScheme.Blue, Palette.GetPalette(1).GetColor(230), OnSelectManufactureProject)
				.AddColumn(1, Alignment.Left, project => "")
				.AddColumn(105, Alignment.Left, project => project.ManufactureType.Metadata().Name)
				.AddColumn(39, Alignment.Left, project => project.EngineersAllocated.FormatNumber())
				.AddColumn(45, Alignment.Left, project => project.UnitsProduced.FormatNumber())
				.AddColumn(27, Alignment.Left, project => project.UnitsToProduce.FormatNumber())
				.AddColumn(47, Alignment.Left, project => $"${project.ManufactureType.Metadata().Cost.FormatNumber()}")
				.AddColumn(24, Alignment.Left, project => project.TimeRemaining));
			AddControl(new Button(176, 8, 148, 16, "New Production", ColorScheme.Blue, Font.Normal, OnNewProduction));
			AddControl(new Button(176, 164, 148, 16, "OK", ColorScheme.Blue, Font.Normal, OnOk));
		}

		private void OnOk()
		{
			GameState.Current.SetScreen(returnToScreen);
		}

		private void OnNewProduction()
		{
			new NewProduction().DoModal(this);
		}

		private void OnSelectManufactureProject(ManufactureProject project)
		{
			new EditProduction(project).DoModal(this);
		}
	}
}
