using System.Linq;
using XCom.Battlescape;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Music;
using XCom.Screens;

namespace XCom.World
{
	public class GroundAssault : Screen
	{
		private readonly Battle battle;

		public GroundAssault(Battle battle)
		{
			this.battle = battle;
			AddControl(new Border(0, 0, 320, 200, ColorScheme.Green, Backgrounds.Assault, 0));
			AddControl(new Label(24, 16, "UFO GROUND ASSAULT", Font.Large, ColorScheme.Aqua));
			AddControl(new Label(40, 16, battle.Craft.Destination.Name, Font.Large, ColorScheme.Aqua));
			AddControl(new Label(56, 16, $"CRAFT> {battle.Craft.Name}", Font.Large, ColorScheme.Aqua));
			var nextTop = 72;
			var instructions = new[]
			{
				"Explore landing site and, if possible, gain entry to the UFO.",
				"Mission will be successful when all enemy units have been",
				"eliminated or neutralized.  Recovery of UFO, artifacts and",
				"alien corpses can then be initiated.  To abort the mission",
				"return XCom operatives to transport vehicle and click on",
				"the 'Abort Mission' icon."
			};
			foreach (var instruction in instructions)
			{
				var top = nextTop;
				nextTop += 8;
				AddControl(new Label(top, 16, instruction, Font.Normal, ColorScheme.Aqua));
			}
			AddControl(new Button(164, 100, 120, 20, "OK", ColorScheme.Aqua, Font.Normal, OnOk));
		}

		public override void OnSetFocus()
		{
			MidiFiles.Play(MusicType.Mission);
		}

		private void OnOk()
		{
			GameState.Current.SetScreen(new Inventory(battle, battle.Soldiers.First(), battle.Stores, true));
		}
	}
}
