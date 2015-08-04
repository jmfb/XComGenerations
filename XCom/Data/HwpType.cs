using System.Collections.Generic;

namespace XCom.Data
{
	public enum HwpType
	{
		TankCannon,
		TankRocketLauncher,
		TankLaser,
		HovertankPlasma,
		HovertankLauncher
	}

	public static class HwpTypeExtensions
	{
		public static HwpMetadata Metadata(this HwpType hwpType)
		{
			return metadata[hwpType];
		}

		private static readonly HwpMetadata tankCannon = new HwpMetadata
		{
			Name = "Tank/Cannon",
			TimeUnits = 70,
			Health = 90,
			FrontArmor = 90,
			LeftArmor = 75,
			RightArmor = 75,
			RearArmor = 60,
			UnderArmor = 60,
			DamageType = DamageType.ArmorPiercing,
			Damage = 60,
			Ammunition = HwpAmmunitionType.CannonShell,
			Rounds = 30,
			Description = new[]
			{
				"Automated heavy weapons platforms are designed to",
				"complement an XCom squad. The combination of high fire power",
				"and strong armor makes these units valuable for open",
				"terrain fire fights. Make sur ethat there ar esufficient",
				"cannon shells in your stores to re-arm tanks. They are armed",
				"automatically when you assign them to a squad."
			}
		};

		private static readonly HwpMetadata tankRocketLauncher = new HwpMetadata
		{
			Name = "Tank/Rocket Launcher",
			TimeUnits = 70,
			Health = 90,
			FrontArmor = 90,
			LeftArmor = 75,
			RightArmor = 75,
			RearArmor = 60,
			UnderArmor = 60,
			DamageType = DamageType.RocketLauncher,
			Damage = 85,
			Ammunition = HwpAmmunitionType.Rocket,
			Rounds = 8,
			Description = new[]
			{
				"This automated heavy weapons platform is armed with powerful",
				"rockets.  This will be devastating for any alien foe.  Make sure",
				"your stores are kept supplied with HWP rockets."
			}
		};

		private static readonly HwpMetadata tankLaserCannon = new HwpMetadata
		{
			Name = "Tank/Laser Cannon",
			TimeUnits = 70,
			Health = 90,
			FrontArmor = 90,
			LeftArmor = 75,
			RightArmor = 75,
			RearArmor = 60,
			UnderArmor = 60,
			DamageType = DamageType.LaserBeam,
			Damage = 110,
			Ammunition = null,
			Rounds = 255,
			Description = new[]
			{
				"Laser weapons are a useful addition for HWPs. It combines",
				"heavy firepower with no ammunition restrictions."
			}
		};

		private static readonly HwpMetadata hovertankPlasma = new HwpMetadata
		{
			Name = "Hovertank/Plasma",
			TimeUnits = 100,
			Health = 90,
			FrontArmor = 130,
			LeftArmor = 130,
			RightArmor = 130,
			RearArmor = 130,
			UnderArmor = 100,
			DamageType = DamageType.PlasmaBeam,
			Damage = 110,
			Ammunition = null,
			Rounds = 255,
			Description = new[]
			{
				"Alien technology has given the HWP a new lease of life. The",
				"added maneuverability of air travel and the power of plasma",
				"beams is a lethal combination."
			}
		};

		private static readonly HwpMetadata hovertankLauncher = new HwpMetadata
		{
			Name = "Hovertank/Launcher",
			TimeUnits = 100,
			Health = 90,
			FrontArmor = 130,
			LeftArmor = 130,
			RightArmor = 130,
			RearArmor = 130,
			UnderArmor = 100,
			DamageType = DamageType.FusionBallLauncher,
			Damage = 140,
			Ammunition = HwpAmmunitionType.FusionBomb,
			Rounds = 8,
			Description = new[]
			{
				"This hovertank has a fusion ball launcher that is capable of",
				"immense devastation.  Use it with great care.  You wlil have",
				"to manufacture the fusion balls to keep these HWPs fully",
				"armed. A fusion ball is an intelligent guided weapon. In order",
				"to fire it you select a number of 'way points' with hte cursor",
				"and then click on the launch icon to fire the fusion ball."
			}
		};

		private static readonly Dictionary<HwpType, HwpMetadata> metadata = new Dictionary<HwpType,HwpMetadata>
		{
			{ HwpType.TankCannon, tankCannon },
			{ HwpType.TankRocketLauncher, tankRocketLauncher },
			{ HwpType.TankLaser, tankLaserCannon },
			{ HwpType.HovertankPlasma, hovertankPlasma },
			{ HwpType.HovertankLauncher, hovertankLauncher }
		};
	}
}
