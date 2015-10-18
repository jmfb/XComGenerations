using System.Collections.Generic;

namespace XCom.Battlescape
{
	public enum InventoryLocation
	{
		RightShoulder,
		LeftShoulder,
		RightHand,
		LeftHand,
		RightLeg,
		LeftLeg,
		BackPack,
		Belt,
		Ground
	}

	public static class InventoryLocationExtensions
	{
		public static InventoryLocationMetadata Metadata(this InventoryLocation location) => metadata[location];

		private static InventoryLocationMetadata CreateShoulder(int rightShoulder, int leftShoulder)
		{
			return new InventoryLocationMetadata
			{
				TimeUnitCost = new Dictionary<InventoryLocation, int>
				{
					{ InventoryLocation.RightShoulder, rightShoulder },
					{ InventoryLocation.LeftShoulder, leftShoulder },
					{ InventoryLocation.RightHand, 3 },
					{ InventoryLocation.LeftHand, 3 },
					{ InventoryLocation.RightLeg, 12 },
					{ InventoryLocation.LeftLeg, 12 },
					{ InventoryLocation.BackPack, 16 },
					{ InventoryLocation.Belt, 10 },
					{ InventoryLocation.Ground, 4 }
				}
			};
		}

		private static InventoryLocationMetadata CreateHand(int rightHand, int leftHand, int rightLeg, int leftLeg)
		{
			return new InventoryLocationMetadata
			{
				TimeUnitCost = new Dictionary<InventoryLocation, int>
				{
					{ InventoryLocation.RightShoulder, 10 },
					{ InventoryLocation.LeftShoulder, 10 },
					{ InventoryLocation.RightHand, rightHand },
					{ InventoryLocation.LeftHand, leftHand },
					{ InventoryLocation.RightLeg, rightLeg },
					{ InventoryLocation.LeftLeg, leftLeg },
					{ InventoryLocation.BackPack, 14 },
					{ InventoryLocation.Belt, 8 },
					{ InventoryLocation.Ground, 2 }
				}
			};
		}

		private static InventoryLocationMetadata CreateLeg(int rightLeg, int leftLeg, int rightHand, int leftHand)
		{
			return new InventoryLocationMetadata
			{
				TimeUnitCost = new Dictionary<InventoryLocation, int>
				{
					{ InventoryLocation.RightShoulder, 10 },
					{ InventoryLocation.LeftShoulder, 10 },
					{ InventoryLocation.RightHand, rightHand },
					{ InventoryLocation.LeftHand, leftHand },
					{ InventoryLocation.RightLeg, rightLeg },
					{ InventoryLocation.LeftLeg, leftLeg },
					{ InventoryLocation.BackPack, 18 },
					{ InventoryLocation.Belt, 10 },
					{ InventoryLocation.Ground, 6 }
				}
			};
		}

		private static readonly InventoryLocationMetadata backPack = new InventoryLocationMetadata
		{
			TimeUnitCost = new Dictionary<InventoryLocation, int>
			{
				{ InventoryLocation.RightShoulder, 14 },
				{ InventoryLocation.LeftShoulder, 14 },
				{ InventoryLocation.RightHand, 8 },
				{ InventoryLocation.LeftHand, 8 },
				{ InventoryLocation.RightLeg, 16 },
				{ InventoryLocation.LeftLeg, 16 },
				{ InventoryLocation.BackPack, 0 },
				{ InventoryLocation.Belt, 12 },
				{ InventoryLocation.Ground, 10 }
			}
		};

		private static readonly InventoryLocationMetadata belt = new InventoryLocationMetadata
		{
			TimeUnitCost = new Dictionary<InventoryLocation, int>
			{
				{ InventoryLocation.RightShoulder, 12 },
				{ InventoryLocation.LeftShoulder, 12 },
				{ InventoryLocation.RightHand, 4 },
				{ InventoryLocation.LeftHand, 4 },
				{ InventoryLocation.RightLeg, 10 },
				{ InventoryLocation.LeftLeg, 10 },
				{ InventoryLocation.BackPack, 16 },
				{ InventoryLocation.Belt, 0 },
				{ InventoryLocation.Ground, 6 }
			}
		};

		private static readonly InventoryLocationMetadata ground = new InventoryLocationMetadata
		{
			TimeUnitCost = new Dictionary<InventoryLocation, int>
			{
				{ InventoryLocation.RightShoulder, 12 },
				{ InventoryLocation.LeftShoulder, 12 },
				{ InventoryLocation.RightHand, 8 },
				{ InventoryLocation.LeftHand, 8 },
				{ InventoryLocation.RightLeg, 10 },
				{ InventoryLocation.LeftLeg, 10 },
				{ InventoryLocation.BackPack, 20 },
				{ InventoryLocation.Belt, 12 },
				{ InventoryLocation.Ground, 0 }
			}
		};

		private static readonly Dictionary<InventoryLocation, InventoryLocationMetadata> metadata = new Dictionary<InventoryLocation, InventoryLocationMetadata>
		{
			{ InventoryLocation.RightShoulder, CreateShoulder(0, 8) },
			{ InventoryLocation.LeftShoulder, CreateShoulder(8, 0) },
			{ InventoryLocation.RightHand, CreateHand(0, 4, 8, 10) },
			{ InventoryLocation.LeftHand, CreateHand(4, 0, 10, 8) },
			{ InventoryLocation.RightLeg, CreateLeg(0, 10, 4, 6) },
			{ InventoryLocation.LeftLeg, CreateLeg(10, 0, 6, 4) },
			{ InventoryLocation.BackPack, backPack },
			{ InventoryLocation.Belt, belt },
			{ InventoryLocation.Ground, ground }
		};
	}
}
