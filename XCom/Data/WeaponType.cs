using XCom.Battlescape.Tiles;
using XCom.Content.Items;

namespace XCom.Data;

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
	BlasterLauncher,
}

public static class WeaponTypeExtensions
{
	public static WeaponMetadata Metadata(this WeaponType weaponType) => metadata[weaponType];

	private static readonly WeaponMetadata pistol = new()
	{
		ItemType = ItemType.Pistol,
		Shots = [Shot.Snap(60, 18), Shot.Aimed(78, 30)],
		Weight = 5,
		Image = Items.Pistol,
		GroundImages = GroundSprite.Pistol,
		Width = 1,
		Height = 2,
		DescriptionLines =
		[
			"The standard issue XCom pistol is a high powered",
			"semi-automatic with a 12 round capacity."
		],
		Sprites = BattleItemSprite.Pistol,
	};

	private static readonly WeaponMetadata rifle = new()
	{
		ItemType = ItemType.Rifle,
		Shots = [Shot.Auto(35, 35), Shot.Snap(60, 25), Shot.Aimed(110, 80)],
		Weight = 8,
		IsTwoHanded = true,
		Image = Items.Rifle,
		GroundImages = GroundSprite.Rifle,
		Width = 1,
		Height = 3,
		DescriptionLines =
		[
			"This highly accurate sniper rifle has laser guided sights and",
			"takes 6.7mm ammunition in 20 round clips."
		],
		Sprites = BattleItemSprite.Rifle,
	};

	private static readonly WeaponMetadata heavyCannon = new()
	{
		ItemType = ItemType.HeavyCannon,
		Shots = [Shot.Snap(60, 33), Shot.Aimed(90, 80)],
		Weight = 18,
		IsTwoHanded = true,
		Image = Items.HeavyCannon,
		GroundImages = GroundSprite.HeavyCannon,
		Width = 2,
		Height = 3,
		DescriptionLines =
		[
			"The heavy cannon is a devastating,",
			"but cumbersome, weapon. Its",
			"versatility comes from the fact that",
			"it can take three types of",
			"ammunition - armor piercing,",
			"incendiary and high explosive."
		],
		Sprites = BattleItemSprite.HeavyCannon,
	};

	private static readonly WeaponMetadata autoCannon = new()
	{
		ItemType = ItemType.AutoCannon,
		Shots = [Shot.Auto(32, 40), Shot.Snap(56, 33), Shot.Aimed(82, 80)],
		Weight = 19,
		IsTwoHanded = true,
		Image = Items.AutoCannon,
		GroundImages = GroundSprite.AutoCannon,
		Width = 2,
		Height = 3,
		DescriptionLines =
		[
			"The auto-cannon combines the",
			"versatility and power of a heavy",
			"cannon with a faster fire rate."
		],
		Sprites = BattleItemSprite.AutoCannon,
	};

	private static readonly WeaponMetadata rocketLauncher = new()
	{
		ItemType = ItemType.RocketLauncher,
		Shots = [Shot.Snap(55, 45), Shot.Aimed(115, 75)],
		Weight = 10,
		IsTwoHanded = true,
		Image = Items.RocketLauncher,
		GroundImages = GroundSprite.RocketLauncher,
		Width = 2,
		Height = 3,
		DescriptionLines =
		[
			"The rocket launcher is a laser guided",
			"system which can fire three different",
			"sizes of missile."
		],
		Sprites = BattleItemSprite.RocketLauncher,
	};

	private static readonly WeaponMetadata laserPistol = new()
	{
		ItemType = ItemType.LaserPistol,
		Shots = [Shot.Auto(28, 25), Shot.Snap(40, 20), Shot.Aimed(68, 55)],
		Weight = 7,
		Image = Items.LaserPistol,
		GroundImages = GroundSprite.LaserPistol,
		Width = 1,
		Height = 2,
		DescriptionLines =
		[
			"The laser pistol is an effective implementation of new",
			"technology. It has the convenience of a pistol with faster and",
			"more accurate firing."
		],
		Sprites = BattleItemSprite.LaserPistol,
	};

