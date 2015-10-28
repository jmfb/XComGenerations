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

		public TileData Merge(TileData tile, int partOffset)
		{
			var result = this;
			if (tile.Ground != 0)
				result.Ground = (byte)(tile.Ground + partOffset - 2);
			if (tile.NorthWall != 0)
				result.NorthWall = (byte)(tile.NorthWall + partOffset - 2);
			if (tile.WestWall != 0)
				result.WestWall = (byte)(tile.WestWall + partOffset - 2);
			if (tile.Entity != 0)
				result.Entity = (byte)(tile.Entity + partOffset - 2);
			return result;
		}
	}
}
