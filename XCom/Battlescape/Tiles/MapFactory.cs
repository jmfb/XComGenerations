using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using XCom.Data;
using XCom.World;

namespace XCom.Battlescape.Tiles
{
	public static class MapFactory
	{
		private static readonly Tileset placeholder = new Tileset();
		private static readonly TerrainCategoryMetadata cityMetadata = new TerrainCategoryMetadata
		{
			FlatTilesets = new[] { Tileset.City3, Tileset.City4 },
			OtherTilesets = new[]
			{
				Tileset.City5,
				Tileset.City6,
				Tileset.City7,
				Tileset.City8,
				Tileset.City9,
				Tileset.City10,
				Tileset.City11,
				Tileset.City12,
				Tileset.City13,
				Tileset.City14
			}
		};
		private static readonly TerrainCategoryMetadata marsMetadata = new TerrainCategoryMetadata
		{
			FlatTilesets = new[] { Tileset.Mars0 },
			OtherTilesets = new[]
			{
				Tileset.Mars1,
				Tileset.Mars2,
				Tileset.Mars3,
				Tileset.Mars4,
				Tileset.Mars5,
				Tileset.Mars6,
				Tileset.Mars7,
				Tileset.Mars8,
				Tileset.Mars9
			}
		};
		private static readonly TerrainCategoryMetadata alienBaseMetadata = new TerrainCategoryMetadata
		{
			FlatTilesets = new Tileset[0],
			OtherTilesets = new[]
			{
				Tileset.AlienBase1,
				Tileset.AlienBase2,
				Tileset.AlienBase3,
				Tileset.AlienBase5,
				Tileset.AlienBase6,
				Tileset.AlienBase7,
				Tileset.AlienBase8,
				Tileset.AlienBase9,
				Tileset.AlienBase10,
				Tileset.AlienBase11
			}
		};
		private static readonly TerrainCategoryMetadata marsBaseMetadata = new TerrainCategoryMetadata
		{
			FlatTilesets = new Tileset[0],
			OtherTilesets = new[]
			{
				Tileset.AlienBase1,
				Tileset.AlienBase2,
				Tileset.AlienBase3,
				Tileset.AlienBase5,
				Tileset.AlienBase6,
				Tileset.AlienBase7,
				Tileset.AlienBase8,
				Tileset.AlienBase9,
				Tileset.AlienBase10,
				Tileset.AlienBase11,
				Tileset.AlienBase12,
				Tileset.AlienBase13,
				Tileset.AlienBase14
			}
		};

		public static Map CreateMarsMap(Craft avenger)
		{
			var tilesets = new Tileset[5, 5];
			PlaceCraft(tilesets, avenger.CraftType.Metadata().Tileset, marsMetadata.FlatTilesets);
			var exitPyramid = Tileset.Mars10;
			PlaceTileset(tilesets, exitPyramid);
			FillTerrain(tilesets, marsMetadata);
			return new Map { Levels = CreateLevels(tilesets, 4) };
		}

		public static Map CreateMarsBaseMap()
		{
			return CreateAlienBaseMap(Tileset.AlienBase15, marsBaseMetadata);
		}

		public static Map CreateXcomBaseMap(Base @base)
		{
			var tilesets = CreateXcomBaseTilesets(@base);
			return new Map { Levels = CreateLevels(tilesets, 2) };
		}

		public static Map CreateFromCraft(Craft craft)
		{
			switch (craft.Destination.WorldObjectType)
			{
			case WorldObjectType.AlienBase:
				return CreateAlienBaseMap(Tileset.AlienBase0, alienBaseMetadata);
			case WorldObjectType.CrashSite:
				return CreateLandingSiteMap(craft);
			case WorldObjectType.TerrorSite:
				return CreateTerrorSiteMap(craft);
			case WorldObjectType.LandingSite:
				return CreateLandingSiteMap(craft);
			}
			throw new InvalidOperationException("Invalid craft destination for map.");
		}

		private static Map CreateAlienBaseMap(Tileset controlRoomTileset, TerrainCategoryMetadata baseMetadata)
		{
			var tilesets = new Tileset[6, 6];
			PlaceTileset(tilesets, controlRoomTileset);
			var entryTileset = Tileset.AlienBase4;
			PlaceTileset(tilesets, entryTileset);
			PlaceTileset(tilesets, entryTileset);
			FillTerrain(tilesets, baseMetadata);
			SetAlienBaseConnectors(tilesets);
			return new Map { Levels = CreateLevels(tilesets, 2) };
		}

		private static Map CreateTerrorSiteMap(Craft craft)
		{
			var tilesets = new Tileset[5, 5];
			PlaceRoads(tilesets);
			PlaceCraft(tilesets, craft.CraftType.Metadata().Tileset, cityMetadata.FlatTilesets);
			FillTerrain(tilesets, cityMetadata);
			return new Map { Levels = CreateLevels(tilesets, 4) };
		}

