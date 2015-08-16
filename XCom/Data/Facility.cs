﻿namespace XCom.Data
{
	public class Facility
	{
		public FacilityType FacilityType { get; set; }
		public int Row { get; set; }
		public int Column { get; set; }
		public int DaysUntilConstructionComplete { get; set; }

		public bool IsAt(int row, int column, bool allowUnderConstruction)
		{
			if (!allowUnderConstruction && DaysUntilConstructionComplete > 0)
				return false;
			var size = FacilityType.Metadata().Shape.Size();
			return row >= Row &&
				row < (Row + size) &&
				column >= Column &&
				column < (Column + size);
		}
	}
}
