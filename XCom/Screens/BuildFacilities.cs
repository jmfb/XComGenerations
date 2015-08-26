using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Modals;

namespace XCom.Screens
{
	public class BuildFacilities : Screen
	{
		public BuildFacilities()
		{
			var data = GameState.Current.Data;
			var selectedBase = GameState.SelectedBase;
			AddControl(new Label(0, 193, selectedBase.Name, Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(16, 194, selectedBase.Area, Font.Normal, ColorScheme.Purple));
			AddControl(new DynamicLabel(24, 194, () => $"FUNDS> ${data.Funds.FormatNumber()}", Font.Normal, ColorScheme.Blue));
			AddControl(new Border(40, 192, 128, 160, ColorScheme.DarkYellow, Backgrounds.Research, 12));
			AddControl(new Label(48, 212, "Installation", Font.Large, ColorScheme.White));
			AddControl(new Button(176, 200, 112, 16, "OK", ColorScheme.DarkYellow, Font.Normal, OnOk));
			AddControl(new ListView<FacilityType>(64, 200, 13, data.AvailableFacilityTypes, ColorScheme.DarkYellow, Palette.GetPalette(12).GetColor(230), OnSelectFacilityType)
				.AddColumn(2, Alignment.Left, facilityType => "")
				.AddColumn(94, Alignment.Left, facilityType => facilityType.Metadata().Name));
			AddControl(new BaseFacilities(BaseFacilities.Mode.ViewFacilities, (row, column) => {}));
		}

		private void OnSelectFacilityType(FacilityType facilityType)
		{
			new BuildFacility(facilityType).DoModal(this);
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(new Base());
		}
	}
}
