using System;
using System.Media;
using XCom.Content.SoundEffects.Introduction;

namespace XCom.Music
{
	public enum IntroductionSoundEffect
	{
		Beep,
		Cannon,
		Chatter,
		Computer,
		DeadAlien1,
		DeadAlien2,
		DeadAlien3,
		DeathScreamFemale,
		DeathScreamMale,
		Hum,
		Landing,
		OpenHatch,
		Plasma,
		Roar1,
		Roar2,
		Roar3,
		Roar4,
		Shot,
		TakeOff,
		Teleport,
		UfoDetected,
		Warning,
		Whoosh
	}

	public static class IntroductionSoundEffectExtensions
	{
		public static void Play(this IntroductionSoundEffect soundEffect)
		{
			GetSoundPlayer(soundEffect).Play();
		}

		private static readonly SoundPlayer beep = new SoundPlayer(Introduction.Beep);
		private static readonly SoundPlayer cannon = new SoundPlayer(Introduction.Cannon);
		private static readonly SoundPlayer chatter = new SoundPlayer(Introduction.Chatter);
		private static readonly SoundPlayer computer = new SoundPlayer(Introduction.Computer);
		private static readonly SoundPlayer deadAlien1 = new SoundPlayer(Introduction.DeadAlien1);
		private static readonly SoundPlayer deadAlien2 = new SoundPlayer(Introduction.DeadAlien2);
		private static readonly SoundPlayer deadAlien3 = new SoundPlayer(Introduction.DeadAlien3);
		private static readonly SoundPlayer deathScreamFemale = new SoundPlayer(Introduction.DeathScreamFemale);
		private static readonly SoundPlayer deathScreamMale = new SoundPlayer(Introduction.DeathScreamMale);
		private static readonly SoundPlayer hum = new SoundPlayer(Introduction.Hum);
		private static readonly SoundPlayer landing = new SoundPlayer(Introduction.Landing);
		private static readonly SoundPlayer openHatch = new SoundPlayer(Introduction.OpenHatch);
		private static readonly SoundPlayer plasma = new SoundPlayer(Introduction.Plasma);
		private static readonly SoundPlayer roar1 = new SoundPlayer(Introduction.Roar1);
		private static readonly SoundPlayer roar2 = new SoundPlayer(Introduction.Roar2);
		private static readonly SoundPlayer roar3 = new SoundPlayer(Introduction.Roar3);
		private static readonly SoundPlayer roar4 = new SoundPlayer(Introduction.Roar4);
		private static readonly SoundPlayer shot = new SoundPlayer(Introduction.Shot);
		private static readonly SoundPlayer takeOff = new SoundPlayer(Introduction.TakeOff);
		private static readonly SoundPlayer teleport = new SoundPlayer(Introduction.Teleport);
		private static readonly SoundPlayer ufoDetected = new SoundPlayer(Introduction.UfoDetected);
		private static readonly SoundPlayer warning = new SoundPlayer(Introduction.Warning);
		private static readonly SoundPlayer whoosh = new SoundPlayer(Introduction.Whoosh);

		private static SoundPlayer GetSoundPlayer(IntroductionSoundEffect soundEffect)
		{
			switch (soundEffect)
			{
			case IntroductionSoundEffect.Beep:
				return beep;
			case IntroductionSoundEffect.Cannon:
				return cannon;
			case IntroductionSoundEffect.Chatter:
				return chatter;
			case IntroductionSoundEffect.Computer:
				return computer;
			case IntroductionSoundEffect.DeadAlien1:
				return deadAlien1;
			case IntroductionSoundEffect.DeadAlien2:
				return deadAlien2;
			case IntroductionSoundEffect.DeadAlien3:
				return deadAlien3;
			case IntroductionSoundEffect.DeathScreamFemale:
				return deathScreamFemale;
			case IntroductionSoundEffect.DeathScreamMale:
				return deathScreamMale;
			case IntroductionSoundEffect.Hum:
				return hum;
			case IntroductionSoundEffect.Landing:
				return landing;
			case IntroductionSoundEffect.OpenHatch:
				return openHatch;
			case IntroductionSoundEffect.Plasma:
				return plasma;
			case IntroductionSoundEffect.Roar1:
				return roar1;
			case IntroductionSoundEffect.Roar2:
				return roar2;
			case IntroductionSoundEffect.Roar3:
				return roar3;
			case IntroductionSoundEffect.Roar4:
				return roar4;
			case IntroductionSoundEffect.Shot:
				return shot;
			case IntroductionSoundEffect.TakeOff:
				return takeOff;
			case IntroductionSoundEffect.Teleport:
				return teleport;
			case IntroductionSoundEffect.UfoDetected:
				return ufoDetected;
			case IntroductionSoundEffect.Warning:
				return warning;
			case IntroductionSoundEffect.Whoosh:
				return whoosh;
			}
			throw new InvalidOperationException("Invalid sound effect.");
		}
	}
}
