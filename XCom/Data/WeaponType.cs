using System.Collections.Generic;
using XCom.Battlescape.Tiles;
using XCom.Content.Items;

namespace XCom.Data
{
	public enum WeaponType
	{
		Pistol,
		Rifle,
		HeavyCannon,
		AutoCannon,
		RocketLauncher,
		LaserPistol,
		LaserRifle,
		HeavyLaser,
		PlasmaPistol,
		PlasmaRifle,
		HeavyPlasma,
		SmallLauncher,
		BlasterLauncher
	}

	public static class WeaponTypeExtensions
	{
		public static WeaponMetadata Metadata(this WeaponType weaponType) => metadata[weaponType];

		private static readonly WeaponMetadata pistol = new WeaponMetadata
		{
			ItemType = ItemType.Pistol,
			Shots = new[]
			{
				Shot.Snap(60, 18),
				Shot.Aimed(78, 30)
			},
			Weight = 5,
			Image = Items.Pistol,
			Width = 1,
			Height = 2,
			DescriptionLines = new[]
			{
				"The standard issue XCom pistol is a high powered",
				"semi-automatic with a 12 round capacity."
			},
			Sprites = BattleItemSprite.Pistol
		};

		private static readonly WeaponMetadata rifle = new WeaponMetadata
		{
			ItemType = ItemType.Rifle,
			Shots = new[]
			{
				Shot.Auto(35, 35),
				Shot.Snap(60, 25),
				Shot.Aimed(110, 80)
			},
			Weight = 8,
			IsTwoHanded = true,
			Image = Items.Rifle,
			Width = 1,
			Height = 3,
			DescriptionLines = new[]
			{
				"This highly accurate sniper rifle has laser guided sights and",
				"takes 6.7mm ammunition in 20 round clips."
			},
			Sprites = BattleItemSprite.Rifle
		};

		private static readonly WeaponMetadata heavyCannon = new WeaponMetadata
		{
			ItemType = ItemType.HeavyCannon,
			Shots = new[]
			{
				Shot.Snap(60, 33),
				Shot.Aimed(90, 80)
			},
			Weight = 18,
			IsTwoHanded = true,
			Image = Items.HeavyCannon,
			Width = 2,
			Height = 3,
			DescriptionLines = new[]
			{
				"The heavy cannon is a devastating,",
				"but cumbersome, weapon. Its",
				"versatility comes from the fact that",
				"it can take three types of",
				"ammunition - armor piercing,",
				"incendiary and high explosive."
			},
			Sprites = BattleItemSprite.HeavyCannon
		};

		private static readonly WeaponMetadata autoCannon = new WeaponMetadata
		{
			ItemType = ItemType.AutoCannon,
			Shots = new[]
			{
				Shot.Auto(32, 40),
				Shot.Snap(56, 33),
				Shot.Aimed(82, 80)
			},
			Weight = 19,
			IsTwoHanded = true,
			Image = Items.AutoCannon,
			Width = 2,
			Height = 3,
			DescriptionLines = new[]
			{
				"The auto-cannon combines the",
				"versatility and power of a heavy",
				"cannon with a faster fire rate."
			},
			Sprites = BattleItemSprite.AutoCannon
		};

		private static readonly WeaponMetadata rocketLauncher = new WeaponMetadata
		{
			ItemType = ItemType.RocketLauncher,
			Shots = new[]
			{
				Shot.Snap(55, 45),
				Shot.Aimed(115, 75)
			},
			Weight = 10,
			IsTwoHanded = true,
			Image = Items.RocketLauncher,
			Width = 2,
			Height = 3,
			DescriptionLines = new[]
			{
				"The rocket launcher is a laser guided",
				"system which can fire three different",
				"sizes of missile."
			},
			Sprites = BattleItemSprite.RocketLauncher
		};

		private static readonly WeaponMetadata laserPistol = new WeaponMetadata
		{
			ItemType = ItemType.LaserPistol,
			Shots = new[]
			{
				Shot.Auto(28, 25),
				Shot.Snap(40, 20),
				Shot.Aimed(68, 55)
			},
			Weight = 7,
			Image = Items.LaserPistol,
			Width = 1,
			Height = 2,
			DescriptionLines = new[]
			{
				"The laser pistol is an effective implementation of new",
				"technology. It has the convenience of a pistol with faster and",
				"more accurate firing."
			},
			Sprites = BattleItemSprite.LaserPistol
		};

		private static readonly WeaponMetadata laserRifle = new WeaponMetadata
		{
			ItemType = ItemType.LaserRifle,
			Shots = new[]
			{
				Shot.Auto(46, 34),
				Shot.Snap(65, 25),
				Shot.Aimed(100, 50)
			},
			Weight = 8,
			IsTwoHanded = true,
			Image = Items.LaserRifle,
			Width = 1,
			Height = 3,
			DescriptionLines = new[]
			{
				"The laser rifle is a more powerful and accurate version of the",
				"earlier pistol design."
			},
			Sprites = BattleItemSprite.LaserRifle
		};

