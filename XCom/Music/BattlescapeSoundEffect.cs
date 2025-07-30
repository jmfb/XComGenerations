using System.Media;
using XCom.Content.SoundEffects.Battlescape;

namespace XCom.Music;

public enum BattlescapeSoundEffect
{
	AmmoHit,
	BeamHit,
	BigGunShot,
	BlasterLaunch,
	BulletHit,
	CelatidAttack,
	CelatidMove,
	CelatidScream,
	ChryssalidAttack,
	DoorOpen,
	EtherealScream,
	FlyingMovement,
	FootstepGround1,
	FootstepGround2,
	FootstepMars1,
	FootstepMars2,
	FootstepMetal1,
	FootstepMetal2,
	FootstepMud1,
	FootstepMud2,
	FootstepSand1,
	FootstepSand2,
	FootstepSnow1,
	FootstepSnow2,
	GunShot,
	HovertankMove,
	ItemDrop,
	ItemThrow,
	LargeExplosion,
	LaserShot,
	MachineDeath,
	MindControl,
	MindProbe,
	MutonScream,
	PlasmaShot,
	ReaperAttack,
	Reload,
	RocketLaunch,
	ScreamFemale1,
	ScreamFemale2,
	ScreamFemale3,
	ScreamMale1,
	ScreamMale2,
	ScreamMale3,
	SectoidScream,
	SilacoidAttack,
	SilacoidMove,
	SmallExplosion,
	SnakemanScream,
	SnakemanSlither,
	StunRod,
	TankMove,
	UfoDoorOpen1,
	UfoDoorOpen2,
}

public static class BattlescapeSoundEffectExtensions
{
	public static void Play(this BattlescapeSoundEffect soundEffect)
	{
		GetSoundPlayer(soundEffect).Play();
	}

