using System;

namespace XCom.Music
{
	public static class MidiFiles
	{
		private static readonly MidiFile battlescape = new MidiFile(Content.Music.Music.Battlescape);
		private static readonly MidiFile enemyBase = new MidiFile(Content.Music.Music.EnemyBase);
		private static readonly MidiFile geoscape1 = new MidiFile(Content.Music.Music.Geoscape1);
		private static readonly MidiFile geoscape2 = new MidiFile(Content.Music.Music.Geoscape2);
		private static readonly MidiFile intercept = new MidiFile(Content.Music.Music.Intercept);
		private static readonly MidiFile introduction1 = new MidiFile(Content.Music.Music.Introduction1);
		private static readonly MidiFile introduction2 = new MidiFile(Content.Music.Music.Introduction2);
		private static readonly MidiFile introduction3 = new MidiFile(Content.Music.Music.Introduction3);
		private static readonly MidiFile lose = new MidiFile(Content.Music.Music.Lose);
		private static readonly MidiFile mars = new MidiFile(Content.Music.Music.Mars);
		private static readonly MidiFile mission = new MidiFile(Content.Music.Music.Mission);
		private static readonly MidiFile month = new MidiFile(Content.Music.Music.Month);
		private static readonly MidiFile story = new MidiFile(Content.Music.Music.Story);
		private static readonly MidiFile win = new MidiFile(Content.Music.Music.Win);

		private static MusicType currentMusic = MusicType.Story;

		public static void Play(MusicType music)
		{
			if (music == currentMusic)
				return;
			currentMusic = music;
			GameState.Current.MusicPlayer.PlayFiles(GetMusicFiles(music));
		}

		private static MidiFile[] GetMusicFiles(MusicType music)
		{
			switch (music)
			{
			case MusicType.Battlescape:
				return new[] { battlescape };
			case MusicType.EnemyBase:
				return new[] { enemyBase };
			case MusicType.Geoscape:
				return new[] { GameState.Current.Random.Next(2) == 0 ? geoscape1 : geoscape2 };
			case MusicType.Intercept:
				return new[] { intercept };
			case MusicType.Introduction:
				return new[] { introduction1, introduction2, introduction3 };
			case MusicType.Lose:
				return new[] { lose };
			case MusicType.Mars:
				return new[] { mars };
			case MusicType.Mission:
				return new[] { mission };
			case MusicType.Month:
				return new[] { month };
			case MusicType.Story:
				return new[] { story };
			case MusicType.Win:
				return new[] { win };
			default:
				throw new InvalidOperationException("Invalid music type.");
			}
		}
	}
}
