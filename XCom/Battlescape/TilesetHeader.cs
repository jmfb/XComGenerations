using System.Runtime.InteropServices;

namespace XCom.Battlescape
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct TilesetHeader
	{
		public byte Height;
		public byte Width;
		public byte Depth;

		public int TileCount => Height * Width * Depth;
	}
}
