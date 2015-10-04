using System;

namespace XCom.Music
{
	public static class MidiFiles
	{
		private static readonly MidiFile battlescape = new MidiFile(Content.Music.Music.Geoscape1);
		private static readonly MidiFile enemyBase = new MidiFile(Content.Music.Music.Geoscape1);
		private static readonly MidiFile geoscape1 = new MidiFile(Content.Music.Music.Geoscape1);
		private static readonly MidiFile geoscape2 = new MidiFile(Content.Music.Music.Geoscape1);
		private static readonly MidiFile intercept = new MidiFile(Content.Music.Music.Geoscape1);
		private static readonly MidiFile introduction1 = new MidiFile(Content.Music.Music.Geoscape1);
		private static readonly MidiFile introduction2 = new MidiFile(Content.Music.Music.Geoscape1);
		private static readonly MidiFile introduction3 = new MidiFile(Content.Music.Music.Geoscape1);
		private static readonly MidiFile lose = new MidiFile(Content.Music.Music.Geoscape1);
		private static readonly MidiFile mars = new MidiFile(Content.Music.Music.Geoscape1);
		private static readonly MidiFile mission = new MidiFile(Content.Music.Music.Geoscape1);
		private static readonly MidiFile month = new MidiFile(Content.Music.Music.Geoscape1);
		private static readonly MidiFile story = new MidiFile(Content.Music.Music.Geoscape1);
		private static readonly MidiFile win = new MidiFile(Content.Music.Music.Geoscape1);

		public static void Play(MusicType music)
		{
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
