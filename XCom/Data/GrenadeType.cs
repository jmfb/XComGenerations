using System.Collections.Generic;
using XCom.Battlescape.Tiles;
using XCom.Content.Items;

namespace XCom.Data
{
	public enum GrenadeType
	{
		Grenade,
		SmokeGrenade,
		ProximityGrenade,
		HighExplosive,
		AlienGrenade
	}

	public static class GenadeTypeExtensions
	{
		public static GrenadeMetadata Metadata(this GrenadeType grenadeType) => metadata[grenadeType];

		private static readonly GrenadeMetadata grenade = new GrenadeMetadata
		{
			ItemType = ItemType.Grenade,
			DamageType = DamageType.HighExplosive,
			Damage = 50,
			Weight = 3,
			Image = Items.Grenade,
			Width = 1,
			Height = 1,
			DescriptionLines = new[]
			{
				"This standard issue grenade has an accurate and sophisticated",
				"timer for precision control."
			},
			Sprites = BattleItemSprite.Grenade
		};

		private static readonly GrenadeMetadata smokeGrenade = new GrenadeMetadata
		{
			ItemType = ItemType.SmokeGrenade,
			DamageType = DamageType.Smoke,
			Damage = 60,
			Weight = 3,
			Image = Items.SmokeGrenade,
			Width = 1,
			Height = 1,
			DescriptionLines = new[]
			{
				"Smoke grenades are useful for providing cover in exposed",
				"combat situations.  Use with care because they can benefit the",
				"enemy as well"
			}
		};

		private static readonly GrenadeMetadata proximityGrenade = new GrenadeMetadata
		{
			ItemType = ItemType.ProximityGrenade,
			DamageType = DamageType.HighExplosive,
			Damage = 70,
			Weight = 3,
			Image = Items.ProximityGrenade,
			Width = 1,
			Height = 1,
			DescriptionLines = new[]
			{
				"A proximity grenade can be thrown like an ordinary grenade",
				"but is triggered by nearby movement after it lands. Great skill",
				"and care is required to use these devices properly."
			}
		};

		private static readonly GrenadeMetadata highExplosive = new GrenadeMetadata
		{
			ItemType = ItemType.HighExplosive,
			DamageType = DamageType.HighExplosive,
			Damage = 110,
			Weight = 6,
			Image = Items.HighExplosive,
			Width = 2,
			Height = 1,
			DescriptionLines = new[]
			{
				"This explosive should only be used for demolition purposes.",
				"Keep personnel clear of demolition sites."
			}
		};

		private static readonly GrenadeMetadata alienGrenade = new GrenadeMetadata
		{
			ItemType = ItemType.AlienGrenade,
			DamageType = DamageType.HighExplosive,
			Damage = 90,
			Weight = 3,
			Image = Items.AlienGrenade,
			Width = 1,
			Height = 1,
			DescriptionLines = new[]
			{
				"This device works in the same way as a terrestrial grenade -",
				"except that it is more powerful."
			}
		};

		private static readonly Dictionary<GrenadeType, GrenadeMetadata> metadata = new Dictionary<GrenadeType, GrenadeMetadata>
		{
			{ GrenadeType.Grenade, grenade },
			{ GrenadeType.SmokeGrenade, smokeGrenade },
			{ GrenadeType.ProximityGrenade, proximityGrenade },
			{ GrenadeType.HighExplosive, highExplosive },
			{ GrenadeType.AlienGrenade, alienGrenade }
		};
	}
}
