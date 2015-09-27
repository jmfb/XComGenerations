using System;
using System.Collections.Generic;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.World
{
	public class SelectWorldObject : Screen
	{
		public SelectWorldObject(ICollection<object> worldObjects, Action<object> onSelectWorldObject)
		{
			const int buttonHeight = 16;
			const int buttonSpacing = 4;
			var borderHeight = 10 + worldObjects.Count * (buttonHeight + buttonSpacing) + buttonSpacing;
			var borderTop = (200 - borderHeight) / 2;
			AddControl(new Border(borderTop, 60, 136, borderHeight, ColorScheme.Aqua, Backgrounds.Ufo, 13));
			var nextTop = borderTop + 5 + buttonSpacing;
			foreach (var worldObject in worldObjects)
			{
				var top = nextTop;
				nextTop += buttonHeight + buttonSpacing;
				var localWorldObject = worldObject;
				Action onClick = () =>
				{
					EndModal();
					onSelectWorldObject(localWorldObject);
				};
				AddControl(new Button(top, 70, 116, buttonHeight, ((dynamic)worldObject).Name, ColorScheme.Aqua, Font.Normal, onClick));
			}
		}
	}
}
