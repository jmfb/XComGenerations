using XCom.Battlescape;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.World
{
	public class ReadyToLand : Screen
	{
		private readonly Craft craft;

		public ReadyToLand(Craft craft)
		{
			this.craft = craft;
			var centerOf = Label.CenterOf(20, 216);
			AddControl(new Border(20, 20, 216, 160, ColorScheme.Aqua, Backgrounds.Ufo, 9));
			AddControl(new Label(40, centerOf, craft.Name, Font.Large, ColorScheme.Yellow));
			AddControl(new Label(56, centerOf, "ready to", Font.Large, ColorScheme.Aqua));
			AddControl(new Label(72, centerOf, "land near", Font.Large, ColorScheme.Aqua));
			AddControl(new Label(88, centerOf, craft.Destination.Name, Font.Large, ColorScheme.Yellow));
			AddControl(new Label(130, centerOf, "Begin Mission?", Font.Large, ColorScheme.Aqua));
			AddControl(new Button(150, 40, 80, 20, "YES", ColorScheme.Aqua, Font.Normal, OnYes));
			AddControl(new Button(150, 136, 80, 20, "NO", ColorScheme.Aqua, Font.Normal, OnNo));
		}

		private void OnYes()
		{
			var battle = Battle.CreateFromCraft(craft);
			GameState.Current.Data.Battle = battle;
			EndModal();
			//TODO: detect ground assault, crash recovery, etc., and show correct mission prompt
			GameState.Current.SetScreen(new GroundAssault(battle));
		}

		private void OnNo()
		{
			craft.StartToReturnToBase();
			EndModal();
		}
	}
}
