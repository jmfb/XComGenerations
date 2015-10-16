using System.Collections.Generic;
using XCom.Content.Paperdolls;

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
			Name = "PERSONAL ARMOR",
			FrontArmor = 50,
			LeftArmor = 40,
			RightArmor = 40,
			RearArmor = 30,
			UnderArmor = 30,
			FireResistant = true,
			StunResistance = 10,
			Item = ItemType.PersonalArmor,
			Overlay = Paperdolls.PersonalArmorWhiteMale
		};

		private static readonly ArmorMetadata powerSuit = new ArmorMetadata
		{
			Name = "POWER SUIT",
			FrontArmor = 100,
			LeftArmor = 80,
			RightArmor = 80,
			RearArmor = 70,
			UnderArmor = 60,
			FireResistant = true,
			SmokeResistant = true,
			StunResistance = 20,
			Item = ItemType.PowerSuit,
			Overlay = Paperdolls.PowerSuit
		};

		private static readonly ArmorMetadata flyingSuit = new ArmorMetadata
		{
			Name = "FLYING SUIT",
			FrontArmor = 110,
			LeftArmor = 90,
			RightArmor = 90,
			RearArmor = 80,
			UnderArmor = 70,
			FireResistant = true,
			SmokeResistant = true,
			StunResistance = 20,
			Item = ItemType.FlyingSuit,
			Overlay = Paperdolls.FlyingSuit
		};

		private static readonly Dictionary<ArmorType, ArmorMetadata> metadata = new Dictionary<ArmorType,ArmorMetadata>
		{
			{ ArmorType.PersonalArmor, personalArmor },
			{ ArmorType.PowerSuit, powerSuit },
			{ ArmorType.FlyingSuit, flyingSuit }
		};
	}
}
