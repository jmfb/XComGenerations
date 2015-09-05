using System.Collections.Generic;

namespace XCom.Data
{
	public enum HwpAmmunitionType
	{
		CannonShell,
		Rocket,
		FusionBomb
	}

	public static class HwpAmmunitionTypeExtensions
	{
		public static HwpAmmunitionMetadata Metadata(this HwpAmmunitionType ammunitionType)
		{
			return metadata[ammunitionType];
		}

		private static HwpAmmunitionMetadata Ammo(string name)
		{
			return new HwpAmmunitionMetadata
			{
				Name = name
			};
		}

		private static readonly Dictionary<HwpAmmunitionType, HwpAmmunitionMetadata> metadata = new Dictionary<HwpAmmunitionType, HwpAmmunitionMetadata>
		{
			{ HwpAmmunitionType.CannonShell, Ammo("HWP Cannon Shells") },
			{ HwpAmmunitionType.Rocket, Ammo("HWP Rockets") },
			{ HwpAmmunitionType.FusionBomb, Ammo("HWP Fusion Bomb") }
		};
	}
}