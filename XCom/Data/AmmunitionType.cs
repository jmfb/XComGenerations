using XCom.Battlescape.Tiles;
using XCom.Content.Items;

namespace XCom.Data;

public enum AmmunitionType
{
	PistolClip,
	RifleClip,
	HcApAmmo,
	HcHeAmmo,
	HcIAmmo,
	AcApAmmo,
	AcHeAmmo,
	AcIAmmo,
	SmallRocket,
	LargeRocket,
	IncendiaryRocket,

	PlasmaPistolClip,
	PlasmaRifleClip,
	HeavyPlasmaClip,
	StunBomb,
	BlasterBomb,
}

public static class AmmunitionTypeExtensions
{
	public static AmmunitionMetadata Metadata(this AmmunitionType ammunitionType) =>
		metadata[ammunitionType];

	private static readonly AmmunitionMetadata pistolClip = new()
	{
		ItemType = ItemType.PistolClip,
		Weapon = WeaponType.Pistol,
		DamageType = DamageType.ArmorPiercing,
		Damage = 26,
		Rounds = 12,
		Weight = 3,
		Image = Items.PistolClip,
		GroundImages = GroundSprite.PistolClip,
		Width = 1,
		Height = 1,
	};

	private static readonly AmmunitionMetadata rifleClip = new()
	{
		ItemType = ItemType.RifleClip,
		Weapon = WeaponType.Rifle,
		DamageType = DamageType.ArmorPiercing,
		Damage = 30,
		Rounds = 20,
		Weight = 3,
		Image = Items.RifleClip,
		GroundImages = GroundSprite.RifleClip,
		Width = 1,
		Height = 1,
	};

	private static readonly AmmunitionMetadata hcApAmmo = new()
	{
		ItemType = ItemType.HcApAmmo,
		Weapon = WeaponType.HeavyCannon,
		DamageType = DamageType.ArmorPiercing,
		Damage = 56,
		Rounds = 6,
		Weight = 6,
		Image = Items.HcApAmmo,
		GroundImages = GroundSprite.HcApAmmo,
		Width = 2,
		Height = 1,
	};

	private static readonly AmmunitionMetadata hcHeAmmo = new()
	{
		ItemType = ItemType.HcHeAmmo,
		Weapon = WeaponType.HeavyCannon,
		DamageType = DamageType.HighExplosive,
		Damage = 52,
		Rounds = 6,
		Weight = 6,
		Image = Items.HcHeAmmo,
		GroundImages = GroundSprite.HcHeAmmo,
		Width = 2,
		Height = 1,
	};

	private static readonly AmmunitionMetadata hcIAmmo = new()
	{
		ItemType = ItemType.HcIAmmo,
		Weapon = WeaponType.HeavyCannon,
		DamageType = DamageType.Incendiary,
		Damage = 60,
		Rounds = 6,
		Weight = 6,
		Image = Items.HcIAmmo,
		GroundImages = GroundSprite.HcIAmmo,
		Width = 2,
		Height = 1,
	};

	private static readonly AmmunitionMetadata acApAmmo = new()
	{
		ItemType = ItemType.AcApAmmo,
		Weapon = WeaponType.AutoCannon,
		DamageType = DamageType.ArmorPiercing,
		Damage = 42,
		Rounds = 14,
		Weight = 5,
		Image = Items.AcApAmmo,
		GroundImages = GroundSprite.AcApAmmo,
		Width = 2,
		Height = 1,
	};

	private static readonly AmmunitionMetadata acHeAmmo = new()
	{
		ItemType = ItemType.AcHeAmmo,
		Weapon = WeaponType.AutoCannon,
		DamageType = DamageType.HighExplosive,
		Damage = 44,
		Rounds = 14,
		Weight = 5,
		Image = Items.AcHeAmmo,
		GroundImages = GroundSprite.AcHeAmmo,
		Width = 2,
		Height = 1,
	};

	private static readonly AmmunitionMetadata acIAmmo = new()
	{
		ItemType = ItemType.AcIAmmo,
		Weapon = WeaponType.AutoCannon,
		DamageType = DamageType.Incendiary,
		Damage = 48,
		Rounds = 14,
		Weight = 5,
		Image = Items.AcIAmmo,
		GroundImages = GroundSprite.AcIAmmo,
		Width = 2,
		Height = 1,
	};

	private static readonly AmmunitionMetadata smallRocket = new()
	{
		ItemType = ItemType.SmallRocket,
		Weapon = WeaponType.RocketLauncher,
		DamageType = DamageType.HighExplosive,
		Damage = 75,
		Rounds = 1,
		Weight = 6,
		Image = Items.SmallRocket,
		GroundImages = GroundSprite.SmallRocket,
		Width = 1,
		Height = 3,
	};

	private static readonly AmmunitionMetadata largeRocket = new()
	{
		ItemType = ItemType.LargeRocket,
		Weapon = WeaponType.RocketLauncher,
		DamageType = DamageType.HighExplosive,
		Damage = 100,
		Rounds = 1,
		Weight = 8,
		Image = Items.LargeRocket,
		GroundImages = GroundSprite.LargeRocket,
		Width = 1,
		Height = 3,
	};

