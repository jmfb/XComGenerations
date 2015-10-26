using System;
using System.Linq;

namespace XCom.Battlescape.Tiles
{
	public class TileGroups
	{
		private readonly TileGroup[] groups;

		private TileGroups(params TileGroup[] groups)
		{
			this.groups = groups;
		}

		public int TileCount => groups.Sum(group => group.TileCount);

		public BattleLocation Create(Tile tile, int level)
		{
			var isGroundLevel = level == 0;
			var automaticallyInsertDirt = tile.Ground == 0 && isGroundLevel;
			const int dirtIndex = 1;
			var groundIndex = automaticallyInsertDirt ? dirtIndex : tile.Ground;
			return new BattleLocation(
				CreatePart(groundIndex),
				CreatePart(tile.WestWall),
				CreatePart(tile.NorthWall),
				CreatePart(tile.Entity));
		}

		private BattleLocationPart CreatePart(int index)
		{
			foreach (var group in groups)
			{
				if (index < group.TileCount)
					return new BattleLocationPart(group.PropertyPages[index], group.ImageGroup);
				index -= group.TileCount;
			}
			throw new InvalidOperationException("Index out of bounds of tile groups.");
		}

		public static readonly TileGroups Skyranger = new TileGroups(TileGroup.Common, TileGroup.Skyranger);
		public static readonly TileGroups Lightning = new TileGroups(TileGroup.Common, TileGroup.Lightning);
		public static readonly TileGroups Avenger = new TileGroups(TileGroup.Common, TileGroup.Avenger);

		public static readonly TileGroups XcomBase = new TileGroups(TileGroup.Common, TileGroup.XcomBase, TileGroup.XcomFacilities);

		public static readonly TileGroups AlienBase = new TileGroups(
			TileGroup.Common,
			TileGroup.AlienBase,
			TileGroup.UfoComponents,
			TileGroup.UfoEquipment,
			TileGroup.Brain);

		public static readonly TileGroups UfoSmallScout = new TileGroups(TileGroup.Common, TileGroup.UfoSmallScout);
		public static readonly TileGroups Ufo = new TileGroups(
			TileGroup.Common,
			TileGroup.UfoExterior,
			TileGroup.UfoComponents,
			TileGroup.UfoBits);
		public static readonly TileGroups UfoWithOperatingTable = new TileGroups(
			TileGroup.Common,
			TileGroup.UfoExterior,
			TileGroup.UfoComponents,
			TileGroup.UfoOperatingTable,
			TileGroup.UfoBits);
		public static readonly TileGroups UfoWithExaminationRoom = new TileGroups(
			TileGroup.Common,
			TileGroup.UfoExterior,
			TileGroup.UfoComponents,
			TileGroup.UfoExaminationRoom,
			TileGroup.UfoBits);
		public static readonly TileGroups UfoWithEquipment = new TileGroups(
			TileGroup.Common,
			TileGroup.UfoExterior,
			TileGroup.UfoComponents,
			TileGroup.UfoEquipment,
			TileGroup.UfoBits);

		public static readonly TileGroups City = new TileGroups(
			TileGroup.Common,
			TileGroup.Roads,
			TileGroup.CityBits,
			TileGroup.City,
			TileGroup.Furniture);

		public static readonly TileGroups Cultivation = new TileGroups(TileGroup.Common, TileGroup.Cultivation, TileGroup.Barn);
		public static readonly TileGroups Forest = new TileGroups(TileGroup.Common, TileGroup.Forest);
		public static readonly TileGroups Desert = new TileGroups(TileGroup.Common, TileGroup.Desert);
		public static readonly TileGroups Jungle = new TileGroups(TileGroup.Common, TileGroup.Jungle);
		public static readonly TileGroups Mountain = new TileGroups(TileGroup.Common, TileGroup.Mountain);
		public static readonly TileGroups Polar = new TileGroups(TileGroup.Common, TileGroup.Polar);

		public static readonly TileGroups Mars = new TileGroups(TileGroup.Common, TileGroup.Mars, TileGroup.UfoComponents);
	}
}
