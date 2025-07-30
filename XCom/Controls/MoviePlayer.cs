using XCom.Graphics;

namespace XCom.Controls;

public class MoviePlayer(byte[] data, Action action) : InteractiveControl
{
	private readonly Movie movie = new(data);

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
