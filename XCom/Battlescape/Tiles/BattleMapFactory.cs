using System.Collections.Generic;
using System.Linq;
using XCom.Data;

namespace XCom.Battlescape.Tiles
{
	public static class BattleMapFactory
	{
		//TODO: Construct alien base
		//TODO: Construct terror mission
		//TODO: Construct ship recovery (landing and crash)
		//TODO: Construct cydonia mission (mars and final base)

		public static BattleMap CreateXcomBaseMap(Base @base)
		{
			var tilesets = CreateXcomBaseTilesets(@base);
			var levels = CreateXcomBaseLevels(tilesets);
			return new BattleMap { Levels = levels };
		}

		private static Tileset[,] CreateXcomBaseTilesets(Base @base)
		{
			var tilesets = CreateEmptyXcomBaseTilesets();
			var completedFacilities = @base.Facilities
				.Where(facility => facility.DaysUntilConstructionComplete == 0)
				.ToList();
			FillFacilityTilesets(tilesets, completedFacilities);
			SetFacilityConnectors(tilesets);
			return tilesets;
		}

		private static Tileset[,] CreateEmptyXcomBaseTilesets()
		{
			var tilesets = new Tileset[6, 6];
			var emptyTileset = Tileset.XcomBase20;
			foreach (var row in Enumerable.Range(0, 6))
				foreach (var column in Enumerable.Range(0, 6))
					tilesets[row, column] = emptyTileset;
			return tilesets;
		}

		private static void FillFacilityTilesets(Tileset[,] tilesets, IEnumerable<Facility> facilities)
		{
			foreach (var facility in facilities)
				FillFacilityTilesets(tilesets, facility);
		}

		private static void FillFacilityTilesets(Tileset[,] tilesets, Facility facility)
		{
			var metadata = facility.FacilityType.Metadata();
			tilesets[facility.Row, facility.Column] = metadata.Tilesets[0];
			if (metadata.Shape != FacilityShape.Hangar)
				return;
			tilesets[facility.Row, facility.Column + 1] = metadata.Tilesets[1];
			tilesets[facility.Row + 1, facility.Column] = metadata.Tilesets[2];
			tilesets[facility.Row + 1, facility.Column + 1] = metadata.Tilesets[3];
		}

		private static void SetFacilityConnectors(Tileset[,] tilesets)
		{
			var facilityConnectors = new FacilityConnectors[6, 6];
			foreach (var row in Enumerable.Range(0, 6))
				foreach (var column in Enumerable.Range(0, 6))
					facilityConnectors[row, column] = new FacilityConnectors(tilesets, row, column);
			foreach (var row in Enumerable.Range(0, 6))
				foreach (var column in Enumerable.Range(0, 6))
					tilesets[row, column] = facilityConnectors[row, column].UpdateTileset(tilesets[row, column]);
		}

		private static BattleLevel[] CreateXcomBaseLevels(Tileset[,] tilesets)
		{
			return Enumerable.Range(0, 2)
				.Select(levelIndex => CreateXcomBaseLevel(tilesets, levelIndex))
				.ToArray();
		}

		private static BattleLevel CreateXcomBaseLevel(Tileset[,] tilesets, int levelIndex)
		{
			var battleLevel = new BattleLevel
			{
				Locations = new BattleLocation[60, 60]
			};
			foreach (var row in Enumerable.Range(0, 6))
				foreach (var column in Enumerable.Range(0, 6))
					battleLevel.LoadTileset(tilesets[row, column], levelIndex, row * 10, column * 10);
			return battleLevel;
		}
	}
}
