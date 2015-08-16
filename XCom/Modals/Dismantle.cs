using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class Dismantle : Screen
	{
		private readonly Facility facility;

		public Dismantle(Facility facility)
		{
			this.facility = facility;
			AddControl(new Border(60, 20, 152, 80, ColorScheme.LightMagenta, Backgrounds.Funds, 9));
			AddControl(new Label(75, Label.CenterOf(20, 152), "Dismantle", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(85, Label.CenterOf(20, 152), facility.FacilityType.Metadata().Name, Font.Normal, ColorScheme.Blue));
			AddControl(new Button(115, 36, 44, 16, "OK", ColorScheme.Purple, Font.Normal, OnOk));
			AddControl(new Button(115, 112, 44, 16, "CANCEL", ColorScheme.Purple, Font.Normal, EndModal));
		}

		private void OnOk()
		{
			var selectedBase = GameState.SelectedBase;
			selectedBase.Facilities.Remove(facility);
			if (selectedBase.Facilities.Count == 0)
			{
				GameState.Current.Data.Bases.Remove(selectedBase);
				GameState.Current.Data.SelectedBase = 0;
			}
			EndModal();
		}
	}
}
