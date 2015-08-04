using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class Difficulty : Screen
	{
		public Difficulty()
		{
			AddControl(new Border(10, 64, 192, 180, ColorScheme.Aqua, Backgrounds.Title, 0));
			AddControl(new Label(30, Label.Center, "Select Difficulty Level", Font.Normal, ColorScheme.Yellow));
			AddControl(new Button(55, 80, 160, 18, "1> Beginner", ColorScheme.Aqua, Font.Normal, () => OnDifficulty(0)));
			AddControl(new Button(80, 80, 160, 18, "2> Experienced", ColorScheme.Aqua, Font.Normal, () => OnDifficulty(1)));
			AddControl(new Button(105, 80, 160, 18, "3> Veteran", ColorScheme.Aqua, Font.Normal, () => OnDifficulty(2)));
			AddControl(new Button(130, 80, 160, 18, "4> Genius", ColorScheme.Aqua, Font.Normal, () => OnDifficulty(3)));
			AddControl(new Button(155, 80, 160, 18, "5> Superhuman", ColorScheme.Aqua, Font.Normal, () => OnDifficulty(4)));
		}

		private static void OnDifficulty(int difficulty)
		{
			GameState.Current.Data = GameData.Create(difficulty);
			GameState.Current.SetScreen(new BuildNewBase());
		}
	}
}
