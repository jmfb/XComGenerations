using System;
using System.Media;
using XCom.Content.SoundEffects.Windows;

namespace XCom.Music
{
	public enum WindowsSoundEffect
	{
		ButtonPush,
		WindowOpen,
		WindowClose
	}

	public static class WindowsSoundEffectExtensions
	{
		public static void Play(this WindowsSoundEffect soundEffect)
		{
			GetSoundPlayer(soundEffect).Play();
		}

		private static readonly SoundPlayer buttonPush1 = new SoundPlayer(Windows.ButtonPush1);
		private static readonly SoundPlayer buttonPush2 = new SoundPlayer(Windows.ButtonPush2);
		private static readonly SoundPlayer windowOpen1 = new SoundPlayer(Windows.WindowOpen1);
		private static readonly SoundPlayer windowOpen2 = new SoundPlayer(Windows.WindowOpen2);
		private static readonly SoundPlayer windowClose = new SoundPlayer(Windows.WindowClose);

		private static SoundPlayer GetSoundPlayer(WindowsSoundEffect soundEffect)
		{
			switch (soundEffect)
			{
			case WindowsSoundEffect.ButtonPush:
				return GameState.Current.Random.Next(2) == 0 ? buttonPush1 : buttonPush2;
			case WindowsSoundEffect.WindowOpen:
				return GameState.Current.Random.Next(2) == 0 ? windowOpen1 : windowOpen2;
			case WindowsSoundEffect.WindowClose:
				return windowClose;
			}
			throw new InvalidOperationException("Invalid sound effect.");
		}
	}
}
