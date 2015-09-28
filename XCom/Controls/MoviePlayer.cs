using System;
using XCom.Graphics;

namespace XCom.Controls
{
	public class MoviePlayer : InteractiveControl
	{
		private readonly Action action;
		private readonly Movie movie;

		public MoviePlayer(byte[] data, Action action)
		{
			this.action = action;
			movie = new Movie(data);
		}

		public override bool HitTest(int row, int column)
		{
			return true;
		}

		public override void OnLeftButtonDown(int row, int column)
		{
			action();
		}

		public override void Render(GraphicsBuffer buffer)
		{
			movie.Render(buffer);
		}

		public void OnIdle()
		{
			movie.OnIdle();
			if (movie.IsOver)
				action();
		}
	}
}
