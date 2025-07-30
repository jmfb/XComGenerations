using System.Media;
using XCom.Content.SoundEffects.Introduction;

namespace XCom.Music;

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
	Whoosh,
}

public static class IntroductionSoundEffectExtensions
{
	public static void Play(this IntroductionSoundEffect soundEffect)
	{
		GetSoundPlayer(soundEffect).Play();
	}

	private static readonly SoundPlayer beep = new(Introduction.Beep);
	private static readonly SoundPlayer cannon = new(Introduction.Cannon);
	private static readonly SoundPlayer chatter = new(Introduction.Chatter);
	private static readonly SoundPlayer computer = new(Introduction.Computer);
	private static readonly SoundPlayer deadAlien1 = new(Introduction.DeadAlien1);
	private static readonly SoundPlayer deadAlien2 = new(Introduction.DeadAlien2);
	private static readonly SoundPlayer deadAlien3 = new(Introduction.DeadAlien3);
	private static readonly SoundPlayer deathScreamFemale = new(Introduction.DeathScreamFemale);
	private static readonly SoundPlayer deathScreamMale = new(Introduction.DeathScreamMale);
	private static readonly SoundPlayer hum = new(Introduction.Hum);
	private static readonly SoundPlayer landing = new(Introduction.Landing);
	private static readonly SoundPlayer openHatch = new(Introduction.OpenHatch);
	private static readonly SoundPlayer plasma = new(Introduction.Plasma);
	private static readonly SoundPlayer roar1 = new(Introduction.Roar1);
	private static readonly SoundPlayer roar2 = new(Introduction.Roar2);
	private static readonly SoundPlayer roar3 = new(Introduction.Roar3);
	private static readonly SoundPlayer roar4 = new(Introduction.Roar4);
	private static readonly SoundPlayer shot = new(Introduction.Shot);
	private static readonly SoundPlayer takeOff = new(Introduction.TakeOff);
	private static readonly SoundPlayer teleport = new(Introduction.Teleport);
	private static readonly SoundPlayer ufoDetected = new(Introduction.UfoDetected);
	private static readonly SoundPlayer warning = new(Introduction.Warning);
	private static readonly SoundPlayer whoosh = new(Introduction.Whoosh);

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
