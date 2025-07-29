using XCom.Battlescape;
using XCom.Battlescape.Tiles;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Music;

namespace XCom.Screens;

public class SpriteTester : Screen
{
	private readonly Stopwatch stopwatch = new();
	private int frame;
	private int deathFrame;

	private readonly Dictionary<Direction, SimpleSprite> sprites = SimpleSprite.Snakeman;
	private readonly Animation death = Animation.SnakemanDeath;
	// = new BattleItem { Item = WeaponType.BlasterLauncher };
	private readonly BattleItem item = null;

	public SpriteTester()
	{
		AddControl(new Button(180, 256, 64, 20, "Main Menu", ColorScheme.Aqua, Font.Normal, OnBackToMainMenu));
		AddControl(new UpDown(160, 0, ColorScheme.Aqua, OnNextFrame, OnPrevFrame));
		AddControl(new UpDown(160, 32, ColorScheme.Aqua, OnNextDeathFrame, OnPrevDeathFrame));
		AddControl(new Button(180, 0, 64, 20, "Start/Stop", ColorScheme.Aqua, Font.Normal, OnToggleStopwatch));
	}

	public override void OnSetFocus()
	{
		MidiFiles.Play(MusicType.Story);
		GameState.Current.OnIdle += OnIdle;
		stopwatch.Restart();
		frame = 0;
		deathFrame = 0;
	}

	public override void OnKillFocus()
	{
		GameState.Current.OnIdle -= OnIdle;
		stopwatch.Stop();
	}

	private static void OnBackToMainMenu()
	{
		GameState.Current.SetScreen(new MainMenu());
	}

	private void OnIdle()
	{
		if (stopwatch.IsRunning && stopwatch.ElapsedMilliseconds > 100)
		{
			OnNextFrame();
			OnNextDeathFrame();
			stopwatch.Restart();
		}
	}

	private void OnToggleStopwatch()
	{
		if (stopwatch.IsRunning)
			stopwatch.Stop();
		else
			stopwatch.Restart();
	}

	private static int GetNextFrame(int currentFrame, int frameCount, int delta) =>
		(currentFrame + frameCount + delta) % frameCount;

	private void OnNextFrame() =>
		frame = GetNextFrame(frame, sprites[Direction.North].FrameCount, 1);

	private void OnPrevFrame() =>
		frame = GetNextFrame(frame, sprites[Direction.North].FrameCount, -1);

	private void OnNextDeathFrame() =>
		deathFrame = GetNextFrame(deathFrame, death.FrameCount, 1);

	private void OnPrevDeathFrame() =>
		deathFrame = GetNextFrame(deathFrame, death.FrameCount, -1);

	// TODO: Firing frames?
	//private int firingFrame;
	//var firing = Animation.CelatidFiring;
	//firingFrame = (firingFrame + 1) % firing.FrameCount;
	//firing.Animate(buffer, 0, 32, firingFrame);


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
		base.Render(buffer);

		const int row1 = 0;
		const int row2 = 40;
		const int row3 = 80;
		const int row4 = 120;
		const int column1 = 144;
		const int column2 = 176;
		const int column3 = 208;
		const int column4 = 240;

		sprites[Direction.North].Render(buffer, row1, column1, item);
		sprites[Direction.NorthEast].Render(buffer, row1, column2, item);
		sprites[Direction.East].Render(buffer, row1, column3, item);
		sprites[Direction.SouthEast].Render(buffer, row1, column4, item);

		sprites[Direction.South].Render(buffer, row3, column4, item);
		sprites[Direction.SouthWest].Render(buffer, row3, column3, item);
		sprites[Direction.West].Render(buffer, row3, column2, item);
		sprites[Direction.NorthWest].Render(buffer, row3, column1, item);

		sprites[Direction.North].Animate(buffer, row2, column1, item, frame);
		sprites[Direction.NorthEast].Animate(buffer, row2, column2, item, frame);
		sprites[Direction.East].Animate(buffer, row2, column3, item, frame);
		sprites[Direction.SouthEast].Animate(buffer, row2, column4, item, frame);

		sprites[Direction.South].Animate(buffer, row4, column4, item, frame);
		sprites[Direction.SouthWest].Animate(buffer, row4, column3, item, frame);
		sprites[Direction.West].Animate(buffer, row4, column2, item, frame);
		sprites[Direction.NorthWest].Animate(buffer, row4, column1, item, frame);

		death.Animate(buffer, 0, 0, deathFrame);

		Font.Normal.DrawString(buffer, 100, 0, $"Frame {frame}", ColorScheme.White);
		Font.Normal.DrawString(buffer, 110, 0, $"Death {deathFrame}", ColorScheme.White);
	}
}
