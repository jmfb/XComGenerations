using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class EditProduction : Screen
	{
		private readonly ManufactureProject production;

		public EditProduction(ManufactureProject production)
		{
			this.production = production;
			var selectedBase = GameState.SelectedBase;
			AddControl(new Border(25, 0, 320, 150, ColorScheme.LightMagenta, Backgrounds.Workshop, 1));
			AddControl(new Label(35, Label.Center, production.ManufactureType.Metadata().Name, Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(55, 16, "ENGINEERS AVAILABLE>", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new DynamicLabel(55, 113, () => selectedBase.EngineersAvailable.FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(65, 16, "WORKSHOP SPACE AVAILABLE>", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new DynamicLabel(65, 139, () => selectedBase.WorkshopSpaceAvailable.FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(75, 16, "Engineers", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(90, 16, "Allocated", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(85, 128, ">", Font.Large, ColorScheme.LightMagenta));
			AddControl(new DynamicLabel(85, 135, () => production.EngineersAllocated.FormatNumber(), Font.Large, ColorScheme.White));
			AddControl(new Label(75, 168, "Units to", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(90, 168, "Produce", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(85, 272, ">", Font.Large, ColorScheme.LightMagenta));
			AddControl(new DynamicLabel(85, 279, () => production.UnitsToProduce.FormatNumber(), Font.Large, ColorScheme.White));
			AddControl(new Label(114, 40, "INCREASE", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(132, 40, "DECREASE", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Repeater(108, 132, 13, 14, "U", ColorScheme.LightMagenta, Font.Arrow, OnIncreaseEngineers, 50));
			AddControl(new Repeater(130, 132, 13, 14, "D", ColorScheme.LightMagenta, Font.Arrow, OnDecreaseEngineers, 50));
			AddControl(new Label(114, 192, "INCREASE", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(132, 192, "DECREASE", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Repeater(108, 284, 13, 14, "U", ColorScheme.LightMagenta, Font.Arrow, OnIncreaseUnits, 50));
			AddControl(new Repeater(130, 284, 13, 14, "D", ColorScheme.LightMagenta, Font.Arrow, OnDecreaseUnits, 50));
			AddControl(new Button(150, 16, 135, 16, "STOP PRODUCTION", ColorScheme.Purple, Font.Normal, OnStopProduction));
			AddControl(new Button(150, 168, 135, 16, "OK", ColorScheme.Purple, Font.Normal, EndModal));
		}

		private void OnStopProduction()
		{
			EndModal();
			GameState.SelectedBase.ManufactureProjects.Remove(production);
		}

		private void OnIncreaseEngineers()
		{
			var selectedBase = GameState.SelectedBase;
			var areEngineersAvailable = selectedBase.EngineersAvailable > 0;
			var isWorkshopSpaceAvailable = selectedBase.WorkshopSpaceAvailable > 0;
			var maximumEngineersAllowed = production.ManufactureType.Metadata().HoursToProduce;
			var areMoreEngineersAllowedOnProject = production.EngineersAllocated < maximumEngineersAllowed;
			if (areEngineersAvailable && isWorkshopSpaceAvailable && areMoreEngineersAllowedOnProject)
				++production.EngineersAllocated;
		}

		private void OnDecreaseEngineers()
		{
			if (production.EngineersAllocated > 0)
				--production.EngineersAllocated;
		}

		private void OnIncreaseUnits()
		{
			++production.UnitsToProduce;
		}

		private void OnDecreaseUnits()
		{
			var minimumUnitsToProduce = production.UnitsProduced + 1;
			if (production.UnitsToProduce > minimumUnitsToProduce)
				--production.UnitsToProduce;
		}
	}
}
