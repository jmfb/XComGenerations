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
			var theme = CurrentTheme;
			AddControl(new Border(0, 0, 320, 200, theme.BorderScheme, theme.Background, theme.BackgroundPalette));
			AddControl(new Label(8, Label.Center, "Select game to load", Font.Large, theme.HeaderScheme));
			AddControl(new Label(24, 36, "Name", Font.Normal, theme.HeaderScheme));
			AddControl(new Label(24, 195, "Time", Font.Normal, theme.HeaderScheme));
			AddControl(new Label(24, 225, "Date", Font.Normal, theme.HeaderScheme));
			
			var nextTopRow = 34;
			foreach (var gameId in Enumerable.Range(1, 10))
			{
				var topRow = nextTopRow;
				nextTopRow += 14;

				if (GameState.GameDataExists(gameId))
				{
					var data = GameState.LoadGameData(gameId);
					AddControl(new Button(topRow - 2, 10, 24, 12, $"{gameId}", theme.ButtonScheme, Font.Normal, () => OnLoadGame(data)));
					AddControl(new ExtendedLabel(topRow, 36, 159, data.Name, Font.Normal, theme.TextScheme));
					AddControl(new Label(topRow, 195, data.Time.ToString("H:mm"), Font.Normal, theme.TextScheme));
					AddControl(new Label(topRow, 225, data.Time.Day.FormatOrdinal(), Font.Normal, theme.TextScheme));
					AddControl(new Label(topRow, 255, data.Time.ToString("MMM"), Font.Normal, theme.TextScheme));
					AddControl(new Label(topRow, 285, data.Time.ToString("yyyy"), Font.Normal, theme.TextScheme));
				}
				else
				{
					AddControl(new Button(topRow - 2, 10, 24, 12, $"{gameId}", theme.ButtonScheme, Font.Normal, () => {}));
				}
			}
			AddControl(new Button(172, 120, 80, 16, "CANCEL", theme.ButtonScheme, Font.Normal, OnCancel));
		}

		private static void OnLoadGame(GameData data)
		{
			GameState.Current.Data = data;
			if (data.Battle == null)
			{
				Geoscape.ResetGameSpeed();
				GameState.Current.SetScreen(Geoscape);
			}
			else
			{
				GameState.Current.SetScreen(new Battlescape.Battlescape(data.Battle));
			}
		}

		private void OnCancel()
		{
			GameState.Current.SetScreen(returnToScreen);
		}

		private class Theme
		{
			public byte[] Background { get; set; }
			public int BackgroundPalette { get; set; }
			public ColorScheme BorderScheme { get; set; }
			public ColorScheme ButtonScheme { get; set; }
			public ColorScheme HeaderScheme { get; set; }
			public ColorScheme TextScheme { get ; set; }
		}

		private static readonly Theme battlescapeTheme = new Theme
		{
			Background = Backgrounds.Turn,
			BackgroundPalette = 1,
			BorderScheme = ColorScheme.White,
			ButtonScheme = ColorScheme.Blue,
			HeaderScheme = ColorScheme.White,
			TextScheme = ColorScheme.White
		};

		private static readonly Theme geoscapeTheme = new Theme
		{
			Background = Backgrounds.Title,
			BackgroundPalette = 0,
			BorderScheme = ColorScheme.Aqua,
			ButtonScheme = ColorScheme.Aqua,
			HeaderScheme = ColorScheme.Green,
			TextScheme = ColorScheme.Yellow
		};

		private Theme CurrentTheme => returnToScreen is Battlescape.Battlescape ? battlescapeTheme : geoscapeTheme;
	}
}
