using System.Diagnostics;
using XCom.Battlescape.Tiles;
using XCom.Graphics;

namespace XCom.Battlescape;

/// <summary>
/// Renders an animated arrow indicator above the selected soldier.
/// The indicator is drawn as if it exists in the level above the soldier's location.
/// </summary>
public class SoldierIndicator
{
	private readonly Stopwatch stopwatch = new();
	private const int ArrowHeight = 8;
	private const int ArrowWidth = 5;
	private const int AnimationRange = 6; // pixels to move up and down
	private const double AnimationSpeed = 2.0; // cycles per second

	public SoldierIndicator()
	{
		stopwatch.Start();
	}

	/// <summary>
	/// Checks if the indicator should be rendered at the specified location.
	/// </summary>
	/// <param name="levelIndex">Current level being rendered</param>
	/// <param name="row">Row in the level</param>
	/// <param name="column">Column in the level</param>
	/// <param name="selectedSoldier">The selected soldier</param>
	/// <returns>True if the indicator should be rendered here</returns>
	public bool ShouldRenderAt(int levelIndex, int row, int column, BattleSoldier selectedSoldier)
	{
		if (selectedSoldier == null)
			return false;

		// The indicator appears in the level above the soldier, at the same row/column
		return levelIndex == selectedSoldier.Location.Level + 1
			&& row == selectedSoldier.Location.Row
			&& column == selectedSoldier.Location.Column;
	}

	/// <summary>
	/// Renders the indicator at the specified screen coordinates.
	/// Should be called after Ground but before Entity/Unit rendering.
	/// </summary>
	/// <param name="buffer">Graphics buffer to render to</param>
	/// <param name="topRow">Top row of the tile</param>
	/// <param name="leftColumn">Left column of the tile</param>
	public void Render(GraphicsBuffer buffer, int topRow, int leftColumn)
	{
		// Calculate animated offset
		var elapsed = stopwatch.Elapsed.TotalSeconds;
		var animationOffset = (int)(Math.Sin(elapsed * AnimationSpeed * 2 * Math.PI) * AnimationRange / 2);
		
		// Position the arrow in the center of the tile, with animation
		var arrowTop = topRow + 8 + animationOffset; // Start 8 pixels down from tile top, add animation
		var arrowLeft = leftColumn + 16 - ArrowWidth / 2; // Center horizontally in the 32-pixel tile

		// Bounds check - only render if visible (using the same bounds as Level.Render)
		var bottom = arrowTop + ArrowHeight;
		var right = arrowLeft + ArrowWidth;
		if (bottom < 0 || right < 0 || arrowTop >= 144 || arrowLeft >= 320)
			return;

		DrawArrow(buffer, arrowTop, arrowLeft);
	}

	/// <summary>
	/// Renders the indicator when the level above the soldier is not being rendered.
	/// This should be called after all levels have been rendered.
	/// </summary>
	/// <param name="buffer">Graphics buffer to render to</param>
	/// <param name="map">The battlescape map</param>
	/// <param name="selectedSoldier">The currently selected soldier (can be null)</param>
	public void RenderAboveTopLevel(GraphicsBuffer buffer, Map map, BattleSoldier selectedSoldier)
	{
		if (selectedSoldier == null)
			return;

		// Only render if the soldier is in a level that is being rendered
		// and the level above the soldier is not being rendered
		if (selectedSoldier.Location.Level > map.SelectedLevelIndex)
			return;

		int indicatorLevel = selectedSoldier.Location.Level + 1;
		if (indicatorLevel <= map.SelectedLevelIndex)
			return; // This case is handled by the tile rendering

		// Calculate position as if we're rendering the level above the soldier
		var levelTopRow = -24 * indicatorLevel + map.RowOffset;
		var levelLeftColumn = map.ColumnOffset;
		
		var row = selectedSoldier.Location.Row;
		var column = selectedSoldier.Location.Column;
		var screenTop = levelTopRow + column * 8 + row * 8;
		var screenLeft = levelLeftColumn + column * 16 - row * 16;

		Render(buffer, screenTop, screenLeft);
	}

	private void DrawArrow(GraphicsBuffer buffer, int topRow, int leftColumn)
	{
		// Use authentic X-COM yellow color
		var palette = Palette.GetPalette(0);
		var arrowColor = palette.GetColor(46); // Yellow color from X-COM palette

		// Simple downward-pointing arrow pattern (5x8):
		//   *     (tip pointing down to soldier)
		//  ***
		// *****   (widest part)
		//  ***
		//   *     (shaft)
		//   *
		//   *
		//   *

		var arrowPattern = new bool[,]
		{
			{ false, false, true, false, false },  // Row 0: tip
			{ false, true, true, true, false },    // Row 1
			{ true, true, true, true, true },      // Row 2: widest
			{ false, true, true, true, false },    // Row 3
			{ false, false, true, false, false },  // Row 4: shaft
			{ false, false, true, false, false },  // Row 5: shaft
			{ false, false, true, false, false },  // Row 6: shaft
			{ false, false, true, false, false }   // Row 7: shaft
		};

		for (int row = 0; row < ArrowHeight; row++)
		{
			for (int col = 0; col < ArrowWidth; col++)
			{
				if (arrowPattern[row, col])
				{
					int pixelRow = topRow + row;
					int pixelCol = leftColumn + col;
					
					// Final bounds check for each pixel
					if (pixelRow >= 0 && pixelRow < 200 && pixelCol >= 0 && pixelCol < 320)
					{
						buffer.SetPixel(pixelRow, pixelCol, arrowColor);
					}
				}
			}
		}
	}
}