	private static readonly SoundPlayer ammoHit = new(BattlescapeSounds.AmmoHit);
	private static readonly SoundPlayer beamHit = new(BattlescapeSounds.BeamHit);
	private static readonly SoundPlayer bigGunShot = new(BattlescapeSounds.BigGunShot);
	private static readonly SoundPlayer blasterLaunch = new(BattlescapeSounds.BlasterLaunch);
	private static readonly SoundPlayer bulletHit = new(BattlescapeSounds.BulletHit);
	private static readonly SoundPlayer celatidAttack = new(BattlescapeSounds.CelatidAttack);
	private static readonly SoundPlayer celatidMove = new(BattlescapeSounds.CelatidMove);
	private static readonly SoundPlayer celatidScream = new(BattlescapeSounds.CelatidScream);
	private static readonly SoundPlayer chryssalidAttack = new(BattlescapeSounds.ChryssalidAttack);
	private static readonly SoundPlayer doorOpen = new(BattlescapeSounds.DoorOpen);
	private static readonly SoundPlayer etherealScream = new(BattlescapeSounds.EtherealScream);
	private static readonly SoundPlayer flyingMovement = new(BattlescapeSounds.FlyingMovement);
	private static readonly SoundPlayer footstepGround1 = new(BattlescapeSounds.FootstepGround1);
	private static readonly SoundPlayer footstepGround2 = new(BattlescapeSounds.FootstepGround2);
	private static readonly SoundPlayer footstepMars1 = new(BattlescapeSounds.FootstepMars1);
	private static readonly SoundPlayer footstepMars2 = new(BattlescapeSounds.FootstepMars2);
	private static readonly SoundPlayer footstepMetal1 = new(BattlescapeSounds.FootstepMetal1);
	private static readonly SoundPlayer footstepMetal2 = new(BattlescapeSounds.FootstepMetal2);
	private static readonly SoundPlayer footstepMud1 = new(BattlescapeSounds.FootstepMud1);
	private static readonly SoundPlayer footstepMud2 = new(BattlescapeSounds.FootstepMud2);
	private static readonly SoundPlayer footstepSand1 = new(BattlescapeSounds.FootstepSand1);
	private static readonly SoundPlayer footstepSand2 = new(BattlescapeSounds.FootstepSand2);
	private static readonly SoundPlayer footstepSnow1 = new(BattlescapeSounds.FootstepSnow1);
	private static readonly SoundPlayer footstepSnow2 = new(BattlescapeSounds.FootstepSnow2);
	private static readonly SoundPlayer gunShot = new(BattlescapeSounds.GunShot);
	private static readonly SoundPlayer hovertankMove = new(BattlescapeSounds.HovertankMove);
	private static readonly SoundPlayer itemDrop = new(BattlescapeSounds.ItemDrop);
	private static readonly SoundPlayer itemThrow = new(BattlescapeSounds.ItemThrow);
	private static readonly SoundPlayer largeExplosion = new(BattlescapeSounds.LargeExplosion);
	private static readonly SoundPlayer laserShot = new(BattlescapeSounds.LaserShot);
	private static readonly SoundPlayer machineDeath = new(BattlescapeSounds.MachineDeath);
	private static readonly SoundPlayer mindControl = new(BattlescapeSounds.MindControl);
	private static readonly SoundPlayer mindProbe = new(BattlescapeSounds.MindProbe);
	private static readonly SoundPlayer mutonScream = new(BattlescapeSounds.MutonScream);
	private static readonly SoundPlayer plasmaShot = new(BattlescapeSounds.PlasmaShot);
	private static readonly SoundPlayer reaperAttack = new(BattlescapeSounds.ReaperAttack);
	private static readonly SoundPlayer reload = new(BattlescapeSounds.Reload);
	private static readonly SoundPlayer rocketLaunch = new(BattlescapeSounds.RocketLaunch);
	private static readonly SoundPlayer screamFemale1 = new(BattlescapeSounds.ScreamFemale1);
	private static readonly SoundPlayer screamFemale2 = new(BattlescapeSounds.ScreamFemale2);
	private static readonly SoundPlayer screamFemale3 = new(BattlescapeSounds.ScreamFemale3);
	private static readonly SoundPlayer screamMale1 = new(BattlescapeSounds.ScreamMale1);
	private static readonly SoundPlayer screamMale2 = new(BattlescapeSounds.ScreamMale2);
	private static readonly SoundPlayer screamMale3 = new(BattlescapeSounds.ScreamMale3);
	private static readonly SoundPlayer sectoidScream = new(BattlescapeSounds.SectoidScream);
	private static readonly SoundPlayer silacoidAttack = new(BattlescapeSounds.SilacoidAttack);
	private static readonly SoundPlayer silacoidMove = new(BattlescapeSounds.SilacoidMove);
	private static readonly SoundPlayer smallExplosion = new(BattlescapeSounds.SmallExplosion);
	private static readonly SoundPlayer snakemanScream = new(BattlescapeSounds.SnakemanScream);
	private static readonly SoundPlayer snakemanSlither = new(BattlescapeSounds.SnakemanSlither);
	private static readonly SoundPlayer stunRod = new(BattlescapeSounds.StunRod);
	private static readonly SoundPlayer tankMove = new(BattlescapeSounds.TankMove);
	private static readonly SoundPlayer ufoDoorOpen1 = new(BattlescapeSounds.UfoDoorOpen1);
	private static readonly SoundPlayer ufoDoorOpen2 = new(BattlescapeSounds.UfoDoorOpen2);

