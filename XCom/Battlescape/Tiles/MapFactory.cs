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

		//TODO: Construct cydonia mission (mars and final base)

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
				throw new NotImplementedException(); //TODO: AlienBase tilesets
			case WorldObjectType.CrashSite:
				//TODO: Ufo should be damaged to some degree
				return CreateLandingSiteMap(craft);
			case WorldObjectType.TerrorSite:
				return CreateTerrorSiteMap(craft);
			case WorldObjectType.LandingSite:
				return CreateLandingSiteMap(craft);
			}
			throw new InvalidOperationException("Invalid craft destination for map.");
		}

		private static Map CreateTerrorSiteMap(Craft craft)
		{
			var tilesets = new Tileset[6, 6];
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
			var row = GameState.Current.Random.Next(6);
			foreach (var column in Enumerable.Range(0, 6))
				tilesets[row, column] = Tileset.City0;
		}

		private static void PlaceVerticalRoad(Tileset[,] tilesets)
		{
			var column = GameState.Current.Random.Next(6);
			foreach (var row in Enumerable.Range(0, 6))
				tilesets[row, column] = Tileset.City1;
		}

		private static void PlaceCrossRoads(Tileset[,] tilesets)
		{
			var crossRow = GameState.Current.Random.Next(6);
			var crossColumn = GameState.Current.Random.Next(6);
			foreach (var column in Enumerable.Range(0, 6))
				tilesets[crossRow, column] = Tileset.City0;
			foreach (var row in Enumerable.Range(0, 6))
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
			var tilesets = new Tileset[6, 6];
			PlaceCraft(tilesets, ufoTileset, terrainMetadata.FlatTilesets);
			PlaceCraft(tilesets, craftTileset, terrainMetadata.FlatTilesets);
			FillTerrain(tilesets, terrainMetadata);
			return tilesets;
		}

		private static void FillTerrain(Tileset[,] tilesets, TerrainCategoryMetadata terrainMetadata)
		{
			foreach (var row in Enumerable.Range(0, 6))
				foreach (var column in Enumerable.Range(0, 6))
					if (tilesets[row, column] == null)
						FillTileset(tilesets, row, column, terrainMetadata);
		}

		private static void PlaceCraft(Tileset[,] tilesets, Tileset craftTileset, Tileset[] flatTilesets)
		{
			var craftHeight = craftTileset.RowCount / 10;
			var craftWidth = craftTileset.ColumnCount / 10;
			var location = GetCraftLocation(tilesets, craftWidth, craftHeight);
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

		private static Point GetCraftLocation(Tileset[,] tilesets, int craftWidth, int craftHeight)
		{
			for (;;)
			{
				var topRow = GameState.Current.Random.Next(6 - craftHeight + 1);
				var leftColumn = GameState.Current.Random.Next(6 - craftWidth + 1);
				var isSpaceAvailable = Enumerable.Range(topRow, craftHeight)
					.All(row => Enumerable.Range(leftColumn, craftWidth)
						.All(column => tilesets[row, column] == null));
				if (isSpaceAvailable)
					return new Point { X = leftColumn, Y = topRow };
			}
		}

		private static void FillTileset(Tileset[,] tilesets, int row, int column, TerrainCategoryMetadata terrainMetadata)
		{
			var isSpaceForLargeTileset =
				row < 5 &&
				column < 5 &&
				tilesets[row, column + 1] == null &&
				tilesets[row + 1, column] == null &&
				tilesets[row + 1, column + 1] == null;
			var terrainTilesets = isSpaceForLargeTileset ? terrainMetadata.AllTilesets : terrainMetadata.SmallTilesets;
			FillTileset(tilesets, row, column, terrainTilesets);
		}

		private static void FillTileset(Tileset[,] tilesets, int row, int column, Tileset[] terrainTilesets)
		{
			var terrainTileset = terrainTilesets[GameState.Current.Random.Next(terrainTilesets.Length)];
			tilesets[row, column] = terrainTileset;
			if (terrainTileset.RowCount == 10)
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

		private static Level[] CreateLevels(Tileset[,] tilesets, int levelCount)
		{
			return Enumerable.Range(0, levelCount)
				.Select(levelIndex => CreateLevel(tilesets, levelIndex))
				.ToArray();
		}

		private static Level CreateLevel(Tileset[,] tilesets, int levelIndex)
		{
			var level = new Level { Tiles = new Tile[60, 60] };
			foreach (var row in Enumerable.Range(0, 6))
				foreach (var column in Enumerable.Range(0, 6))
					if (tilesets[row, column] != placeholder)
						level.LoadTileset(tilesets[row, column], levelIndex, row * 10, column * 10);
			return level;
		}
	}
}
