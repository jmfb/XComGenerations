using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class NotEnoughStoresToRearmCraft : Screen
	{
		public NotEnoughStoresToRearmCraft(Data.Base @base, Craft craft, ItemType ammo)
		{
			AddControl(new Border(20, 32, 256, 160, ColorScheme.Green, Backgrounds.Craft, 10));
			AddControl(new Label(66, Label.Center, "Not enough", Font.Large, ColorScheme.Green));
			AddControl(new Label(82, Label.Center, ammo.Metadata().Name, Font.Large, ColorScheme.Green));
			AddControl(new Label(98, Label.Center, $"to rearm {craft.Name}", Font.Large, ColorScheme.Green));
			AddControl(new Label(114, Label.Center, $"at {@base.Name}", Font.Large, ColorScheme.Green));
			AddControl(new Button(150, 48, 100, 16, "OK", ColorScheme.Green, Font.Normal, EndModal));
			AddControl(new Button(150, 172, 100, 16, "OK - 5 secs", ColorScheme.Green, Font.Normal, OnOkFiveSeconds));
		}

		private void OnOkFiveSeconds()
		{
			Geoscape.ResetGameSpeed();
			EndModal();
		}
	}
}
