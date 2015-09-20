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

		private static IEnumerable<Terrain> LoadTerrain(int offset)
		{
			var vertices = Enumerable.Range(0, coordinateCount)
				.Select(index => LoadVertex(offset + index * coordinateRecordSize))
				.OfType<Point>()
				.ToArray();
			var terrainType = (TerrainType)BitConverter.ToInt32(WorldResources.Landscape, offset + coordinateRecordSize * coordinateCount);
			yield return new Terrain
			{
				Vertices = new[] { vertices[0], vertices[1], vertices[2] },
				TerrainType = terrainType
			};
			if (vertices.Length == 4)
				yield return new Terrain
				{
					Vertices = new[] { vertices[0], vertices[2], vertices[3] },
					TerrainType = terrainType
				};
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
