﻿using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class ProductionCompleted : Screen
	{
		public ProductionCompleted(string baseName, string manufactureName)
		{
			AddControl(new Border(20, 32, 256, 160, ColorScheme.Aqua, Backgrounds.Workshop, 6));
			AddControl(new Label(50, Label.Center, "Production complete:", Font.Large, ColorScheme.Aqua));
			AddControl(new Label(66, Label.Center, manufactureName, Font.Large, ColorScheme.Aqua));
			AddControl(new Label(82, Label.Center, "at", Font.Large, ColorScheme.Aqua));
			AddControl(new Label(98, Label.Center, baseName, Font.Large, ColorScheme.Aqua));
			AddControl(new Button(154, 100, 120, 16, "OK", ColorScheme.Aqua, Font.Normal, EndModal));
		}
	}
}
