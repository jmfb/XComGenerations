using System;
using System.Linq;

namespace XCom.Battlescape.Tiles
{
	public class ImageTable
	{
		public ushort[] Offsets { get; }

		public ImageTable(byte[] data)
		{
			var count = data.Length / sizeof(ushort);
			Offsets = Enumerable.Range(0, count)
				.Select(index => index * sizeof(ushort))
				.Select(offset => BitConverter.ToUInt16(data, offset))
				.ToArray();
		}
	}
}
