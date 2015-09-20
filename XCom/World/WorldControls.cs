using System;
using System.Diagnostics;
using XCom.Controls;
using XCom.Graphics;

namespace XCom.World
{
	public class WorldControls : InteractiveControl
	{
		private readonly WorldView worldView;
		private Action currentAction;
		private readonly Stopwatch stopwatch = new Stopwatch();

		public WorldControls(WorldView worldView)
		{
			this.worldView = worldView;
		}

		public override bool HitTest(int row, int column)
		{
			return row >= 154 && column >= 257;
		}

		public override void OnLeftButtonDown(int row, int column)
		{
			if (column >= 295)
			{
				if (row < 178)
					worldView.IncreaseZoom();
				else
					worldView.DecreaseZoom();
			}
			else
			{
				if (row < 171)
					currentAction = () => worldView.ChangePitch(-10);
				else if (row >= 190)
					currentAction = () => worldView.ChangePitch(10);
				else if (column < 268)
					currentAction = () => worldView.ChangeLongitudeOffset(10);
				else if (column >= 286)
					currentAction = () => worldView.ChangeLongitudeOffset(-10);
				if (currentAction != null)
				{
					GameState.Current.Dispatcher.CaptureFocus(this);
					GameState.Current.OnIdle += OnIdle;
					stopwatch.Restart();
					currentAction();
				}
			}
		}

		public override void OnLeftButtonUp(int row, int column)
		{
			if (currentAction == null)
				return;
			GameState.Current.Dispatcher.ReleaseFocus();
			GameState.Current.OnIdle -= OnIdle;
			currentAction = null;
		}

		private void OnIdle()
		{
			if (currentAction == null || stopwatch.ElapsedMilliseconds < 5)
				return;
			stopwatch.Restart();
			currentAction();
		}

		public override void Render(GraphicsBuffer buffer)
		{
		}
	}
}
