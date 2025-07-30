using XCom.Battlescape.Tiles;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Music;

namespace XCom.Screens;

public class TankSpriteTester : Screen
{
	private readonly Stopwatch stopwatch = new();
	private int frame;

	private int spriteIndex;
	private Dictionary<Direction, TankSprite> Sprites => TankSprite.All[spriteIndex];

	public TankSpriteTester()
	{
		AddControl(
			new Button(
				180,
				256,
				64,
				20,
				"Main Menu",
				ColorScheme.Aqua,
				Font.Normal,
				OnBackToMainMenu
			)
		);
		AddControl(new UpDown(160, 0, ColorScheme.Aqua, OnNextFrame, OnPrevFrame));
		AddControl(
			new Button(
				180,
				0,
				64,
				20,
				"Start/Stop",
				ColorScheme.Aqua,
				Font.Normal,
				OnToggleStopwatch
			)
		);
		AddControl(
			new Button(180, 128, 64, 20, "Sprite", ColorScheme.Aqua, Font.Normal, OnToggleSprite)
		);
	}

	public override void OnSetFocus()
	{
		MidiFiles.Play(MusicType.Story);
		GameState.Current.OnIdle += OnIdle;
		stopwatch.Restart();
		frame = 0;
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

	private void OnToggleSprite()
	{
		spriteIndex = (spriteIndex + 1) % TankSprite.All.Length;
		frame = GetNextFrame(frame, Sprites[Direction.North].FrameCount, 0);
	}

	private static int GetNextFrame(int currentFrame, int frameCount, int delta) =>
		(currentFrame + frameCount + delta) % frameCount;

	private void OnNextFrame() =>
		frame = GetNextFrame(frame, Sprites[Direction.North].FrameCount, 1);

	private void OnPrevFrame() =>
		frame = GetNextFrame(frame, Sprites[Direction.North].FrameCount, -1);

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

		Sprites[Direction.North].Animate(buffer, row1, column1, frame);
		Sprites[Direction.NorthEast].Animate(buffer, row1, column3, frame);
		Sprites[Direction.East].Animate(buffer, row2, column2, frame);
		Sprites[Direction.SouthEast].Animate(buffer, row2, column4, frame);

		Sprites[Direction.South].Animate(buffer, row3, column1, frame);
		Sprites[Direction.SouthWest].Animate(buffer, row3, column3, frame);
		Sprites[Direction.West].Animate(buffer, row4, column2, frame);
		Sprites[Direction.NorthWest].Animate(buffer, row4, column4, frame);

		Font.Normal.DrawString(buffer, 100, 0, $"Frame {frame}", ColorScheme.White);
	}
}
