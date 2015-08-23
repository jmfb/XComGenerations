using System;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class ProductionStopped : Screen
	{
		public ProductionStopped(string baseName, string manufactureName, ManufactureStatus status)
		{
			var reason = GetReason(status);
			AddControl(new Border(20, 32, 256, 160, ColorScheme.Aqua, Backgrounds.Workshop, 6));
			AddControl(new Label(50, Label.Center, reason[0], Font.Large, ColorScheme.Aqua));
			AddControl(new Label(66, Label.Center, reason[1], Font.Large, ColorScheme.Aqua));
			AddControl(new Label(82, Label.Center, manufactureName, Font.Large, ColorScheme.Aqua));
			AddControl(new Label(98, Label.Center, "at", Font.Large, ColorScheme.Aqua));
			AddControl(new Label(114, Label.Center, baseName, Font.Large, ColorScheme.Aqua));
			AddControl(new Button(154, 100, 120, 16, "OK", ColorScheme.Aqua, Font.Normal, EndModal));
		}

		private static string[] GetReason(ManufactureStatus status)
		{
			switch (status)
			{
			case ManufactureStatus.InsufficientFunds:
				return new[] { "Not enough money to", "produce" };
			case ManufactureStatus.InsufficientHangarSpace:
				return new[] { "Not enough hangar space", "to produce" };
			case ManufactureStatus.InsufficientMaterials:
				return new[] { "Not enough special materials", "to produce" };
			case ManufactureStatus.InfufficentStorageSpace:
				return new[] { "Not enough storage space", "to produce" };
			}
			throw new InvalidOperationException("Invalid manufacture status");
		}
	}
}
