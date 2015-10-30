using System.Collections.Generic;
using System.Linq;

namespace XCom.Battlescape.Tiles
{
	public class FacilityConnectors
	{
		private readonly bool northConnector;
		private readonly bool southConnector;
		private readonly bool eastConnector;
		private readonly bool westConnector;
		private readonly byte northWall;
		private readonly byte westWall;

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
			northWall = 14;
			westWall = 15;
		}

		public FacilityConnectors(Tileset tileset, int row, int column)
		{
			northConnector = row > 0;
			westConnector = column > 0;
			southConnector = row < (6 - tileset.RowCount / 10);
			eastConnector = column < (6 - tileset.ColumnCount / 10);
			var isAlienGarden = alienGardens.Contains(tileset);
			northWall = (byte)(isAlienGarden ? 54 : 86);
			westWall = (byte)(isAlienGarden ? 55 : 87);
			//TODO: Set correct ground tile when taking out south/east "objects" (unless dirt looks okay for some facilities...)
		}

		private static readonly List<Tileset> alienGardens = new List<Tileset>
		{
			Tileset.AlienBase0,
			Tileset.AlienBase1,
			Tileset.AlienBase9,
			Tileset.AlienBase14
		};

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
			if (northConnector)
				SetNorthConnectors(copy);
			if (southConnector)
				SetSouthConnectors(copy);
			if (eastConnector)
				SetEastConnectors(copy);
			if (westConnector)
				SetWestConnectors(copy);
			return copy;
		}

		private static void SetNorthConnectors(Tileset tileset)
		{
			foreach (var offset in Enumerable.Range(0, tileset.ColumnCount / 10).Select(index => 10 * index))
			{
				tileset[0, 0, 3 + offset] = tileset[0, 0, 3 + offset].SetNorthWall(0);
				tileset[0, 0, 4 + offset] = tileset[0, 0, 4 + offset].SetNorthWall(0);
				tileset[0, 0, 5 + offset] = tileset[0, 0, 5 + offset].SetNorthWall(0);
			}
		}

		private void SetSouthConnectors(Tileset tileset)
		{
			var bottom = tileset.RowCount - 1;
			foreach (var offset in Enumerable.Range(0, tileset.ColumnCount / 10).Select(index => 10 * index))
			{
				tileset[0, bottom, 3 + offset] = tileset[0, bottom, 3 + offset].SetNorthWall(0).SetEntity(0).SetWestWall(westWall);
				tileset[0, bottom, 4 + offset] = tileset[0, bottom, 4 + offset].SetNorthWall(0).SetEntity(0);
				tileset[0, bottom, 5 + offset] = tileset[0, bottom, 5 + offset].SetNorthWall(0).SetEntity(0);
				tileset[0, bottom, 6 + offset] = tileset[0, bottom, 6 + offset].SetWestWall(westWall);
			}
		}

		private void SetEastConnectors(Tileset tileset)
		{
			var right = tileset.ColumnCount - 1;
			foreach (var offset in Enumerable.Range(0, tileset.RowCount / 10).Select(index => 10 * index))
			{
				tileset[0, 3 + offset, right] = tileset[0, 3 + offset, right].SetWestWall(0).SetEntity(0).SetNorthWall(northWall);
				tileset[0, 4 + offset, right] = tileset[0, 4 + offset, right].SetWestWall(0).SetEntity(0);
				tileset[0, 5 + offset, right] = tileset[0, 5 + offset, right].SetWestWall(0).SetEntity(0);
				tileset[0, 6 + offset, right] = tileset[0, 6 + offset, right].SetNorthWall(northWall);
			}
		}

		private static void SetWestConnectors(Tileset tileset)
		{
			foreach (var offset in Enumerable.Range(0, tileset.RowCount / 10).Select(index => 10 * index))
			{
				tileset[0, 3 + offset, 0] = tileset[0, 3 + offset, 0].SetWestWall(0);
				tileset[0, 4 + offset, 0] = tileset[0, 4 + offset, 0].SetWestWall(0);
				tileset[0, 5 + offset, 0] = tileset[0, 5 + offset, 0].SetWestWall(0);
			}
		}
	}
}
