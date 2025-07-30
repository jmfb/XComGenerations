using System.Windows.Forms;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls;

public class Edit(
	int topRow,
	int leftColumn,
	int width,
	string text,
	Font font,
	ColorScheme scheme,
	Action<string> action
) : InteractiveControl
{
	protected int TopRow { get; private set; } = topRow;
	protected int LeftColumn { get; private set; } = leftColumn;
	protected int Width { get; private set; } = width;
	public string Text { get; private set; } = text;
	protected Font Font { get; private set; } = font;
	protected ColorScheme Scheme { get; private set; } = scheme;
	protected bool Editing { get; private set; }

	public override void OnKeyPressed(char value)
	{
		if (!Editing)
			return;

		switch (value)
		{
			case (char)Keys.Escape:
			case (char)0x0a:
			case (char)Keys.Tab:
			case '`':
				break;

			case (char)Keys.Back:
				TryDeleteLastCharacter();
				break;

			case (char)Keys.Return:
				EndEdit();
				break;

			default:
				TryAppend(value);
				break;
		}
	}

	public void BeginEdit()
	{
		if (Editing)
			return;
		Editing = true;
		GameState.Current.Dispatcher.CaptureFocus(this);
		//TODO: hide cursor
	}

	private void EndEdit()
	{
		GameState.Current.Dispatcher.ReleaseFocus();
		//TODO: show cursor
		Editing = false;
		action(Text);
	}

	private void TryDeleteLastCharacter()
	{
		if (Text.Any())
			Text = Text.Substring(0, Text.Length - 1);
	}

	private void TryAppend(char value)
	{
		var newText = Text + value;
		if (Font.MeasureString(newText + "*") <= Width)
			Text = newText;
	}

	public override void Render(GraphicsBuffer buffer)
	{
		Font.DrawString(buffer, TopRow, LeftColumn, Text, Scheme);
		if (Editing && IsTimeToDrawBlinkingCursor())
			Font.DrawString(buffer, TopRow, LeftColumn + Font.MeasureString(Text), "*", Scheme);
	}

	private static bool IsTimeToDrawBlinkingCursor()
	{
		var quarterSecond = DateTime.Now.Millisecond / 250;
		return (quarterSecond % 2) == 1;
	}
}
