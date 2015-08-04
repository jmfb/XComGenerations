using XCom.Controls;
using XCom.Data;

namespace XCom.Screens
{
	public class PlaceAccessLift : Screen
	{
		public PlaceAccessLift()
		{
			AddControl(new BaseFacilities(BaseFacilities.Mode.PlaceAccessLift, OnPlaceAccessLift));
		}

		private static void OnPlaceAccessLift(int row, int column)
		{
			GameState.SelectedBase.Facilities.Add(new Facility
			{
				 FacilityType = FacilityType.AccessLift,
				 DaysUntilConstructionComplete = 0,
				 Row = row,
				 Column = column
			});
			GameState.Current.SetScreen(new Base());
		}
	}
}
