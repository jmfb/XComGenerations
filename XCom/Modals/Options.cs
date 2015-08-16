using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class Options : Screen
	{
		public Options()
		{
			AddControl(new Border(20, 20, 216, 160, ColorScheme.Green, Backgrounds.Title, 0));
			AddControl(new Label(32, Label.CenterOf(20, 216), "GAME OPTIONS", Font.Large, ColorScheme.Green));
			AddControl(new Button(60, 38, 180, 20, "LOAD GAME", ColorScheme.Green, Font.Normal, OnLoadGame));
			AddControl(new Button(85, 38, 180, 20, "SAVE GAME", ColorScheme.Green, Font.Normal, OnSaveGame));
			AddControl(new Button(110, 38, 180, 20, "ABANDON GAME", ColorScheme.Green, Font.Normal, OnAbandonGame));
			AddControl(new Button(140, 38, 180, 20, "CANCEL", ColorScheme.Green, Font.Normal, EndModal));
		}

		private void OnLoadGame()
		{
			var parent = ModalParent;
			EndModal();
			GameState.Current.SetScreen(new LoadGame(parent));
		}

		private void OnSaveGame()
		{
			var parent = ModalParent;
			EndModal();
			GameState.Current.SetScreen(new SaveGame(parent));
		}

		private void OnAbandonGame()
		{
			SwitchToModal(new AbandonGame());
		}
	}
}