	private static readonly AmmunitionMetadata incendiaryRocket = new()
	{
		ItemType = ItemType.IncendiaryRocket,
		Weapon = WeaponType.RocketLauncher,
		DamageType = DamageType.Incendiary,
		Damage = 90,
		Rounds = 1,
		Weight = 8,
		Image = Items.IncendiaryRocket,
		GroundImages = GroundSprite.IncendiaryRocket,
		Width = 1,
		Height = 3,
	};

	private static readonly AmmunitionMetadata plasmaPistolClip = new()
	{
		ItemType = ItemType.PlasmaPistolClip,
		Weapon = WeaponType.PlasmaPistol,
		DamageType = DamageType.PlasmaBeam,
		Damage = 52,
		Rounds = 26,
		Weight = 3,
		Image = Items.PlasmaPistolClip,
		GroundImages = GroundSprite.PlasmaClip,
		Width = 1,
		Height = 1,
		DescriptionLines =
		[
			"Power source for the small alien plasma pistol. Contains Elerium",
			"- the source of all alien power."
		],
	};

	private static readonly AmmunitionMetadata plasmaRifleClip = new()
	{
		ItemType = ItemType.PlasmaRifleClip,
		Weapon = WeaponType.PlasmaRifle,
		DamageType = DamageType.PlasmaBeam,
		Damage = 80,
		Rounds = 28,
		Weight = 3,
		Image = Items.PlasmaPistolClip,
		GroundImages = GroundSprite.PlasmaClip,
		Width = 1,
		Height = 1,
		DescriptionLines =
		[
			"This small object is used as a power source for a plasma rifle",
			"- a medium powered alien weapon. Contains a small quantity of",
			"Elerium."
		],
	};

	private static readonly AmmunitionMetadata heavyPlasmaClip = new()
	{
		ItemType = ItemType.HeavyPlasmaClip,
		Weapon = WeaponType.HeavyPlasma,
		DamageType = DamageType.PlasmaBeam,
		Damage = 115,
		Rounds = 35,
		Weight = 3,
		Image = Items.HeavyPlasmaClip,
		GroundImages = GroundSprite.PlasmaClip,
		Width = 1,
		Height = 1,
		DescriptionLines =
		[
			"This compact device is used as ammunition for a Heavy Plasma",
			"Gun. It contains a small quantity of Elerium."
		],
	};

	private static readonly AmmunitionMetadata stunBomb = new()
	{
		ItemType = ItemType.StunBomb,
		Weapon = WeaponType.SmallLauncher,
		DamageType = DamageType.Stun,
		Damage = 90,
		Rounds = 1,
		Weight = 3,
		Image = Items.StunBomb,
		GroundImages = GroundSprite.StunBomb,
		Width = 1,
		Height = 1,
		DescriptionLines =
		[
			"The Stun bomb is used for capturing live human specimens, but",
			"it can also be used against most alien races. It is fired from a",
			"small launcher."
		],
	};

	private static readonly AmmunitionMetadata blasterBomb = new()
	{
		ItemType = ItemType.BlasterBomb,
		Weapon = WeaponType.BlasterLauncher,
		DamageType = DamageType.HighExplosive,
		Damage = 200,
		Rounds = 1,
		Weight = 3,
		Image = Items.BlasterBomb,
		GroundImages = GroundSprite.BlasterBomb,
		Width = 1,
		Height = 2,
		DescriptionLines =
		[
			"This device is a highly explosive missile that has an intelligent",
			"guidance system. It is fired from a blaster launcher."
		],
	};

	private static readonly Dictionary<AmmunitionType, AmmunitionMetadata> metadata =
		new()
		{
			{ AmmunitionType.PistolClip, pistolClip },
			{ AmmunitionType.RifleClip, rifleClip },
			{ AmmunitionType.HcApAmmo, hcApAmmo },
			{ AmmunitionType.HcHeAmmo, hcHeAmmo },
			{ AmmunitionType.HcIAmmo, hcIAmmo },
			{ AmmunitionType.AcApAmmo, acApAmmo },
			{ AmmunitionType.AcHeAmmo, acHeAmmo },
			{ AmmunitionType.AcIAmmo, acIAmmo },
			{ AmmunitionType.SmallRocket, smallRocket },
			{ AmmunitionType.LargeRocket, largeRocket },
			{ AmmunitionType.IncendiaryRocket, incendiaryRocket },
			{ AmmunitionType.PlasmaPistolClip, plasmaPistolClip },
			{ AmmunitionType.PlasmaRifleClip, plasmaRifleClip },
			{ AmmunitionType.HeavyPlasmaClip, heavyPlasmaClip },
			{ AmmunitionType.StunBomb, stunBomb },
			{ AmmunitionType.BlasterBomb, blasterBomb },
		};
}
