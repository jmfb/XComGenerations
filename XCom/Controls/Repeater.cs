using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls;

public class Repeater(
	int topRow,
	int leftColumn,
	int width,
	int height,
	string text,
	ColorScheme scheme,
	Font font,
	Action action,
	int repeatInterval
) : Button(topRow, leftColumn, width, height, text, scheme, font, action)
{
	private DateTime lastAction;

	public override void OnLeftButtonDown(int row, int column)
	{
		if (Pushed)
			return;
		Pushed = true;
		Action();
		lastAction = DateTime.Now;
		//TODO: hide cursor
		GameState.Current.Dispatcher.CaptureFocus(this);
		GameState.Current.OnIdle += OnIdle;
	}

	public override void OnLeftButtonUp(int row, int column)
	{
		if (!Pushed)
			return;
		Pushed = false;
		//TODO: show cursor
		GameState.Current.Dispatcher.ReleaseFocus();
		GameState.Current.OnIdle -= OnIdle;
	}

	private void OnIdle()
	{
		if (!Visible)
			return;
		var timeSinceLastAction = DateTime.Now - lastAction;
		if (timeSinceLastAction.TotalMilliseconds < repeatInterval)
			return;
		Action();
		lastAction = DateTime.Now;
	}
}
