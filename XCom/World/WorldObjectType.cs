using System.Collections.Generic;

namespace XCom.World
{
	public enum WorldObjectType
	{
		AlienBase,
		XcomBase,
		TerrorSite,
		CrashSite,
		LandingSite,
		Interceptor,
		Waypoint,
		Ufo
	}

	public static class WorldObjectTypeExtensions
	{
		public static WorldObjectMetadata Metadata(this WorldObjectType worldObjectType) => metadata[worldObjectType];

		private static readonly WorldObjectMetadata alienBase = new WorldObjectMetadata
		{
			Name = "Alien Base",
			PaletteIndex = 1,
			Mask = new[]
			{
				new[] { true, true, true },
				new[] { true, false, true },
				new[] { true, true, true }
			}
		};

		private static readonly WorldObjectMetadata xcomBase = new WorldObjectMetadata
		{
			Name = "XCom Base",
			PaletteIndex = 9,
			Mask = new[]
			{
				new[] { true, true, true },
				new[] { true, false, true },
				new[] { true, true, true }
			}
		};

		private static readonly WorldObjectMetadata terrorSite = new WorldObjectMetadata
		{
			Name = "Terror Site",
			PaletteIndex = 1,
			Mask = new[]
			{
				new[] { false, true, false },
				new[] { true, true, true },
				new[] { false, true, false }
			}
		};

		private static readonly WorldObjectMetadata crashSite = new WorldObjectMetadata
		{
			Name = "Crash Site",
			PaletteIndex = 5,
			Mask = new[]
			{
				new[] { true, false, true },
				new[] { false, true, false },
				new[] { true, false, true }
			}
		};

		private static readonly WorldObjectMetadata landingSite = new WorldObjectMetadata
		{
			Name = "Landing Site",
			PaletteIndex = 7,
			Mask = new[]
			{
				new[] { true, false, true },
				new[] { false, true, false },
				new[] { true, false, true }
			}
		};

		private static readonly WorldObjectMetadata interceptor = new WorldObjectMetadata
		{
			Name = "Interceptor",
			PaletteIndex = 11,
			Mask = new[]
			{
				new[] { false, true, false },
				new[] { true, false, true },
				new[] { false, true, false }
			}
		};

		private static readonly WorldObjectMetadata waypoint = new WorldObjectMetadata
		{
			Name = "Waypoint",
			PaletteIndex = 3,
			Mask = new[]
			{
				new[] { true, false, true },
				new[] { false, true, false },
				new[] { true, false, true }
			}
		};

		private static readonly WorldObjectMetadata ufo = new WorldObjectMetadata
		{
			Name = "UFO",
			PaletteIndex = 13,
			Mask = new[]
			{
				new[] { false, true, false },
				new[] { true, true, true },
				new[] { false, true, false }
			}
		};

		private static readonly Dictionary<WorldObjectType, WorldObjectMetadata> metadata = new Dictionary<WorldObjectType, WorldObjectMetadata>
		{
			{ WorldObjectType.AlienBase, alienBase },
			{ WorldObjectType.XcomBase, xcomBase },
			{ WorldObjectType.TerrorSite, terrorSite },
			{ WorldObjectType.CrashSite, crashSite },
			{ WorldObjectType.LandingSite, landingSite },
			{ WorldObjectType.Interceptor, interceptor },
			{ WorldObjectType.Waypoint, waypoint },
			{ WorldObjectType.Ufo, ufo }
		};
	}
}