	private static readonly WeaponMetadata laserRifle = new()
	{
		ItemType = ItemType.LaserRifle,
		Shots = [Shot.Auto(46, 34), Shot.Snap(65, 25), Shot.Aimed(100, 50)],
		Weight = 8,
		IsTwoHanded = true,
		Image = Items.LaserRifle,
		GroundImages = GroundSprite.LaserRifle,
		Width = 1,
		Height = 3,
		DescriptionLines =
		[
			"The laser rifle is a more powerful and accurate version of the",
			"earlier pistol design."
		],
		Sprites = BattleItemSprite.LaserRifle,
	};

	private static readonly WeaponMetadata heavyLaser = new()
	{
		ItemType = ItemType.HeavyLaser,
		Shots = [Shot.Snap(50, 33), Shot.Aimed(84, 75)],
		Weight = 18,
		IsTwoHanded = true,
		Image = Items.HeavyLaser,
		GroundImages = GroundSprite.HeavyLaser,
		Width = 2,
		Height = 3,
		DescriptionLines = ["The heavy laser is cumbersome, but extremely effective."],
		Sprites = BattleItemSprite.HeavyLaser,
	};

	private static readonly WeaponMetadata heavyPlasma = new()
	{
		ItemType = ItemType.HeavyPlasma,
		Shots = [Shot.Auto(50, 35), Shot.Snap(75, 30), Shot.Aimed(110, 60)],
		Weight = 8,
		IsTwoHanded = true,
		Image = Items.HeavyPlasma,
		GroundImages = GroundSprite.HeavyPlasma,
		Width = 2,
		Height = 3,
		DescriptionLines =
		[
			"This is a devastatingly powerful weapon based on accelerating",
			"particles from within a minute anti-gravity field"
		],
		Sprites = BattleItemSprite.HeavyPlasma,
	};

	private static readonly WeaponMetadata plasmaRifle = new()
	{
		ItemType = ItemType.PlasmaRifle,
		Shots = [Shot.Auto(55, 36), Shot.Snap(86, 30), Shot.Aimed(100, 60)],
		Weight = 5,
		IsTwoHanded = true,
		Image = Items.PlasmaRifle,
		GroundImages = GroundSprite.PlasmaRifle,
		Width = 1,
		Height = 3,
		DescriptionLines =
		[
			"This is a devastatingly powerful weapon based on accelerating",
			"particles from within a minute anti-gravity field"
		],
		Sprites = BattleItemSprite.PlasmaRifle,
	};

	private static readonly WeaponMetadata plasmaPistol = new()
	{
		ItemType = ItemType.PlasmaPistol,
		Shots = [Shot.Auto(50, 30), Shot.Snap(65, 30), Shot.Aimed(85, 60)],
		Weight = 3,
		Image = Items.PlasmaPistol,
		GroundImages = GroundSprite.PlasmaPistol,
		Width = 1,
		Height = 2,
		DescriptionLines =
		[
			"Plasma pistols are a lethal alien weapon based on accelerating",
			"particles from within a minute anti-gravity field"
		],
		Sprites = BattleItemSprite.PlasmaPistol,
	};

	private static readonly WeaponMetadata blasterLauncher = new()
	{
		ItemType = ItemType.BlasterLauncher,
		Shots = [Shot.Aimed(120, 80)],
		Weight = 16,
		IsTwoHanded = true,
		Image = Items.BlasterLauncher,
		GroundImages = GroundSprite.BlasterLauncher,
		Width = 2,
		Height = 3,
		DescriptionLines =
		[
			"This is an alien guided missile launcher which fires powerful",
			"'blaster bombs'. When you click to fire the weapon it will",
			"generate 'way points' for the blaster bomb to follow.  When",
			"you have positioned enough way points click on the special",
			"launch icon."
		],
		Sprites = BattleItemSprite.BlasterLauncher,
	};

	private static readonly WeaponMetadata smallLauncher = new()
	{
		ItemType = ItemType.SmallLauncher,
		Shots = [Shot.Snap(65, 40), Shot.Aimed(110, 75)],
		Weight = 10,
		Image = Items.SmallLauncher,
		GroundImages = GroundSprite.SmallLauncher,
		Width = 2,
		Height = 2,
		DescriptionLines =
		[
			"A small launcher which fires stun bombs. Very useful for",
			"capturing live aliens."
		],
		Sprites = BattleItemSprite.SmallLauncher,
	};

	private static readonly Dictionary<WeaponType, WeaponMetadata> metadata = new()
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
		{ WeaponType.SmallLauncher, smallLauncher },
	};
}
