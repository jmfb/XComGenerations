namespace XCom.Battlescape.Tiles;

public static class GroundSprite
{
	private static byte[][] LoadSprites(int index, bool isLarge = false) =>
		isLarge
			? ImageGroup.Ground.Images.Skip(index).Take(4).ToArray()
			: [ImageGroup.Ground.Images[index]];

	// NOTE: Images 25 and 27 are unused

	public static readonly byte[][] LaserRifle = LoadSprites(0);
	public static readonly byte[][] Rifle = LoadSprites(1);
	public static readonly byte[][] RifleClip = LoadSprites(2);
	public static readonly byte[][] Pistol = LoadSprites(3);
	public static readonly byte[][] PistolClip = LoadSprites(4);
	public static readonly byte[][] LaserPistol = LoadSprites(5);
	public static readonly byte[][] HeavyLaser = LoadSprites(6);
	public static readonly byte[][] AutoCannon = LoadSprites(7);
	public static readonly byte[][] AcApAmmo = LoadSprites(8);
	public static readonly byte[][] AcHeAmmo = LoadSprites(9);
	public static readonly byte[][] AcIAmmo = LoadSprites(10);
	public static readonly byte[][] HeavyCannon = LoadSprites(11);
	public static readonly byte[][] HcApAmmo = LoadSprites(12);
	public static readonly byte[][] HcHeAmmo = LoadSprites(13);
	public static readonly byte[][] HcIAmmo = LoadSprites(14);
	public static readonly byte[][] RocketLauncher = LoadSprites(15);
	public static readonly byte[][] SmallRocket = LoadSprites(16);
	public static readonly byte[][] LargeRocket = LoadSprites(17);
	public static readonly byte[][] IncendiaryRocket = LoadSprites(18);
	public static readonly byte[][] Grenade = LoadSprites(19);
	public static readonly byte[][] SmokeGrenade = LoadSprites(20);
	public static readonly byte[][] ProximityGrenade = LoadSprites(21);
	public static readonly byte[][] HighExplosive = LoadSprites(22);
	public static readonly byte[][] MotionScanner = LoadSprites(23);
	public static readonly byte[][] MediKit = LoadSprites(24);
	public static readonly byte[][] StunRod = LoadSprites(26);
	public static readonly byte[][] MindProbe = LoadSprites(28);
	public static readonly byte[][] HeavyPlasma = LoadSprites(29);
	public static readonly byte[][] PlasmaRifle = LoadSprites(30);
	public static readonly byte[][] PlasmaPistol = LoadSprites(31);
	public static readonly byte[][] PsiAmp = LoadSprites(32);
	public static readonly byte[][] PlasmaClip = LoadSprites(33);
	public static readonly byte[][] BlasterLauncher = LoadSprites(34);
	public static readonly byte[][] BlasterBomb = LoadSprites(35);
	public static readonly byte[][] SmallLauncher = LoadSprites(36);
	public static readonly byte[][] StunBomb = LoadSprites(37);
	public static readonly byte[][] AlienGrenade = LoadSprites(38);
	public static readonly byte[][] SoldierCorpse = LoadSprites(39);
	public static readonly byte[][] PersonalArmorCorpse = LoadSprites(40);
	public static readonly byte[][] PowerSuitCorpse = LoadSprites(41);
	public static readonly byte[][] SectoidCorpse = LoadSprites(42);
	public static readonly byte[][] CelatidCorpse = LoadSprites(43);
	public static readonly byte[][] MutonCorpse = LoadSprites(44);
	public static readonly byte[][] EtherealCorpse = LoadSprites(45);
	public static readonly byte[][] SnakemanCorpse = LoadSprites(46);
	public static readonly byte[][] SilacoidCorpse = LoadSprites(47);
	public static readonly byte[][] FloaterCorpse = LoadSprites(48);
	public static readonly byte[][] ChryssalidCorpse = LoadSprites(49);
	public static readonly byte[][] MaleCivilianCorpse = LoadSprites(50);
	public static readonly byte[][] FemaleCivilianCorpse = LoadSprites(51);
	public static readonly byte[][] ReaperCorpse = LoadSprites(52, true);
	public static readonly byte[][] CyberdiscCorpse = LoadSprites(56, true);
	public static readonly byte[][] SectopodCorpse = LoadSprites(60, true);
	public static readonly byte[][] HovertankCorpse = LoadSprites(64, true);
	public static readonly byte[][] TankCorpse = LoadSprites(68, true);
	public static readonly byte[][] ElectroFlare = LoadSprites(72);
}