		private static void PlaceRoads(Tileset[,] tilesets)
		{
			switch (GameState.Current.Random.Next(3))
			{
			case 0:
				PlaceHorizontalRoad(tilesets);
				break;
			case 1:
				PlaceVerticalRoad(tilesets);
				break;
			case 2:
				PlaceCrossRoads(tilesets);
				break;
			}
		}

		private static void PlaceHorizontalRoad(Tileset[,] tilesets)
		{
			var row = GameState.Current.Random.Next(tilesets.GetLength(0));
			foreach (var column in Enumerable.Range(0, tilesets.GetLength(1)))
				tilesets[row, column] = Tileset.City0;
		}

		private static void PlaceVerticalRoad(Tileset[,] tilesets)
		{
			var column = GameState.Current.Random.Next(tilesets.GetLength(1));
			foreach (var row in Enumerable.Range(0, tilesets.GetLength(0)))
				tilesets[row, column] = Tileset.City1;
		}

		private static void PlaceCrossRoads(Tileset[,] tilesets)
		{
			var crossRow = GameState.Current.Random.Next(tilesets.GetLength(0));
			var crossColumn = GameState.Current.Random.Next(tilesets.GetLength(1));
			foreach (var column in Enumerable.Range(0, tilesets.GetLength(1)))
				tilesets[crossRow, column] = Tileset.City0;
			foreach (var row in Enumerable.Range(0, tilesets.GetLength(0)))
				tilesets[row, crossColumn] = Tileset.City1;
			tilesets[crossRow, crossColumn] = Tileset.City2;
		}

		private static Map CreateLandingSiteMap(Craft craft)
		{
			var mapLocation = World.Map.Instance[craft.Destination.Location];
			var category = mapLocation.TerrainType?.Metadata().Category;
			var ufo = GameState.Current.Data.GetUfo(craft.Destination.Number);
			return CreateUfoMap(
				craft.CraftType.Metadata().Tileset,
				ufo.UfoType.Metadata().Tileset,
				category?.Metadata(mapLocation.Location.Latitude));
		}

		private static Map CreateUfoMap(Tileset craftTileset, Tileset ufoTileset, TerrainCategoryMetadata terrainMetadata)
		{
			var tilesets = CreateUfoMapTilesets(craftTileset, ufoTileset, terrainMetadata);
			var levels = CreateLevels(tilesets, 4);
			return new Map { Levels = levels };
		}

		private static Tileset[,] CreateUfoMapTilesets(Tileset craftTileset, Tileset ufoTileset, TerrainCategoryMetadata terrainMetadata)
		{
			var size = IsSmallUfoTileset(ufoTileset) ? 4 : 5;
			var tilesets = new Tileset[size, size];
			PlaceCraft(tilesets, ufoTileset, terrainMetadata.FlatTilesets);
			PlaceCraft(tilesets, craftTileset, terrainMetadata.FlatTilesets);
			FillTerrain(tilesets, terrainMetadata);
			return tilesets;
		}

		private static bool IsSmallUfoTileset(Tileset ufoTileset)
		{
			return ufoTileset == Tileset.SmallScout || ufoTileset == Tileset.MediumScout;
		}

		private static void FillTerrain(Tileset[,] tilesets, TerrainCategoryMetadata terrainMetadata)
		{
			foreach (var row in Enumerable.Range(0, tilesets.GetLength(0)))
				foreach (var column in Enumerable.Range(0, tilesets.GetLength(1)))
					if (tilesets[row, column] == null)
						FillTileset(tilesets, row, column, terrainMetadata);
		}

		private static void PlaceCraft(Tileset[,] tilesets, Tileset craftTileset, Tileset[] flatTilesets)
		{
			var craftHeight = craftTileset.RowCount / 10;
			var craftWidth = craftTileset.ColumnCount / 10;
			var location = GetAvailableLocation(tilesets, craftWidth, craftHeight);
			foreach (var row in Enumerable.Range(0, craftHeight))
				foreach (var column in Enumerable.Range(0, craftWidth))
					FillCraftSection(
						tilesets,
						location.Y + row,
						location.X + column,
						craftTileset,
						row,
						column,
						flatTilesets);
		}

		private static void FillCraftSection(
			Tileset[,] tilesets,
			int row,
			int column,
			Tileset craftTileset,
			int craftRow,
			int craftColumn,
			Tileset[] flatTilesets)
		{
			FillTileset(tilesets, row, column, flatTilesets);
			MergeCraftSection(tilesets, row, column, craftTileset, craftRow, craftColumn);
		}

