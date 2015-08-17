using System.Collections.Generic;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class NewProduction : Screen
	{
		public NewProduction()
		{
			AddControl(new Border(30, 0, 320, 140, ColorScheme.LightMagenta, Backgrounds.Workshop, 1));
			AddControl(new Label(38, Label.Center, "Production Items", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(54, 12, "ITEM", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(54, 167, "CATEGORY", Font.Normal, ColorScheme.LightMagenta));
			var data = new List<ManufactureType> { ManufactureType.LaserPistol }; //TODO: real list of available manufacture minus existing projects
			AddControl(new ListView<ManufactureType>(70, 10, 9, data, ColorScheme.White, Palette.GetPalette(1).GetColor(230), OnSelectProject)
				.AddColumn(2, Alignment.Left, project => "")
				.AddColumn(155, Alignment.Left, project => project.Metadata().Name)
				.AddColumn(130, Alignment.Left, project => project.Metadata().Category));
			AddControl(new Button(146, 9, 302, 16, "OK", ColorScheme.Blue, Font.Normal, EndModal));
		}

		private void OnSelectProject(ManufactureType project)
		{
			new ProductionInformation(project, OnStartProduction).DoModal(this);
		}

		private void OnStartProduction(ManufactureProject production)
		{
			SwitchToModal(new EditProduction(production));
		}
	}
}
