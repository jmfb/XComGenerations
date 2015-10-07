using System;
using System.Linq;
using XCom.Content.World;

namespace XCom.World
{
	public class Map
	{
		private const int longitudeCount = Trigonometry.EighthDegreesCount;
		private const int latitudeCount = Trigonometry.EighthDegreesCount / 2;
		private const int minLatitude = -latitudeCount / 2;
		private readonly MapLocation[,] locations = new MapLocation[longitudeCount, latitudeCount];

		private Map()
		{
			var index = 0;
			foreach (var longitude in Enumerable.Range(0, longitudeCount))
			{
				foreach (var latitudeIndex in Enumerable.Range(0, latitudeCount))
				{
					var terrain = WorldResources.Map[index++];
					var region = WorldResources.Map[index++];
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

		public MapLocation this[Location location]
		{
			get
			{
				if (location.Longitude < 0 ||
					location.Longitude >= longitudeCount ||
					location.Latitude < minLatitude ||
					location.Latitude >= minLatitude + latitudeCount)
					throw new InvalidOperationException($"Invalid longitude/latitude: ({location.Longitude}, {location.Latitude})");
				return locations[location.Longitude, location.Latitude - minLatitude];
			}
		}

		public static readonly Map Instance = new Map();
	}
}
