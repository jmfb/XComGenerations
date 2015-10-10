using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace XCom.World
{
	public class Map
	{
		private const int longitudeCount = Trigonometry.EighthDegreesCount;
		private const int latitudeCount = Trigonometry.EighthDegreesCount / 2 + 1;
		private const int minLatitude = -latitudeCount / 2;
		private readonly MapLocation[,] locations = new MapLocation[longitudeCount, latitudeCount];

		public Map(byte[] data)
		{
			var index = 0;
			foreach (var longitude in Enumerable.Range(0, longitudeCount))
			{
				foreach (var latitudeIndex in Enumerable.Range(0, latitudeCount))
				{
					var terrain = data[index++];
					var region = data[index++];
					locations[longitude, latitudeIndex] = new MapLocation
					{
						Location = new Location
						{
							Longitude = longitude,
							Latitude = latitudeIndex + minLatitude
						},
						TerrainType = terrain == byte.MaxValue ? null : (TerrainType?)terrain,
						RegionType = (RegionType)region
					};
				}
			}
		}

		public Map()
		{
			foreach (var longitude in Enumerable.Range(0, longitudeCount))
			{
				foreach (var latitudeIndex in Enumerable.Range(0, latitudeCount))
				{
					locations[longitude, latitudeIndex] = new MapLocation
					{
						Location = new Location
						{
							Longitude = longitude,
							Latitude = latitudeIndex + minLatitude
						}
					};
				}
			}
			ApplyTerrains();
			ApplyRegions();
		}

		public void Save()
		{
			using (var output = File.OpenWrite(@"c:\temp\map.bin"))
			{
				foreach (var mapLocation in locations)
				{
					output.WriteByte(mapLocation.TerrainType == null ? byte.MaxValue : (byte)mapLocation.TerrainType);
					output.WriteByte((byte)mapLocation.RegionType);
				}
			}
		}

		private void ApplyTerrains()
		{
			foreach (var terrain in Terrain.Landscape)
				ApplyTerrain(terrain);
		}

		private void ApplyTerrain(Terrain terrain)
		{
			foreach (var point in Triangle(terrain.Vertices, terrain.LongitudeOffset))
				locations[point.X, point.Y - minLatitude].TerrainType = terrain.TerrainType;
		}

		private static void Swap<T>(ref T value1, ref T value2)
		{
			var temp = value1;
			value1 = value2;
			value2 = temp;
		}

		private static IEnumerable<Point> Line(Point from, Point to, int longitudeOffset)
		{
			var x0 = Trigonometry.AddEighthDegrees(from.X, -longitudeOffset);
			var y0 = from.Y;
			var x1 = Trigonometry.AddEighthDegrees(to.X, -longitudeOffset);
			var y1 = to.Y;
			var steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
			if (steep)
			{
				Swap(ref x0, ref y0);
				Swap(ref x1, ref y1);
			}
			if (x0 > x1)
			{
				Swap(ref x0, ref x1);
				Swap(ref y0, ref y1);
			}
			var dX = x1 - x0;
			var dY = Math.Abs(y1 - y0);
			var error = dX / 2;
			var yStep = y0 < y1 ? 1 : -1;
			var y = y0;

			for (var x = x0; x <= x1; ++x)
			{
				yield return steep ?
					new Point { X = y, Y = x } :
					new Point { X = x, Y = y };
				error = error - dY;
				if (error >= 0)
					continue;
				y += yStep;
				error += dX;
			}
		}

		private static IEnumerable<Point> Triangle(Point[] vertices, int longitudeOffset)
		{
			foreach (var group in Line(vertices[0], vertices[1], longitudeOffset)
				.Concat(Line(vertices[1], vertices[2], longitudeOffset))
				.Concat(Line(vertices[2], vertices[0], longitudeOffset))
				.GroupBy(point => point.Y))
			{
				var minX = group.Min(point => point.X);
				var maxX = group.Max(point => point.X);
				foreach (var column in Enumerable.Range(minX, maxX - minX + 1))
				{
					yield return new Point { X = Trigonometry.AddEighthDegrees(column, longitudeOffset), Y = group.Key };
				}
			}
		}

		private void ApplyRegions()
		{
			foreach (var regionType in EnumEx.GetValues<RegionType>())
				ApplyRegionType(regionType);
		}

		private void ApplyRegionType(RegionType regionType)
		{
			foreach (var region in regionType.Metadata().Regions)
				ApplyRegion(regionType, region);
		}

		private void ApplyRegion(RegionType regionType, Region region)
		{
			foreach (var column in Enumerable.Range(0, region.Width))
				foreach (var row in Enumerable.Range(0, region.Height))
					locations[region.Left + column, region.Top + row - minLatitude].RegionType = regionType;
		}

		public MapLocation this[Location location]
		{
			get
			{
				if (location == null)
					return null;
				if (location.Longitude < 0 ||
					location.Longitude >= longitudeCount ||
					location.Latitude < minLatitude ||
					location.Latitude >= minLatitude + latitudeCount)
					throw new InvalidOperationException($"Invalid longitude/latitude: ({location.Longitude}, {location.Latitude})");
				return locations[location.Longitude, location.Latitude - minLatitude];
			}
		}

		public static Map Instance { get; set; }
	}
}
