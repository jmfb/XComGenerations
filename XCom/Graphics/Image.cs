using System.Drawing;

namespace XCom.Graphics;

public class Image(byte[] data)
{
	public int Width => BitConverter.ToInt32(data, 0);

	private int Height => BitConverter.ToInt32(data, sizeof(int));

	public void Render(GraphicsBuffer buffer, int topRow, int leftColumn)
	{
		var nextIndex = sizeof(int) * 2;
		foreach (var row in Enumerable.Range(0, Height))
		{
			foreach (var column in Enumerable.Range(0, Width))
			{
				var index = nextIndex;
				nextIndex += 4;
				if (data[index + 3] != 0)
				{
					buffer.SetPixel(
						topRow + Height - row - 1,
						leftColumn + column,
						Color.FromArgb(data[index], data[index + 1], data[index + 2])
					);
				}
			}
		}
	}
}
