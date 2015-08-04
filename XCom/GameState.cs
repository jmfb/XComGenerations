using System;
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
		private Screen activeScreen;
		public GameData Data { get; set; }

		public Random Random { get; private set; }

		private GameState()
		{
			Dispatcher = new InteractiveDispatcher();
			SetScreen(new MainMenu());

			var seed = DateTime.Now.Ticks.GetHashCode();
			Random = new Random(seed);
		}

		public static readonly GameState Current = new GameState();
		public static Base SelectedBase
		{
			get { return Current.Data.Bases[Current.Data.SelectedBase]; }
		}
		
		public event Action OnQuit;
		public event Action OnIdle;

		public void Quit()
		{
			if (OnQuit != null)
				OnQuit();
		}

		public void Idle()
		{
			if (OnIdle != null)
				OnIdle();
		}

		public void Render(GraphicsBuffer buffer)
		{
			if (activeScreen != null)
				activeScreen.Render(buffer);
		}

		private Func<Point> pointerPosition;

		public void SetPointerPositionFunction(Func<Point> pointerPositionFunction)
		{
			pointerPosition = pointerPositionFunction;
		}

		public Point PointerPosition
		{
			get { return pointerPosition(); }
		}

		public void SetScreen(Screen newScreen)
		{
			if (activeScreen != null)
			{
				activeScreen.OnKillFocus();
				Dispatcher.ReleaseFocus();
			}
			activeScreen = newScreen;
			if (activeScreen == null)
				return;
			Dispatcher.CaptureFocus(activeScreen);
			activeScreen.OnSetFocus();
		}

		public static bool GameDataExists(int gameId)
		{
			return File.Exists(GetGameDataFileName(gameId));
		}

		private static string GetGameDataFileName(int gameId)
		{
			return string.Format("save{0}.json", gameId);
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
