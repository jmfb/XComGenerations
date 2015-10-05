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

		private static readonly SoundPlayer ammoHit = new SoundPlayer(Battlescape.AmmoHit);
		private static readonly SoundPlayer beamHit = new SoundPlayer(Battlescape.BeamHit);
		private static readonly SoundPlayer bigGunShot = new SoundPlayer(Battlescape.BigGunShot);
		private static readonly SoundPlayer blasterLaunch = new SoundPlayer(Battlescape.BlasterLaunch);
		private static readonly SoundPlayer bulletHit = new SoundPlayer(Battlescape.BulletHit);
		private static readonly SoundPlayer celatidAttack = new SoundPlayer(Battlescape.CelatidAttack);
		private static readonly SoundPlayer celatidMove = new SoundPlayer(Battlescape.CelatidMove);
		private static readonly SoundPlayer celatidScream = new SoundPlayer(Battlescape.CelatidScream);
		private static readonly SoundPlayer chryssalidAttack = new SoundPlayer(Battlescape.ChryssalidAttack);
		private static readonly SoundPlayer doorOpen = new SoundPlayer(Battlescape.DoorOpen);
		private static readonly SoundPlayer etherealScream = new SoundPlayer(Battlescape.EtherealScream);
		private static readonly SoundPlayer flyingMovement = new SoundPlayer(Battlescape.FlyingMovement);
		private static readonly SoundPlayer footstepGround1 = new SoundPlayer(Battlescape.FootstepGround1);
		private static readonly SoundPlayer footstepGround2 = new SoundPlayer(Battlescape.FootstepGround2);
		private static readonly SoundPlayer footstepMars1 = new SoundPlayer(Battlescape.FootstepMars1);
		private static readonly SoundPlayer footstepMars2 = new SoundPlayer(Battlescape.FootstepMars2);
		private static readonly SoundPlayer footstepMetal1 = new SoundPlayer(Battlescape.FootstepMetal1);
		private static readonly SoundPlayer footstepMetal2 = new SoundPlayer(Battlescape.FootstepMetal2);
		private static readonly SoundPlayer footstepMud1 = new SoundPlayer(Battlescape.FootstepMud1);
		private static readonly SoundPlayer footstepMud2 = new SoundPlayer(Battlescape.FootstepMud2);
		private static readonly SoundPlayer footstepSand1 = new SoundPlayer(Battlescape.FootstepSand1);
		private static readonly SoundPlayer footstepSand2 = new SoundPlayer(Battlescape.FootstepSand2);
		private static readonly SoundPlayer footstepSnow1 = new SoundPlayer(Battlescape.FootstepSnow1);
		private static readonly SoundPlayer footstepSnow2 = new SoundPlayer(Battlescape.FootstepSnow2);
		private static readonly SoundPlayer gunShot = new SoundPlayer(Battlescape.GunShot);
		private static readonly SoundPlayer hovertankMove = new SoundPlayer(Battlescape.HovertankMove);
		private static readonly SoundPlayer itemDrop = new SoundPlayer(Battlescape.ItemDrop);
		private static readonly SoundPlayer itemThrow = new SoundPlayer(Battlescape.ItemThrow);
		private static readonly SoundPlayer largeExplosion = new SoundPlayer(Battlescape.LargeExplosion);
		private static readonly SoundPlayer laserShot = new SoundPlayer(Battlescape.LaserShot);
		private static readonly SoundPlayer machineDeath = new SoundPlayer(Battlescape.MachineDeath);
		private static readonly SoundPlayer mindControl = new SoundPlayer(Battlescape.MindControl);
		private static readonly SoundPlayer mindProbe = new SoundPlayer(Battlescape.MindProbe);
		private static readonly SoundPlayer mutonScream = new SoundPlayer(Battlescape.MutonScream);
		private static readonly SoundPlayer plasmaShot = new SoundPlayer(Battlescape.PlasmaShot);
		private static readonly SoundPlayer reaperAttack = new SoundPlayer(Battlescape.ReaperAttack);
		private static readonly SoundPlayer reload = new SoundPlayer(Battlescape.Reload);
		private static readonly SoundPlayer rocketLaunch = new SoundPlayer(Battlescape.RocketLaunch);
		private static readonly SoundPlayer screamFemale1 = new SoundPlayer(Battlescape.ScreamFemale1);
		private static readonly SoundPlayer screamFemale2 = new SoundPlayer(Battlescape.ScreamFemale2);
		private static readonly SoundPlayer screamFemale3 = new SoundPlayer(Battlescape.ScreamFemale3);
		private static readonly SoundPlayer screamMale1 = new SoundPlayer(Battlescape.ScreamMale1);
		private static readonly SoundPlayer screamMale2 = new SoundPlayer(Battlescape.ScreamMale2);
		private static readonly SoundPlayer screamMale3 = new SoundPlayer(Battlescape.ScreamMale3);
		private static readonly SoundPlayer sectoidScream = new SoundPlayer(Battlescape.SectoidScream);
		private static readonly SoundPlayer silacoidAttack = new SoundPlayer(Battlescape.SilacoidAttack);
		private static readonly SoundPlayer silacoidMove = new SoundPlayer(Battlescape.SilacoidMove);
		private static readonly SoundPlayer smallExplosion = new SoundPlayer(Battlescape.SmallExplosion);
		private static readonly SoundPlayer snakemanScream = new SoundPlayer(Battlescape.SnakemanScream);
		private static readonly SoundPlayer snakemanSlither = new SoundPlayer(Battlescape.SnakemanSlither);
		private static readonly SoundPlayer stunRod = new SoundPlayer(Battlescape.StunRod);
		private static readonly SoundPlayer tankMove = new SoundPlayer(Battlescape.TankMove);
		private static readonly SoundPlayer ufoDoorOpen1 = new SoundPlayer(Battlescape.UfoDoorOpen1);
		private static readonly SoundPlayer ufoDoorOpen2 = new SoundPlayer(Battlescape.UfoDoorOpen2);

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
