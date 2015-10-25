using System.Linq;
using XCom.Content.Maps.ImageGroups;

namespace XCom.Battlescape
{
	public class ImageGroup
	{
		public byte[][] Images { get; }

		private ImageGroup(ImageTable table, byte[] data)
		{
			Images = table.Offsets
				.Select(offset => data
					.Skip(offset)
					.TakeWhile(index => index != 0xff)
					.ToArray())
				.ToArray();
		}

		public static readonly ImageGroup Common = new ImageGroup(ImageTable.Common, ImageGroups.Common);
		public static readonly ImageGroup Forest = new ImageGroup(ImageTable.Forest, ImageGroups.Forest);
	}
}
