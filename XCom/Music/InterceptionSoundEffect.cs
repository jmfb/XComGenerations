using System;
using System.Media;
using XCom.Content.SoundEffects.Interception;

namespace XCom.Music
{
	public enum InterceptionSoundEffect
	{
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

	public static class InterceptionSoundEffectExtensions
	{
		public static void Play(this InterceptionSoundEffect soundEffect)
		{
			GetSoundPlayer(soundEffect).Play();
		}

		private static readonly SoundPlayer cannon = new SoundPlayer(Interception.Cannon);
		private static readonly SoundPlayer missile = new SoundPlayer(Interception.Missile);
		private static readonly SoundPlayer laserCannon = new SoundPlayer(Interception.LaserCannon);
		private static readonly SoundPlayer plasmaCannon = new SoundPlayer(Interception.PlasmaCannon);
		private static readonly SoundPlayer fusionBall = new SoundPlayer(Interception.FusionBall);

		private static readonly SoundPlayer ufoHit = new SoundPlayer(Interception.UfoHit);
		private static readonly SoundPlayer ufoExplosion = new SoundPlayer(Interception.UfoExplosion);
		private static readonly SoundPlayer craftHit = new SoundPlayer(Interception.CraftHit);
		private static readonly SoundPlayer craftExplosion = new SoundPlayer(Interception.CraftExplosion);

		private static SoundPlayer GetSoundPlayer(InterceptionSoundEffect soundEffect)
		{
			switch (soundEffect)
			{
			case InterceptionSoundEffect.Cannon:
				return cannon;
			case InterceptionSoundEffect.Missile:
				return missile;
			case InterceptionSoundEffect.LaserCannon:
				return laserCannon;
			case InterceptionSoundEffect.PlasmaCannon:
				return plasmaCannon;
			case InterceptionSoundEffect.FusionBall:
				return fusionBall;

			case InterceptionSoundEffect.UfoHit:
				return ufoHit;
			case InterceptionSoundEffect.UfoExplosion:
				return ufoExplosion;
			case InterceptionSoundEffect.CraftHit:
				return craftHit;
			case InterceptionSoundEffect.CraftExplosion:
				return craftExplosion;
			}
			throw new InvalidOperationException("Invalid sound effect.");
		}
	}
}
