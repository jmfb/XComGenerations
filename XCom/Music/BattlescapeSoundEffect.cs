using System;
using System.Media;
using XCom.Content.SoundEffects.Battlescape;

namespace XCom.Music
{
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
		UfoDoorOpen2
	}

	public static class BattlescapeSoundEffectExtensions
	{
		public static void Play(this BattlescapeSoundEffect soundEffect)
		{
			GetSoundPlayer(soundEffect).Play();
		}

		private static readonly SoundPlayer ammoHit = new SoundPlayer(BattlescapeSounds.AmmoHit);
		private static readonly SoundPlayer beamHit = new SoundPlayer(BattlescapeSounds.BeamHit);
		private static readonly SoundPlayer bigGunShot = new SoundPlayer(BattlescapeSounds.BigGunShot);
		private static readonly SoundPlayer blasterLaunch = new SoundPlayer(BattlescapeSounds.BlasterLaunch);
		private static readonly SoundPlayer bulletHit = new SoundPlayer(BattlescapeSounds.BulletHit);
		private static readonly SoundPlayer celatidAttack = new SoundPlayer(BattlescapeSounds.CelatidAttack);
		private static readonly SoundPlayer celatidMove = new SoundPlayer(BattlescapeSounds.CelatidMove);
		private static readonly SoundPlayer celatidScream = new SoundPlayer(BattlescapeSounds.CelatidScream);
		private static readonly SoundPlayer chryssalidAttack = new SoundPlayer(BattlescapeSounds.ChryssalidAttack);
		private static readonly SoundPlayer doorOpen = new SoundPlayer(BattlescapeSounds.DoorOpen);
		private static readonly SoundPlayer etherealScream = new SoundPlayer(BattlescapeSounds.EtherealScream);
		private static readonly SoundPlayer flyingMovement = new SoundPlayer(BattlescapeSounds.FlyingMovement);
		private static readonly SoundPlayer footstepGround1 = new SoundPlayer(BattlescapeSounds.FootstepGround1);
		private static readonly SoundPlayer footstepGround2 = new SoundPlayer(BattlescapeSounds.FootstepGround2);
		private static readonly SoundPlayer footstepMars1 = new SoundPlayer(BattlescapeSounds.FootstepMars1);
		private static readonly SoundPlayer footstepMars2 = new SoundPlayer(BattlescapeSounds.FootstepMars2);
		private static readonly SoundPlayer footstepMetal1 = new SoundPlayer(BattlescapeSounds.FootstepMetal1);
		private static readonly SoundPlayer footstepMetal2 = new SoundPlayer(BattlescapeSounds.FootstepMetal2);
		private static readonly SoundPlayer footstepMud1 = new SoundPlayer(BattlescapeSounds.FootstepMud1);
		private static readonly SoundPlayer footstepMud2 = new SoundPlayer(BattlescapeSounds.FootstepMud2);
		private static readonly SoundPlayer footstepSand1 = new SoundPlayer(BattlescapeSounds.FootstepSand1);
		private static readonly SoundPlayer footstepSand2 = new SoundPlayer(BattlescapeSounds.FootstepSand2);
		private static readonly SoundPlayer footstepSnow1 = new SoundPlayer(BattlescapeSounds.FootstepSnow1);
		private static readonly SoundPlayer footstepSnow2 = new SoundPlayer(BattlescapeSounds.FootstepSnow2);
		private static readonly SoundPlayer gunShot = new SoundPlayer(BattlescapeSounds.GunShot);
		private static readonly SoundPlayer hovertankMove = new SoundPlayer(BattlescapeSounds.HovertankMove);
		private static readonly SoundPlayer itemDrop = new SoundPlayer(BattlescapeSounds.ItemDrop);
		private static readonly SoundPlayer itemThrow = new SoundPlayer(BattlescapeSounds.ItemThrow);
		private static readonly SoundPlayer largeExplosion = new SoundPlayer(BattlescapeSounds.LargeExplosion);
		private static readonly SoundPlayer laserShot = new SoundPlayer(BattlescapeSounds.LaserShot);
		private static readonly SoundPlayer machineDeath = new SoundPlayer(BattlescapeSounds.MachineDeath);
		private static readonly SoundPlayer mindControl = new SoundPlayer(BattlescapeSounds.MindControl);
		private static readonly SoundPlayer mindProbe = new SoundPlayer(BattlescapeSounds.MindProbe);
		private static readonly SoundPlayer mutonScream = new SoundPlayer(BattlescapeSounds.MutonScream);
		private static readonly SoundPlayer plasmaShot = new SoundPlayer(BattlescapeSounds.PlasmaShot);
		private static readonly SoundPlayer reaperAttack = new SoundPlayer(BattlescapeSounds.ReaperAttack);
		private static readonly SoundPlayer reload = new SoundPlayer(BattlescapeSounds.Reload);
		private static readonly SoundPlayer rocketLaunch = new SoundPlayer(BattlescapeSounds.RocketLaunch);
		private static readonly SoundPlayer screamFemale1 = new SoundPlayer(BattlescapeSounds.ScreamFemale1);
		private static readonly SoundPlayer screamFemale2 = new SoundPlayer(BattlescapeSounds.ScreamFemale2);
		private static readonly SoundPlayer screamFemale3 = new SoundPlayer(BattlescapeSounds.ScreamFemale3);
		private static readonly SoundPlayer screamMale1 = new SoundPlayer(BattlescapeSounds.ScreamMale1);
		private static readonly SoundPlayer screamMale2 = new SoundPlayer(BattlescapeSounds.ScreamMale2);
		private static readonly SoundPlayer screamMale3 = new SoundPlayer(BattlescapeSounds.ScreamMale3);
		private static readonly SoundPlayer sectoidScream = new SoundPlayer(BattlescapeSounds.SectoidScream);
		private static readonly SoundPlayer silacoidAttack = new SoundPlayer(BattlescapeSounds.SilacoidAttack);
		private static readonly SoundPlayer silacoidMove = new SoundPlayer(BattlescapeSounds.SilacoidMove);
		private static readonly SoundPlayer smallExplosion = new SoundPlayer(BattlescapeSounds.SmallExplosion);
		private static readonly SoundPlayer snakemanScream = new SoundPlayer(BattlescapeSounds.SnakemanScream);
		private static readonly SoundPlayer snakemanSlither = new SoundPlayer(BattlescapeSounds.SnakemanSlither);
		private static readonly SoundPlayer stunRod = new SoundPlayer(BattlescapeSounds.StunRod);
		private static readonly SoundPlayer tankMove = new SoundPlayer(BattlescapeSounds.TankMove);
		private static readonly SoundPlayer ufoDoorOpen1 = new SoundPlayer(BattlescapeSounds.UfoDoorOpen1);
		private static readonly SoundPlayer ufoDoorOpen2 = new SoundPlayer(BattlescapeSounds.UfoDoorOpen2);

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
}
