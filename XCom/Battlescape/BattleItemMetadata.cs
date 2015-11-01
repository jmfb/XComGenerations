using System.Collections.Generic;
using XCom.Battlescape.Tiles;

namespace XCom.Battlescape
{
	public interface BattleItemMetadata
	{
		string Name { get; }
		byte[] Image { get; }
		int Width { get; }
		int Height { get; }
		Dictionary<Direction, byte[]> Sprites { get; }
		bool IsTwoHanded { get; }
	}
}
