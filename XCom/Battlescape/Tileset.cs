using System;
using System.Linq;
using System.Runtime.InteropServices;
using XCom.Content.Maps.TilePropertyPages;
using XCom.Content.Maps.Tilesets;

namespace XCom.Battlescape
{
	public class Tileset
	{
		private readonly TilesetHeader header;
		private readonly Tile[] tiles;
		private readonly TileGroups groups;

		public Tileset(byte[] data, TileGroups groups)
		{
			header = data.ReadStruct<TilesetHeader>(0);
			tiles = Enumerable.Range(0, header.TileCount)
				.Select(index => Marshal.SizeOf(header) + index * Marshal.SizeOf(typeof(Tile)))
				.Select(data.ReadStruct<Tile>)
				.ToArray();
			this.groups = groups;
		}

		public BattleLocation CreateBattleLocation(int level, int row, int column)
		{
			if (level >= LevelCount)
				return groups.Create(Tile.Empty, level);
			var invertedLevel = LevelCount - level - 1;
			return groups.Create(GetTile(invertedLevel, row, column), level);
		}

		public int RowCount => header.Height;
		public int ColumnCount => header.Width;
		private int LevelCount => header.Depth;
		private Tile GetTile(int invertedLevel, int row, int column) => tiles[invertedLevel * header.TilesPerLevel + row * header.TilesPerRow + column];

		public static readonly Tileset Forest0 = new Tileset(Tilesets.Forest0, TileGroups.Forest);
		public static readonly Tileset Forest1 = new Tileset(Tilesets.Forest1, TileGroups.Forest);
		public static readonly Tileset Forest2 = new Tileset(Tilesets.Forest2, TileGroups.Forest);
		public static readonly Tileset Forest3 = new Tileset(Tilesets.Forest3, TileGroups.Forest);
		public static readonly Tileset Forest4 = new Tileset(Tilesets.Forest4, TileGroups.Forest);
		public static readonly Tileset Forest5 = new Tileset(Tilesets.Forest5, TileGroups.Forest);
		public static readonly Tileset Forest6 = new Tileset(Tilesets.Forest6, TileGroups.Forest);
		public static readonly Tileset Forest7 = new Tileset(Tilesets.Forest7, TileGroups.Forest);
		public static readonly Tileset Forest8 = new Tileset(Tilesets.Forest8, TileGroups.Forest);
		public static readonly Tileset Forest9 = new Tileset(Tilesets.Forest9, TileGroups.Forest);
		public static readonly Tileset Forest10 = new Tileset(Tilesets.Forest10, TileGroups.Forest);
		public static readonly Tileset Forest11 = new Tileset(Tilesets.Forest11, TileGroups.Forest);
	}
}
