using System;
using XCom.Battlescape.Tiles;

namespace XCom.World
{
	public enum TerrainCategory
	{
		Forest,
		Farm,
		Mountain,
		Desert,
		PolarIce,
		PolarSeas
	}

	public static class TerrainCategoryExtensions
	{
		public static TerrainCategoryMetadata Metadata(this TerrainCategory category, int latitude)
		{
			switch (category)
			{
			case TerrainCategory.Forest:
				return latitude < 0 ? forest : jungle;
			case TerrainCategory.Farm:
				return farm;
			case TerrainCategory.Mountain:
				return mountain;
			case TerrainCategory.Desert:
				return desert;
			case TerrainCategory.PolarIce:
			case TerrainCategory.PolarSeas:
				return polar;
			}
			throw new InvalidOperationException("Invalid category");
		}

		private static readonly TerrainCategoryMetadata forest = new TerrainCategoryMetadata
		{
			FlatTilesets = new[] { Tileset.Forest0, Tileset.Forest1 },
			OtherTilesets = new[]
			{
				Tileset.Forest2,
				Tileset.Forest3,
				Tileset.Forest4,
				Tileset.Forest5,
				Tileset.Forest6,
				Tileset.Forest7,
				Tileset.Forest8,
				Tileset.Forest9,
				Tileset.Forest10,
				Tileset.Forest11
			}
		};

		private static readonly TerrainCategoryMetadata jungle = new TerrainCategoryMetadata
		{
			FlatTilesets = new[] { Tileset.Jungle0, Tileset.Jungle1, Tileset.Jungle2 },
			OtherTilesets = new[]
			{
				Tileset.Jungle3,
				Tileset.Jungle4,
				Tileset.Jungle5,
				Tileset.Jungle6,
				Tileset.Jungle7,
				Tileset.Jungle8,
				Tileset.Jungle9,
				Tileset.Jungle10,
				Tileset.Jungle11
			}
		};

		private static readonly TerrainCategoryMetadata farm = new TerrainCategoryMetadata
		{
			FlatTilesets = new[] { Tileset.Cultivation0, Tileset.Cultivation7, Tileset.Cultivation11 },
			OtherTilesets = new[]
			{
				Tileset.Cultivation1,
				Tileset.Cultivation2,
				Tileset.Cultivation3,
				Tileset.Cultivation4,
				Tileset.Cultivation5,
				Tileset.Cultivation6,
				Tileset.Cultivation8,
				Tileset.Cultivation9,
				Tileset.Cultivation10,
				Tileset.Cultivation12,
				Tileset.Cultivation13,
				Tileset.Cultivation14,
				Tileset.Cultivation15,
				Tileset.Cultivation16,
				Tileset.Cultivation17,
				Tileset.Cultivation18
			}
		};

		private static readonly TerrainCategoryMetadata mountain = new TerrainCategoryMetadata
		{
			FlatTilesets = new[] { Tileset.Mountain0, Tileset.Mountain1, Tileset.Mountain2 },
			OtherTilesets = new[]
			{
				Tileset.Mountain3,
				Tileset.Mountain4,
				Tileset.Mountain5,
				Tileset.Mountain6,
				Tileset.Mountain7,
				Tileset.Mountain8,
				Tileset.Mountain9,
				Tileset.Mountain10,
				Tileset.Mountain11,
				Tileset.Mountain12
			}
		};

		private static readonly TerrainCategoryMetadata desert = new TerrainCategoryMetadata
		{
			FlatTilesets = new[] { Tileset.Desert0, Tileset.Desert1, Tileset.Desert2 },
			OtherTilesets = new[]
			{
				Tileset.Desert3,
				Tileset.Desert4,
				Tileset.Desert5,
				Tileset.Desert6,
				Tileset.Desert7,
				Tileset.Desert8,
				Tileset.Desert9,
				Tileset.Desert10,
				Tileset.Desert11
			}
		};

		private static readonly TerrainCategoryMetadata polar = new TerrainCategoryMetadata
		{
			FlatTilesets = new[] { Tileset.Polar0, Tileset.Polar1, Tileset.Polar2 },
			OtherTilesets = new[]
			{
				Tileset.Polar3,
				Tileset.Polar4,
				Tileset.Polar5,
				Tileset.Polar6,
				Tileset.Polar7,
				Tileset.Polar8,
				Tileset.Polar9,
				Tileset.Polar10,
				Tileset.Polar11,
				Tileset.Polar12,
				Tileset.Polar13
			}
		};
	}
}
