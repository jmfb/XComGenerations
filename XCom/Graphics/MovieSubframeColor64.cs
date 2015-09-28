using System;
using System.Drawing;

namespace XCom.Graphics
{
	public class SubframeColor64
	{
		public Color[] Colors { get; } = new Color[256];

		public SubframeColor64(byte[] data, int offset)
		{
			var parts = BitConverter.ToUInt16(data, offset);
			offset += sizeof(ushort);
			var index = 0;
			for (var part = 0; part < parts; ++part)
			{
				index += data[offset++];
				var count = (int)data[offset++];
				if (count == 0)
					count = 256;
				for (var triplet = 0; triplet < count; ++triplet)
				{
					var red = data[offset++];
					var green = data[offset++];
					var blue = data[offset++];
					Colors[index++] = Color.FromArgb(4 * red, 4 * green, 4 * blue);
				}
			}
		}
	}
}
