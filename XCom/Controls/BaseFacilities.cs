using System;
using System.Globalization;
using System.Linq;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls
{
	public class BaseFacilities : InteractiveControl
	{
		public enum Mode
		{
			PlaceAccessLift,
			ViewFacilities,
			BuildFacility
		}

		private readonly Mode mode;
		private readonly Action<int, int> action;
		private static readonly Image horizontalBridge = new Image(Content.Images.Base.Base.BridgeHorizontal);
		private static readonly Image verticalBridge = new Image(Content.Images.Base.Base.BridgeVertical);

		public BaseFacilities(Mode mode, Action<int, int> action)
		{
			this.mode = mode;
			this.action = action;
		}

		public override bool HitTest(int row, int column)
		{
			return row >= 8 &&
				row < GraphicsBuffer.GameHeight &&
				column >= 0 &&
				column < 192;
		}

		public override void OnLeftButtonDown(int row, int column)
		{
			var baseRow = (row - 8) / 32;
			var baseColumn = column / 32;
			//If BuildFacility, enabled, check size constraints, then invoke action
			action(baseRow, baseColumn);
		}

		public override void Render(GraphicsBuffer buffer)
		{
			RenderBackground(buffer);
			if (mode == Mode.PlaceAccessLift)
			{
				Font.Normal.DrawString(buffer, 0, 10, "SELECT POSITION FOR ACCESS LIFT", ColorScheme.Blue);
				return;
			}

			RenderFacilities(buffer);
			//TODO: Hit Test for facility under cursor to draw name
			//TODO: If build facility && enabled, draw focus rect/frame
		}

		private static void RenderBackground(GraphicsBuffer buffer)
		{
			var backgroundImage = new Image(Content.Images.Base.Base.Background);
			foreach (var row in Enumerable.Range(0, 6))
				foreach (var column in Enumerable.Range(0, 6))
					backgroundImage.Render(buffer, row * 32 + 8, column * 32);
		}

		private static void RenderFacilities(GraphicsBuffer buffer)
		{
			var selectedBase = GameState.SelectedBase;
			foreach (var facility in selectedBase.Facilities)
				RenderBuilding(buffer, facility);
			foreach (var facility in selectedBase.Facilities)
				RenderBridges(buffer, facility);
			foreach (var facility in selectedBase.Facilities)
				RenderFacility(buffer, facility);
			RenderCrafts(buffer);
		}

		private static void RenderCrafts(GraphicsBuffer buffer)
		{
			var selectedBase = GameState.SelectedBase;
			var crafts = selectedBase.Crafts.Where(craft => craft.Status != CraftStatus.Out).ToList();
			var hangars = selectedBase.Facilities.Where(facility => facility.FacilityType == FacilityType.Hangar).ToList();
			foreach (var craftAndHangar in hangars.Zip(crafts, (hangar, craft) => new {Hangar = hangar, Craft = craft}))
				RenderCraft(buffer, craftAndHangar.Hangar, craftAndHangar.Craft);
		}

		private static void RenderBuilding(GraphicsBuffer buffer, Facility facility)
		{
			var topRow = facility.Row * 32 + 9;
			var leftColumn = facility.Column * 32 + 1;
			var metadata = facility.FacilityType.Metadata();

			if (facility.DaysUntilConstructionComplete > 0)
				metadata.Shape.ConstructionImage().Render(buffer, topRow, leftColumn);
			else if (metadata.Shape == FacilityShape.Hangar)
				metadata.Image.Render(buffer, topRow, leftColumn);
			else
				metadata.Shape.BuildingImage().Render(buffer, topRow, leftColumn);
		}

		private static void RenderBridges(GraphicsBuffer buffer, Facility facility)
		{
			if (facility.DaysUntilConstructionComplete > 0)
				return;
			if (facility.FacilityType == FacilityType.Hangar)
				RenderHangarBridges(buffer, facility);
			else
				RenderBuildingBridges(buffer, facility);
		}

		private static void RenderHangarBridges(GraphicsBuffer buffer, Facility facility)
		{
			var topRow = facility.Row * 32 + 8;
			var leftColumn = facility.Column * 32;
			if (IsFacilityAt(facility.Row + 2, facility.Column, false))
				verticalBridge.Render(buffer, topRow + 32 + 29, leftColumn + 12);
			if (IsFacilityAt(facility.Row + 2, facility.Column + 1, false))
				verticalBridge.Render(buffer, topRow + 32 + 29, leftColumn + 32 + 12);
			if (IsFacilityAt(facility.Row, facility.Column + 2, false))
				horizontalBridge.Render(buffer, topRow + 12, leftColumn + 32 + 29);
			if (IsFacilityAt(facility.Row + 1, facility.Column + 2, false))
				horizontalBridge.Render(buffer, topRow + 32 + 12, leftColumn + 32 + 29);
		}

		private static void RenderBuildingBridges(GraphicsBuffer buffer, Facility facility)
		{
			var topRow = facility.Row * 32 + 8;
			var leftColumn = facility.Column * 32;
			if (IsFacilityAt(facility.Row + 1, facility.Column, false))
				verticalBridge.Render(buffer, topRow + 29, leftColumn + 12);
			if (IsFacilityAt(facility.Row, facility.Column + 1, false))
				horizontalBridge.Render(buffer, topRow + 12, leftColumn + 29);
		}

		private static void RenderFacility(GraphicsBuffer buffer, Facility facility)
		{
			var topRow = facility.Row * 32 + 8;
			var leftColumn = facility.Column * 32;

			var metadata = facility.FacilityType.Metadata();
			if (metadata.Shape != FacilityShape.Hangar)
				metadata.Image.Render(buffer, topRow + metadata.RowOffset, leftColumn + metadata.ColumnOffset);

			if (facility.DaysUntilConstructionComplete == 0)
				return;

			var daysRemaining = facility.DaysUntilConstructionComplete.ToString(CultureInfo.InvariantCulture);
			var size = metadata.Shape.Size() * 32;
			var textTopRow = topRow + (size - Font.Large.Height) / 2;
			var textLeftColumn = leftColumn + (size - Font.Large.MeasureString(daysRemaining)) / 2;
			Font.Large.DrawString(buffer, textTopRow, textLeftColumn, daysRemaining, ColorScheme.Yellow);
		}

		private static void RenderCraft(GraphicsBuffer buffer, Facility hangar, Craft craft)
		{
			var metadata = craft.CraftType.Metadata();
			var topRow = hangar.Row * 32 + 8 + metadata.RowOffset;
			var leftColumn = hangar.Column * 32 + metadata.ColumnOffset;
			metadata.Image.Render(buffer, topRow, leftColumn);
		}

		private static bool IsFacilityAt(int row, int column, bool allowUnderConstruction)
		{
			return FindFacilityAt(row, column, allowUnderConstruction) != null;
		}

		private static Facility FindFacilityAt(int row, int column, bool allowUnderConstruction)
		{
			return GameState.SelectedBase.Facilities.FirstOrDefault(facility =>
				FacilityIsAt(facility, row, column, allowUnderConstruction));
		}

		private static bool FacilityIsAt(Facility facility, int row, int column, bool allowUnderConstruction)
		{
			if (!allowUnderConstruction && facility.DaysUntilConstructionComplete > 0)
				return false;
			var size = facility.FacilityType.Metadata().Shape.Size();
			return row >= facility.Row &&
				row < (facility.Row + size) &&
				column >= facility.Column &&
				column < (facility.Column + size);
		}
	}
}
