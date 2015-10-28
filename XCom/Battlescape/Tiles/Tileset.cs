using System.Linq;
using System.Runtime.InteropServices;
using XCom.Content.Maps.Tilesets;

namespace XCom.Battlescape.Tiles
{
	public class Tileset
	{
		private readonly TilesetHeader header;
		private readonly TileData[] tiles;
		private readonly TileTypes types;

		public Tileset()
		{
		}

		private Tileset(byte[] data, TileTypes types)
		{
			header = data.ReadStruct<TilesetHeader>(0);
			tiles = Enumerable.Range(0, header.TileCount)
				.Select(index => Marshal.SizeOf(header) + index * Marshal.SizeOf(typeof(TileData)))
				.Select(data.ReadStruct<TileData>)
				.ToArray();
			this.types = types;
		}

		public Tileset(Tileset value)
		{
			header = value.header;
			tiles = value.tiles.ToArray();
			types = value.types;
		}

		public Tileset(Tileset value, Tileset other)
		{
			header = value.header;
			header.Depth = (byte)other.LevelCount;
			tiles = Enumerable.Repeat(TileData.Empty, (other.LevelCount - 1) * header.TilesPerLevel).Concat(value.tiles).ToArray();
			types = new TileTypes(value.types, other.types);
		}

		public Tile CreateTile(int level, int row, int column)
		{
			if (level >= LevelCount)
				return types.CreateTile(TileData.Empty, level);
			var invertedLevel = LevelCount - level - 1;
			return types.CreateTile(GetTile(invertedLevel, row, column), level);
		}

		public int RowCount => header.Height;
		public int ColumnCount => header.Width;
		public int LevelCount => header.Depth;
		public int PartCount => types.PartCount;

		private int GetTileIndex(int invertedLevel, int row, int column) => invertedLevel * header.TilesPerLevel + row * header.TilesPerRow + column;
		private TileData GetTile(int invertedLevel, int row, int column) => tiles[GetTileIndex(invertedLevel, row, column)];
		private void SetTile(int invertedLevel, int row, int column, TileData tile) => tiles[GetTileIndex(invertedLevel, row, column)] = tile;

		public TileData this[int level, int row, int column]
		{
			get { return GetTile(LevelCount - level - 1, row, column); }
			set { SetTile(LevelCount - level - 1, row, column, value); }
		}

		public static readonly Tileset Skyranger = new Tileset(Tilesets.Skyranger, TileTypes.Skyranger);
		public static readonly Tileset Lightning = new Tileset(Tilesets.Lightning, TileTypes.Lightning);
		public static readonly Tileset Avenger = new Tileset(Tilesets.Avenger, TileTypes.Avenger);

		public static readonly Tileset XcomBase0 = new Tileset(Tilesets.XcomBase0, TileTypes.XcomBase);
		public static readonly Tileset XcomBase1 = new Tileset(Tilesets.XcomBase1, TileTypes.XcomBase);
		public static readonly Tileset XcomBase2 = new Tileset(Tilesets.XcomBase2, TileTypes.XcomBase);
		public static readonly Tileset XcomBase3 = new Tileset(Tilesets.XcomBase3, TileTypes.XcomBase);
		public static readonly Tileset XcomBase4 = new Tileset(Tilesets.XcomBase4, TileTypes.XcomBase);
		public static readonly Tileset XcomBase5 = new Tileset(Tilesets.XcomBase5, TileTypes.XcomBase);
		public static readonly Tileset XcomBase6 = new Tileset(Tilesets.XcomBase6, TileTypes.XcomBase);
		public static readonly Tileset XcomBase7 = new Tileset(Tilesets.XcomBase7, TileTypes.XcomBase);
		public static readonly Tileset XcomBase8 = new Tileset(Tilesets.XcomBase8, TileTypes.XcomBase);
		public static readonly Tileset XcomBase9 = new Tileset(Tilesets.XcomBase9, TileTypes.XcomBase);
		public static readonly Tileset XcomBase10 = new Tileset(Tilesets.XcomBase10, TileTypes.XcomBase);
		public static readonly Tileset XcomBase11 = new Tileset(Tilesets.XcomBase11, TileTypes.XcomBase);
		public static readonly Tileset XcomBase12 = new Tileset(Tilesets.XcomBase12, TileTypes.XcomBase);
		public static readonly Tileset XcomBase13 = new Tileset(Tilesets.XcomBase13, TileTypes.XcomBase);
		public static readonly Tileset XcomBase14 = new Tileset(Tilesets.XcomBase14, TileTypes.XcomBase);
		public static readonly Tileset XcomBase15 = new Tileset(Tilesets.XcomBase15, TileTypes.XcomBase);
		public static readonly Tileset XcomBase16 = new Tileset(Tilesets.XcomBase16, TileTypes.XcomBase);
		public static readonly Tileset XcomBase17 = new Tileset(Tilesets.XcomBase17, TileTypes.XcomBase);
		public static readonly Tileset XcomBase18 = new Tileset(Tilesets.XcomBase18, TileTypes.XcomBase);
		public static readonly Tileset XcomBase19 = new Tileset(Tilesets.XcomBase19, TileTypes.XcomBase);
		public static readonly Tileset XcomBase20 = new Tileset(Tilesets.XcomBase20, TileTypes.XcomBase);