		private static readonly WeaponMetadata heavyLaser = new WeaponMetadata
		{
			ItemType = ItemType.HeavyLaser,
			Shots = new[]
			{
				Shot.Snap(50, 33),
				Shot.Aimed(84, 75)
			},
			Weight = 18,
			IsTwoHanded = true,
			Image = Items.HeavyLaser,
			Width = 2,
			Height = 3,
			DescriptionLines = new[]
			{
				"The heavy laser is cumbersome, but extremely effective."
			},
			Sprites = BattleItemSprite.HeavyLaser
		};

		private static readonly WeaponMetadata heavyPlasma = new WeaponMetadata
		{
			ItemType = ItemType.HeavyPlasma,
			Shots = new[]
			{
				Shot.Auto(50, 35),
				Shot.Snap(75, 30),
				Shot.Aimed(110, 60)
			},
			Weight = 8,
			IsTwoHanded = true,
			Image = Items.HeavyPlasma,
			Width = 2,
			Height = 3,
			DescriptionLines = new[]
			{
				"This is a devastatingly powerful weapon based on accelerating",
				"particles from within a minute anti-gravity field"
			},
			Sprites = BattleItemSprite.HeavyPlasma
		};

		private static readonly WeaponMetadata plasmaRifle = new WeaponMetadata
		{
			ItemType = ItemType.PlasmaRifle,
			Shots = new[]
			{
				Shot.Auto(55, 36),
				Shot.Snap(86, 30),
				Shot.Aimed(100, 60)
			},
			Weight = 5,
			IsTwoHanded = true,
			Image = Items.PlasmaRifle,
			Width = 1,
			Height = 3,
			DescriptionLines = new[]
			{
				"This is a devastatingly powerful weapon based on accelerating",
				"particles from within a minute anti-gravity field"
			},
			Sprites = BattleItemSprite.PlasmaRifle
		};

		private static readonly WeaponMetadata plasmaPistol = new WeaponMetadata
		{
			ItemType = ItemType.PlasmaPistol,
			Shots = new[]
			{
				Shot.Auto(50, 30),
				Shot.Snap(65, 30),
				Shot.Aimed(85, 60)
			},
			Weight = 3,
			Image = Items.PlasmaPistol,
			Width = 1,
			Height = 2,
			DescriptionLines = new[]
			{
				"Plasma pistols are a lethal alien weapon based on accelerating",
				"particles from within a minute anti-gravity field"
			},
			Sprites = BattleItemSprite.PlasmaPistol
		};

		private static readonly WeaponMetadata blasterLauncher = new WeaponMetadata
		{
			ItemType = ItemType.BlasterLauncher,
			Shots = new[]
			{
				Shot.Aimed(120, 80)
			},
			Weight = 16,
			IsTwoHanded = true,
			Image = Items.BlasterLauncher,
			Width = 2,
			Height = 3,
			DescriptionLines = new[]
			{
				"This is an alien guided missile launcher which fires powerful",
				"'blaster bombs'. When you click to fire the weapon it will",
				"generate 'way points' for the blaster bomb to follow.  When",
				"you have positioned enough way points click on the special",
				"launch icon."
			},
			Sprites = BattleItemSprite.BlasterLauncher
		};

		private static readonly WeaponMetadata smallLauncher = new WeaponMetadata
		{
			ItemType = ItemType.SmallLauncher,
			Shots = new[]
			{
				Shot.Snap(65, 40),
				Shot.Aimed(110, 75)
			},
			Weight = 10,
			Image = Items.SmallLauncher,
			Width = 2,
			Height = 2,
			DescriptionLines = new[]
			{
				"A small launcher which fires stun bombs. Very useful for",
				"capturing live aliens."
			},
			Sprites = BattleItemSprite.SmallLauncher
		};

		private readonly static Dictionary<WeaponType, WeaponMetadata> metadata = new Dictionary<WeaponType, WeaponMetadata>
		{
			{ WeaponType.Pistol, pistol },
			{ WeaponType.Rifle, rifle },
			{ WeaponType.HeavyCannon, heavyCannon },
			{ WeaponType.AutoCannon, autoCannon },
			{ WeaponType.RocketLauncher, rocketLauncher },
			{ WeaponType.LaserPistol, laserPistol },
			{ WeaponType.LaserRifle, laserRifle },
			{ WeaponType.HeavyLaser, heavyLaser },
			{ WeaponType.HeavyPlasma, heavyPlasma },
			{ WeaponType.PlasmaRifle, plasmaRifle },
			{ WeaponType.PlasmaPistol, plasmaPistol },
			{ WeaponType.BlasterLauncher, blasterLauncher },
			{ WeaponType.SmallLauncher, smallLauncher }
		};
	}
}
