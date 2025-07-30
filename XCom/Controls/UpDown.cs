using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls;

public class UpDown(
	int topRow,
	int leftColumn,
	ColorScheme scheme,
	Action upAction,
	Action downAction
) : InteractiveControl
{
	private readonly Stopwatch stopwatch = new();

	private enum State
	{
		None,
		Up,
		Down,
	}

	private State state = State.None;

	public override bool HitTest(int row, int column)
	{
		return row >= topRow
			&& row < (topRow + 8)
			&& column >= leftColumn
			&& column < (leftColumn + 23);
	}

	public override void OnLeftButtonDown(int row, int column)
	{
		var middleColumn = leftColumn + 11;
		if (column < middleColumn)
			ChangeState(State.Up);
		else if (column > middleColumn)
			ChangeState(State.Down);
		else
			ChangeState(State.None);
	}

	public override void OnLeftButtonUp(int row, int column)
	{
		ChangeState(State.None);
	}

	private void OnIdle()
	{
		if (state == State.None)
			return;
		var position = GameState.Current.PointerPosition;
		if (!HitTest(position.Y, position.X))
			ChangeState(State.None);
		else if (stopwatch.ElapsedMilliseconds >= 100)
			FireEvent();
	}

	private void ChangeState(State newState)
	{
		if (newState == state)
			return;
		if (newState == State.None)
		{
			state = State.None;
			GameState.Current.OnIdle -= OnIdle;
			return;
		}

		if (state == State.None)
			GameState.Current.OnIdle += OnIdle;
		state = newState;
		FireEvent();
	}

	private void FireEvent()
	{
		stopwatch.Restart();
		switch (state)
		{
			case State.Up:
				upAction();
				break;
			case State.Down:
				downAction();
				break;
		}
	}

	public override void Render(GraphicsBuffer buffer)
	{
		Font.UpDownButtons.DrawString(
			buffer,
			topRow,
			leftColumn,
			"U",
			state == State.Up ? scheme.Inverse : scheme
		);
		Font.UpDownButtons.DrawString(
			buffer,
			topRow,
			leftColumn + 12,
			"D",
			state == State.Down ? scheme.Inverse : scheme
		);
	}

	public void Abort()
	{
		ChangeState(State.None);
	}
}
