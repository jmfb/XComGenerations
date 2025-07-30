namespace XCom.Music;

public static class MidiFiles
{
	private static readonly MidiFile battlescape = new(Content.Music.Music.Battlescape);
	private static readonly MidiFile enemyBase = new(Content.Music.Music.EnemyBase);
	private static readonly MidiFile geoscape1 = new(Content.Music.Music.Geoscape1);
	private static readonly MidiFile geoscape2 = new(Content.Music.Music.Geoscape2);
	private static readonly MidiFile intercept = new(Content.Music.Music.Intercept);
	private static readonly MidiFile introduction1 = new(Content.Music.Music.Introduction1);
	private static readonly MidiFile introduction2 = new(Content.Music.Music.Introduction2);
	private static readonly MidiFile introduction3 = new(Content.Music.Music.Introduction3);
	private static readonly MidiFile lose = new(Content.Music.Music.Lose);
	private static readonly MidiFile mars = new(Content.Music.Music.Mars);
	private static readonly MidiFile mission = new(Content.Music.Music.Mission);
	private static readonly MidiFile month = new(Content.Music.Music.Month);
	private static readonly MidiFile story = new(Content.Music.Music.Story);
	private static readonly MidiFile win = new(Content.Music.Music.Win);

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
				return [battlescape];
			case MusicType.EnemyBase:
				return [enemyBase];
			case MusicType.Geoscape:
				return [GameState.Current.Random.Next(2) == 0 ? geoscape1 : geoscape2];
			case MusicType.Intercept:
				return [intercept];
			case MusicType.Introduction:
				return [introduction1, introduction2, introduction3];
			case MusicType.Lose:
				return [lose];
			case MusicType.Mars:
				return [mars];
			case MusicType.Mission:
				return [mission];
			case MusicType.Month:
				return [month];
			case MusicType.Story:
				return [story];
			case MusicType.Win:
				return [win];
			default:
				throw new InvalidOperationException("Invalid music type.");
		}
	}
}
