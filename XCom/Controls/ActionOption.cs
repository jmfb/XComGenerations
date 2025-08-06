using XCom.Graphics;
using Font = XCom.Fonts.Font;

namespace XCom.Controls;

public class ActionOption(
	int topRow,
	string label,
	int? accuracy,
	int timeUnits,
	Action action,
	Action cancel
) : InteractiveControl
{
	private const int leftColumn = 25;
	private const int width = 270;
	public const int Height = 40;

	public override void Render(GraphicsBuffer buffer)
	{
		var scheme = ColorScheme.White;
		var pattern = new[]
		{
			scheme.Darker,
			scheme.Base,
			scheme.Light,
			scheme.Lighter,
			scheme.Light,
			scheme.Base,
			scheme.Darker,
		};
		foreach (var index in Enumerable.Range(0, pattern.Length))
			buffer.DrawFrame(
				topRow + index,
				leftColumn + index,
				width - 2 * index,
				Height - 2 * index,
				pattern[index]
			);

		var position = GameState.Current.PointerPosition;
		var isHovered = HitTest(position.Y, position.X);
		var color = isHovered ? scheme.Base : scheme.Darker;
		buffer.FillRect(
			topRow + pattern.Length,
			leftColumn + pattern.Length,
			width - 2 * pattern.Length,
			Height - 2 * pattern.Length,
			color
		);

		var textTop = topRow + 13;
		Font.Large.DrawString(buffer, textTop, 40, label, scheme);
		if (accuracy != null)
			Font.Large.DrawString(buffer, textTop, 150, $"Acc>{accuracy}%", scheme);
		Font.Large.DrawString(buffer, textTop, 220, $"TUs>{timeUnits}", scheme);
	}

	public override bool HitTest(int row, int column)
	{
		return row >= topRow
			&& row < (topRow + Height)
			&& column >= leftColumn
			&& column < (leftColumn + width);
	}

	public override void OnLeftButtonDown(int row, int column)
	{
		action();
	}

	public override void OnRightButtonDown(int row, int column)
	{
		cancel();
	}
}
