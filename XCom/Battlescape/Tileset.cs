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

		public static readonly Tileset XcomBase0 = new Tileset(Tilesets.XcomBase0, TileGroups.XcomBase);
		public static readonly Tileset XcomBase1 = new Tileset(Tilesets.XcomBase1, TileGroups.XcomBase);
		public static readonly Tileset XcomBase2 = new Tileset(Tilesets.XcomBase2, TileGroups.XcomBase);
		public static readonly Tileset XcomBase3 = new Tileset(Tilesets.XcomBase3, TileGroups.XcomBase);
		public static readonly Tileset XcomBase4 = new Tileset(Tilesets.XcomBase4, TileGroups.XcomBase);
		public static readonly Tileset XcomBase5 = new Tileset(Tilesets.XcomBase5, TileGroups.XcomBase);
		public static readonly Tileset XcomBase6 = new Tileset(Tilesets.XcomBase6, TileGroups.XcomBase);
		public static readonly Tileset XcomBase7 = new Tileset(Tilesets.XcomBase7, TileGroups.XcomBase);
		public static readonly Tileset XcomBase8 = new Tileset(Tilesets.XcomBase8, TileGroups.XcomBase);
		public static readonly Tileset XcomBase9 = new Tileset(Tilesets.XcomBase9, TileGroups.XcomBase);
		public static readonly Tileset XcomBase10 = new Tileset(Tilesets.XcomBase10, TileGroups.XcomBase);
		public static readonly Tileset XcomBase11 = new Tileset(Tilesets.XcomBase11, TileGroups.XcomBase);
		public static readonly Tileset XcomBase12 = new Tileset(Tilesets.XcomBase12, TileGroups.XcomBase);
		public static readonly Tileset XcomBase13 = new Tileset(Tilesets.XcomBase13, TileGroups.XcomBase);
		public static readonly Tileset XcomBase14 = new Tileset(Tilesets.XcomBase14, TileGroups.XcomBase);
		public static readonly Tileset XcomBase15 = new Tileset(Tilesets.XcomBase15, TileGroups.XcomBase);
		public static readonly Tileset XcomBase16 = new Tileset(Tilesets.XcomBase16, TileGroups.XcomBase);
		public static readonly Tileset XcomBase17 = new Tileset(Tilesets.XcomBase17, TileGroups.XcomBase);
		public static readonly Tileset XcomBase18 = new Tileset(Tilesets.XcomBase18, TileGroups.XcomBase);
		public static readonly Tileset XcomBase19 = new Tileset(Tilesets.XcomBase19, TileGroups.XcomBase);
		public static readonly Tileset XcomBase20 = new Tileset(Tilesets.XcomBase20, TileGroups.XcomBase);

		public static readonly Tileset City0 = new Tileset(Tilesets.City0, TileGroups.City);
		public static readonly Tileset City1 = new Tileset(Tilesets.City1, TileGroups.City);
		public static readonly Tileset City2 = new Tileset(Tilesets.City2, TileGroups.City);
		public static readonly Tileset City3 = new Tileset(Tilesets.City3, TileGroups.City);
		public static readonly Tileset City4 = new Tileset(Tilesets.City4, TileGroups.City);
		public static readonly Tileset City5 = new Tileset(Tilesets.City5, TileGroups.City);
		public static readonly Tileset City6 = new Tileset(Tilesets.City6, TileGroups.City);
		public static readonly Tileset City7 = new Tileset(Tilesets.City7, TileGroups.City);
		public static readonly Tileset City8 = new Tileset(Tilesets.City8, TileGroups.City);
		public static readonly Tileset City9 = new Tileset(Tilesets.City9, TileGroups.City);
		public static readonly Tileset City10 = new Tileset(Tilesets.City10, TileGroups.City);
		public static readonly Tileset City11 = new Tileset(Tilesets.City11, TileGroups.City);
		public static readonly Tileset City12 = new Tileset(Tilesets.City12, TileGroups.City);
		public static readonly Tileset City13 = new Tileset(Tilesets.City13, TileGroups.City);
		public static readonly Tileset City14 = new Tileset(Tilesets.City14, TileGroups.City);

		public static readonly Tileset Cultivation0 = new Tileset(Tilesets.Cultivation0, TileGroups.Cultivation);
		public static readonly Tileset Cultivation1 = new Tileset(Tilesets.Cultivation1, TileGroups.Cultivation);
		public static readonly Tileset Cultivation2 = new Tileset(Tilesets.Cultivation2, TileGroups.Cultivation);
		public static readonly Tileset Cultivation3 = new Tileset(Tilesets.Cultivation3, TileGroups.Cultivation);
		public static readonly Tileset Cultivation4 = new Tileset(Tilesets.Cultivation4, TileGroups.Cultivation);
		public static readonly Tileset Cultivation5 = new Tileset(Tilesets.Cultivation5, TileGroups.Cultivation);
		public static readonly Tileset Cultivation6 = new Tileset(Tilesets.Cultivation6, TileGroups.Cultivation);
		public static readonly Tileset Cultivation7 = new Tileset(Tilesets.Cultivation7, TileGroups.Cultivation);
		public static readonly Tileset Cultivation8 = new Tileset(Tilesets.Cultivation8, TileGroups.Cultivation);
		public static readonly Tileset Cultivation9 = new Tileset(Tilesets.Cultivation9, TileGroups.Cultivation);
		public static readonly Tileset Cultivation10 = new Tileset(Tilesets.Cultivation10, TileGroups.Cultivation);
		public static readonly Tileset Cultivation11 = new Tileset(Tilesets.Cultivation11, TileGroups.Cultivation);
		public static readonly Tileset Cultivation12 = new Tileset(Tilesets.Cultivation12, TileGroups.Cultivation);
		public static readonly Tileset Cultivation13 = new Tileset(Tilesets.Cultivation13, TileGroups.Cultivation);
		public static readonly Tileset Cultivation14 = new Tileset(Tilesets.Cultivation14, TileGroups.Cultivation);
		public static readonly Tileset Cultivation15 = new Tileset(Tilesets.Cultivation15, TileGroups.Cultivation);
		public static readonly Tileset Cultivation16 = new Tileset(Tilesets.Cultivation16, TileGroups.Cultivation);
		public static readonly Tileset Cultivation17 = new Tileset(Tilesets.Cultivation17, TileGroups.Cultivation);
		public static readonly Tileset Cultivation18 = new Tileset(Tilesets.Cultivation18, TileGroups.Cultivation);

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

		public static readonly Tileset Mars0 = new Tileset(Tilesets.Mars0, TileGroups.Mars);
		public static readonly Tileset Mars1 = new Tileset(Tilesets.Mars1, TileGroups.Mars);
		public static readonly Tileset Mars2 = new Tileset(Tilesets.Mars2, TileGroups.Mars);
		public static readonly Tileset Mars3 = new Tileset(Tilesets.Mars3, TileGroups.Mars);
		public static readonly Tileset Mars4 = new Tileset(Tilesets.Mars4, TileGroups.Mars);
		public static readonly Tileset Mars5 = new Tileset(Tilesets.Mars5, TileGroups.Mars);
		public static readonly Tileset Mars6 = new Tileset(Tilesets.Mars6, TileGroups.Mars);
		public static readonly Tileset Mars7 = new Tileset(Tilesets.Mars7, TileGroups.Mars);
		public static readonly Tileset Mars8 = new Tileset(Tilesets.Mars8, TileGroups.Mars);
		public static readonly Tileset Mars9 = new Tileset(Tilesets.Mars9, TileGroups.Mars);
		public static readonly Tileset Mars10 = new Tileset(Tilesets.Mars10, TileGroups.Mars);
	}
}
