using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Battlescape
{
	public class GameOptions : Screen
	{
		private readonly Toggle[] scrollSpeeds = new Toggle[5];
		private readonly Toggle[] scrollTypes = new Toggle[2];
		private readonly Toggle[] fireSpeeds = new Toggle[6];
		private readonly Toggle[] xcomMovementSpeeds = new Toggle[6];
		private readonly Toggle[] alienMovementSpeeds = new Toggle[6];

		public GameOptions()
		{
			AddControl(new Border(0, 0, 320, 200, ColorScheme.White, Backgrounds.Turn, 1));
			AddControl(new Label(16, Label.Center, "GAME OPTIONS", Font.Large, ColorScheme.White));
			AddControl(new Label(32, 16, "SCROLL SPEED", Font.Normal, ColorScheme.White));
			foreach (var scrollSpeed in Enumerable.Range(0, 5))
			{
				var toggle = new Toggle(42, 16 + 24 * scrollSpeed, 22, 14 + 4 * scrollSpeed, $"{scrollSpeed + 1}", ColorScheme.White, Font.Normal, () => OnScrollSpeed(scrollSpeed));
				scrollSpeeds[scrollSpeed] = toggle;
				AddControl(toggle);
			}
			AddControl(new Label(32, 150, "SCROLL TYPE", Font.Normal, ColorScheme.White));
			foreach (var scrollType in Enumerable.Range(0, 2))
			{
				var toggle = new Toggle(42 + 16 * scrollType, 150, 30, 14, $"{scrollType + 1}", ColorScheme.White, Font.Normal, () => OnScrollType(scrollType));
				scrollTypes[scrollType] = toggle;
				AddControl(toggle);
			}
			AddControl(new Label(45, 182, "TRIGGER SCROLL", Font.Normal, ColorScheme.White));
			AddControl(new Label(61, 182, "AUTO-SCROLL", Font.Normal, ColorScheme.White));
			AddControl(new Label(74, 16, "FIRE SPEED", Font.Normal, ColorScheme.White));
			var widths = new[] { 22, 28, 36, 45, 56, 69 };
			var nextLeft = 16;
			foreach (var fireSpeed in Enumerable.Range(0, 6))
			{
				var left = nextLeft;
				nextLeft += widths[fireSpeed] + 2;
				var toggle = new Toggle(84, left, widths[fireSpeed], 12, $"{fireSpeed + 1}", ColorScheme.White, Font.Normal, () => OnFireSpeed(fireSpeed));
				fireSpeeds[fireSpeed] = toggle;
				AddControl(toggle);
			}
			AddControl(new Label(106, 16, "XCOM MOVEMENT SPEED", Font.Normal, ColorScheme.White));
			nextLeft = 16;
			foreach (var movementSpeed in Enumerable.Range(0, 6))
			{
				var left = nextLeft;
				nextLeft += widths[movementSpeed] + 2;
				var toggle = new Toggle(116, left, widths[movementSpeed], 12, $"{movementSpeed + 1}", ColorScheme.White, Font.Normal, () => OnXcomMovementSpeed(movementSpeed));
				xcomMovementSpeeds[movementSpeed] = toggle;
				AddControl(toggle);
			}
			AddControl(new Label(138, 16, "ALIEN MOVEMENT SPEED", Font.Normal, ColorScheme.White));
			nextLeft = 16;
			foreach (var movementSpeed in Enumerable.Range(0, 6))
			{
				var left = nextLeft;
				nextLeft += widths[movementSpeed] + 2;
				var toggle = new Toggle(148, left, widths[movementSpeed], 12, $"{movementSpeed + 1}", ColorScheme.White, Font.Normal, () => OnAlienMovementSpeed(movementSpeed));
				alienMovementSpeeds[movementSpeed] = toggle;
				AddControl(toggle);
			}
			AddControl(new Button(174, 16, 120, 16, "OK", ColorScheme.White, Font.Normal, OnOk));
			AddControl(new Button(174, 184, 120, 16, "SAVE", ColorScheme.White, Font.Normal, OnSave));
			//TODO: Add Load option!  No more abort, pout, load

			scrollSpeeds[GameState.Current.Data.ScrollSpeed].Value = true;
			scrollTypes[GameState.Current.Data.ScrollType].Value = true;
			fireSpeeds[GameState.Current.Data.FireSpeed].Value = true;
			xcomMovementSpeeds[GameState.Current.Data.XcomMovementSpeed].Value = true;
			alienMovementSpeeds[GameState.Current.Data.AlienMovementSpeed].Value = true;
		}

		private void OnScrollSpeed(int value)
		{
			scrollSpeeds[GameState.Current.Data.ScrollSpeed].Value = false;
			GameState.Current.Data.ScrollSpeed = value;
		}

		private void OnScrollType(int value)
		{
			scrollTypes[GameState.Current.Data.ScrollType].Value = false;
			GameState.Current.Data.ScrollType = value;
		}

		private void OnFireSpeed(int value)
		{
			fireSpeeds[GameState.Current.Data.FireSpeed].Value = false;
			GameState.Current.Data.FireSpeed = value;
		}

		private void OnXcomMovementSpeed(int value)
		{
			xcomMovementSpeeds[GameState.Current.Data.XcomMovementSpeed].Value = false;
			GameState.Current.Data.XcomMovementSpeed = value;
		}

		private void OnAlienMovementSpeed(int value)
		{
			alienMovementSpeeds[GameState.Current.Data.AlienMovementSpeed].Value = false;
			GameState.Current.Data.AlienMovementSpeed = value;
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(new Battlescape(GameState.Current.Data.Battle));
		}

		private static void OnSave()
		{
			GameState.Current.SetScreen(new SaveGame(new Battlescape(GameState.Current.Data.Battle)));
		}
	}
}
