using System.Collections.Generic;

namespace XCom.Data
{
	public enum ArmorType
	{
		PersonalArmor,
		PowerSuit,
		FlyingSuit
	}

	public static class ArmorTypeExtensions
	{
		public static ArmorMetadata Metadata(this ArmorType armorType)
		{
			return metadata[armorType];
		}

		private static readonly ArmorMetadata personalArmor = new ArmorMetadata
		{
			Name = "PERSONAL ARMOR"
		};

		private static readonly ArmorMetadata powerSuit = new ArmorMetadata
		{
			Name = "POWER SUIT"
		};

		private static readonly ArmorMetadata flyingSuit = new ArmorMetadata
		{
			Name = "FLYING SUIT"
		};

		private static readonly Dictionary<ArmorType, ArmorMetadata> metadata = new Dictionary<ArmorType,ArmorMetadata>
		{
			{ ArmorType.PersonalArmor, personalArmor },
			{ ArmorType.PowerSuit, powerSuit },
			{ ArmorType.FlyingSuit, flyingSuit }
		};
	}
}
