using System.Runtime.InteropServices;

namespace XCom.Battlescape.Tiles
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct TileData
	{
		public byte Ground;
		public byte WestWall;
		public byte NorthWall;
		public byte Entity;

		public static readonly TileData Empty = default(TileData);

		public TileData SetNorthWall(byte value)
		{
			var result = this;
			result.NorthWall = value;
			return result;
		}

		public TileData SetWestWall(byte value)
		{
			var result = this;
			result.WestWall = value;
			return result;
		}

		public TileData SetEntity(byte value)
		{
			var result = this;
			result.Entity = value;
			return result;
		}
	}
}
