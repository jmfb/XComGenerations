using System.Collections.Generic;
using XCom.Battlescape.Tiles;
using XCom.Content.Images.Crafts;
using XCom.Content.Overlays;
using XCom.Graphics;

namespace XCom.Data
{
	public enum CraftType
	{
		Skyranger,
		Interceptor,
		Firestorm,
		Lightning,
		Avenger
	}

	public static class CraftTypeExtensions
	{
		public static CraftMetadata Metadata(this CraftType craftType)
		{
			return metadata[craftType];
		}

		private static readonly CraftMetadata skyranger = new CraftMetadata
		{
			Name = "SKYRANGER",
			Damage = 150,
			Fuel = 1500,
			FuelType = FuelType.Normal,
			WeaponCount = 0,
			Space = 14,
			HwpCount = 3,
			Speed = 760,
			Acceleration = 2,
			Image = new Image(Crafts.Skyranger),
			RowOffset = 17,
			ColumnOffset = 19,
			Overlay = Overlays.Skyranger,
			DescriptionLines = new[]
			{
				"TROOP TRANSPORTER. THE",
				"FASTEST OF ITS KIND, WITH",
				"VERTICAL TAKE OFF AND",
				"LANDING (V.T.O.L) CAPABILITY."
			},
			Tileset = Tileset.Skyranger
		};

		private static readonly CraftMetadata interceptor = new CraftMetadata
		{
			Name = "INTERCEPTOR",
			Damage = 100,
			Fuel = 1000,
			FuelType = FuelType.Normal,
			WeaponCount = 2,
			Space = 0,
			HwpCount = 0,
			Speed = 2100,
			Acceleration = 3,
			Image = new Image(Crafts.Interceptor),
			RowOffset = 21,
			ColumnOffset = 23,
			Overlay = Overlays.Interceptor,
			DescriptionLines = new[]
			{
				"COMBAT AIRCRAFT WITH DUAL PULSE",
				"DETONATION ENGINES AND SPECIALLY SHIELDED",
				"ELECTRONIC SYSTEMS. THE BEST AVAILABLE",
				"EARTH BASED TECHNOLOGY."
			},
			ShowStatsOnBottom = true
		};

		private static readonly CraftMetadata firestorm = new CraftMetadata
		{
			Name = "FIRESTORM",
			Damage = 500,
			Fuel = 20,
			FuelType = FuelType.Elerium115,
			WeaponCount = 2,
			Space = 0,
			HwpCount = 0,
			Speed = 4200,
			Acceleration = 9,
			Image = new Image(Crafts.Firestorm),
			RowOffset = 26,
			ColumnOffset = 27,
			Overlay = Overlays.Firestorm,
			DescriptionLines = new[]
			{
				"COMBAT CRAFT.  THIS ONE-MAN",
				"FIGHTER REPLICATES THE",
				"CLASSIC ALIEN FLYING SAUCER",
				"DESIGN, WITH CENTRAL",
				"PROPULSION UNIT."
			}
		};

		private static readonly CraftMetadata lightning = new CraftMetadata
		{
			Name = "LIGHTNING",
			Damage = 800,
			Fuel = 30,
			FuelType = FuelType.Elerium115,
			WeaponCount = 1,
			Space = 12,
			HwpCount = 0,
			Speed = 3100,
			Acceleration = 8,
			Image = new Image(Crafts.Lightning),
			RowOffset = 23,
			ColumnOffset = 24,
			Overlay = Overlays.Lightning,
			DescriptionLines = new[]
			{
				"TRANSPORTER AND COMBAT CRAFT.  A CRUDE BUT EFFECTIVE",
				"REPLICATION OF ALIEN PROPULSION SYSTEMS."
			},
			ShowStatsOnBottom = true,
			Tileset = Tileset.Lightning
		};

		private static readonly CraftMetadata avenger = new CraftMetadata
		{
			Name = "AVENGER",
			Damage = 1200,
			Fuel = 60,
			FuelType = FuelType.Elerium115,
			WeaponCount = 2,
			Space = 26,
			HwpCount = 4,
			Speed = 5400,
			Acceleration = 10,
			Image = new Image(Crafts.Avenger),
			RowOffset = 20,
			ColumnOffset = 23,
			Overlay = Overlays.Avenger,
			DescriptionLines = new[]
			{
				"TRANSPORTER AND COMBAT",
				"SPACEFRACT.  THE ULTIMATE",
				"REPLICATION OF ALIEN",
				"TECHNOLOGY."
			},
			Tileset = Tileset.Avenger
		};

		private static readonly Dictionary<CraftType, CraftMetadata> metadata = new Dictionary<CraftType,CraftMetadata>
 		{
			{ CraftType.Skyranger, skyranger },
			{ CraftType.Interceptor, interceptor },
			{ CraftType.Firestorm, firestorm },
			{ CraftType.Lightning, lightning },
			{ CraftType.Avenger, avenger }
		};
	}
}