		private static Point GetAvailableLocation(Tileset[,] tilesets, int width, int height)
		{
			for (;;)
			{
				var topRow = GameState.Current.Random.Next(tilesets.GetLength(0) - height + 1);
				var leftColumn = GameState.Current.Random.Next(tilesets.GetLength(1) - width + 1);
				var isSpaceAvailable = Enumerable.Range(topRow, height)
					.All(row => Enumerable.Range(leftColumn, width)
						.All(column => tilesets[row, column] == null));
				if (isSpaceAvailable)
					return new Point { X = leftColumn, Y = topRow };
			}
		}

		private static void FillTileset(Tileset[,] tilesets, int row, int column, TerrainCategoryMetadata terrainMetadata)
		{
			var isSpaceForLargeTileset =
				row < (tilesets.GetLength(0) - 1) &&
				column < (tilesets.GetLength(1) - 1) &&
				tilesets[row, column + 1] == null &&
				tilesets[row + 1, column] == null &&
				tilesets[row + 1, column + 1] == null;
			var terrainTilesets = isSpaceForLargeTileset ? terrainMetadata.AllTilesets : terrainMetadata.SmallTilesets;
			FillTileset(tilesets, row, column, terrainTilesets);
		}

		private static void FillTileset(Tileset[,] tilesets, int row, int column, Tileset[] terrainTilesets)
		{
			var terrainTileset = terrainTilesets[GameState.Current.Random.Next(terrainTilesets.Length)];
			PlaceTileset(tilesets, row, column, terrainTileset);
		}

		private static void PlaceTileset(Tileset[,] tilesets, Tileset tileset)
		{
			var location = GetAvailableLocation(tilesets, tileset.ColumnCount / 10, tileset.RowCount / 10);
			PlaceTileset(tilesets, location.Y, location.X, tileset);
		}

		private static void PlaceTileset(Tileset[,] tilesets, int row, int column, Tileset tileset)
		{
			tilesets[row, column] = tileset;
			if (tileset.RowCount == 10)
				return;
			tilesets[row, column + 1] = placeholder;
			tilesets[row + 1, column] = placeholder;
			tilesets[row + 1, column + 1] = placeholder;
		}

		private static void MergeCraftSection(
			Tileset[,] tilesets,
			int row,
			int column,
			Tileset craftTileset,
			int sectionRow,
			int sectionColumn)
		{
			var tileset = tilesets[row, column];
			var mergedTileset = new Tileset(tileset, craftTileset);
			foreach (var levelIndex in Enumerable.Range(0, craftTileset.LevelCount))
				foreach (var tileRow in Enumerable.Range(0, 10))
					foreach (var tileColumn in Enumerable.Range(0, 10))
						MergeCraftTile(
							mergedTileset,
							levelIndex,
							tileRow,
							tileColumn,
							craftTileset,
							sectionRow,
							sectionColumn,
							tileset.PartCount);
			tilesets[row, column] = mergedTileset;
		}

		private static void MergeCraftTile(
			Tileset terrainTileset,
			int levelIndex,
			int tileRow,
			int tileColumn,
			Tileset craftTileset,
			int sectionRow,
			int sectionColumn,
			int partOffset)
		{
			var terrainTile = terrainTileset[levelIndex, tileRow, tileColumn];
			var craftTile = craftTileset[levelIndex, sectionRow * 10 + tileRow, sectionColumn * 10 + tileColumn];
			var mergedTile = terrainTile.Merge(craftTile, partOffset);
			terrainTileset[levelIndex, tileRow, tileColumn] = mergedTile;
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

		private static void SetAlienBaseConnectors(Tileset[,] tilesets)
		{
			foreach (var row in Enumerable.Range(0, 6))
				foreach (var column in Enumerable.Range(0, 6))
				{
					var tileset = tilesets[row, column];
					if (tileset == placeholder)
						continue;
					var facilityConnectors = new FacilityConnectors(tileset, row, column);
					tilesets[row, column] = facilityConnectors.UpdateTileset(tileset);
				}
		}

		private static Level[] CreateLevels(Tileset[,] tilesets, int levelCount)
		{
			return Enumerable.Range(0, levelCount)
				.Select(levelIndex => CreateLevel(tilesets, levelIndex))
				.ToArray();
		}

		private static Level CreateLevel(Tileset[,] tilesets, int levelIndex)
		{
			var level = new Level { Tiles = new Tile[10 * tilesets.GetLength(0), 10 * tilesets.GetLength(1)] };
			foreach (var row in Enumerable.Range(0, tilesets.GetLength(0)))
				foreach (var column in Enumerable.Range(0, tilesets.GetLength(1)))
					if (tilesets[row, column] != placeholder)
						level.LoadTileset(tilesets[row, column], levelIndex, row * 10, column * 10);
			return level;
		}
	}
}
