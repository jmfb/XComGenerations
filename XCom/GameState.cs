using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web.Script.Serialization;
using XCom.Data;
using XCom.Graphics;
using XCom.Music;
using XCom.Screens;
using Base = XCom.Data.Base;

namespace XCom
{
	public class GameState : Drawable
	{
		public InteractiveDispatcher Dispatcher { get; } = new InteractiveDispatcher();
		public Screen ActiveScreen { get; private set; }
		public GameData Data { get; set; }
		public MidiOutputDevice MusicPlayer { get; } = new MidiOutputDevice();
		public Random Random { get; } = new Random(DateTime.Now.Ticks.GetHashCode());

		public Queue<Action> Notifications { get; } = new Queue<Action>();

		private GameState()
		{
			OnIdle += MusicPlayer.OnIdle;
		}

		public static readonly GameState Current = new GameState();
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
		}

		private Func<Point> pointerPosition;

		public void SetPointerPositionFunction(Func<Point> pointerPositionFunction)
		{
			pointerPosition = pointerPositionFunction;
		}

		public Point PointerPosition => pointerPosition();

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
			return new JavaScriptSerializer().Deserialize<GameData>(fileContents);
		}

		public static void SaveGameData(int gameId, GameData data)
		{
			var fileContents = new JavaScriptSerializer().Serialize(data);
			File.WriteAllText(GetGameDataFileName(gameId), fileContents);
		}
	}
}