		public static readonly Tileset AlienBase0 = new Tileset(Tilesets.AlienBase0, TileTypes.AlienBase);
		public static readonly Tileset AlienBase1 = new Tileset(Tilesets.AlienBase1, TileTypes.AlienBase);
		public static readonly Tileset AlienBase2 = new Tileset(Tilesets.AlienBase2, TileTypes.AlienBase);
		public static readonly Tileset AlienBase3 = new Tileset(Tilesets.AlienBase3, TileTypes.AlienBase);
		public static readonly Tileset AlienBase4 = new Tileset(Tilesets.AlienBase4, TileTypes.AlienBase);
		public static readonly Tileset AlienBase5 = new Tileset(Tilesets.AlienBase5, TileTypes.AlienBase);
		public static readonly Tileset AlienBase6 = new Tileset(Tilesets.AlienBase6, TileTypes.AlienBase);
		public static readonly Tileset AlienBase7 = new Tileset(Tilesets.AlienBase7, TileTypes.AlienBase);
		public static readonly Tileset AlienBase8 = new Tileset(Tilesets.AlienBase8, TileTypes.AlienBase);
		public static readonly Tileset AlienBase9 = new Tileset(Tilesets.AlienBase9, TileTypes.AlienBase);
		public static readonly Tileset AlienBase10 = new Tileset(Tilesets.AlienBase10, TileTypes.AlienBase);
		public static readonly Tileset AlienBase11 = new Tileset(Tilesets.AlienBase11, TileTypes.AlienBase);
		public static readonly Tileset AlienBase12 = new Tileset(Tilesets.AlienBase12, TileTypes.AlienBase);
		public static readonly Tileset AlienBase13 = new Tileset(Tilesets.AlienBase13, TileTypes.AlienBase);
		public static readonly Tileset AlienBase14 = new Tileset(Tilesets.AlienBase14, TileTypes.AlienBase);
		public static readonly Tileset AlienBase15 = new Tileset(Tilesets.AlienBase15, TileTypes.AlienBase);

		public static readonly Tileset SmallScout = new Tileset(Tilesets.SmallScout, TileTypes.UfoSmallScout);
		public static readonly Tileset MediumScout = new Tileset(Tilesets.MediumScout, TileTypes.Ufo);
		public static readonly Tileset LargeScout = new Tileset(Tilesets.LargeScout, TileTypes.Ufo);
		public static readonly Tileset Abductor = new Tileset(Tilesets.Abductor, TileTypes.UfoWithOperatingTable);
		public static readonly Tileset Harvester = new Tileset(Tilesets.Harvester, TileTypes.UfoWithExaminationRoom);
		public static readonly Tileset TerrorShip = new Tileset(Tilesets.TerrorShip, TileTypes.UfoWithEquipment);
		public static readonly Tileset Battleship = new Tileset(Tilesets.Battleship, TileTypes.UfoWithEquipment);
		public static readonly Tileset SupplyShip = new Tileset(Tilesets.SupplyShip, TileTypes.UfoWithExaminationRoom);

