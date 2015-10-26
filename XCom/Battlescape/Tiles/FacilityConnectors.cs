using System.Collections.Generic;

namespace XCom.Battlescape.Tiles
{
	public class FacilityConnectors
	{
		private readonly bool northConnector;
		private readonly bool southConnector;
		private readonly bool eastConnector;
		private readonly bool westConnector;

		public FacilityConnectors(Tileset[,] tilesets, int row, int column)
		{
			var facility = tilesets[row, column];
			var northFacility = row == 0 ? null : tilesets[row - 1, column];
			var sourthFacility = row == 5 ? null : tilesets[row + 1, column];
			var eastFacility = column == 5 ? null : tilesets[row, column + 1];
			var westFacility = column == 0 ? null : tilesets[row, column - 1];
			northConnector = AreVerticallyConnected(northFacility, facility);
			southConnector = AreVerticallyConnected(facility, sourthFacility);
			eastConnector = AreHorizontallyConnected(facility, eastFacility);
			westConnector = AreHorizontallyConnected(westFacility, facility);
		}

		private static readonly List<Tileset> noSouthConnectors = new List<Tileset>
		{
			null,
			Tileset.XcomBase16,
			Tileset.XcomBase17,
			Tileset.XcomBase20
		};
		private static readonly List<Tileset> noNorthConnectors = new List<Tileset>
		{
			null,
			Tileset.XcomBase18,
			Tileset.XcomBase19,
			Tileset.XcomBase20
		};

		private static readonly List<Tileset> noEastConnectors = new List<Tileset>
		{
			null,
			Tileset.XcomBase16,
			Tileset.XcomBase18,
			Tileset.XcomBase20
		};
		private static readonly List<Tileset> noWestConnectors = new List<Tileset>
		{
			null,
			Tileset.XcomBase17,
			Tileset.XcomBase19,
			Tileset.XcomBase20
		};

		private static bool AreVerticallyConnected(Tileset northFacility, Tileset southFacility)
		{
			return !noSouthConnectors.Contains(northFacility) && !noNorthConnectors.Contains(southFacility);
		}

		private static bool AreHorizontallyConnected(Tileset westFacility, Tileset eastFacility)
		{
			return !noEastConnectors.Contains(westFacility) && !noWestConnectors.Contains(eastFacility);
		}

		private bool HasAnyConnectors => northConnector || southConnector || eastConnector || westConnector;

		public Tileset UpdateTileset(Tileset tileset)
		{
			if (!HasAnyConnectors)
				return tileset;
			var copy = new Tileset(tileset);
			SetNorthConnector(copy);
			SetSouthConnector(copy);
			SetEastConnector(copy);
			SetWestConnector(copy);
			return copy;
		}

		private void SetNorthConnector(Tileset tileset)
		{
			if (!northConnector)
				return;
			tileset[0, 0, 3] = tileset[0, 0, 3].SetNorthWall(0);
			tileset[0, 0, 4] = tileset[0, 0, 4].SetNorthWall(0);
			tileset[0, 0, 5] = tileset[0, 0, 5].SetNorthWall(0);
		}

		private void SetSouthConnector(Tileset tileset)
		{
			if (!southConnector)
				return;
			tileset[0, 9, 3] = tileset[0, 9, 3].SetNorthWall(0).SetEntity(0).SetWestWall(15);
			tileset[0, 9, 4] = tileset[0, 9, 4].SetNorthWall(0).SetEntity(0);
			tileset[0, 9, 5] = tileset[0, 9, 5].SetNorthWall(0).SetEntity(0);
			tileset[0, 9, 6] = tileset[0, 9, 6].SetWestWall(15);
		}

		private void SetEastConnector(Tileset tileset)
		{
			if (!eastConnector)
				return;
			tileset[0, 3, 9] = tileset[0, 3, 9].SetWestWall(0).SetEntity(0).SetNorthWall(14);
			tileset[0, 4, 9] = tileset[0, 4, 9].SetWestWall(0).SetEntity(0);
			tileset[0, 5, 9] = tileset[0, 5, 9].SetWestWall(0).SetEntity(0);
			tileset[0, 6, 9] = tileset[0, 6, 9].SetNorthWall(14);
		}

		private void SetWestConnector(Tileset tileset)
		{
			if (!westConnector)
				return;
			tileset[0, 3, 0] = tileset[0, 3, 0].SetWestWall(0);
			tileset[0, 4, 0] = tileset[0, 4, 0].SetWestWall(0);
			tileset[0, 5, 0] = tileset[0, 5, 0].SetWestWall(0);
		}
	}
}
