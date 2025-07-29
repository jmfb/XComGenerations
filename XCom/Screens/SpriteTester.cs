using XCom.Battlescape;
using XCom.Battlescape.Tiles;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Music;

namespace XCom.Screens;

public class SpriteTester : Screen
{
	private readonly Stopwatch stopwatch = new();
	private int frame;
	private int deathFrame;

	private int spriteIndex;
	private Dictionary<Direction, SimpleSprite> Sprites => SimpleSprite.All[spriteIndex];
	private Animation death = Animation.SnakemanDeath;
	private BattleItem item;

	public SpriteTester()
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
		AddControl(new UpDown(160, 32, ColorScheme.Aqua, OnNextDeathFrame, OnPrevDeathFrame));
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
			new Button(180, 64, 64, 20, "Toggle Item", ColorScheme.Aqua, Font.Normal, OnToggleItem)
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

	private void OnToggleItem()
	{
		if (item == null)
			item = new BattleItem { Item = WeaponType.PlasmaPistol };
		else if (item.IsTwoHanded)
			item = null;
		else
			item = new BattleItem { Item = WeaponType.BlasterLauncher };
	}

	private void OnToggleSprite()
	{
		spriteIndex = (spriteIndex + 1) % SimpleSprite.All.Length;
		if (Sprites == SimpleSprite.Zombie)
			death = Animation.ZombieDeath;
		else if (Sprites == SimpleSprite.Celatid)
			death = Animation.CelatidDeath;
		else if (Sprites == SimpleSprite.Silacoid)
			death = Animation.SilacoidDeath;
		else if (Sprites == SimpleSprite.CivilianFemale)
			death = Animation.CivilianFemaleDeath;
		else if (Sprites == SimpleSprite.CivilianMale)
			death = Animation.CivilianMaleDeath;
		else if (Sprites == SimpleSprite.Floater)
			death = Animation.FloaterDeath;
		else if (Sprites == SimpleSprite.Snakeman)
			death = Animation.SnakemanDeath;
		else if (Sprites == SimpleSprite.Ethereal)
			death = Animation.EtherealDeath;
		else
			death = Animation.ZombieDeath;
		frame = GetNextFrame(frame, Sprites[Direction.North].FrameCount, 0);
		deathFrame = GetNextFrame(deathFrame, death.FrameCount, 0);
	}

	private static int GetNextFrame(int currentFrame, int frameCount, int delta) =>
		(currentFrame + frameCount + delta) % frameCount;

	private void OnNextFrame() =>
		frame = GetNextFrame(frame, Sprites[Direction.North].FrameCount, 1);

	private void OnPrevFrame() =>
		frame = GetNextFrame(frame, Sprites[Direction.North].FrameCount, -1);

	private void OnNextDeathFrame() => deathFrame = GetNextFrame(deathFrame, death.FrameCount, 1);

	private void OnPrevDeathFrame() => deathFrame = GetNextFrame(deathFrame, death.FrameCount, -1);

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

		Sprites[Direction.North].Render(buffer, row1, column1, item);
		Sprites[Direction.NorthEast].Render(buffer, row1, column2, item);
		Sprites[Direction.East].Render(buffer, row1, column3, item);
		Sprites[Direction.SouthEast].Render(buffer, row1, column4, item);

		Sprites[Direction.South].Render(buffer, row3, column4, item);
		Sprites[Direction.SouthWest].Render(buffer, row3, column3, item);
		Sprites[Direction.West].Render(buffer, row3, column2, item);
		Sprites[Direction.NorthWest].Render(buffer, row3, column1, item);

		Sprites[Direction.North].Animate(buffer, row2, column1, item, frame);
		Sprites[Direction.NorthEast].Animate(buffer, row2, column2, item, frame);
		Sprites[Direction.East].Animate(buffer, row2, column3, item, frame);
		Sprites[Direction.SouthEast].Animate(buffer, row2, column4, item, frame);

		Sprites[Direction.South].Animate(buffer, row4, column4, item, frame);
		Sprites[Direction.SouthWest].Animate(buffer, row4, column3, item, frame);
		Sprites[Direction.West].Animate(buffer, row4, column2, item, frame);
		Sprites[Direction.NorthWest].Animate(buffer, row4, column1, item, frame);

		death.Animate(buffer, 0, 0, deathFrame);

		Font.Normal.DrawString(buffer, 100, 0, $"Frame {frame}", ColorScheme.White);
		Font.Normal.DrawString(buffer, 110, 0, $"Death {deathFrame}", ColorScheme.White);
	}
}
