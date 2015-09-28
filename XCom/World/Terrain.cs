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
		public int Longitude { get; set; }

		public int Shading
		{
			get
			{
				const int secondsInDay = 60 * 60 * 24;
				const int secondsPerEighthDegree = secondsInDay / Trigonometry.EighthDegreesCount;
				const int secondsPerShade = 450;
				var secondOfDay = (int)GameState.Current.Data.Time.TimeOfDay.TotalSeconds;
				var localSecondOfDay = (Longitude * secondsPerEighthDegree + secondsInDay + secondOfDay) % secondsInDay;
				var shadeIndex = localSecondOfDay / secondsPerShade;
				if (shadeIndex < 44)
					return 8;
				if (shadeIndex < 52)
					return 52 - shadeIndex;
				if (shadeIndex < 140)
					return 0;
				if (shadeIndex < 148)
					return shadeIndex - 140;
				return 8;
			}
		}

		private bool HitTest(Location location)
		{
			return Trigonometry.IsLocationInTriangle(location, Vertices);
		}

		private const int coordinateRecordSize = sizeof(short) * 2;
		private const int coordinateCount = 4;
		private const int terrainRecordSize = coordinateRecordSize * coordinateCount + sizeof(int);

		private static List<Terrain> LoadLandscape()
		{
			var terrainCount = WorldResources.Landscape.Length / terrainRecordSize;
			return Enumerable.Range(0, terrainCount)
				.SelectMany(index => LoadTerrain(index * terrainRecordSize))
				.ToList();
		}

		private static Terrain Create(TerrainType terrainType, params Point[] vertices)
		{
			return new Terrain
			{
				TerrainType = terrainType,
				Vertices = vertices,
				Longitude = LongitudeCenter(vertices)
			};
		}

		private static int LongitudeCenter(Point[] vertices)
		{
			//TODO: This apparently has some issues at the poles
			var minLongitude = vertices.Min(vertex => vertex.X);
			var maxLongitude = vertices.Max(vertex => vertex.X);
			var longitudeRange = maxLongitude - minLongitude;
			return longitudeRange > Trigonometry.EighthDegreesCount / 2 ?
				(maxLongitude + Trigonometry.EighthDegreesCount - longitudeRange) % Trigonometry.EighthDegreesCount :
				minLongitude + longitudeRange / 2;
		}

		private static IEnumerable<Terrain> LoadTerrain(int offset)
		{
			var vertices = Enumerable.Range(0, coordinateCount)
				.Select(index => LoadVertex(offset + index * coordinateRecordSize))
				.OfType<Point>()
				.ToArray();
			var terrainType = (TerrainType)BitConverter.ToInt32(WorldResources.Landscape, offset + coordinateRecordSize * coordinateCount);
			yield return Create(terrainType, vertices[0], vertices[1], vertices[2]);
			if (vertices.Length == 4)
				yield return Create(terrainType, vertices[0], vertices[2], vertices[3]);
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
		public static bool IsOnLand(Location location) => Landscape.Any(terrain => terrain.HitTest(location));
	}
}