		public static readonly Tileset City0 = new Tileset(Tilesets.City0, TileTypes.City);
		public static readonly Tileset City1 = new Tileset(Tilesets.City1, TileTypes.City);
		public static readonly Tileset City2 = new Tileset(Tilesets.City2, TileTypes.City);
		public static readonly Tileset City3 = new Tileset(Tilesets.City3, TileTypes.City);
		public static readonly Tileset City4 = new Tileset(Tilesets.City4, TileTypes.City);
		public static readonly Tileset City5 = new Tileset(Tilesets.City5, TileTypes.City);
		public static readonly Tileset City6 = new Tileset(Tilesets.City6, TileTypes.City);
		public static readonly Tileset City7 = new Tileset(Tilesets.City7, TileTypes.City);
		public static readonly Tileset City8 = new Tileset(Tilesets.City8, TileTypes.City);
		public static readonly Tileset City9 = new Tileset(Tilesets.City9, TileTypes.City);
		public static readonly Tileset City10 = new Tileset(Tilesets.City10, TileTypes.City);
		public static readonly Tileset City11 = new Tileset(Tilesets.City11, TileTypes.City);
		public static readonly Tileset City12 = new Tileset(Tilesets.City12, TileTypes.City);
		public static readonly Tileset City13 = new Tileset(Tilesets.City13, TileTypes.City);
		public static readonly Tileset City14 = new Tileset(Tilesets.City14, TileTypes.City);

		public static readonly Tileset Cultivation0 = new Tileset(Tilesets.Cultivation0, TileTypes.Cultivation);
		public static readonly Tileset Cultivation1 = new Tileset(Tilesets.Cultivation1, TileTypes.Cultivation);
		public static readonly Tileset Cultivation2 = new Tileset(Tilesets.Cultivation2, TileTypes.Cultivation);
		public static readonly Tileset Cultivation3 = new Tileset(Tilesets.Cultivation3, TileTypes.Cultivation);
		public static readonly Tileset Cultivation4 = new Tileset(Tilesets.Cultivation4, TileTypes.Cultivation);
		public static readonly Tileset Cultivation5 = new Tileset(Tilesets.Cultivation5, TileTypes.Cultivation);
		public static readonly Tileset Cultivation6 = new Tileset(Tilesets.Cultivation6, TileTypes.Cultivation);
		public static readonly Tileset Cultivation7 = new Tileset(Tilesets.Cultivation7, TileTypes.Cultivation);
		public static readonly Tileset Cultivation8 = new Tileset(Tilesets.Cultivation8, TileTypes.Cultivation);
		public static readonly Tileset Cultivation9 = new Tileset(Tilesets.Cultivation9, TileTypes.Cultivation);
		public static readonly Tileset Cultivation10 = new Tileset(Tilesets.Cultivation10, TileTypes.Cultivation);
		public static readonly Tileset Cultivation11 = new Tileset(Tilesets.Cultivation11, TileTypes.Cultivation);
		public static readonly Tileset Cultivation12 = new Tileset(Tilesets.Cultivation12, TileTypes.Cultivation);
		public static readonly Tileset Cultivation13 = new Tileset(Tilesets.Cultivation13, TileTypes.Cultivation);
		public static readonly Tileset Cultivation14 = new Tileset(Tilesets.Cultivation14, TileTypes.Cultivation);
		public static readonly Tileset Cultivation15 = new Tileset(Tilesets.Cultivation15, TileTypes.Cultivation);
		public static readonly Tileset Cultivation16 = new Tileset(Tilesets.Cultivation16, TileTypes.Cultivation);
		public static readonly Tileset Cultivation17 = new Tileset(Tilesets.Cultivation17, TileTypes.Cultivation);
		public static readonly Tileset Cultivation18 = new Tileset(Tilesets.Cultivation18, TileTypes.Cultivation);

