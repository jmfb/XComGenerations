using System;
using System.Linq;
using XCom.Content.World;

namespace XCom.World
{
	public class Map
	{
		private const int longitudeCount = Trigonometry.EighthDegreesCount;
		private const int latitudeCount = Trigonometry.EighthDegreesCount / 2 + 1;
		private const int minLatitude = -latitudeCount / 2;
		private readonly MapLocation[,] locations = new MapLocation[longitudeCount, latitudeCount];

		public Map()
		{
			var index = 0;
			var data = WorldResources.Map;
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
