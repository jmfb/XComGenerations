using System.Collections.Generic;
using XCom.Battlescape.Tiles;
using XCom.Content.Items;

namespace XCom.Data
{
	public enum EquipmentType
	{
		StunRod,
		ElectroFlare,
		MotionScanner,
		MediKit,
		PsiAmp,
		Elerium115,
		MindProbe
	}

	public static class EquipmentTypeExtensions
	{
		public static EquipmentMetadata Metadata(this EquipmentType equipmentType) => metadata[equipmentType];

		private static readonly EquipmentMetadata stunRod = new EquipmentMetadata
		{
			ItemType = ItemType.StunRod,
			Weight = 6,
			Image = Items.StunRod,
			Width = 1,
			Height = 3,
			DescriptionLines = new[]
			{
				"This device can only be used in close combat, but will stun a",
				"living organism without killing it by using electric shocks."
			},
			IsTwoHanded = true,
			Sprites = BattleItemSprite.StunRod
		};

		private static readonly EquipmentMetadata electroFlare = new EquipmentMetadata
		{
			ItemType = ItemType.ElectroFlare,
			Weight = 3,
			Image = Items.ElectroFlare,
			Width = 1,
			Height = 1,
			DescriptionLines = new[]
			{
				"This compact device produces a bright flare light when it is",
				"thrown. This will highlight enemy units in the vicinity of the",
				"electro-flare during night time missions."
			}
		};

		private static readonly EquipmentMetadata motionScanner = new EquipmentMetadata
		{
			ItemType = ItemType.MotionScanner,
			Weight = 3,
			Image = Items.MotionScanner,
			Width = 1,
			Height = 1,
			DescriptionLines = new[]
			{
				"This sophisticated device uses a variety of detectors and",
				"advanced computer algorithms to identify moving enemy units.",
				"However, it requires some practice to use effectively. Click on",
				"the motion scanner icon on the tactical display. Select 'Use",
				"Scanner' from the menu.  The Scanner display shows an arrow",
				"in the center which is the direction the soldier is facing (North",
				"is at the top). The flashing blobs show units which have moved",
				"recently. Large units, or fast moving units, will produce larger",
				"blobs. Static units will not be detected."
			}
		};

		private static readonly EquipmentMetadata mediKit = new EquipmentMetadata
		{
			ItemType = ItemType.MediKit,
			Weight = 5,
			Image = Items.MediKit,
			Width = 1,
			Height = 2,
			DescriptionLines = new[]
			{
				"The medi-kit combines a healing facility with pain killters and",
				"stimulants. In order to use the medi-kit you must face",
				"towards the soldier requiring treatment. If the soldier is",
				"stunned you must stand over the body. Click on the medi-kit",
				"icon and select 'use medi-kit' from the menu.",
				"HEALING> Red body parts show fatal wounds. Click on a body",
				"part that is wounded. Click on the 'Heal' button. One fatal",
				"would will be cured and some health restored.",
				"STIMULANT> This will restore energy and revive unconcious",
				"(stunned) soldiers. In order to revive an unconcious soldier",
				"you must stand directly over the body.",
				"PAIN KILLER> This will restore the morale of wounded soldiers",
				"up to an amount equivalent to the soldier's last health."
			}
		};

		private static readonly EquipmentMetadata psiAmp = new EquipmentMetadata
		{
			ItemType = ItemType.PsiAmp,
			Weight = 10,
			Image = Items.PsiAmp,
			Width = 1,
			Height = 3,
			DescriptionLines = new[]
			{
				"The Psi-amp can only be used by soldiers with psionic skill.",
				"During combat, click on the Psi-amp, select the type of attack,",
				"and select a target unit with the cursor. There are two types",
				"of psionic attack:",
				"PANIC UNIT> If the attack is successful it will reduce the",
				"target's morale and may cause it to panic.",
				"MIND CONTROL> If this is successful then you will gain immediate",
				"control of the enemy unit as if it was one of your own (except",
				"that you cannot access the object screen). It is more difficult",
				"to be successful with this type of attack."
			},
			Sprites = BattleItemSprite.PsiAmp
		};

		private static readonly EquipmentMetadata elerium115 = new EquipmentMetadata
		{
			ItemType = ItemType.Elerium115,
			Weight = 3,
			Image = Items.Elerium115,
			Width = 1,
			Height = 1,
			DescriptionLines = new[]
			{
				"This element has the unusual property of generating",
				"anti-matter power when bombarded with certain particles. This",
				"creates gravity waves and other forms of energy. It is not",
				"naturally found in our solar system and cannot be reproduced."
			}
		};

		private static readonly EquipmentMetadata mindProbe = new EquipmentMetadata
		{
			ItemType = ItemType.MindProbe,
			Weight = 5,
			Image = Items.MindProbe,
			Width = 2,
			Height = 2,
			DescriptionLines = new[]
			{
				"The mind probe is an alien communication device which is used",
				"to take information directly from brain waves. XCom units can",
				"use this device in combat to display an alien's characteristics.",
				"Click on the mind probe and the 'use' option. Then click on an",
				"alien with the cursor."
			}
		};

		private static readonly Dictionary<EquipmentType, EquipmentMetadata> metadata = new Dictionary<EquipmentType, EquipmentMetadata>
		{
			{ EquipmentType.StunRod, stunRod },
			{ EquipmentType.ElectroFlare, electroFlare },
			{ EquipmentType.MotionScanner, motionScanner },
			{ EquipmentType.MediKit, mediKit },
			{ EquipmentType.PsiAmp, psiAmp },
			{ EquipmentType.Elerium115, elerium115 },
			{ EquipmentType.MindProbe, mindProbe }
		};
	}
}
