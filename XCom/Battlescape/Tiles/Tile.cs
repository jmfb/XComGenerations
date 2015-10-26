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

		public Tile SetNorthWall(byte value)
		{
			var result = this;
			result.NorthWall = value;
			return result;
		}

		public Tile SetWestWall(byte value)
		{
			var result = this;
			result.WestWall = value;
			return result;
		}

		public Tile SetEntity(byte value)
		{
			var result = this;
			result.Entity = value;
			return result;
		}
	}
}
