using System;
using System.Drawing;
using System.Linq;
using XCom.Content.Images.BasePreview;
using XCom.Data;
using XCom.Graphics;
using Image = XCom.Graphics.Image;

namespace XCom.Controls
{
	public class BaseSelect : InteractiveControl
	{
		private readonly int topRow;
		private readonly int leftColumn;
		private readonly Action action;

		private static readonly Image preview = new Image(BasePreview.Background);
		private static readonly Image facility1x1 = new Image(BasePreview.Facility1x1);
		private static readonly Image facility2x2 = new Image(BasePreview.Facility2x2);
		private static readonly Image construction1x1 = new Image(BasePreview.Construction1x1);
		private static readonly Image construction2x2 = new Image(BasePreview.Construction2x2);

		public BaseSelect(int topRow, int leftColumn, Action action)
		{
			this.topRow = topRow;
			this.leftColumn = leftColumn;
			this.action = action;
		}

		public override bool HitTest(int row, int column)
		{
			return row >= topRow &&
				row < (topRow + 16) &&
				column >= leftColumn &&
				column < (leftColumn + 128);
		}

		public override void OnMouseMove(int row, int column, bool leftButton, bool rightButton)
		{
			if (leftButton)
				OnLeftButtonDown(row, column);
		}

		public override void OnLeftButtonDown(int row, int column)
		{
			var newBaseIndex = (column - leftColumn) / 16;
			if (newBaseIndex == GameState.Current.Data.SelectedBase ||
				newBaseIndex < 0 ||
				newBaseIndex >= GameState.Current.Data.Bases.Count)
				return;
			GameState.Current.Data.SelectedBase = newBaseIndex;
			action();
		}

		public override void Render(GraphicsBuffer buffer)
		{
			foreach (var index in Enumerable.Range(0, 8))
			{
				var baseLeftColumn = leftColumn + index * 16;
				preview.Render(buffer, topRow + 1, baseLeftColumn + 1);
				if (index == GameState.Current.Data.SelectedBase)
					buffer.DrawFrame(topRow, baseLeftColumn, 16, 16, Color.White);
				if (index >= GameState.Current.Data.Bases.Count)
					continue;
				foreach (var facility in GameState.Current.Data.Bases[index].Facilities)
				{
					var facilityTopRow = topRow + 2 + facility.Row * 2;
					var facilityLeftColumn = baseLeftColumn + 2 + facility.Column * 2;
					var image = GetFacilityPreviewImage(facility);
					image.Render(buffer, facilityTopRow, facilityLeftColumn);
				}
			}
		}

		private static Image GetFacilityPreviewImage(Facility facility)
		{
			var size = facility.FacilityType.Metadata().Shape.Size();
			if (facility.DaysUntilConstructionComplete > 0)
				return size == 1 ? construction1x1 : construction2x2;
			return size == 1 ? facility1x1 : facility2x2;
		}
	}
}
