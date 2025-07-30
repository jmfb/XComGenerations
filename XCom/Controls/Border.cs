using XCom.Graphics;

namespace XCom.Controls;

public class Border(
	int topRow,
	int leftColumn,
	int width,
	int height,
	ColorScheme scheme,
	byte[] background,
	int paletteIndex
) : Drawable
{
	public void Render(GraphicsBuffer buffer)
	{
		var pattern = new[]
		{
			scheme.Base,
			scheme.Light,
			scheme.Lighter,
			scheme.Light,
			scheme.Base,
		};
		foreach (var index in Enumerable.Range(0, pattern.Length))
			buffer.DrawFrame(
				topRow + index,
				leftColumn + index,
				width - 2 * index,
				height - 2 * index,
				pattern[index]
			);
		buffer.DrawBackground(
			background,
			topRow + pattern.Length,
			leftColumn + pattern.Length,
			width - 2 * pattern.Length,
			height - 2 * pattern.Length,
			paletteIndex
		);
	}
}
