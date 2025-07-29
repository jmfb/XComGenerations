using System.Diagnostics;
using XCom.Battlescape;
using XCom.Battlescape.Tiles;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Music;

namespace XCom.Screens;

public class SpriteTester : Screen
{
	public SpriteTester()
	{
		AddControl(new Border(20, 32, 256, 160, ColorScheme.Aqua, Backgrounds.Title, 0));
		AddControl(new Label(45, Label.Center, "Sprite Tester", Font.Large, ColorScheme.Yellow));
		AddControl(new Button(146, 64, 192, 20, "Back to Main Menu", ColorScheme.Aqua, Font.Normal, OnBackToMainMenu));
	}

	public override void OnSetFocus()
	{
		MidiFiles.Play(MusicType.Story);
		stopwatch.Restart();
	}

	private static void OnBackToMainMenu()
	{
		GameState.Current.SetScreen(new MainMenu());
	}

	private readonly Stopwatch stopwatch = new Stopwatch();
	private int frame;
	private int deathFrame;

	//private int firingFrame;

	//TODO: Floater
	//TODO: Snakeman

	//HWPs (large 4x4 images)
	//TODO: Tanks (tanks, laser, hover)
	//TODO: Cyberdisc
	//TODO: Reaper
	//TODO: Sectopod

	//TODO: Ground items

	public override void Render(GraphicsBuffer buffer)
	{
		//base.Render(buffer);
		//var item = new BattleItem { Item = WeaponType.BlasterLauncher };
		const BattleItem item = null;
		var sprites = SimpleSprite.Snakeman;
		var death = Animation.SnakemanDeath;
		//var firing = Animation.CelatidFiring;

		sprites[Direction.North].Render(buffer, 0, 144, item);
		sprites[Direction.NorthEast].Render(buffer, 0, 176, item);
		sprites[Direction.East].Render(buffer, 0, 208, item);
		sprites[Direction.SouthEast].Render(buffer, 0, 240, item);
		sprites[Direction.South].Render(buffer, 80, 240, item);
		sprites[Direction.SouthWest].Render(buffer, 80, 208, item);
		sprites[Direction.West].Render(buffer, 80, 176, item);
		sprites[Direction.NorthWest].Render(buffer, 80, 144, item);

		if (stopwatch.ElapsedMilliseconds > 100)
		{
			frame = (frame + 1) % sprites[Direction.North].FrameCount;
			deathFrame = (deathFrame + 1) % death.FrameCount;
			//firingFrame = (firingFrame + 1) % firing.FrameCount;
			stopwatch.Restart();
		}

		sprites[Direction.North].Animate(buffer, 40, 144, item, frame);
		sprites[Direction.NorthEast].Animate(buffer, 40, 176, item, frame);
		sprites[Direction.East].Animate(buffer, 40, 208, item, frame);
		sprites[Direction.SouthEast].Animate(buffer, 40, 240, item, frame);
		sprites[Direction.South].Animate(buffer, 120, 240, item, frame);
		sprites[Direction.SouthWest].Animate(buffer, 120, 208, item, frame);
		sprites[Direction.West].Animate(buffer, 120, 176, item, frame);
		sprites[Direction.NorthWest].Animate(buffer, 120, 144, item, frame);

		death.Animate(buffer, 0, 0, deathFrame);
		//firing.Animate(buffer, 0, 32, firingFrame);

		Font.Normal.DrawString(buffer, 100, 0, $"Frame {frame}", ColorScheme.White);
		Font.Normal.DrawString(buffer, 110, 0, $"Death {deathFrame}", ColorScheme.White);
	}
}
