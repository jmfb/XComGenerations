using System;
using XCom.Graphics;

namespace XCom.Data
{
	public enum FacilityShape
	{
		Square,
		Octagon,
		Cross,
		Hangar
	}

	public static class FacilityShapeExtensions
	{
		public static Image ConstructionImage(this FacilityShape shape)
		{
			switch (shape)
			{
			case FacilityShape.Square:
				return squareConstruction;
			case FacilityShape.Octagon:
				return octagonConstruction;
			case FacilityShape.Cross:
				return crossConstruction;
			case FacilityShape.Hangar:
				return hangarConstruction;
			}
			throw new InvalidOperationException("Invalid shape for construction image.");
		}

		public static Image BuildingImage(this FacilityShape shape)
		{
			switch (shape)
			{
			case FacilityShape.Square:
				return squareBuilding;
			case FacilityShape.Octagon:
				return octagonBuilding;
			case FacilityShape.Cross:
				return crossBuilding;
			}
			throw new InvalidOperationException("Invalid shape for building image.");
		}

		public static int Size(this FacilityShape shape)
		{
			return shape == FacilityShape.Hangar ? 2 : 1;
		}

		private static readonly Image squareConstruction = new Image(Content.Images.Base.Base.ConstructionSquare);
		private static readonly Image octagonConstruction = new Image(Content.Images.Base.Base.ConstructionOctagon);
		private static readonly Image crossConstruction = new Image(Content.Images.Base.Base.ConstructionCross);
		private static readonly Image hangarConstruction = new Image(Content.Images.Base.Base.ConstructionHangar);

		private static readonly Image squareBuilding = new Image(Content.Images.Base.Base.Square);
		private static readonly Image octagonBuilding = new Image(Content.Images.Base.Base.Octagon);
		private static readonly Image crossBuilding = new Image(Content.Images.Base.Base.Cross);
	}
}
