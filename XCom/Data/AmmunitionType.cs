using System.Collections.Generic;
using XCom.Content.Items;

namespace XCom.Data
{
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
		BlasterBomb
	}

	public static class AmmunitionTypeExtensions
	{
		public static AmmunitionMetadata Metadata(this AmmunitionType ammunitionType) => metadata[ammunitionType];

		private static readonly AmmunitionMetadata pistolClip = new AmmunitionMetadata
		{
			ItemType = ItemType.PistolClip,
			Weapon = WeaponType.Pistol,
			DamageType = DamageType.ArmorPiercing,
			Damage = 26,
			Rounds = 12,
			Weight = 3,
			Image = Items.PistolClip,
			Width = 1,
			Height = 1
		};

		private static readonly AmmunitionMetadata rifleClip = new AmmunitionMetadata
		{
			ItemType = ItemType.RifleClip,
			Weapon = WeaponType.Rifle,
			DamageType = DamageType.ArmorPiercing,
			Damage = 30,
			Rounds = 20,
			Weight = 3,
			Image = Items.RifleClip,
			Width = 1,
			Height = 1
		};

		private static readonly AmmunitionMetadata hcApAmmo = new AmmunitionMetadata
		{
			ItemType = ItemType.HcApAmmo,
			Weapon = WeaponType.HeavyCannon,
			DamageType = DamageType.ArmorPiercing,
			Damage = 56,
			Rounds = 6,
			Weight = 6,
			Image = Items.HcApAmmo,
			Width = 2,
			Height = 1
		};

		private static readonly AmmunitionMetadata hcHeAmmo = new AmmunitionMetadata
		{
			ItemType = ItemType.HcHeAmmo,
			Weapon = WeaponType.HeavyCannon,
			DamageType = DamageType.HighExplosive,
			Damage = 52,
			Rounds = 6,
			Weight = 6,
			Image = Items.HcHeAmmo,
			Width = 2,
			Height = 1
		};

		private static readonly AmmunitionMetadata hcIAmmo = new AmmunitionMetadata
		{
			ItemType = ItemType.HcIAmmo,
			Weapon = WeaponType.HeavyCannon,
			DamageType = DamageType.Incendiary,
			Damage = 60,
			Rounds = 6,
			Weight = 6,
			Image = Items.HcIAmmo,
			Width = 2,
			Height = 1
		};

		private static readonly AmmunitionMetadata acApAmmo = new AmmunitionMetadata
		{
			ItemType = ItemType.AcApAmmo,
			Weapon = WeaponType.AutoCannon,
			DamageType = DamageType.ArmorPiercing,
			Damage = 42,
			Rounds = 14,
			Weight = 5,
			Image = Items.AcApAmmo,
			Width = 2,
			Height = 1
		};

		private static readonly AmmunitionMetadata acHeAmmo = new AmmunitionMetadata
		{
			ItemType = ItemType.AcHeAmmo,
			Weapon = WeaponType.AutoCannon,
			DamageType = DamageType.HighExplosive,
			Damage = 44,
			Rounds = 14,
			Weight = 5,
			Image = Items.AcHeAmmo,
			Width = 2,
			Height = 1
		};

		private static readonly AmmunitionMetadata acIAmmo = new AmmunitionMetadata
		{
			ItemType = ItemType.AcIAmmo,
			Weapon = WeaponType.AutoCannon,
			DamageType = DamageType.Incendiary,
			Damage = 48,
			Rounds = 14,
			Weight = 5,
			Image = Items.AcIAmmo,
			Width = 2,
			Height = 1
		};

		private static readonly AmmunitionMetadata smallRocket = new AmmunitionMetadata
		{
			ItemType = ItemType.SmallRocket,
			Weapon = WeaponType.RocketLauncher,
			DamageType = DamageType.HighExplosive,
			Damage = 75,
			Rounds = 1,
			Weight = 6,
			Image = Items.SmallRocket,
			Width = 1,
			Height = 3
		};

		private static readonly AmmunitionMetadata largeRocket = new AmmunitionMetadata
		{
			ItemType = ItemType.LargeRocket,
			Weapon = WeaponType.RocketLauncher,
			DamageType = DamageType.HighExplosive,
			Damage = 100,
			Rounds = 1,
			Weight = 8,
			Image = Items.LargeRocket,
			Width = 1,
			Height = 3
		};

		private static readonly AmmunitionMetadata incendiaryRocket = new AmmunitionMetadata
		{
			ItemType = ItemType.IncendiaryRocket,
			Weapon = WeaponType.RocketLauncher,
			DamageType = DamageType.Incendiary,
			Damage = 90,
			Rounds = 1,
			Weight = 8,
			Image = Items.IncendiaryRocket,
			Width = 1,
			Height = 3
		};

		private static readonly AmmunitionMetadata plasmaPistolClip = new AmmunitionMetadata
		{
			ItemType = ItemType.PlasmaPistolClip,
			Weapon = WeaponType.PlasmaPistol,
			DamageType = DamageType.PlasmaBeam,
			Damage = 52,
			Rounds = 26,
			Weight = 3,
			Image = Items.PlasmaPistolClip,
			Width = 1,
			Height = 1,
			DescriptionLines = new[]
			{
				"Power source for the small alien plasma pistol. Contains Elerium",
				"- the source of all alien power."
			}
		};

		private static readonly AmmunitionMetadata plasmaRifleClip = new AmmunitionMetadata
		{
			ItemType = ItemType.PlasmaRifleClip,
			Weapon = WeaponType.PlasmaRifle,
			DamageType = DamageType.PlasmaBeam,
			Damage = 80,
			Rounds = 28,
			Weight = 3,
			Image = Items.PlasmaPistolClip,
			Width = 1,
			Height = 1,
			DescriptionLines = new[]
			{
				"This small object is used as a power source for a plasma rifle",
				"- a medium powered alien weapon. Contains a small quantity of",
				"Elerium."
			}
		};

		private static readonly AmmunitionMetadata heavyPlasmaClip = new AmmunitionMetadata
		{
			ItemType = ItemType.HeavyPlasmaClip,
			Weapon = WeaponType.HeavyPlasma,
			DamageType = DamageType.PlasmaBeam,
			Damage = 115,
			Rounds = 35,
			Weight = 3,
			Image = Items.HeavyPlasmaClip,
			Width = 1,
			Height = 1,
			DescriptionLines = new[]
			{
				"This compact device is used as ammunition for a Heavy Plasma",
				"Gun. It contains a small quantity of Elerium."
			}
		};

		private static readonly AmmunitionMetadata stunBomb = new AmmunitionMetadata
		{
			ItemType = ItemType.StunBomb,
			Weapon = WeaponType.SmallLauncher,
			DamageType = DamageType.Stun,
			Damage = 90,
			Rounds = 1,
			Weight = 3,
			Image = Items.StunBomb,
			Width = 1,
			Height = 1,
			DescriptionLines = new[]
			{
				"The Stun bomb is used for capturing live human specimens, but",
				"it can also be used against most alien races. It is fired from a",
				"small launcher."
			}
		};

		private static readonly AmmunitionMetadata blasterBomb = new AmmunitionMetadata
		{
			ItemType = ItemType.BlasterBomb,
			Weapon = WeaponType.BlasterLauncher,
			DamageType = DamageType.HighExplosive,
			Damage = 200,
			Rounds = 1,
			Weight = 3,
			Image = Items.BlasterBomb,
			Width = 1,
			Height = 2,
			DescriptionLines = new[]
			{
				"This device is a highly explosive missile that has an intelligent",
				"guidance system. It is fired from a blaster launcher."
			}
		};

		private static readonly Dictionary<AmmunitionType, AmmunitionMetadata> metadata = new Dictionary<AmmunitionType, AmmunitionMetadata>
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
			{ AmmunitionType.BlasterBomb, blasterBomb }
		};
	}
}
