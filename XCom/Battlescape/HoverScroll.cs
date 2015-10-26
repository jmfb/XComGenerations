using System;
using System.Diagnostics;
using System.Drawing;

namespace XCom.Battlescape
{
	public class HoverScroll
	{
		public event Action<int> OnScrollUp;
		public event Action<int> OnScrollDown;
		public event Action<int> OnScrollLeft;
		public event Action<int> OnScrollRight;
		private readonly Stopwatch stopwatch = new Stopwatch();

		public HoverScroll()
		{
			stopwatch.Restart();
		}

		private static int ScrollIncrement => 10 + GameState.Current.Data.ScrollSpeed * 10;

		public void OnIdle()
		{
			if (stopwatch.ElapsedMilliseconds < 25)
				return;
			var pointer = GameState.Current.PointerPosition;
			if (pointer.Y < 0 || pointer.Y >= 200 || pointer.X < 0 || pointer.X >= 320)
				return;
			if (ShouldScrollUp(pointer))
				OnScrollUp?.Invoke(ScrollIncrement);
			if (ShouldScrollDown(pointer))
				OnScrollDown?.Invoke(ScrollIncrement);
			if (ShouldScrollLeft(pointer))
				OnScrollLeft?.Invoke(ScrollIncrement);
			if (ShouldScrollRight(pointer))
				OnScrollRight?.Invoke(ScrollIncrement);
			if (ShouldScrollInAtLeastOneDirection(pointer))
				stopwatch.Restart();
		}

		private static bool ShouldScrollInAtLeastOneDirection(Point pointer) =>
			ShouldScrollUp(pointer) ||
			ShouldScrollDown(pointer) ||
			ShouldScrollLeft(pointer) ||
			ShouldScrollRight(pointer);
		private static bool ShouldScrollUp(Point pointer) => pointer.Y < (ShouldScrollHorizontally(pointer) ? 50 : 10);
		private static bool ShouldScrollDown(Point pointer) => pointer.Y >= (ShouldScrollHorizontally(pointer) ? 150 : 190);
		private static bool ShouldScrollLeft(Point pointer) => pointer.X < (ShouldScrollVertically(pointer) ? 50 : 10);
		private static bool ShouldScrollRight(Point pointer) => pointer.X >= (ShouldScrollVertically(pointer) ? 270 : 310);
		private static bool ShouldScrollHorizontally(Point pointer) => pointer.X < 10 || pointer.X >= 310;
		private static bool ShouldScrollVertically(Point pointer) => pointer.Y < 10 || pointer.Y >= 190;
	}
}
