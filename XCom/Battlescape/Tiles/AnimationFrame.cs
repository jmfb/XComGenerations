namespace XCom.Battlescape.Tiles;

public static class AnimationFrame
{
	private static readonly Stopwatch stopwatch = Stopwatch.StartNew();

	public static int GetCurrent(int frameCount) =>
		(int)((stopwatch.ElapsedMilliseconds / 100) % frameCount);
}
