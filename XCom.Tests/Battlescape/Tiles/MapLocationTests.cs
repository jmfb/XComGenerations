using System.Drawing;
using XCom.Battlescape.Tiles;

namespace XCom.Tests.Battlescape.Tiles;

public class MapLocationTests
{
	[Theory]
	[InlineData(-1, 10)]
	[InlineData(320, 10)]
	[InlineData(10, -1)]
	[InlineData(10, 144)]
	public void FromPointerPosition_OutsideMapView(int x, int y)
	{
		var result = MapLocation.FromPointerPosition(new Point(x, y), 0, 0, 0, 4, 4);
		Assert.Null(result);
	}

	[Theory]
	[InlineData(14, 11)]
	[InlineData(15, 11)]
	[InlineData(13, 12)]
	[InlineData(11, 13)]
	[InlineData(9, 14)]
	public void FromPointerPosition_OutsideMapLocation(int x, int y)
	{
		var result = MapLocation.FromPointerPosition(new Point(x, y), 0, 0, 0, 4, 4);
		Assert.Null(result);
	}

	[Theory]
	[InlineData(14, 12)]
	[InlineData(15, 12)]
	[InlineData(12, 13)]
	[InlineData(13, 13)]
	[InlineData(14, 13)]
	[InlineData(15, 13)]
	[InlineData(10, 14)]
	[InlineData(11, 14)]
	[InlineData(12, 14)]
	[InlineData(13, 14)]
	[InlineData(14, 14)]
	[InlineData(15, 14)]
	public void FromPointerPosition_FirstSquareQuadrant1(int x, int y)
	{
		var result = MapLocation.FromPointerPosition(new Point(x, y), 0, 0, 0, 4, 4);
		Assert.NotNull(result);
		Assert.Equal(0, result.Level);
		Assert.Equal(0, result.Row);
		Assert.Equal(0, result.Column);
	}
}
