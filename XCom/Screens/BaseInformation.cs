using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class BaseInformation : Screen
	{
		public BaseInformation()
		{
			AddControl(new Background(Backgrounds.InfoBase, 4));
			AddControl(new ClickToEdit(8, 8, 137, GameState.SelectedBase.Name, Font.Large, ColorScheme.LightMagenta, OnEditBaseName));
			AddControl(new BaseSelect(8, 182, OnSelectBase));
			CreateRows();
			AddControl(new Button(180, 10, 30, 14, "OK", ColorScheme.Purple, Font.Normal, OnOk));
			AddControl(new Button(180, 46, 80, 14, "TRANSFERS", ColorScheme.Purple, Font.Normal, OnTransfers));
			AddControl(new Button(180, 132, 80, 14, "STORES", ColorScheme.Purple, Font.Normal, OnStores));
			AddControl(new Button(180, 218, 92, 14, "Monthly Costs", ColorScheme.Purple, Font.Normal, OnMonthlyCosts));
		}

		private static void OnEditBaseName(string name)
		{
			GameState.SelectedBase.Name = name;
		}

		private static void OnSelectBase()
		{
			GameState.Current.SetScreen(new BaseInformation());
		}

		private void CreateRows()
		{
			CreatePersonnelRows();
			CreateFacilityRows();
			CreateDefenceStrengthRow();
			CreateRadarRows();
		}

		private void CreatePersonnelRows()
		{
			AddControl(new Label(30, 8, "PERSONNEL AVAILABLE:PERSONNEL TOTAL>", Font.Normal, ColorScheme.LightMagenta));
			CreateSoldiersRow();
			CreateEngineersRow();
			CreateScientistsRow();
		}

		private void CreateSoldiersRow()
		{
			var selectedBase = GameState.SelectedBase;
			var total = selectedBase.Soldiers.Count;
			var used = selectedBase.Crafts.Sum(craft => craft.SoldierIds.Count);
			var available = total - used;
			AddControl(new BaseInformationRow(41, "Soldiers", 16, 10, 10, available, total, true));
		}

		private void CreateEngineersRow()
		{
			var selectedBase = GameState.SelectedBase;
			var total = selectedBase.EngineerCount;
			var available = total; //TODO
			AddControl(new BaseInformationRow(51, "Engineers", 16, 10, 10, available, total, true));
		}

		private void CreateScientistsRow()
		{
			var selectedBase = GameState.SelectedBase;
			var total = selectedBase.ScientistCount;
			var available = selectedBase.GetScientistsAvailable();
			AddControl(new BaseInformationRow(61, "Scientists", 16, 10, 10, available, total, true));
		}

		private void CreateFacilityRows()
		{
			AddControl(new Label(72, 8, "SPACE USED:SPACE AVAILABLE>", Font.Normal, ColorScheme.LightMagenta));
			CreateLivingQuartersRow();
			CreateStoresRow();
			CreateLaboratoriesRow();
			CreateWorkShopsRow();
			CreateHangarsRow();
		}

		private void CreateLivingQuartersRow()
		{
			var selectedBase = GameState.SelectedBase;
			var total = selectedBase.CountFacilities(FacilityType.LivingQuarters) * 50;
			var used = selectedBase.Soldiers.Count + selectedBase.EngineerCount + selectedBase.ScientistCount;
			AddControl(new BaseInformationRow(83, "Living Quarters", 48, 25, 50, used, total, true));
		}

		private void CreateStoresRow()
		{
			var selectedBase = GameState.SelectedBase;
			var total = selectedBase.CountFacilities(FacilityType.GeneralStores) * 50;
			var used = 0; //TODO:
			AddControl(new BaseInformationRow(93, "Stores", 48, 25, 50, used, total, true));
		}

		private void CreateLaboratoriesRow()
		{
			var selectedBase = GameState.SelectedBase;
			var total = selectedBase.GetTotalLaboratorySpace();
			var used = selectedBase.GetScientistsAllocated();
			AddControl(new BaseInformationRow(103, "Laboratories", 48, 25, 50, used, total, true));
		}

		private void CreateWorkShopsRow()
		{
			var selectedBase = GameState.SelectedBase;
			var total = selectedBase.CountFacilities(FacilityType.Workshop) * 50;
			var used = 0; //TODO:
			AddControl(new BaseInformationRow(113, "Work Shops", 48, 25, 50, used, total, true));
		}

		private void CreateHangarsRow()
		{
			var selectedBase = GameState.SelectedBase;
			var total = selectedBase.CountFacilities(FacilityType.Hangar);
			var used = selectedBase.Crafts.Count;
			AddControl(new BaseInformationRow(123, "Hangars", 48, 18, 1, used, total, true));
		}

		private void CreateDefenceStrengthRow()
		{
			var selectedBase = GameState.SelectedBase;
			var total =
				selectedBase.CountFacilities(FacilityType.MissileDefences) * 500 +
				selectedBase.CountFacilities(FacilityType.LaserDefences) * 600 +
				selectedBase.CountFacilities(FacilityType.PlasmaDefences) * 900 +
				selectedBase.CountFacilities(FacilityType.FusionBallDefences) * 1200;
			AddControl(new BaseInformationRow(138, "Defence Strength", 32, 1, 60, total, total, false));
		}

		private void CreateRadarRows()
		{
			CreateShortRangeDetectionRow();
			CreateLongRangeDetectionRow();
		}

		private void CreateShortRangeDetectionRow()
		{
			var total = GameState.SelectedBase.CountFacilities(FacilityType.SmallRadarSystem);
			AddControl(new BaseInformationRow(153, "Short Range Detection", 128, 25, 1, total, total, false));
		}

		private void CreateLongRangeDetectionRow()
		{
			var selectedBase = GameState.SelectedBase;
			var total =
				selectedBase.CountFacilities(FacilityType.LargeRadarSystem) +
				selectedBase.CountFacilities(FacilityType.HyperWaveDecoder);
			AddControl(new BaseInformationRow(163, "Long Range Detection", 128, 25, 1, total, total, false));
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(new Base());
		}

		private static void OnTransfers()
		{
			//TODO:
		}

		private static void OnStores()
		{
			//TODO:
		}

		private static void OnMonthlyCosts()
		{
			GameState.Current.SetScreen(new MonthlyCosts());
		}
	}
}
