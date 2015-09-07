using System.Collections.Generic;
using XCom.Content.UfoPreviews;

namespace XCom.Data
{
	public enum UfoType
	{
		SmallScout,
		MediumScout,
		LargeScout,
		Abductor,
		Harvester,
		SupplyShip,
		TerrorShip,
		Battleship
	}

	public static class UfoTypeExtensions
	{
		public static UfoMetadata Metadata(this UfoType ufoType) => metadata[ufoType];

		private static readonly UfoMetadata smallScout = new UfoMetadata
		{
			Name = "Small Scout",
			RequiredResearch = ResearchType.SmallScout,
			Size = "Very Small",
			Points = 100,
			DamageCapacity = 50,
			WeaponPower = 0,
			WeaponRange = 0,
			MaximumSpeed = 2200,
			Image = UfoPreviews.SmallScout,
			Description = "This tiny craft is primarily used for reconnaissance " +
				"or research. It normally precedes larger vessels at the start " +
				"of an alien mission."
		};

		private static readonly UfoMetadata mediumScout = new UfoMetadata
		{
			Name = "Medium Scout",
			RequiredResearch = ResearchType.MediumScout,
			Size = "Small",
			Points = 150,
			DamageCapacity = 200,
			WeaponPower = 20,
			WeaponRange = 120,
			MaximumSpeed = 2400,
			Image = UfoPreviews.MediumScout,
			Description = "A medium sized scout vessel that poses little threat to " +
				"earth forces. Normally appears before larger vessels during missions."
		};

		private static readonly UfoMetadata largeScout = new UfoMetadata
		{
			Name = "Large Scout",
			RequiredResearch = ResearchType.LargeScout,
			Size = "Small",
			Points = 250,
			DamageCapacity = 250,
			WeaponPower = 20,
			WeaponRange = 272,
			MaximumSpeed = 2700,
			Image = UfoPreviews.LargeScout,
			Description = "The largest alien scout craft is a general purpose vessel " +
				"that is used in all types of alien mission."
		};

		private static readonly UfoMetadata abductor = new UfoMetadata
		{
			Name = "Abductor",
			RequiredResearch = ResearchType.Abductor,
			Size = "Medium",
			Points = 500,
			DamageCapacity = 500,
			WeaponPower = 40,
			WeaponRange = 176,
			MaximumSpeed = 4300,
			Image = UfoPreviews.Abductor,
			Description = "This vessel is equipped with an examination room for " +
				"performing horrific experiments on human subjects.  The victim is " +
				"normally paralyzed by telepathic powers, but remains conscious while " +
				"on the operating table."
		};

		private static readonly UfoMetadata harvester = new UfoMetadata
		{
			Name = "Harvester",
			RequiredResearch = ResearchType.Harvester,
			Size = "Medium",
			Points = 500,
			DamageCapacity = 500,
			WeaponPower = 40,
			WeaponRange = 160,
			MaximumSpeed = 4000,
			Image = UfoPreviews.Harvester,
			Description = "The harvester has a trap door in its base and is equipped " +
				"with lifting gear to haul up cattle or other beasts.  Laser cutters " +
				"are used to extract the desired material and the carcass is dumped on " +
				"the ground. There are also storage containers for body parts."
		};

		private static readonly UfoMetadata terrorShip = new UfoMetadata
		{
			Name = "Terror Ship",
			RequiredResearch = ResearchType.TerrorShip,
			Size = "Large",
			Points = 1000,
			DamageCapacity = 1200,
			WeaponPower = 120,
			WeaponRange = 336,
			MaximumSpeed = 4800,
			Image = UfoPreviews.TerrorShip,
			Description = "The terror ship has a containment facility for large alien " +
				"terror weapons or creatures. It is used to transport these alien " +
				"terrorists into populated areas."
		};

		private static readonly UfoMetadata supplyShip = new UfoMetadata
		{
			Name = "Supply Ship",
			RequiredResearch = ResearchType.SupplyShip,
			Size = "Large",
			Points = 800,
			DamageCapacity = 2200,
			WeaponPower = 60,
			WeaponRange = 288,
			MaximumSpeed = 3200,
			Image = UfoPreviews.SupplyShip,
			Description = "The supply vessel is used during the construction of alien " +
				"bases or for supplying existing bases. It carries alien food containers " +
				"and reproduction chambers."
		};

		private static readonly UfoMetadata battleship = new UfoMetadata
		{
			Name = "Battleship",
			RequiredResearch = ResearchType.Battleship,
			Size = "Very Large",
			Points = 1400,
			DamageCapacity = 3200,
			WeaponPower = 148,
			WeaponRange = 520,
			MaximumSpeed = 5000,
			Image = UfoPreviews.Battleship,
			Description = "The battleship is the largest and most powerful alien craft. " +
				"It is normally the primary alien mission craft, equipped with powerful " +
				"weapons and numerous crew members."
		};

		private static readonly Dictionary<UfoType, UfoMetadata> metadata = new Dictionary<UfoType, UfoMetadata>
		{
			{ UfoType.SmallScout, smallScout },
			{ UfoType.MediumScout, mediumScout },
			{ UfoType.LargeScout, largeScout },
			{ UfoType.Abductor, abductor },
			{ UfoType.Harvester, harvester },
			{ UfoType.SupplyShip, supplyShip },
			{ UfoType.TerrorShip, terrorShip },
			{ UfoType.Battleship, battleship }
		};
	}
}
