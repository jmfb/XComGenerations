using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class Soldiers : Screen
	{
		public Soldiers()
		{
			AddControl(new Border(0, 0, 320, 200, ColorScheme.LightMagenta, Backgrounds.Soldier, 8));
			AddControl(new Label(8, Label.Center, "Soldier List", Font.Large, ColorScheme.Blue));
			AddControl(new Label(32, 16, "NAME", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(32, 130, "RANK", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(32, 232, "CRAFT", Font.Normal, ColorScheme.LightMagenta));
			var selectionColor = Palette.GetPalette(8).GetColor(230);
			AddControl(new ListView<Soldier>(40, 8, 16, GameState.SelectedBase.Soldiers, ColorScheme.LightMagenta, selectionColor, OnClickSoldier)
				.AddColumn(8, Alignment.Left, soldier => "", GetSoldierColorScheme)
				.AddColumn(114, Alignment.Left, soldier => soldier.Name, GetSoldierColorScheme)
				.AddColumn(102, Alignment.Left, soldier => $"{soldier.Rank}", GetSoldierColorScheme)
				.AddColumn(64, Alignment.Left, solider => solider.CraftName, GetSoldierColorScheme));
			AddControl(new Button(176, 16, 288, 16, "OK", ColorScheme.LightMagenta, Font.Normal, OnOk));
		}

		private static ColorScheme GetSoldierColorScheme(Soldier soldier)
		{
			return soldier.Craft == null ?
				ColorScheme.Purple :
				ColorScheme.Blue;
		}

		private static void OnClickSoldier(Soldier soldier)
		{
			GameState.Current.SetScreen(new SoldierView(soldier));
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(new Base());
		}
	}
}
