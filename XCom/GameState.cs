using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web.Script.Serialization;
using XCom.Data;
using XCom.Graphics;
using XCom.Screens;
using Base = XCom.Data.Base;

namespace XCom
{
	public class GameState : Drawable
	{
		public InteractiveDispatcher Dispatcher { get; private set; }
		public Screen ActiveScreen { get; private set; }
		public GameData Data { get; set; }

		public Random Random { get; private set; }

		public Queue<Action> Notifications { get; } = new Queue<Action>();

		private GameState()
		{
			Dispatcher = new InteractiveDispatcher();
			var seed = DateTime.Now.Ticks.GetHashCode();
			Random = new Random(seed);
		}

		public static readonly GameState Current = new GameState();
		public static Base SelectedBase => Current.Data.Bases[Current.Data.SelectedBase];

		public event Action OnQuit;
		public event Action OnIdle;

		public void Quit()
		{
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
