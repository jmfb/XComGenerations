using System;
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
	public class ProductionInformation : Screen
	{
		private readonly ManufactureProject production;
		private readonly Action<ManufactureProject> action;

		public ProductionInformation(ManufactureType project, Action<ManufactureProject> action)
		{
			production = new ManufactureProject { ManufactureType = project, UnitsToProduce = 1 };
			this.action = action;
			var metadata = project.Metadata();

			AddControl(new Border(20, 0, 320, 160, ColorScheme.Blue, Backgrounds.Workshop, 1));
			AddControl(new Label(30, Label.Center, metadata.Name, Font.Large, ColorScheme.Blue));
			AddControl(new Label(50, 16, metadata.HoursToProduce.FormatNumber() + " Engineer hours to produce one unit", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(60, 16, "Cost per unit>$", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(60, 87, metadata.Cost.FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(70, 16, "Work Space Required>", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(70, 112, metadata.SpaceRequired.FormatNumber(), Font.Normal, ColorScheme.White));

			var specialMaterials = metadata.SpecialMaterials;
			if (specialMaterials.Any())
				DisplaySpecialMaterials(specialMaterials);

			AddControl(new Button(155, 16, 135, 16, "CANCEL", ColorScheme.Blue, Font.Normal, EndModal));
			if (production.CanProduce(GameState.SelectedBase))
				AddControl(new Button(155, 168, 135, 16, "START PRODUCTION", ColorScheme.Blue, Font.Normal, OnStartProduction));
		}

		private void DisplaySpecialMaterials(IEnumerable<StoreItem> specialMaterials)
		{
			AddControl(new Label(84, Label.Center, "SPECIAL MATERIALS REQUIRED", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(92, 30, "ITEM", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(100, 30, "REQUIRED", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(92, 155, "UNITS", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(100, 155, "REQUIRED", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(92, 230, "UNITS", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(100, 230, "AVAILABLE", Font.Normal, ColorScheme.Blue));
			var nextTop = 110;
			foreach (var storeItem in specialMaterials)
			{
				AddControl(new Label(nextTop, 30, storeItem.ItemType.Metadata().Name, Font.Normal, ColorScheme.Blue));
				AddControl(new Label(nextTop, 170, storeItem.Count.FormatNumber(), Font.Normal, ColorScheme.White));
				AddControl(new Label(nextTop, 245, GameState.SelectedBase.Stores[storeItem.ItemType].FormatNumber(), Font.Normal, ColorScheme.White));
				nextTop += 10;
			}
		}

		private void OnStartProduction()
		{
			GameState.SelectedBase.ManufactureProjects.Add(production);
			var status = production.BeginUnitProduction(GameState.SelectedBase);
			if (status != ManufactureStatus.UnitStarted)
				throw new InvalidOperationException("Could not start production on item.");
			EndModal();
			action(production);
		}
	}
}
