using System.Collections.Generic;
using System.Linq;
using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class SimpleSprite
	{
		private readonly Direction direction;
		private readonly byte[] image;
		private readonly byte[][] animation;

		private SimpleSprite(
			ImageGroup imageGroup,
			Direction direction,
			int imageIndex,
			int animationIndex,
			int animationCount)
		{
			this.direction = direction;
			image = imageGroup.Images[imageIndex];
			animation = imageGroup.Images.Skip(animationIndex).Take(animationCount).ToArray();
		}

		public void Render(GraphicsBuffer buffer, int topRow, int leftColumn, BattleItem item)
		{
			DrawSprite(buffer, topRow, leftColumn, item, false, 0);
		}

		public void Animate(GraphicsBuffer buffer, int topRow, int leftColumn, BattleItem item, int frame)
		{
			DrawSprite(buffer, topRow, leftColumn, item, true, frame);
		}

		private static readonly int[] walkingOffsets = { 1, 0, -1, 0, 1, 0, -1, 0 };

		private void DrawSprite(GraphicsBuffer buffer, int topRow, int leftColumn, BattleItem item, bool animating, int frame)
		{
			var body = animating ? animation[frame] : image;
			var walkingOffset = animating ? walkingOffsets[frame] : 0;
			foreach (var part in direction.Metadata().DrawOrder)
			{
				switch (part)
				{
				case SpritePart.Head:
					buffer.DrawItem(topRow, leftColumn, body);
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
					imageIndex + index,
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
					imageIndex,
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
	}
}
