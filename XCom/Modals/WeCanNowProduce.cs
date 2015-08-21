using System.Collections.Generic;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class WeCanNowProduce : Screen
	{
		public WeCanNowProduce(IEnumerable<ManufactureType> newManufactureTypes)
		{
			AddControl(new Border(10, 16, 288, 180, ColorScheme.Green, Backgrounds.Workshop, 7));
			AddControl(new Label(20, Label.Center, "We can now produce", Font.Large, ColorScheme.Green));
			var nextTop = 56;
			foreach (var newManufactureType in newManufactureTypes)
			{
				AddControl(new Label(nextTop, Label.Center, newManufactureType.Metadata().Name, Font.Large, ColorScheme.DarkYellow));
				nextTop += 16;
			}
			AddControl(new Button(148, 80, 160, 14, "OK", ColorScheme.Green, Font.Normal, EndModal));
			AddControl(new Button(164, 80, 160, 14, "Allocate Manufacture", ColorScheme.Green, Font.Normal, OnAllocateManufacture));
		}

		private void OnAllocateManufacture()
		{
			EndModal();
			GameState.Current.SetScreen(new Manufacture(Geoscape));
		}
	}
}
