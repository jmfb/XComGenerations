using XCom.Graphics;

namespace XCom.Battlescape.Tiles;

public class SimpleSprite : BaseSprite
{
	private readonly Direction direction;
	private readonly byte[] image;
	private readonly byte[] headImage;
	private readonly byte[][] animation;
	private readonly byte[] emptyLeftArm;
	private readonly byte[] twoHandedLeftArm;
	private readonly byte[] emptyRightArm;
	private readonly byte[] oneHandedRightArm;
	private readonly byte[] twoHandedRightArm;
	private readonly byte[] firingRightArm;

	private readonly int[] walkingOffsets = [0, 0, 0, 0, 0, 0, 0, 0];
	private readonly int[] headTopOffsets = [0, 0, 0, 0, 0, 0, 0, 0];
	private readonly int[] headLeftOffsets = [0, 0, 0, 0, 0, 0, 0, 0];
	private readonly int oneHandedWeaponOffset = 0;

	private SimpleSprite(
		ImageGroup imageGroup,
		Direction direction,
		int emptyLeftArmIndex,
		int twoHandedLeftArmIndex,
		int emptyRightArmIndex,
		int oneHandedRightArmIndex,
		int twoHandedRightArmIndex,
		int firingRightArmIndex,
		int imageIndex,
		int headImageIndex,
		int animationIndex,
		int animationCount
	)
	{
		this.direction = direction;
		image = imageGroup.Images[imageIndex];
		headImage = headImageIndex == -1 ? null : imageGroup.Images[headImageIndex];
		animation = imageGroup.Images.Skip(animationIndex).Take(animationCount).ToArray();
		emptyLeftArm = emptyLeftArmIndex == -1 ? null : imageGroup.Images[emptyLeftArmIndex];
		twoHandedLeftArm =
			twoHandedLeftArmIndex == -1 ? null : imageGroup.Images[twoHandedLeftArmIndex];
		emptyRightArm = emptyRightArmIndex == -1 ? null : imageGroup.Images[emptyRightArmIndex];
		oneHandedRightArm =
			oneHandedRightArmIndex == -1 ? null : imageGroup.Images[oneHandedRightArmIndex];
		twoHandedRightArm =
			twoHandedRightArmIndex == -1 ? null : imageGroup.Images[twoHandedRightArmIndex];
		firingRightArm = firingRightArmIndex == -1 ? null : imageGroup.Images[firingRightArmIndex];

		if (imageGroup == ImageGroup.Ethereal)
		{
			walkingOffsets = [1, 0, -1, 0, 1, 0, -1, 0];
		}

		if (imageGroup == ImageGroup.Snakeman)
		{
			headTopOffsets = [3, 3, 2, 1, 0, 0, 1, 2];
			if (direction is Direction.North or Direction.NorthEast or Direction.East)
			{
				headLeftOffsets = [0, 0, 1, 2, 3, 2, 1, 0];
			}
			else if (direction is Direction.South or Direction.SouthWest or Direction.West)
			{
				headLeftOffsets = [0, 0, -1, -2, -3, -2, -1, 0];
			}

			switch (direction)
			{
				case Direction.North:
					oneHandedWeaponOffset = 2;
					break;
				case Direction.NorthEast:
					oneHandedWeaponOffset = 1;
					break;
			}
		}
	}

	public void Render(GraphicsBuffer buffer, int topRow, int leftColumn, BattleItem item)
	{
		DrawSprite(buffer, topRow, leftColumn, item, false, 0);
	}

	public void Animate(
		GraphicsBuffer buffer,
		int topRow,
		int leftColumn,
		BattleItem item,
		int frame
	)
	{
		DrawSprite(buffer, topRow, leftColumn, item, true, frame);
	}

	private void DrawSprite(
		GraphicsBuffer buffer,
		int topRow,
		int leftColumn,
		BattleItem item,
		bool animating,
		int frame
	)
	{
		var body = animating ? animation[frame] : image;
		var walkingOffset = animating ? walkingOffsets[frame] : 0;
		var headTopOffset = animating ? headTopOffsets[frame] : 0;
		var headLeftOffset = animating ? headLeftOffsets[frame] : 0;

		// TODO: Firing position
		var isOneHanded = item is { IsTwoHanded: false };
		var isTwoHanded = item is { IsTwoHanded: true };
		var leftArm = isTwoHanded ? twoHandedLeftArm : emptyLeftArm;
		var rightArm =
			isTwoHanded ? twoHandedRightArm
			: isOneHanded ? oneHandedRightArm
			: emptyRightArm;

		foreach (var part in direction.Metadata().DrawOrder)
		{
			switch (part)
			{
				case SpritePart.Head:
					if (headImage != null)
						buffer.DrawItem(
							topRow + headTopOffset,
							leftColumn + headLeftOffset,
							headImage
						);
					buffer.DrawItem(topRow, leftColumn, body);
					break;
				case SpritePart.LeftArm:
					if (leftArm != null)
						buffer.DrawItem(
							topRow + headTopOffset,
							leftColumn + headLeftOffset,
							leftArm
						);
					break;
				case SpritePart.RightArm:
					if (rightArm != null)
						buffer.DrawItem(
							topRow + headTopOffset,
							leftColumn + headLeftOffset,
							rightArm
						);
					break;
				case SpritePart.OneHandedWeapon:
					if (isOneHanded)
						buffer.DrawItem(
							topRow + walkingOffset + headTopOffset + oneHandedWeaponOffset,
							leftColumn + headLeftOffset,
							item.Sprites[direction]
						);
					break;
				case SpritePart.TwoHandedWeapon:
					if (isTwoHanded)
						buffer.DrawItem(
							topRow + walkingOffset + headTopOffset,
							leftColumn + headLeftOffset,
							item.Sprites[direction]
						);
					break;
			}
		}
	}

