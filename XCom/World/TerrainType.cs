using System;
using System.Collections.Generic;
using System.Linq;
using XCom.Content.World;

namespace XCom.World
{
	public enum TerrainType
	{
		Forest1,
		Farm1,
		Farm2,
		Farm3,
		Farm4,
		Mountain,
		Forest2,
		Desert1,
		Desert2,
		PolarIce,
		Forest3,
		Forest4,
		PolarSeas
	}

	public static class TerrainTypeExtensions
	{
		public static TerrainMetadata Metadata(this TerrainType terrainType) => metadata[terrainType];

		private static TerrainCategory GetCategory(TerrainType terrainType)
		{
			switch (terrainType)
			{
			case TerrainType.Forest1:
			case TerrainType.Forest2:
			case TerrainType.Forest3:
			case TerrainType.Forest4:
				return TerrainCategory.Forest;
			case TerrainType.Farm1:
			case TerrainType.Farm2:
			case TerrainType.Farm3:
			case TerrainType.Farm4:
				return TerrainCategory.Farm;
			case TerrainType.Mountain:
				return TerrainCategory.Mountain;
			case TerrainType.Desert1:
			case TerrainType.Desert2:
				return TerrainCategory.Desert;
			case TerrainType.PolarIce:
				return TerrainCategory.PolarIce;
			case TerrainType.PolarSeas:
				return TerrainCategory.PolarSeas;
			}
			throw new InvalidOperationException("Invalid terrain type.");
		}

		private static readonly int terrainTypeCount = EnumEx.GetValues<TerrainType>().Count();

		private static TerrainMetadata LoadMetadata(TerrainType terrainType)
		{
			const int terrainRecordSize = 32 * 32;
			var zoomRecordSize = terrainRecordSize * terrainTypeCount;
			var index = (int)terrainType;
			var zoomOffset = index * terrainRecordSize;
			return new TerrainMetadata
			{
				Category = GetCategory(terrainType),
				ImageZoom1 = WorldResources.TerrainTypes.Skip(zoomOffset).Take(terrainRecordSize).ToArray(),
				ImageZoom2 = WorldResources.TerrainTypes.Skip(zoomRecordSize + zoomOffset).Take(terrainRecordSize).ToArray(),
				ImageZoom3 = WorldResources.TerrainTypes.Skip(2 * zoomRecordSize + zoomOffset).Take(terrainRecordSize).ToArray()
			};
		}

		private static readonly Dictionary<TerrainType, TerrainMetadata> metadata = EnumEx.GetValues<TerrainType>()
			.ToDictionary(terrainType => terrainType, LoadMetadata);
	}
}
