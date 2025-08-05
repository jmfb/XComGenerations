using System.Drawing;

namespace XCom.Battlescape.Tiles;

public class MapLocation
{
	public int Level { get; set; }
	public int Row { get; set; }
	public int Column { get; set; }

	public static MapLocation FromPointerPosition(
		Point pointerPosition,
		int rowOffset,
		int columnOffset,
		int level,
		int mapRowCount,
		int mapColumnCount
	)
	{
		if (!IsPointInMapView(pointerPosition))
			return null;

		var (x, y) = AdjustForScrollAndLevel(pointerPosition, rowOffset, columnOffset, level);
		var (row, column) = GetMapCoordinates(x, y);
		if (!IsLocationInMap(row, column, mapRowCount, mapColumnCount))
			return null;

		return new MapLocation
		{
			Level = level,
			Row = row,
			Column = column,
		};
	}

	private static int MapViewWidth = 320;
	private static int MapViewHeight = 144;

	private static int RowsPerLevel = 24;
	private static int TileWidth = 32;
	private static int TileHeight = 40;

	private static int ColumnsPerUnit = TileWidth / 2;
	private static int GridUnitRatio = 2;
	private static int RowsPerUnit = ColumnsPerUnit / GridUnitRatio;

	private static int HoverRowOffset = -(TileHeight - 2 * RowsPerUnit) / 2;
	private static int HoverColumnOffset = -ColumnsPerUnit;

	private static bool IsPointInMapView(Point pointerPosition) =>
		pointerPosition.X >= 0
		&& pointerPosition.X < MapViewWidth
		&& pointerPosition.Y >= 0
		&& pointerPosition.Y < MapViewHeight;

	private static (int x, int y) AdjustForScrollAndLevel(
		Point pointerPosition,
		int rowOffset,
		int columnOffset,
		int level
	) =>
		(
			pointerPosition.X - columnOffset + HoverColumnOffset,
			pointerPosition.Y - rowOffset + RowsPerLevel * level + HoverRowOffset
		);

	private static (int hUnit, int hUnitOffset, int vUnit, int vUnitOffset) ToGridUnits(
		int x,
		int y
	) =>
		(
			(x < 0 ? (x - ColumnsPerUnit + 1) : x) / ColumnsPerUnit,
			((x % ColumnsPerUnit) + ColumnsPerUnit) % ColumnsPerUnit,
			(y < 0 ? (y - RowsPerUnit + 1) : y) / RowsPerUnit,
			((y % RowsPerUnit) + RowsPerUnit) % RowsPerUnit
		);

	private static (int row, int column) GetMapCoordinates(int x, int y)
	{
		var (hUnit, hUnitOffset, vUnit, vUnitOffset) = ToGridUnits(x, y);
		var isTopRightCorner = IsTopRightCorner(hUnitOffset, vUnitOffset);
		var isBottomRightCorner = IsBottomRightCorner(hUnitOffset, vUnitOffset);
		return (Math.Abs(hUnit) % 2) == (Math.Abs(vUnit) % 2)
			? GetEqualMapCoordinates(hUnit, vUnit, isTopRightCorner)
			: GetXorMapCoordinates(hUnit, vUnit, isBottomRightCorner);
	}

	private static bool IsTopRightCorner(int xOffset, int yOffset) =>
		yOffset <= (xOffset / GridUnitRatio);

	private static bool IsBottomRightCorner(int xOffset, int yOffset) =>
		(RowsPerUnit - yOffset - 1) <= (xOffset / GridUnitRatio);

	private static (int row, int column) GetEqualMapCoordinates(
		int hUnit,
		int vUnit,
		bool isTopRightCorner
	) => ((vUnit - hUnit) / 2 - (isTopRightCorner ? 1 : 0), (vUnit + hUnit) / 2);

	private static (int row, int column) GetXorMapCoordinates(
		int hUnit,
		int vUnit,
		bool isBottomRightCorner
	) => ((vUnit - hUnit - 1) / 2, (vUnit + hUnit - 1) / 2 + (isBottomRightCorner ? 1 : 0));

	private static bool IsLocationInMap(int row, int column, int mapRowCount, int mapColumnCount) =>
		row >= 0 && row < mapRowCount && column >= 0 && column < mapColumnCount;
}
