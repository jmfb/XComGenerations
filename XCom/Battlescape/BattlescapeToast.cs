using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Battlescape;

public class BattlescapeToast : Drawable
{
	private const int topRow = 176;
	private const int leftColumn = 48;
	private const int width = GraphicsBuffer.GameWidth - leftColumn * 2;
	private const int height = GraphicsBuffer.GameHeight - topRow;
	private string message;
	private readonly Stopwatch stopwatch = new Stopwatch();

	public void Show(string message)
	{
		this.message = message;
		stopwatch.Restart();
	}

	public void Render(GraphicsBuffer buffer)
	{
		if (string.IsNullOrWhiteSpace(message))
			return;

		var frame = (int)(stopwatch.ElapsedMilliseconds / 150);
		if (frame >= 16)
		{
			message = null;
			stopwatch.Reset();
			return;
		}

		var color = Palette.GetPalette(14).GetColor(32 + frame);
		buffer.FillRect(topRow, leftColumn, width, height, color);
		var label = new Label(topRow + 8, Label.Center, message, Font.Normal, ColorScheme.Orange);
		label.Render(buffer);
	}
}