		public static readonly Tileset Forest0 = new Tileset(Tilesets.Forest0, TileTypes.Forest);
		public static readonly Tileset Forest1 = new Tileset(Tilesets.Forest1, TileTypes.Forest);
		public static readonly Tileset Forest2 = new Tileset(Tilesets.Forest2, TileTypes.Forest);
		public static readonly Tileset Forest3 = new Tileset(Tilesets.Forest3, TileTypes.Forest);
		public static readonly Tileset Forest4 = new Tileset(Tilesets.Forest4, TileTypes.Forest);
		public static readonly Tileset Forest5 = new Tileset(Tilesets.Forest5, TileTypes.Forest);
		public static readonly Tileset Forest6 = new Tileset(Tilesets.Forest6, TileTypes.Forest);
		public static readonly Tileset Forest7 = new Tileset(Tilesets.Forest7, TileTypes.Forest);
		public static readonly Tileset Forest8 = new Tileset(Tilesets.Forest8, TileTypes.Forest);
		public static readonly Tileset Forest9 = new Tileset(Tilesets.Forest9, TileTypes.Forest);
		public static readonly Tileset Forest10 = new Tileset(Tilesets.Forest10, TileTypes.Forest);
		public static readonly Tileset Forest11 = new Tileset(Tilesets.Forest11, TileTypes.Forest);

		public static readonly Tileset Desert0 = new Tileset(Tilesets.Desert0, TileTypes.Desert);
		public static readonly Tileset Desert1 = new Tileset(Tilesets.Desert1, TileTypes.Desert);
		public static readonly Tileset Desert2 = new Tileset(Tilesets.Desert2, TileTypes.Desert);
		public static readonly Tileset Desert3 = new Tileset(Tilesets.Desert3, TileTypes.Desert);
		public static readonly Tileset Desert4 = new Tileset(Tilesets.Desert4, TileTypes.Desert);
		public static readonly Tileset Desert5 = new Tileset(Tilesets.Desert5, TileTypes.Desert);
		public static readonly Tileset Desert6 = new Tileset(Tilesets.Desert6, TileTypes.Desert);
		public static readonly Tileset Desert7 = new Tileset(Tilesets.Desert7, TileTypes.Desert);
		public static readonly Tileset Desert8 = new Tileset(Tilesets.Desert8, TileTypes.Desert);
		public static readonly Tileset Desert9 = new Tileset(Tilesets.Desert9, TileTypes.Desert);
		public static readonly Tileset Desert10 = new Tileset(Tilesets.Desert10, TileTypes.Desert);
		public static readonly Tileset Desert11 = new Tileset(Tilesets.Desert11, TileTypes.Desert);

		public static readonly Tileset Jungle0 = new Tileset(Tilesets.Jungle0, TileTypes.Jungle);
		public static readonly Tileset Jungle1 = new Tileset(Tilesets.Jungle1, TileTypes.Jungle);
		public static readonly Tileset Jungle2 = new Tileset(Tilesets.Jungle2, TileTypes.Jungle);
		public static readonly Tileset Jungle3 = new Tileset(Tilesets.Jungle3, TileTypes.Jungle);
		public static readonly Tileset Jungle4 = new Tileset(Tilesets.Jungle4, TileTypes.Jungle);
		public static readonly Tileset Jungle5 = new Tileset(Tilesets.Jungle5, TileTypes.Jungle);
		public static readonly Tileset Jungle6 = new Tileset(Tilesets.Jungle6, TileTypes.Jungle);
		public static readonly Tileset Jungle7 = new Tileset(Tilesets.Jungle7, TileTypes.Jungle);
		public static readonly Tileset Jungle8 = new Tileset(Tilesets.Jungle8, TileTypes.Jungle);
		public static readonly Tileset Jungle9 = new Tileset(Tilesets.Jungle9, TileTypes.Jungle);
		public static readonly Tileset Jungle10 = new Tileset(Tilesets.Jungle10, TileTypes.Jungle);
		public static readonly Tileset Jungle11 = new Tileset(Tilesets.Jungle11, TileTypes.Jungle);

