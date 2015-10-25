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

		public static readonly Tileset Skyranger = new Tileset(Tilesets.Skyranger, TileGroups.Skyranger);
		public static readonly Tileset Lightning = new Tileset(Tilesets.Lightning, TileGroups.Lightning);
		public static readonly Tileset Avenger = new Tileset(Tilesets.Avenger, TileGroups.Avenger);

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

		public static readonly Tileset Desert0 = new Tileset(Tilesets.Desert0, TileGroups.Desert);
		public static readonly Tileset Desert1 = new Tileset(Tilesets.Desert1, TileGroups.Desert);
		public static readonly Tileset Desert2 = new Tileset(Tilesets.Desert2, TileGroups.Desert);
		public static readonly Tileset Desert3 = new Tileset(Tilesets.Desert3, TileGroups.Desert);
		public static readonly Tileset Desert4 = new Tileset(Tilesets.Desert4, TileGroups.Desert);
		public static readonly Tileset Desert5 = new Tileset(Tilesets.Desert5, TileGroups.Desert);
		public static readonly Tileset Desert6 = new Tileset(Tilesets.Desert6, TileGroups.Desert);
		public static readonly Tileset Desert7 = new Tileset(Tilesets.Desert7, TileGroups.Desert);
		public static readonly Tileset Desert8 = new Tileset(Tilesets.Desert8, TileGroups.Desert);
		public static readonly Tileset Desert9 = new Tileset(Tilesets.Desert9, TileGroups.Desert);
		public static readonly Tileset Desert10 = new Tileset(Tilesets.Desert10, TileGroups.Desert);
		public static readonly Tileset Desert11 = new Tileset(Tilesets.Desert11, TileGroups.Desert);

		public static readonly Tileset Jungle0 = new Tileset(Tilesets.Jungle0, TileGroups.Jungle);
		public static readonly Tileset Jungle1 = new Tileset(Tilesets.Jungle1, TileGroups.Jungle);
		public static readonly Tileset Jungle2 = new Tileset(Tilesets.Jungle2, TileGroups.Jungle);
		public static readonly Tileset Jungle3 = new Tileset(Tilesets.Jungle3, TileGroups.Jungle);
		public static readonly Tileset Jungle4 = new Tileset(Tilesets.Jungle4, TileGroups.Jungle);
		public static readonly Tileset Jungle5 = new Tileset(Tilesets.Jungle5, TileGroups.Jungle);
		public static readonly Tileset Jungle6 = new Tileset(Tilesets.Jungle6, TileGroups.Jungle);
		public static readonly Tileset Jungle7 = new Tileset(Tilesets.Jungle7, TileGroups.Jungle);
		public static readonly Tileset Jungle8 = new Tileset(Tilesets.Jungle8, TileGroups.Jungle);
		public static readonly Tileset Jungle9 = new Tileset(Tilesets.Jungle9, TileGroups.Jungle);
		public static readonly Tileset Jungle10 = new Tileset(Tilesets.Jungle10, TileGroups.Jungle);
		public static readonly Tileset Jungle11 = new Tileset(Tilesets.Jungle11, TileGroups.Jungle);

		public static readonly Tileset Mountain0 = new Tileset(Tilesets.Mountain0, TileGroups.Mountain);
		public static readonly Tileset Mountain1 = new Tileset(Tilesets.Mountain1, TileGroups.Mountain);
		public static readonly Tileset Mountain2 = new Tileset(Tilesets.Mountain2, TileGroups.Mountain);
		public static readonly Tileset Mountain3 = new Tileset(Tilesets.Mountain3, TileGroups.Mountain);
		public static readonly Tileset Mountain4 = new Tileset(Tilesets.Mountain4, TileGroups.Mountain);
		public static readonly Tileset Mountain5 = new Tileset(Tilesets.Mountain5, TileGroups.Mountain);
		public static readonly Tileset Mountain6 = new Tileset(Tilesets.Mountain6, TileGroups.Mountain);
		public static readonly Tileset Mountain7 = new Tileset(Tilesets.Mountain7, TileGroups.Mountain);
		public static readonly Tileset Mountain8 = new Tileset(Tilesets.Mountain8, TileGroups.Mountain);
		public static readonly Tileset Mountain9 = new Tileset(Tilesets.Mountain9, TileGroups.Mountain);
		public static readonly Tileset Mountain10 = new Tileset(Tilesets.Mountain10, TileGroups.Mountain);
		public static readonly Tileset Mountain11 = new Tileset(Tilesets.Mountain11, TileGroups.Mountain);
		public static readonly Tileset Mountain12 = new Tileset(Tilesets.Mountain12, TileGroups.Mountain);

		public static readonly Tileset Polar0 = new Tileset(Tilesets.Polar0, TileGroups.Polar);
		public static readonly Tileset Polar1 = new Tileset(Tilesets.Polar1, TileGroups.Polar);
		public static readonly Tileset Polar2 = new Tileset(Tilesets.Polar2, TileGroups.Polar);
		public static readonly Tileset Polar3 = new Tileset(Tilesets.Polar3, TileGroups.Polar);
		public static readonly Tileset Polar4 = new Tileset(Tilesets.Polar4, TileGroups.Polar);
		public static readonly Tileset Polar5 = new Tileset(Tilesets.Polar5, TileGroups.Polar);
		public static readonly Tileset Polar6 = new Tileset(Tilesets.Polar6, TileGroups.Polar);
		public static readonly Tileset Polar7 = new Tileset(Tilesets.Polar7, TileGroups.Polar);
		public static readonly Tileset Polar8 = new Tileset(Tilesets.Polar8, TileGroups.Polar);
		public static readonly Tileset Polar9 = new Tileset(Tilesets.Polar9, TileGroups.Polar);
		public static readonly Tileset Polar10 = new Tileset(Tilesets.Polar10, TileGroups.Polar);
		public static readonly Tileset Polar11 = new Tileset(Tilesets.Polar11, TileGroups.Polar);
		public static readonly Tileset Polar12 = new Tileset(Tilesets.Polar12, TileGroups.Polar);
		public static readonly Tileset Polar13 = new Tileset(Tilesets.Polar13, TileGroups.Polar);
	}
}
