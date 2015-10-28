using System;
using System.Linq;

namespace XCom.Battlescape.Tiles
{
	public class TileTypes
	{
		private readonly TileType[] tileTypes;

		private TileTypes(params TileType[] tileTypes)
		{
			this.tileTypes = tileTypes;
		}

		public TileTypes(TileTypes value, TileTypes other)
		{
			tileTypes = value.tileTypes.Concat(other.tileTypes).ToArray();
		}

		public int PartCount => tileTypes.Sum(tileType => tileType.PartCount());

		public Tile CreateTile(TileData tile, int level)
		{
			var isGroundLevel = level == 0;
			var automaticallyInsertDirt = tile.Ground == 0 && isGroundLevel;
			const int dirtIndex = 1;
			var groundIndex = automaticallyInsertDirt ? dirtIndex : tile.Ground;
			return new Tile
			{
				Ground = CreatePart(groundIndex),
				WestWall = CreatePart(tile.WestWall),
				NorthWall = CreatePart(tile.NorthWall),
				Entity = CreatePart(tile.Entity)
			};
		}

		private Part CreatePart(int index)
		{
			foreach (var tileType in tileTypes)
			{
				if (index < tileType.PartCount())
					return new Part
					{
						TileType = tileType,
						Index = index
					};
				index -= tileType.PartCount();
			}
			throw new InvalidOperationException("Index out of bounds of parts in all tile types.");
		}

		public static readonly TileTypes Skyranger = new TileTypes(TileType.Skyranger);
		public static readonly TileTypes Lightning = new TileTypes(TileType.Lightning);
		public static readonly TileTypes Avenger = new TileTypes(TileType.Avenger);

		public static readonly TileTypes XcomBase = new TileTypes(TileType.Common, TileType.XcomBase, TileType.XcomFacilities);

		public static readonly TileTypes AlienBase = new TileTypes(
			TileType.Common,
			TileType.AlienBase,
			TileType.UfoComponents,
			TileType.UfoEquipment,
			TileType.Brain);

		public static readonly TileTypes UfoSmallScout = new TileTypes(TileType.UfoSmallScout);
		public static readonly TileTypes Ufo = new TileTypes(
			TileType.UfoExterior,
			TileType.UfoComponents,
			TileType.UfoBits);
		public static readonly TileTypes UfoWithOperatingTable = new TileTypes(
			TileType.UfoExterior,
			TileType.UfoComponents,
			TileType.UfoOperatingTable,
			TileType.UfoBits);
		public static readonly TileTypes UfoWithExaminationRoom = new TileTypes(
			TileType.UfoExterior,
			TileType.UfoComponents,
			TileType.UfoExaminationRoom,
			TileType.UfoBits);
		public static readonly TileTypes UfoWithEquipment = new TileTypes(
			TileType.UfoExterior,
			TileType.UfoComponents,
			TileType.UfoEquipment,
			TileType.UfoBits);

		public static readonly TileTypes City = new TileTypes(
			TileType.Common,
			TileType.Roads,
			TileType.CityBits,
			TileType.City,
			TileType.Furniture);

		public static readonly TileTypes Cultivation = new TileTypes(TileType.Common, TileType.Cultivation, TileType.Barn);
		public static readonly TileTypes Forest = new TileTypes(TileType.Common, TileType.Forest);
		public static readonly TileTypes Desert = new TileTypes(TileType.Common, TileType.Desert);
		public static readonly TileTypes Jungle = new TileTypes(TileType.Common, TileType.Jungle);
		public static readonly TileTypes Mountain = new TileTypes(TileType.Common, TileType.Mountain);
		public static readonly TileTypes Polar = new TileTypes(TileType.Common, TileType.Polar);

		public static readonly TileTypes Mars = new TileTypes(TileType.Common, TileType.Mars, TileType.UfoComponents);
	}
}
