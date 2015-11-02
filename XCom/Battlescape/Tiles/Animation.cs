using System.Linq;
using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
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

		public static readonly Animation SoldierCoverallsDeath = new Animation(ImageGroup.SoldierCoveralls, 264, 3);
		public static readonly Animation SoldierPersonalArmorDeath = new Animation(ImageGroup.SoldierPersonalArmor, 264, 3);
		public static readonly Animation SoldierPowerSuitDeath = new Animation(ImageGroup.SoldierPowerSuit, 264, 3);
		public static readonly Animation CivilianFemaleDeath = new Animation(ImageGroup.CivilianFemale, 72, 3);
		public static readonly Animation CivilianMaleDeath = new Animation(ImageGroup.CivilianMale, 72, 3);
		public static readonly Animation ZombieDeath = new Animation(ImageGroup.Zombie, 72, 18);
		public static readonly Animation CelatidDeath = new Animation(ImageGroup.Celatid, 25, 3);
		public static readonly Animation CelatidFiring = new Animation(ImageGroup.Celatid, 6, 18); //Shot is ImageGroup.Images[24]
		public static readonly Animation SilacoidDeath = new Animation(ImageGroup.Silacoid, 6, 3);
		public static readonly Animation EtherealDeath = new Animation(ImageGroup.Ethereal, 72, 3);
	}
}
