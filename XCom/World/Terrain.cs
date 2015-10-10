using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using XCom.Content.World;

namespace XCom.World
{
	public class Terrain
	{
		public TerrainType TerrainType { get; set; }
		public Point[] Vertices { get; set; }
		public int MiddleLongitude { get; set; }
		public int LongitudeOffset { get; set; }

		public bool HitTest(Location location)
		{
			return Trigonometry.IsLocationInTriangle(location, Vertices, LongitudeOffset);
		}
		private const int coordinateRecordSize = sizeof(short) * 2;
		private const int coordinateCount = 4;
		private const int terrainRecordSize = coordinateRecordSize * coordinateCount + sizeof(int);

		private static List<Terrain> LoadLandscape()
		{
			var terrainCount = WorldResources.Landscape.Length / terrainRecordSize;
			return Enumerable.Range(0, terrainCount)
				.SelectMany(index => LoadTerrain(index * terrainRecordSize))
				.Concat(new[]
				{
					new Terrain
					{
						TerrainType = TerrainType.PolarIce,
						LongitudeOffset = 0,
						MiddleLongitude = 1440,
						Vertices = new[]
						{
							new Point { X = 0, Y = 720 },
							new Point { X = 1533, Y = 628 },
							new Point { X = 2879, Y = 720 },
						}
					},
					new Terrain
					{
						TerrainType = TerrainType.PolarIce,
						LongitudeOffset = 0,
						MiddleLongitude = 1440,
						Vertices = new[]
						{
							new Point { X = 0, Y = -720 },
							new Point { X = 1520, Y = -629 },
							new Point { X = 2879, Y = -720 },
						}
					}
				})
				.ToList();
		}

		private static Terrain Create(TerrainType terrainType, int longitudeOffset, params Point[] vertices)
		{
			return new Terrain
			{
				TerrainType = terrainType,
				Vertices = vertices,
				MiddleLongitude = GetMiddleLongitude(longitudeOffset, vertices),
				LongitudeOffset = longitudeOffset
			};
		}

		private static int GetMiddleLongitude(int longitudeOffset, IEnumerable<Point> vertices)
		{
			var longitudes = vertices.Select(vertex => Trigonometry.AddEighthDegrees(vertex.X, -longitudeOffset)).ToList();
			var min = longitudes.Min();
			var max = longitudes.Max();
			var range = max - min;
			var middle = range / 2 + min;
			return Trigonometry.AddEighthDegrees(middle, longitudeOffset);
		}

		private static IEnumerable<Terrain> LoadTerrain(int offset)
		{
			var vertices = Enumerable.Range(0, coordinateCount)
				.Select(index => LoadVertex(offset + index * coordinateRecordSize))
				.OfType<Point>()
				.ToArray();
			var terrainType = (TerrainType)BitConverter.ToInt32(WorldResources.Landscape, offset + coordinateRecordSize * coordinateCount);
			var longitudeOffset = DetermineBestLongitudeOffset(vertices);
			yield return Create(terrainType, longitudeOffset, vertices[0], vertices[1], vertices[2]);
			if (vertices.Length == 4)
				yield return Create(terrainType, longitudeOffset, vertices[0], vertices[2], vertices[3]);
		}

		private static int DetermineBestLongitudeOffset(Point[] vertices)
		{
			return vertices
				.OrderBy(vertex => GetLongitudeOffsetSpan(vertex.X, vertices))
				.Select(vertex => vertex.X)
				.First();
		}

		private static int GetLongitudeOffsetSpan(int longitudeOffset, IEnumerable<Point> vertices)
		{
			var longitudes = vertices.Select(vertex => Trigonometry.AddEighthDegrees(vertex.X, -longitudeOffset)).ToList();
			return longitudes.Max() - longitudes.Min();
		}

		private static Point? LoadVertex(int offset)
		{
			var longitude = BitConverter.ToInt16(WorldResources.Landscape, offset);
			var latitude = BitConverter.ToInt16(WorldResources.Landscape, offset + sizeof(short));
			if (longitude == -1 && latitude == 0)
				return null;
			return new Point
			{
				X = longitude,
				Y = latitude
			};
		}

		public static readonly List<Terrain> Landscape = LoadLandscape();
	}
}
