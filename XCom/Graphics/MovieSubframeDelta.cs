using System;
using System.Linq;

namespace XCom.Graphics
{
	public class MovieSubframeDelta
	{
		private readonly byte[] data;
		private readonly int offset;

		public MovieSubframeDelta(byte[] data, int offset)
		{
			this.data = data;
			this.offset = offset;
		}

		public void Apply(byte[,] image)
		{
			var index = offset;
			var firstRow = BitConverter.ToUInt16(data, index);
			index += sizeof(ushort);
			var rowCount = BitConverter.ToUInt16(data, index);
			index += sizeof(ushort);
			foreach (var row in Enumerable.Range(firstRow, rowCount))
				ApplyRow(row, ref index, image);
		}

		private void ApplyRow(int row, ref int index, byte[,] image)
		{
			var column = 0;
			var packets = data[index++];
			for (var packet = 0; packet < packets; ++packet)
			{
				column += data[index++];
				var count = (sbyte)data[index++];
				if (count < 0)
				{
					var repeatedColor = data[index++];
					while (count++ < 0)
						image[row, column++] = repeatedColor;
				}
				else
				{
					while (count-- > 0)
						image[row, column++] = data[index++];
				}
			}
		}
	}
}
