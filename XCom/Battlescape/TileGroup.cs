using System;

namespace XCom.Battlescape
{
	public class TileGroup
	{
		public TilePropertyPage[] PropertyPages { get; }
		public ImageGroup ImageGroup { get; }

		public int TileCount => PropertyPages.Length;

		private TileGroup(TilePropertyPage[] propertyPages, ImageGroup imageGroup)
		{
			PropertyPages = propertyPages;
			ImageGroup = imageGroup;
		}

		public static readonly TileGroup Common = new TileGroup(TilePropertyPage.Common, ImageGroup.Common);
		public static readonly TileGroup Forest = new TileGroup(TilePropertyPage.Forest, ImageGroup.Forest);
	}
}
