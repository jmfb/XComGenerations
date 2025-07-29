using XCom.Graphics;

namespace XCom.Battlescape.Tiles;

public interface BaseSprite
{
	void Render(GraphicsBuffer buffer, int topRow, int leftColumn, BattleItem item);

	void Animate(GraphicsBuffer buffer, int topRow, int leftColumn, BattleItem item, int frame);

	public int FrameCount { get; }

	public static readonly Dictionary<Direction, BaseSprite>[] All = Sprite
		.All.Concat(SimpleSprite.All)
		.ToArray();
}
