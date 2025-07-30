using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls;

public class DynamicLabel(
	int topRow,
	int leftColumn,
	Func<string> textAction,
	Font font,
	ColorScheme scheme
) : Label(topRow, leftColumn, textAction(), font, scheme)
{
	public override void Render(GraphicsBuffer buffer)
	{
		Text = textAction();
		base.Render(buffer);
	}
}