		public static readonly Tileset Mountain0 = new Tileset(Tilesets.Mountain0, TileTypes.Mountain);
		public static readonly Tileset Mountain1 = new Tileset(Tilesets.Mountain1, TileTypes.Mountain);
		public static readonly Tileset Mountain2 = new Tileset(Tilesets.Mountain2, TileTypes.Mountain);
		public static readonly Tileset Mountain3 = new Tileset(Tilesets.Mountain3, TileTypes.Mountain);
		public static readonly Tileset Mountain4 = new Tileset(Tilesets.Mountain4, TileTypes.Mountain);
		public static readonly Tileset Mountain5 = new Tileset(Tilesets.Mountain5, TileTypes.Mountain);
		public static readonly Tileset Mountain6 = new Tileset(Tilesets.Mountain6, TileTypes.Mountain);
		public static readonly Tileset Mountain7 = new Tileset(Tilesets.Mountain7, TileTypes.Mountain);
		public static readonly Tileset Mountain8 = new Tileset(Tilesets.Mountain8, TileTypes.Mountain);
		public static readonly Tileset Mountain9 = new Tileset(Tilesets.Mountain9, TileTypes.Mountain);
		public static readonly Tileset Mountain10 = new Tileset(Tilesets.Mountain10, TileTypes.Mountain);
		public static readonly Tileset Mountain11 = new Tileset(Tilesets.Mountain11, TileTypes.Mountain);
		public static readonly Tileset Mountain12 = new Tileset(Tilesets.Mountain12, TileTypes.Mountain);

		public static readonly Tileset Polar0 = new Tileset(Tilesets.Polar0, TileTypes.Polar);
		public static readonly Tileset Polar1 = new Tileset(Tilesets.Polar1, TileTypes.Polar);
		public static readonly Tileset Polar2 = new Tileset(Tilesets.Polar2, TileTypes.Polar);
		public static readonly Tileset Polar3 = new Tileset(Tilesets.Polar3, TileTypes.Polar);
		public static readonly Tileset Polar4 = new Tileset(Tilesets.Polar4, TileTypes.Polar);
		public static readonly Tileset Polar5 = new Tileset(Tilesets.Polar5, TileTypes.Polar);
		public static readonly Tileset Polar6 = new Tileset(Tilesets.Polar6, TileTypes.Polar);
		public static readonly Tileset Polar7 = new Tileset(Tilesets.Polar7, TileTypes.Polar);
		public static readonly Tileset Polar8 = new Tileset(Tilesets.Polar8, TileTypes.Polar);
		public static readonly Tileset Polar9 = new Tileset(Tilesets.Polar9, TileTypes.Polar);
		public static readonly Tileset Polar10 = new Tileset(Tilesets.Polar10, TileTypes.Polar);
		public static readonly Tileset Polar11 = new Tileset(Tilesets.Polar11, TileTypes.Polar);
		public static readonly Tileset Polar12 = new Tileset(Tilesets.Polar12, TileTypes.Polar);
		public static readonly Tileset Polar13 = new Tileset(Tilesets.Polar13, TileTypes.Polar);

		public static readonly Tileset Mars0 = new Tileset(Tilesets.Mars0, TileTypes.Mars);
		public static readonly Tileset Mars1 = new Tileset(Tilesets.Mars1, TileTypes.Mars);
		public static readonly Tileset Mars2 = new Tileset(Tilesets.Mars2, TileTypes.Mars);
		public static readonly Tileset Mars3 = new Tileset(Tilesets.Mars3, TileTypes.Mars);
		public static readonly Tileset Mars4 = new Tileset(Tilesets.Mars4, TileTypes.Mars);
		public static readonly Tileset Mars5 = new Tileset(Tilesets.Mars5, TileTypes.Mars);
		public static readonly Tileset Mars6 = new Tileset(Tilesets.Mars6, TileTypes.Mars);
		public static readonly Tileset Mars7 = new Tileset(Tilesets.Mars7, TileTypes.Mars);
		public static readonly Tileset Mars8 = new Tileset(Tilesets.Mars8, TileTypes.Mars);
		public static readonly Tileset Mars9 = new Tileset(Tilesets.Mars9, TileTypes.Mars);
		public static readonly Tileset Mars10 = new Tileset(Tilesets.Mars10, TileTypes.Mars);
	}
}
