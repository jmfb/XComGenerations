using XCom.Graphics;

namespace XCom.Battlescape.Tiles;

public class Animation
{
	private readonly byte[][] images;

	private Animation(ImageGroup imageGroup, int index, int count)
	{
		images = imageGroup.Images.Skip(index).Take(count).ToArray();
	}

	public void Animate(GraphicsBuffer buffer, int topRow, int leftColumn, int frame)
	{
		buffer.DrawItem(topRow, leftColumn, images[frame]);
	}

	public int FrameCount => images.Length;

	public static readonly Animation SoldierCoverallsDeath = new(
		ImageGroup.SoldierCoveralls,
		264,
		3
	);
	public static readonly Animation SoldierPersonalArmorDeath = new(
		ImageGroup.SoldierPersonalArmor,
		264,
		3
	);
	public static readonly Animation SoldierPowerSuitDeath = new(
		ImageGroup.SoldierPowerSuit,
		264,
		3
	);
	public static readonly Animation CivilianFemaleDeath = new(ImageGroup.CivilianFemale, 72, 3);
	public static readonly Animation CivilianMaleDeath = new(ImageGroup.CivilianMale, 72, 3);
	public static readonly Animation ZombieDeath = new(ImageGroup.Zombie, 72, 18);
	public static readonly Animation CelatidDeath = new(ImageGroup.Celatid, 25, 3);
	public static readonly Animation CelatidFiring = new(ImageGroup.Celatid, 6, 18); //Shot is ImageGroup.Images[24]
	public static readonly Animation SilacoidDeath = new(ImageGroup.Silacoid, 6, 3);
	public static readonly Animation EtherealDeath = new(ImageGroup.Ethereal, 72, 3);
	public static readonly Animation MutonDeath = new(ImageGroup.Muton, 264, 3);
	public static readonly Animation SectoidDeath = new(ImageGroup.Sectoid, 264, 3);
	public static readonly Animation ChryssalidDeath = new(ImageGroup.Chryssalid, 224, 3);
	public static readonly Animation FloaterDeath = new(ImageGroup.Floater, 64, 3);
	public static readonly Animation SnakemanDeath = new(ImageGroup.Snakeman, 96, 3);
}
