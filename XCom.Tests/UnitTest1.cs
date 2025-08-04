using XCom.Battlescape.Tiles;

namespace XCom.Tests;

public class UnitTest1
{
    [Fact]
    public void MapLocation_Properties_ShouldSetCorrectly()
    {
        // Arrange
        var level = 1;
        var row = 5;
        var column = 10;

        // Act
        var location = new MapLocation
        {
            Level = level,
            Row = row,
            Column = column
        };

        // Assert
        Assert.Equal(level, location.Level);
        Assert.Equal(row, location.Row);
        Assert.Equal(column, location.Column);
    }

    [Fact]
    public void DummyTest_ShouldAlwaysPass()
    {
        // Arrange & Act
        var result = 2 + 2;

        // Assert
        Assert.Equal(4, result);
    }
}
