using System;
using System.Media;
using XCom.Content.SoundEffects;

namespace XCom.Music
{
	public enum SoundEffectType
	{
		ButtonPush,
		WindowOpen,
		WindowClose,

		Cannon,
		Missile,
		LaserCannon,
		PlasmaCannon,
		FusionBall,

		UfoHit,
		UfoExplosion,
		CraftHit,
		CraftExplosion
	}

	public static class SoundEffectTypeExtensions
	{
		public static void Play(this SoundEffectType soundEffect)
		{
			GetSoundPlayer(soundEffect).Play();
		}

		private static readonly SoundPlayer buttonPush1 = new SoundPlayer(SoundEffects.ButtonPush1);
		private static readonly SoundPlayer buttonPush2 = new SoundPlayer(SoundEffects.ButtonPush2);
		private static readonly SoundPlayer windowOpen1 = new SoundPlayer(SoundEffects.WindowOpen1);
		private static readonly SoundPlayer windowOpen2 = new SoundPlayer(SoundEffects.WindowOpen2);
		private static readonly SoundPlayer windowClose = new SoundPlayer(SoundEffects.WindowClose);

		private static readonly SoundPlayer cannon = new SoundPlayer(SoundEffects.Cannon);
		private static readonly SoundPlayer missile = new SoundPlayer(SoundEffects.Missile);
		private static readonly SoundPlayer laserCannon = new SoundPlayer(SoundEffects.LaserCannon);
		private static readonly SoundPlayer plasmaCannon = new SoundPlayer(SoundEffects.PlasmaCannon);
		private static readonly SoundPlayer fusionBall = new SoundPlayer(SoundEffects.FusionBall);

		private static readonly SoundPlayer ufoHit = new SoundPlayer(SoundEffects.UfoHit);
		private static readonly SoundPlayer ufoExplosion = new SoundPlayer(SoundEffects.UfoExplosion);
		private static readonly SoundPlayer craftHit = new SoundPlayer(SoundEffects.CraftHit);
		private static readonly SoundPlayer craftExplosion = new SoundPlayer(SoundEffects.CraftExplosion);

		private static SoundPlayer GetSoundPlayer(SoundEffectType soundEffect)
		{
			switch (soundEffect)
			{
			case SoundEffectType.ButtonPush:
				return GameState.Current.Random.Next(2) == 0 ? buttonPush1 : buttonPush2;
			case SoundEffectType.WindowOpen:
				return GameState.Current.Random.Next(2) == 0 ? windowOpen1 : windowOpen2;
			case SoundEffectType.WindowClose:
				return windowClose;

			case SoundEffectType.Cannon:
				return cannon;
			case SoundEffectType.Missile:
				return missile;
			case SoundEffectType.LaserCannon:
				return laserCannon;
			case SoundEffectType.PlasmaCannon:
				return plasmaCannon;
			case SoundEffectType.FusionBall:
				return fusionBall;

			case SoundEffectType.UfoHit:
				return ufoHit;
			case SoundEffectType.UfoExplosion:
				return ufoExplosion;
			case SoundEffectType.CraftHit:
				return craftHit;
			case SoundEffectType.CraftExplosion:
				return craftExplosion;
			}
			throw new InvalidOperationException("Invalid sound effect.");
		}
	}
}
