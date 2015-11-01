using System.Collections.Generic;
using System.Linq;

namespace XCom.Battlescape.Tiles
{
	public static class BattleItemSprite
	{
		private static Dictionary<Direction, byte[]> LoadSprites(int groupIndex)
		{
			return EnumEx.GetValues<Direction>()
				.Select((direction, index) => new
				{
					Direction = direction,
					Image = ImageGroup.Hand.Images[groupIndex * 8 + index]
				})
				.ToDictionary(value => value.Direction, value => value.Image);
		}

		public static readonly Dictionary<Direction, byte[]> Rifle = LoadSprites(0);
		public static readonly Dictionary<Direction, byte[]> LaserRifle = LoadSprites(1);
		public static readonly Dictionary<Direction, byte[]> HeavyLaser = LoadSprites(2);
		public static readonly Dictionary<Direction, byte[]> HeavyCannon = LoadSprites(3);
		public static readonly Dictionary<Direction, byte[]> AutoCannon = LoadSprites(4);
		public static readonly Dictionary<Direction, byte[]> HeavyPlasma = LoadSprites(5);
		public static readonly Dictionary<Direction, byte[]> PlasmaRifle = LoadSprites(6);
		public static readonly Dictionary<Direction, byte[]> BlasterLauncher = LoadSprites(7);
		public static readonly Dictionary<Direction, byte[]> SmallLauncher = LoadSprites(8);
		public static readonly Dictionary<Direction, byte[]> RocketLauncher = LoadSprites(9);
		public static readonly Dictionary<Direction, byte[]> StunRod = LoadSprites(10);
		public static readonly Dictionary<Direction, byte[]> PsiAmp = LoadSprites(11);
		public static readonly Dictionary<Direction, byte[]> Pistol = LoadSprites(12);
		public static readonly Dictionary<Direction, byte[]> PlasmaPistol = LoadSprites(13);
		public static readonly Dictionary<Direction, byte[]> LaserPistol = LoadSprites(14);
		public static readonly Dictionary<Direction, byte[]> Grenade = LoadSprites(15);
	}
}
