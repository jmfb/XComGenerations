using System.Collections.Generic;
using System.Linq;
using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class Sprite
	{
		private readonly Direction direction;
		private readonly byte[] emptyLeftArm;
		private readonly byte[] twoHandedLeftArm;
		private readonly byte[][] leftArmAnimation;
		private readonly byte[] emptyRightArm;
		private readonly byte[] oneHandedRightArm;
		private readonly byte[] twoHandedRightArm;
		private readonly byte[] firingRightArm;
		private readonly byte[][] rightArmAnimation;
		private readonly byte[] legsStanding;
		private readonly byte[] legsKneeling;
		private readonly byte[][] legsAnimation;
		private readonly byte[] head;

		private Sprite(
			ImageGroup imageGroup,
			Direction direction,
			int emptyLeftArmIndex,
			int twoHandedLeftArmIndex,
			int leftArmAnimationIndex,
			int emptyRightArmIndex,
			int oneHandedRightArmIndex,
			int twoHandedRightArmIndex,
			int firingRightArmIndex,
			int rightArmAnimationIndex,
			int legsStandingIndex,
			int legsKneelingIndex,
			int legsAnimationIndex,
			int headIndex)
		{
			this.direction = direction;
			emptyLeftArm = imageGroup.Images[emptyLeftArmIndex];
			twoHandedLeftArm = imageGroup.Images[twoHandedLeftArmIndex];
			leftArmAnimation = imageGroup.Images.Skip(leftArmAnimationIndex).Take(8).ToArray();
			emptyRightArm = imageGroup.Images[emptyRightArmIndex];
			oneHandedRightArm = imageGroup.Images[oneHandedRightArmIndex];
			twoHandedRightArm = imageGroup.Images[twoHandedRightArmIndex];
			firingRightArm = imageGroup.Images[firingRightArmIndex];
			rightArmAnimation = imageGroup.Images.Skip(rightArmAnimationIndex).Take(8).ToArray();
			legsStanding = imageGroup.Images[legsStandingIndex];
			if (legsKneelingIndex != -1)
				legsKneeling = imageGroup.Images[legsKneelingIndex];
			legsAnimation = imageGroup.Images.Skip(legsAnimationIndex).Take(8).ToArray();
			head = imageGroup.Images[headIndex];

			if (imageGroup == ImageGroup.SoldierPersonalArmor && this.direction == Direction.South)
			{
				var temp = rightArmAnimation;
				rightArmAnimation = leftArmAnimation;
				leftArmAnimation = temp;
			}
			if (imageGroup == ImageGroup.Muton)
			{
				walkingOffsets = new[] { 1, 1, 0, -1, 1, 1, 0, -1 };
				armOffsets = new[] { 0, 0, -1, -2, 0, 0, -1, -2 };
			}
		}

		public void Render(GraphicsBuffer buffer, int topRow, int leftColumn, BattleItem item)
		{
			//TODO: kneeling
			DrawSprite(buffer, topRow, leftColumn, item, LegPosition.Standing, 0);
		}

		public void Animate(GraphicsBuffer buffer, int topRow, int leftColumn, BattleItem item, int frame)
		{
			DrawSprite(buffer, topRow, leftColumn, item, LegPosition.Walking, frame);
		}

		public int FrameCount => 8;

		private enum LegPosition { Standing, Kneeling, Walking }
		private readonly int[] walkingOffsets = { 1, 0, -1, 0, 1, 0, -1, 0 };
		private readonly int[] armOffsets = { 1, 0, -1, 0, 1, 0, -1, 0 };

		private void DrawSprite(GraphicsBuffer buffer, int topRow, int leftColumn, BattleItem item, LegPosition legPosition, int frame)
		{
			var isWalking = legPosition == LegPosition.Walking;
			var isKneeling = legPosition == LegPosition.Kneeling;
			var isOneHanded = item != null && !item.IsTwoHanded;
			var isTwoHanded = item != null && item.IsTwoHanded;

			var walkingOffset =
				isWalking ? walkingOffsets[frame] :
				isKneeling ? 2 : //TODO: correct offset for kneeling
				0;
			var armOffset =
				isWalking ? armOffsets[frame] :
				isKneeling ? 2 : //TODO: correct offset
				0;
			var leftArm =
				isTwoHanded ? twoHandedLeftArm :
				isWalking ? leftArmAnimation[frame] :
				emptyLeftArm;
			//TODO: Firing position
			var rightArm =
				isTwoHanded ? twoHandedRightArm :
				isOneHanded ? oneHandedRightArm :
				isWalking ? rightArmAnimation[frame] :
				emptyRightArm;
			var legs =
				isWalking ? legsAnimation[frame] :
				isKneeling ? legsKneeling :
				legsStanding;

			foreach (var part in direction.Metadata().DrawOrder)
			{
				switch (part)
				{
				case SpritePart.OneHandedWeapon:
					if (isOneHanded)
						buffer.DrawItem(topRow + armOffset, leftColumn, item.Sprites[direction]);
					break;
				case SpritePart.TwoHandedWeapon:
					if (isTwoHanded)
						buffer.DrawItem(topRow + armOffset, leftColumn, item.Sprites[direction]);
					break;
				case SpritePart.LeftArm:
					buffer.DrawItem(topRow + armOffset, leftColumn, leftArm);
					break;
				case SpritePart.RightArm:
					buffer.DrawItem(topRow + armOffset, leftColumn, rightArm);
					break;
				case SpritePart.Head:
					buffer.DrawItem(topRow + walkingOffset, leftColumn, head);
					break;
				case SpritePart.Legs:
					buffer.DrawItem(topRow, leftColumn, legs);
					break;
				}
			}
		}

		private static Dictionary<Direction, Sprite> LoadSprites(
			ImageGroup imageGroup,
			int emptyLeftArm,
			int twoHandedLeftArm,
			int leftArmAnimation,
			int emptyRightArm,
			int oneHandedRightArm,
			int twoHandedRightArm,
			int firingRightArm,
			int rightArmAnimation,
			int legsStanding,
			int legsKneeling,
			int legsAnimation,
			int head)
		{
			return EnumEx.GetValues<Direction>()
				.Select((direction, index) => new Sprite(
					imageGroup,
					direction,
					emptyLeftArm + index,
					twoHandedLeftArm + index,
					leftArmAnimation + index * 24,
					emptyRightArm + index,
					oneHandedRightArm + index,
					twoHandedRightArm + index,
					firingRightArm + index,
					rightArmAnimation + index * 24,
					legsStanding + index,
					legsKneeling == -1 ? -1 : legsKneeling + index,
					legsAnimation + index * 24,
					head + index))
				.ToDictionary(sprite => sprite.direction, sprite => sprite);
		}

		public static readonly Dictionary<Direction, Sprite> SoldierCoverallsMale = LoadSprites(ImageGroup.SoldierCoveralls, 0, 240, 40, 8, 232, 248, 256, 48, 16, 24, 56, 32);
		public static readonly Dictionary<Direction, Sprite> SoldierCoverallsFemale = LoadSprites(ImageGroup.SoldierCoveralls, 0, 240, 40, 8, 232, 248, 256, 48, 16, 24, 56, 267);
		public static readonly Dictionary<Direction, Sprite> SoldierPersonalArmorMale = LoadSprites(ImageGroup.SoldierPersonalArmor, 0, 240, 40, 8, 232, 248, 256, 48, 16, 24, 56, 32);
		public static readonly Dictionary<Direction, Sprite> SoldierPersonalArmorFemale = LoadSprites(ImageGroup.SoldierPersonalArmor, 0, 240, 40, 8, 232, 248, 256, 48, 16, 24, 56, 267);
		public static readonly Dictionary<Direction, Sprite> SoldierPowerSuit = LoadSprites(ImageGroup.SoldierPowerSuit, 0, 240, 40, 8, 232, 248, 256, 48, 16, 24, 56, 32);
		public static readonly Dictionary<Direction, Sprite> SoldierFlyingSuit = LoadSprites(ImageGroup.SoldierPowerSuit, 0, 240, 40, 8, 232, 248, 256, 48, 16, 24, 56, 267);
		public static readonly Dictionary<Direction, Sprite> SoldierFlyingSuitFlying = LoadSprites(ImageGroup.SoldierPowerSuit, 0, 240, 40, 8, 232, 248, 256, 48, 275, 24, 56, 267);
		public static readonly Dictionary<Direction, Sprite> Muton = LoadSprites(ImageGroup.Muton, 0, 240, 40, 8, 232, 248, 256, 48, 16, 24, 56, 32); //NOTE: East empty right arm animation is incorrect.
	}
}
