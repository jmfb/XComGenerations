using System.Drawing;
using System.IO;
using Newtonsoft.Json;
using XCom.Data;
using XCom.Graphics;
using XCom.Music;
using XCom.Screens;
using Base = XCom.Data.Base;

namespace XCom;

public class GameState : Drawable
{
	public InteractiveDispatcher Dispatcher { get; } = new();
	public Screen ActiveScreen { get; private set; }
	public GameData Data { get; set; }
	public MidiOutputDevice MusicPlayer { get; } = new();
	public Random Random { get; } = new(DateTime.Now.Ticks.GetHashCode());

	public Queue<Action> Notifications { get; } = new();

	private GameState()
	{
		OnIdle += MusicPlayer.OnIdle;
	}

	public static readonly GameState Current = new();
	public static Base SelectedBase => Current.Data.Bases[Current.Data.SelectedBase];

	public event Action OnQuit;
	public event Action OnIdle;

	public void Quit()
	{
		OnIdle -= MusicPlayer.OnIdle;
		MusicPlayer.Close();
		OnQuit?.Invoke();
	}

	public void Idle()
	{
		OnIdle?.Invoke();
	}

	public void Render(GraphicsBuffer buffer)
	{
		ActiveScreen?.Render(buffer);
		var pointerPosition = PointerPosition;
		Pointer.Render(pointerPosition.Y, pointerPosition.X, buffer);
	}

	private Func<Point> getPointerPosition;

	public void SetPointerPositionFunction(Func<Point> pointerPositionFunction)
	{
		getPointerPosition = pointerPositionFunction;
	}

	public Point PointerPosition => getPointerPosition();

	public void SetScreen(Screen newScreen)
	{
		if (ActiveScreen != null)
		{
			ActiveScreen.OnKillFocus();
			Dispatcher.ReleaseFocus();
		}
		ActiveScreen = newScreen;
		if (ActiveScreen == null)
			return;
		Dispatcher.CaptureFocus(ActiveScreen);
		ActiveScreen.OnSetFocus();
	}

	public static bool GameDataExists(int gameId)
	{
		return File.Exists(GetGameDataFileName(gameId));
	}

	private static string GetGameDataFileName(int gameId)
	{
		return $"save{gameId}.json";
	}

	public static GameData LoadGameData(int gameId)
	{
		var fileContents = File.ReadAllText(GetGameDataFileName(gameId));
		return JsonConvert.DeserializeObject<GameData>(fileContents);
	}

	public static void SaveGameData(int gameId, GameData data)
	{
		var fileContents = JsonConvert.SerializeObject(data);
		File.WriteAllText(GetGameDataFileName(gameId), fileContents);
	}
}
