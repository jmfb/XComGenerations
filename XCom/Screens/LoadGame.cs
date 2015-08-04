using System.Globalization;
using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class LoadGame : Screen
	{
		private readonly Screen returnToScreen;

		public LoadGame(Screen returnToScreen)
		{
			this.returnToScreen = returnToScreen;
			AddControl(new Border(0, 0, 320, 200, ColorScheme.Aqua, Backgrounds.Title, 0));
			AddControl(new Label(8, Label.Center, "Select game to load", Font.Large, ColorScheme.Green));
			AddControl(new Label(24, 36, "Name", Font.Normal, ColorScheme.Green));
			AddControl(new Label(24, 195, "Time", Font.Normal, ColorScheme.Green));
			AddControl(new Label(24, 225, "Date", Font.Normal, ColorScheme.Green));
			
			var nextTopRow = 34;
			foreach (var gameId in Enumerable.Range(1, 10))
			{
				var topRow = nextTopRow;
				nextTopRow += 14;

				var buttonText = gameId.ToString(CultureInfo.InvariantCulture);
				if (GameState.GameDataExists(gameId))
				{
					var data = GameState.LoadGameData(gameId);
					AddControl(new Button(topRow - 2, 10, 24, 12, buttonText, ColorScheme.Aqua, Font.Normal, () => OnLoadGame(data)));
					AddControl(new ExtendedLabel(topRow, 36, 159, data.Name, Font.Normal, ColorScheme.Yellow));
					AddControl(new Label(topRow, 195, data.Time.ToString("H:mm"), Font.Normal, ColorScheme.Yellow));
					AddControl(new Label(topRow, 225, data.Time.Day.FormatOrdinal(), Font.Normal, ColorScheme.Yellow));
					AddControl(new Label(topRow, 255, data.Time.ToString("MMM"), Font.Normal, ColorScheme.Yellow));
					AddControl(new Label(topRow, 285, data.Time.ToString("yyyy"), Font.Normal, ColorScheme.Yellow));
				}
				else
				{
					AddControl(new Button(topRow - 2, 10, 24, 12, buttonText, ColorScheme.Aqua, Font.Normal, () => {}));
				}
			}
			AddControl(new Button(172, 120, 80, 16, "CANCEL", ColorScheme.Aqua, Font.Normal, OnCancel));
		}

		private static void OnLoadGame(GameData data)
		{
			GameState.Current.Data = data;
			//TODO: determine battlescape or geoscape
			Geoscape.ResetGameSpeed();
			GameState.Current.SetScreen(Geoscape);
		}

		private void OnCancel()
		{
			GameState.Current.SetScreen(returnToScreen);
		}
	}
}
