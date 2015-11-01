using System.Collections.Generic;
using System.Linq;
using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class Sprite
	{
		public Direction Direction { get; set; }
		public byte[] EmptyLeftArm { get; set; }
		public byte[] TwoHandedLeftArm { get; set; }
		public byte[][] LeftArmAnimation { get; set; }
		public byte[] EmptyRightArm { get; set; }
		public byte[] OneHandedRightArm { get; set; }
		public byte[] TwoHandedRightArm { get; set; }
		public byte[] FiringRightArm { get; set; }
		public byte[][] RightArmAnimation { get; set; }
		public byte[] LegsStanding { get; set; }
		public byte[] LegsKneeling { get; set; }
		public byte[][] LegsAnimation { get; set; }
		public byte[] Head { get; set; }

		public Sprite(
			ImageGroup imageGroup,
			Direction direction,
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
			Direction = direction;
			EmptyLeftArm = imageGroup.Images[emptyLeftArm];
			TwoHandedLeftArm = imageGroup.Images[twoHandedLeftArm];
			LeftArmAnimation = imageGroup.Images.Skip(leftArmAnimation).Take(8).ToArray();
			EmptyRightArm = imageGroup.Images[emptyRightArm];
			OneHandedRightArm = imageGroup.Images[oneHandedRightArm];
			TwoHandedRightArm = imageGroup.Images[twoHandedRightArm];
			FiringRightArm = imageGroup.Images[firingRightArm];
			RightArmAnimation = imageGroup.Images.Skip(rightArmAnimation).Take(8).ToArray();
			LegsStanding = imageGroup.Images[legsStanding];
			LegsKneeling = imageGroup.Images[legsKneeling];
			LegsAnimation = imageGroup.Images.Skip(legsAnimation).Take(8).ToArray();
			Head = imageGroup.Images[head];

			if (imageGroup == ImageGroup.SoldierPersonalArmor && Direction == Direction.South)
			{
				var temp = RightArmAnimation;
				RightArmAnimation = LeftArmAnimation;
				LeftArmAnimation = temp;
			}
		}

		public void Render(GraphicsBuffer buffer, int topRow, int leftColumn)
		{
			DrawSprite(buffer, topRow, leftColumn, Head, LegsStanding, EmptyLeftArm, EmptyRightArm, 0);
		}

		private static readonly int[] headOffsets = { 1, 0, -1, 0, 1, 0, -1, 0 };

		public void Animate(GraphicsBuffer buffer, int topRow, int leftColumn, int frame)
		{
			DrawSprite(buffer, topRow, leftColumn, Head, LegsAnimation[frame], LeftArmAnimation[frame], RightArmAnimation[frame], headOffsets[frame]);
		}

		private void DrawSprite(GraphicsBuffer buffer, int topRow, int leftColumn, byte[] head, byte[] legs, byte[] leftArm, byte[] rightArm, int headOffset)
		{
			var parts =
				IsLeftArmObscured ? new[] { leftArm, head, legs, rightArm } :
				IsRightArmObscured ? new[] { rightArm, head, legs, leftArm } :
				new[] { head, legs, leftArm, rightArm };
			foreach (var part in parts)
				buffer.DrawItem(topRow + (part == head ? headOffset : 0), leftColumn, part);
		}

		private bool IsLeftArmObscured =>
			Direction == Direction.North ||
			Direction == Direction.NorthEast ||
			Direction == Direction.East;
		private bool IsRightArmObscured =>
			Direction == Direction.South ||
			Direction == Direction.SouthWest ||
			Direction == Direction.West;

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
					legsKneeling + index,
					legsAnimation + index * 24,
					head + index))
				.ToDictionary(sprite => sprite.Direction, sprite => sprite);
		}

		public static readonly Dictionary<Direction, Sprite> SoldierCoverallsMale = LoadSprites(ImageGroup.SoldierCoveralls, 0, 240, 40, 8, 232, 248, 256, 48, 16, 24, 56, 32);
		public static readonly Dictionary<Direction, Sprite> SoldierCoverallsFemale = LoadSprites(ImageGroup.SoldierCoveralls, 0, 240, 40, 8, 232, 248, 256, 48, 16, 24, 56, 267);
		public static readonly Dictionary<Direction, Sprite> SoldierPersonalArmorMale = LoadSprites(ImageGroup.SoldierPersonalArmor, 0, 240, 40, 8, 232, 248, 256, 48, 16, 24, 56, 32);
		public static readonly Dictionary<Direction, Sprite> SoldierPersonalArmorFemale = LoadSprites(ImageGroup.SoldierPersonalArmor, 0, 240, 40, 8, 232, 248, 256, 48, 16, 24, 56, 267);
	}
}
