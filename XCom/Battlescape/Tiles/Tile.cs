using System.Runtime.InteropServices;

namespace XCom.Battlescape.Tiles
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct Tile
	{
		public byte Ground;
		public byte WestWall;
		public byte NorthWall;
		public byte Entity;

		public static readonly Tile Empty = default(Tile);
	}
}
