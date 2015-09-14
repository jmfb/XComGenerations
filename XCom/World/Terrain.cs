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
				.Select(index => LoadTerrain(index * terrainRecordSize))
				.ToList();
		}

		private static Terrain LoadTerrain(int offset)
		{
			return new Terrain
			{
				Vertices = Enumerable.Range(0, coordinateCount)
					.Select(index => LoadVertex(offset + index * coordinateRecordSize))
					.OfType<Point>()
					.ToArray(),
				TerrainType = (TerrainType)BitConverter.ToInt32(WorldResources.Landscape, offset + coordinateRecordSize * coordinateCount)
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
