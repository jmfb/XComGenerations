using System.Collections.Generic;
using System.Linq;
using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class SimpleSprite
	{
		private readonly Direction direction;
		private readonly byte[] image;
		private readonly byte[] headImage;
		private readonly byte[][] animation;
		private readonly byte[] emptyLeftArm;
		private readonly byte[] emptyRightArm;

		private static readonly int[] walkingOffsets = { 1, 0, -1, 0, 1, 0, -1, 0 };
		private readonly int[] headTopOffsets = { 0, 0, 0, 0, 0, 0, 0, 0 };
		private readonly int[] headLeftOffsets = { 0, 0, 0, 0, 0, 0, 0, 0 };

		private SimpleSprite(
			ImageGroup imageGroup,
			Direction direction,
			int emptyLeftArmIndex,
			int emptyRightArmIndex,
			int imageIndex,
			int headImageIndex,
			int animationIndex,
			int animationCount)
		{
			this.direction = direction;
			image = imageGroup.Images[imageIndex];
			headImage = headImageIndex == -1 ? null : imageGroup.Images[headImageIndex];
			animation = imageGroup.Images.Skip(animationIndex).Take(animationCount).ToArray();
			emptyLeftArm = emptyLeftArmIndex == -1 ? null : imageGroup.Images[emptyLeftArmIndex];
			emptyRightArm = emptyRightArmIndex == -1 ? null : imageGroup.Images[emptyRightArmIndex];

			if (imageGroup == ImageGroup.Snakeman)
			{
				headTopOffsets = new[] { 3, 3, 2, 1, 0, 0, 1, 2 };
				if (direction == Direction.North ||
					direction == Direction.NorthEast ||
					direction == Direction.East)
				{
					headLeftOffsets = new[] { 0, 0, 1, 2, 3, 2, 1, 0 };
				}
				else if (direction == Direction.South ||
					direction == Direction.SouthWest ||
					direction == Direction.West)
				{
					headLeftOffsets = new[] { 0, 0, -1, -2, -3, -2, -1, 0 };
				}
			}
		}

		public void Render(GraphicsBuffer buffer, int topRow, int leftColumn, BattleItem item)
		{
			DrawSprite(buffer, topRow, leftColumn, item, false, 0);
		}

		public void Animate(GraphicsBuffer buffer, int topRow, int leftColumn, BattleItem item, int frame)
		{
			DrawSprite(buffer, topRow, leftColumn, item, true, frame);
		}

		private void DrawSprite(GraphicsBuffer buffer, int topRow, int leftColumn, BattleItem item, bool animating, int frame)
		{
			var body = animating ? animation[frame] : image;
			var walkingOffset = animating ? walkingOffsets[frame] : 0;
			var headTopOffset = animating ? headTopOffsets[frame] : 0;
			var headLeftOffset = animating ? headLeftOffsets[frame] : 0;

			//TODO: arms with one or two handed, possibly animating, possibly with offset
			var leftArm = emptyLeftArm;
			var rightArm = emptyRightArm;

			foreach (var part in direction.Metadata().DrawOrder)
			{
				switch (part)
				{
				case SpritePart.Head:
					if (headImage != null)
						buffer.DrawItem(topRow + headTopOffset, leftColumn + headLeftOffset, headImage);
					buffer.DrawItem(topRow, leftColumn, body);
					break;
				case SpritePart.LeftArm:
					buffer.DrawItem(topRow + headTopOffset, leftColumn + headLeftOffset, leftArm);
					break;
				case SpritePart.RightArm:
					buffer.DrawItem(topRow + headTopOffset, leftColumn + headLeftOffset, rightArm);
					break;
				case SpritePart.OneHandedWeapon:
					if (item != null && !item.IsTwoHanded)
						buffer.DrawItem(topRow + walkingOffset, leftColumn, item.Sprites[direction]);
					break;
				case SpritePart.TwoHandedWeapon:
					if (item != null && item.IsTwoHanded)
						buffer.DrawItem(topRow + walkingOffset, leftColumn, item.Sprites[direction]);
					break;
				}
			}
		}

		public int FrameCount => animation.Length;

		private static Dictionary<Direction, SimpleSprite> LoadSprites(
			ImageGroup imageGroup,
			int imageIndex,
			int animationIndex,
			int animationCount)
		{
			return EnumEx.GetValues<Direction>()
				.Select((direction, index) => new SimpleSprite(
					imageGroup,
					direction,
					-1,
					-1,
					imageIndex + index,
					-1,
					animationIndex + index * animationCount,
					animationCount))
				.ToDictionary(sprite => sprite.direction, sprite => sprite);
		}

		private static Dictionary<Direction, SimpleSprite> LoadSpritesWithArms(
			ImageGroup imageGroup,
			int emptyLeftArmIndex,
			int emptyRightArmIndex,
			int imageIndex,
			int animationIndex,
			int animationCount)
		{
			return EnumEx.GetValues<Direction>()
				.Select((direction, index) => new SimpleSprite(
					imageGroup,
					direction,
					emptyLeftArmIndex + index,
					emptyRightArmIndex + index,
					imageIndex + index,
					-1,
					animationIndex + index * animationCount,
					animationCount))
				.ToDictionary(sprite => sprite.direction, sprite => sprite);
		}

		private static Dictionary<Direction, SimpleSprite> LoadSpritesWithHead(
			ImageGroup imageGroup,
			int emptyLeftArmIndex,
			int emptyRightArmIndex,
			int imageIndex,
			int headImageIndex,
			int animationIndex,
			int animationCount)
		{
			return EnumEx.GetValues<Direction>()
				.Select((direction, index) => new SimpleSprite(
					imageGroup,
					direction,
					emptyLeftArmIndex + index,
					emptyRightArmIndex + index,
					imageIndex + index,
					headImageIndex + index,
					animationIndex + index * animationCount,
					animationCount))
				.ToDictionary(sprite => sprite.direction, sprite => sprite);
		}

		private static Dictionary<Direction, SimpleSprite> LoadOmnidirectionalSprites(
			ImageGroup imageGroup,
			int imageIndex,
			int animationIndex,
			int animationCount)
		{
			return EnumEx.GetValues<Direction>()
				.Select(direction => new SimpleSprite(
					imageGroup,
					direction,
					-1,
					-1,
					imageIndex,
					-1,
					animationIndex,
					animationCount))
				.ToDictionary(sprite => sprite.direction, sprite => sprite);
		}

		public static readonly Dictionary<Direction, SimpleSprite> CivilianFemale = LoadSprites(ImageGroup.CivilianFemale, 0, 8, 8);
		public static readonly Dictionary<Direction, SimpleSprite> CivilianMale = LoadSprites(ImageGroup.CivilianMale, 0, 8, 8);
		public static readonly Dictionary<Direction, SimpleSprite> Zombie = LoadSprites(ImageGroup.Zombie, 0, 8, 8);
		public static readonly Dictionary<Direction, SimpleSprite> Celatid = LoadOmnidirectionalSprites(ImageGroup.Celatid, 0, 1, 5);
		public static readonly Dictionary<Direction, SimpleSprite> Silacoid = LoadOmnidirectionalSprites(ImageGroup.Silacoid, 0, 1, 5);
		public static readonly Dictionary<Direction, SimpleSprite> Ethereal = LoadSprites(ImageGroup.Ethereal, 0, 8, 8);
		//TODO: Floater and Snakeman still need firing/animating arms.
		//TODO: 32 Float arms: 67-98, 32 Snakeman arms: 99-130
		public static readonly Dictionary<Direction, SimpleSprite> Floater = LoadSpritesWithArms(ImageGroup.Floater, 8, 0, 16, 24, 5);
		public static readonly Dictionary<Direction, SimpleSprite> Snakeman = LoadSpritesWithHead(ImageGroup.Snakeman, 0, 8, 16, 24, 32, 8);
	}
}