	private static SoundPlayer GetSoundPlayer(BattlescapeSoundEffect soundEffect)
	{
		switch (soundEffect)
		{
			case BattlescapeSoundEffect.AmmoHit:
				return ammoHit;
			case BattlescapeSoundEffect.BeamHit:
				return beamHit;
			case BattlescapeSoundEffect.BigGunShot:
				return bigGunShot;
			case BattlescapeSoundEffect.BlasterLaunch:
				return blasterLaunch;
			case BattlescapeSoundEffect.BulletHit:
				return bulletHit;
			case BattlescapeSoundEffect.CelatidAttack:
				return celatidAttack;
			case BattlescapeSoundEffect.CelatidMove:
				return celatidMove;
			case BattlescapeSoundEffect.CelatidScream:
				return celatidScream;
			case BattlescapeSoundEffect.ChryssalidAttack:
				return chryssalidAttack;
			case BattlescapeSoundEffect.DoorOpen:
				return doorOpen;
			case BattlescapeSoundEffect.EtherealScream:
				return etherealScream;
			case BattlescapeSoundEffect.FlyingMovement:
				return flyingMovement;
			case BattlescapeSoundEffect.FootstepGround1:
				return footstepGround1;
			case BattlescapeSoundEffect.FootstepGround2:
				return footstepGround2;
			case BattlescapeSoundEffect.FootstepMars1:
				return footstepMars1;
			case BattlescapeSoundEffect.FootstepMars2:
				return footstepMars2;
			case BattlescapeSoundEffect.FootstepMetal1:
				return footstepMetal1;
			case BattlescapeSoundEffect.FootstepMetal2:
				return footstepMetal2;
			case BattlescapeSoundEffect.FootstepMud1:
				return footstepMud1;
			case BattlescapeSoundEffect.FootstepMud2:
				return footstepMud2;
			case BattlescapeSoundEffect.FootstepSand1:
				return footstepSand1;
			case BattlescapeSoundEffect.FootstepSand2:
				return footstepSand2;
			case BattlescapeSoundEffect.FootstepSnow1:
				return footstepSnow1;
			case BattlescapeSoundEffect.FootstepSnow2:
				return footstepSnow2;
			case BattlescapeSoundEffect.GunShot:
				return gunShot;
			case BattlescapeSoundEffect.HovertankMove:
				return hovertankMove;
			case BattlescapeSoundEffect.ItemDrop:
				return itemDrop;
			case BattlescapeSoundEffect.ItemThrow:
				return itemThrow;
			case BattlescapeSoundEffect.LargeExplosion:
				return largeExplosion;
			case BattlescapeSoundEffect.LaserShot:
				return laserShot;
			case BattlescapeSoundEffect.MachineDeath:
				return machineDeath;
			case BattlescapeSoundEffect.MindControl:
				return mindControl;
			case BattlescapeSoundEffect.MindProbe:
				return mindProbe;
			case BattlescapeSoundEffect.MutonScream:
				return mutonScream;
			case BattlescapeSoundEffect.PlasmaShot:
				return plasmaShot;
			case BattlescapeSoundEffect.ReaperAttack:
				return reaperAttack;
			case BattlescapeSoundEffect.Reload:
				return reload;
			case BattlescapeSoundEffect.RocketLaunch:
				return rocketLaunch;
			case BattlescapeSoundEffect.ScreamFemale1:
				return screamFemale1;
			case BattlescapeSoundEffect.ScreamFemale2:
				return screamFemale2;
			case BattlescapeSoundEffect.ScreamFemale3:
				return screamFemale3;
			case BattlescapeSoundEffect.ScreamMale1:
				return screamMale1;
			case BattlescapeSoundEffect.ScreamMale2:
				return screamMale2;
			case BattlescapeSoundEffect.ScreamMale3:
				return screamMale3;
			case BattlescapeSoundEffect.SectoidScream:
				return sectoidScream;
			case BattlescapeSoundEffect.SilacoidAttack:
				return silacoidAttack;
			case BattlescapeSoundEffect.SilacoidMove:
				return silacoidMove;
			case BattlescapeSoundEffect.SmallExplosion:
				return smallExplosion;
			case BattlescapeSoundEffect.SnakemanScream:
				return snakemanScream;
			case BattlescapeSoundEffect.SnakemanSlither:
				return snakemanSlither;
			case BattlescapeSoundEffect.StunRod:
				return stunRod;
			case BattlescapeSoundEffect.TankMove:
				return tankMove;
			case BattlescapeSoundEffect.UfoDoorOpen1:
				return ufoDoorOpen1;
			case BattlescapeSoundEffect.UfoDoorOpen2:
				return ufoDoorOpen2;
		}
		throw new InvalidOperationException("Invalid sound effect.");
	}
}
