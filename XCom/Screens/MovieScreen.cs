using XCom.Controls;

namespace XCom.Screens
{
	public class MovieScreen : Screen
	{
		private readonly MoviePlayer player;
		private readonly Screen nextScreen;

		public MovieScreen(byte[] movieData, Screen nextScreen)
		{
			this.nextScreen = nextScreen;
			player = new MoviePlayer(movieData, OnMovieFinished);
			AddControl(player);
		}

		public override void OnSetFocus()
		{
			GameState.Current.OnIdle += player.OnIdle;
		}

		public override void OnKillFocus()
		{
			GameState.Current.OnIdle -= player.OnIdle;
		}

		private void OnMovieFinished()
		{
			GameState.Current.SetScreen(nextScreen);
		}
	}
}
