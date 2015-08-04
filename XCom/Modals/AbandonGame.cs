using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class AbandonGame : Screen
	{
		public AbandonGame()
		{
			AddControl(new Border(20, 20, 216, 160, ColorScheme.Green, Backgrounds.Title, 0));
			AddControl(new Label(70, Label.CenterOf(20, 216), "ABANDON GAME?", Font.Large, ColorScheme.Green));
			AddControl(new Button(140, 38, 50, 20, "YES", ColorScheme.Green, Font.Normal, OnYes));
			AddControl(new Button(140, 168, 50, 20, "NO", ColorScheme.Green, Font.Normal, EndModal));
		}

		private void OnYes()
		{
			EndModal();
			Geoscape.ResetGameSpeed();
			GameState.Current.SetScreen(new MainMenu());
		}
	}
}
