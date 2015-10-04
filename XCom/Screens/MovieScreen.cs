using XCom.Controls;
using XCom.Music;

namespace XCom.Screens
{
	public class MovieScreen : Screen
	{
		private readonly MoviePlayer moviePlayer;
		private readonly MusicType music;
		private readonly Screen nextScreen;

		public MovieScreen(byte[] movieData, MusicType music, Screen nextScreen)
		{
			this.music = music;
			this.nextScreen = nextScreen;
			moviePlayer = new MoviePlayer(movieData, OnMovieFinished);
			AddControl(moviePlayer);
		}

		public override void OnSetFocus()
		{
			MidiFiles.Play(music);
			GameState.Current.OnIdle += moviePlayer.OnIdle;
		}

		public override void OnKillFocus()
		{
			GameState.Current.OnIdle -= moviePlayer.OnIdle;
		}

		private void OnMovieFinished()
		{
			GameState.Current.SetScreen(nextScreen);
		}
	}
}
