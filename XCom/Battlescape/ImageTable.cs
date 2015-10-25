using System;
using System.Linq;
using XCom.Content.Maps.ImageTables;

namespace XCom.Battlescape
{
	public class ImageTable
	{
		public ushort[] Offsets { get; set; }

		public ImageTable(byte[] data)
		{
			var count = data.Length / sizeof(ushort);
			Offsets = Enumerable.Range(0, count)
				.Select(index => index * sizeof(ushort))
				.Select(offset => BitConverter.ToUInt16(data, offset))
				.ToArray();
		}

		public static readonly ImageTable Common = new ImageTable(ImageTables.Common);
		public static readonly ImageTable Forest = new ImageTable(ImageTables.Forest);
	}
}
