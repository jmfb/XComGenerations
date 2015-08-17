using System;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class ProductionInformation : Screen
	{
		private readonly ManufactureType project;
		private readonly Action<ManufactureProject> action;

		public ProductionInformation(ManufactureType project, Action<ManufactureProject> action)
		{
			this.project = project;
			this.action = action;
			AddControl(new Border(20, 0, 320, 160, ColorScheme.Blue, Backgrounds.Workshop, 1));
			AddControl(new Label(30, Label.Center, project.Metadata().Name, Font.Large, ColorScheme.Blue));
			AddControl(new Label(50, 16, project.Metadata().HoursToProduce.FormatNumber() + " Engineer hours to produce one unit", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(60, 16, "Cost per unit>$", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(60, 87, project.Metadata().Cost.FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(70, 16, "Work Space Required>", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(70, 112, project.Metadata().SpaceRequired.FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Button(155, 16, 135, 16, "CANCEL", ColorScheme.Blue, Font.Normal, EndModal));
			AddControl(new Button(155, 168, 135, 16, "START PRODUCTION", ColorScheme.Blue, Font.Normal, OnStartProduction));
		}

		private void OnStartProduction()
		{
			var production = new ManufactureProject { ManufactureType = project };
			GameState.SelectedBase.ManufactureProjects.Add(production);
			EndModal();
			action(production);
		}
	}
}
