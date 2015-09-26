using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.World
{
	public class LowFuel : Screen
	{
		public LowFuel(Craft craft)
		{
			AddControl(new Border(40, 16, 224, 120, ColorScheme.Aqua, Backgrounds.Craft, 10));
			AddControl(new Label(60, Label.CenterOf(16, 224), craft.Name, Font.Large, ColorScheme.Yellow));
			AddControl(new Label(90, Label.CenterOf(16, 224), "is low on fuel,", Font.Normal, ColorScheme.Yellow));
			AddControl(new Label(98, Label.CenterOf(16, 224), "returning to base", Font.Normal, ColorScheme.Yellow));
			AddControl(new Button(120, 30, 90, 18, "OK", ColorScheme.Aqua, Font.Normal, EndModal));
			AddControl(new Button(120, 135, 90, 18, "OK - 5 secs", ColorScheme.Aqua, Font.Normal, OnOkFiveSeconds));
		}

		private void OnOkFiveSeconds()
		{
			Geoscape.ResetGameSpeed();
			EndModal();
		}
	}
}
