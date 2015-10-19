using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Battlescape
{
	public class DisplayTurn : Screen
	{
		private readonly Battle battle;

		public DisplayTurn(Battle battle)
		{
			this.battle = battle;
			AddControl(new Border(0, 0, 320, 200, ColorScheme.White, Backgrounds.Turn, 1));
			AddControl(new Label(68, Label.Center, "UFO", Font.Large, ColorScheme.White));
			AddControl(new Label(92, Label.Center, $"TURN> {battle.Turn}", Font.Large, ColorScheme.White));
			AddControl(new Label(108, Label.Center, "SIDE> Xcom", Font.Large, ColorScheme.White));
			AddControl(new Label(132, Label.Center, "Press button to continue", Font.Large, ColorScheme.White));
		}

		public override bool HitTest(int row, int column)
		{
			return true;
		}

		public override void OnLeftButtonDown(int row, int column)
		{
			SwitchToBattlescape();
		}

		public override void OnKeyPressed(char value)
		{
			SwitchToBattlescape();
		}

		private void SwitchToBattlescape()
		{
			GameState.Current.SetScreen(new Battlescape(battle));
		}
	}
}
