using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class MainMenu : Screen
	{
		public MainMenu()
		{
			AddControl(new Border(20, 32, 256, 160, ColorScheme.Aqua, Backgrounds.Title, 0));
			AddControl(new Label(45, Label.Center, "X-Com", Font.Large, ColorScheme.Yellow));
			AddControl(new Label(61, Label.Center, "UFO Defense", Font.Normal, ColorScheme.Yellow));
			AddControl(new Button(90, 64, 192, 20, "New Game", ColorScheme.Aqua, Font.Normal, OnNewGame));
			AddControl(new Button(118, 64, 192, 20, "Load Saved Game", ColorScheme.Aqua, Font.Normal, OnLoadSavedGame));
			AddControl(new Button(146, 64, 192, 20, "Quit", ColorScheme.Aqua, Font.Normal, OnQuit));
		}

		private static void OnNewGame()
		{
			GameState.Current.SetScreen(new Difficulty());
		}

		private void OnLoadSavedGame()
		{
			GameState.Current.SetScreen(new LoadGame(this));
		}

		private static void OnQuit()
		{
			GameState.Current.Quit();
		}
	}
}
