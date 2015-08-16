using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class BuildFacility : Screen
	{
		private readonly FacilityType facilityType;

		public BuildFacility(FacilityType facilityType)
		{
			this.facilityType = facilityType;
			var metadata = facilityType.Metadata();

			AddControl(new Border(40, 192, 128, 160, ColorScheme.Blue, Backgrounds.Title, 12));
			AddControl(new Label(50, 202, metadata.Name, Font.Normal, ColorScheme.Blue));
			AddControl(new Label(62, 202, "COST>", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(70, 202, metadata.Cost.FormatNumber(), Font.Large, ColorScheme.White));
			AddControl(new Label(90, 202, "CONSTRUCTION TIME>", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(98, 202, metadata.DaysToConstruct.FormatNumber() + " days", Font.Large, ColorScheme.White));
			AddControl(new Label(118, 202, "MAINTENANCE>", Font.Normal, ColorScheme.Blue));
			AddControl(new Label(126, 202, metadata.Maintenance.FormatNumber(), Font.Large, ColorScheme.White));
			AddControl(new Button(176, 200, 112, 16, "Cancel", ColorScheme.Blue, Font.Normal, OnCancel));
			AddControl(new BaseFacilities(facilityType, OnClickFacility));
		}

		private void OnClickFacility(int row, int column)
		{
			var metadata = facilityType.Metadata();
			if (metadata.Cost > GameState.Current.Data.Funds)
			{
				new NotEnoughMoney(ColorScheme.Blue, Backgrounds.Title).DoModal(this);
				return;
			}

			if (!IsConnectedToAccessLift(row, column, metadata.Shape.Size()))
			{
				new CannotBuildHere().DoModal(this);
				return;
			}

			GameState.Current.Data.Funds -= metadata.Cost;
			GameState.SelectedBase.Facilities.Add(new Facility
			{
				FacilityType = facilityType,
				Row = row,
				Column = column,
				DaysUntilConstructionComplete = metadata.DaysToConstruct
			});
			EndModal();
		}

		private static bool IsConnectedToAccessLift(int row, int column, int size)
		{
			foreach (var index in Enumerable.Range(0, size))
			{
				if (IsValidConstructedFacility(row - 1, column + index) ||
					IsValidConstructedFacility(row + size, column + index) ||
					IsValidConstructedFacility(row + index, column - 1) ||
					IsValidConstructedFacility(row + index, column + size))
					return true;
			}
			return false;
		}

		private static bool IsValidConstructedFacility(int row, int column)
		{
			const bool allowUnderConstruction = false;
			return GameState.SelectedBase.FindFacilityAt(row, column, allowUnderConstruction) != null;
		}

		private void OnCancel()
		{
			EndModal();
		}
	}
}
