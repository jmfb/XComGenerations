using System.Linq;

namespace XCom.Graphics
{
	public class MovieSubframeByteRun
	{
		private readonly byte[] data;
		private readonly int offset;

		public MovieSubframeByteRun(byte[] data, int offset)
		{
			this.data = data;
			this.offset = offset;
		}

		public void Apply(byte[,] image)
		{
			var index = offset;
			foreach (var row in Enumerable.Range(0, 200))
				ApplyRow(row, ref index, image);
		}

		private void ApplyRow(int row, ref int index, byte[,] image)
		{
			var packets = data[index++];
			var column = 0;
			for (var packet = 0; packet < packets; ++packet)
			{
				var count = (sbyte)data[index++];
				if (count < 0)
				{
					while (count++ < 0)
						image[row, column++] = data[index++];
				}
				else
				{
					var repeatedColor = data[index++];
					while (count-- > 0)
						image[row, column++] = repeatedColor;
				}
			}
		}
	}
}
