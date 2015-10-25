using System.Runtime.InteropServices;

namespace XCom.Battlescape
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct Tile
	{
		public byte Ground;
		public byte WestWall;
		public byte NorthWall;
		public byte Entity;
	}
}