	public int FrameCount => animation.Length;

	private static Dictionary<Direction, BaseSprite> LoadSprites(
		ImageGroup imageGroup,
		int imageIndex,
		int animationIndex,
		int animationCount
	)
	{
		return Enum.GetValues<Direction>()
			.Select(
				(direction, index) =>
					new SimpleSprite(
						imageGroup,
						direction,
						-1,
						-1,
						-1,
						-1,
						-1,
						-1,
						imageIndex + index,
						-1,
						animationIndex + index * animationCount,
						animationCount
					)
			)
			.ToDictionary(sprite => sprite.direction, sprite => (BaseSprite)sprite);
	}

	private static Dictionary<Direction, BaseSprite> LoadSpritesWithArms(
		ImageGroup imageGroup,
		int emptyLeftArmIndex,
		int twoHandedLeftArmIndex,
		int emptyRightArmIndex,
		int oneHandedRightArmIndex,
		int twoHandedRightArmIndex,
		int firingRightArmIndex,
		int imageIndex,
		int animationIndex,
		int animationCount
	)
	{
		return Enum.GetValues<Direction>()
			.Select(
				(direction, index) =>
					new SimpleSprite(
						imageGroup,
						direction,
						emptyLeftArmIndex + index,
						twoHandedLeftArmIndex + index,
						emptyRightArmIndex + index,
						oneHandedRightArmIndex + index,
						twoHandedRightArmIndex + index,
						firingRightArmIndex + index,
						imageIndex + index,
						-1,
						animationIndex + index * animationCount,
						animationCount
					)
			)
			.ToDictionary(sprite => sprite.direction, sprite => (BaseSprite)sprite);
	}

	private static Dictionary<Direction, BaseSprite> LoadSpritesWithHead(
		ImageGroup imageGroup,
		int emptyLeftArmIndex,
		int twoHandedLeftArmIndex,
		int emptyRightArmIndex,
		int oneHandedRightArmIndex,
		int twoHandedRightArmIndex,
		int firingRightArmIndex,
		int imageIndex,
		int headImageIndex,
		int animationIndex,
		int animationCount
	)
	{
		return Enum.GetValues<Direction>()
			.Select(
				(direction, index) =>
					new SimpleSprite(
						imageGroup,
						direction,
						emptyLeftArmIndex + index,
						twoHandedLeftArmIndex + index,
						emptyRightArmIndex + index,
						oneHandedRightArmIndex + index,
						twoHandedRightArmIndex + index,
						firingRightArmIndex + index,
						imageIndex + index,
						headImageIndex + index,
						animationIndex + index * animationCount,
						animationCount
					)
			)
			.ToDictionary(sprite => sprite.direction, sprite => (BaseSprite)sprite);
	}

	private static Dictionary<Direction, BaseSprite> LoadOmnidirectionalSprites(
		ImageGroup imageGroup,
		int imageIndex,
		int animationIndex,
		int animationCount
	)
	{
		return Enum.GetValues<Direction>()
			.Select(direction => new SimpleSprite(
				imageGroup,
				direction,
				-1,
				-1,
				-1,
				-1,
				-1,
				-1,
				imageIndex,
				-1,
				animationIndex,
				animationCount
			))
			.ToDictionary(sprite => sprite.direction, sprite => (BaseSprite)sprite);
	}

	public static readonly Dictionary<Direction, BaseSprite> CivilianFemale = LoadSprites(
		ImageGroup.CivilianFemale,
		0,
		8,
		8
	);
	public static readonly Dictionary<Direction, BaseSprite> CivilianMale = LoadSprites(
		ImageGroup.CivilianMale,
		0,
		8,
		8
	);
	public static readonly Dictionary<Direction, BaseSprite> Zombie = LoadSprites(
		ImageGroup.Zombie,
		0,
		8,
		8
	);
	public static readonly Dictionary<Direction, BaseSprite> Celatid = LoadOmnidirectionalSprites(
		ImageGroup.Celatid,
		0,
		1,
		5
	);
	public static readonly Dictionary<Direction, BaseSprite> Silacoid = LoadOmnidirectionalSprites(
		ImageGroup.Silacoid,
		0,
		1,
		5
	);
	public static readonly Dictionary<Direction, BaseSprite> Ethereal = LoadSprites(
		ImageGroup.Ethereal,
		0,
		8,
		8
	);
	public static readonly Dictionary<Direction, BaseSprite> Floater = LoadSpritesWithArms(
		ImageGroup.Floater,
		8,
		75,
		0,
		67,
		83,
		91,
		16,
		24,
		5
	);
	public static readonly Dictionary<Direction, BaseSprite> Snakeman = LoadSpritesWithHead(
		ImageGroup.Snakeman,
		0,
		107,
		8,
		99,
		115,
		123,
		16,
		24,
		32,
		8
	);

	public static readonly Dictionary<Direction, BaseSprite>[] All =
	[
		CivilianFemale,
		CivilianMale,
		Zombie,
		Celatid,
		Silacoid,
		Ethereal,
		Floater,
		Snakeman,
	];
}
