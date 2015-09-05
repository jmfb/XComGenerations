using System.Collections.Generic;

namespace XCom.Data
{
	public enum DamageType
	{
		ArmorPiercing,
		RocketLauncher,
		LaserBeam,
		PlasmaBeam,
		FusionBallLauncher
	}

	public static class DamageTypeExtensions
	{
		public static DamageMetadata Metadata(this DamageType damageType)
		{
			return metadata[damageType];
		}

		private static DamageMetadata Damage(string name)
		{
			return new DamageMetadata
			{
				Name = name
			};
		}

		private static readonly Dictionary<DamageType, DamageMetadata> metadata = new Dictionary<DamageType, DamageMetadata>
		{
			{ DamageType.ArmorPiercing, Damage("ARMOR PIERCING") },
			{ DamageType.RocketLauncher, Damage("ROCKET LAUNCHER") },
			{ DamageType.LaserBeam, Damage("LASER BEAM") },
			{ DamageType.PlasmaBeam, Damage("PLASMA BEAM") },
			{ DamageType.FusionBallLauncher, Damage("FUSION BALL LAUNCHER") }
		};
	}
}
