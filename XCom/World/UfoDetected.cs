using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.World
{
	public class UfoDetected : Screen
	{
		private readonly Ufo ufo;

		public UfoDetected(Ufo ufo)
		{
			this.ufo = ufo;
			if (ufo.HyperWaveTransmissionsDecoded)
				DisplayHyperWaveTransmissions();
			else
				DisplayBasicRadarResults();
		}

		private void DisplayHyperWaveTransmissions()
		{
			//TODO
			AddControl(new Button(144, 48, 160, 12, "CANCEL", ColorScheme.Aqua, Font.Normal, EndModal));
		}

		private void DisplayBasicRadarResults()
		{
			AddControl(new Border(48, 24, 208, 120, ColorScheme.Aqua, Backgrounds.Ufo, 13));
			AddControl(new Label(56, 48, ufo.Name, Font.Large, ColorScheme.Aqua));
			AddControl(new Label(72, 48, "Detected", Font.Normal, ColorScheme.Aqua));
			AddControl(new ExtendedLabel(82, 48, 82, "SIZE", Font.Normal, ColorScheme.Aqua));
			AddControl(new Label(82, 130, ufo.UfoType.Metadata().Size, Font.Normal, ColorScheme.Yellow));
			AddControl(new ExtendedLabel(90, 48, 82, "ALTITUDE", Font.Normal, ColorScheme.Aqua));
			AddControl(new Label(90, 130, ufo.Altitude, Font.Normal, ColorScheme.Yellow));
			AddControl(new ExtendedLabel(98, 48, 82, "HEADING", Font.Normal, ColorScheme.Aqua));
			AddControl(new Label(98, 130, ufo.Heading, Font.Normal, ColorScheme.Yellow));
			AddControl(new ExtendedLabel(106, 48, 82, "SPEED", Font.Normal, ColorScheme.Aqua));
			AddControl(new Label(106, 130, ((int)ufo.Speed).FormatNumber(), Font.Normal, ColorScheme.Yellow));
			AddControl(new Button(128, 48, 160, 12, "CENTER ON UFO-TIME=5 Secs", ColorScheme.Aqua, Font.Normal, OnOk));
			AddControl(new Button(144, 48, 160, 12, "CANCEL", ColorScheme.Aqua, Font.Normal, EndModal));
		}

		private void OnOk()
		{
			GameState.Current.Data.CenterOn(ufo.Location);
			Geoscape.ResetGameSpeed();
			EndModal();
		}
	}
}
