using System;
using System.Linq;
using System.Runtime.InteropServices;
using XCom.Content.Maps.TilePropertyPages;
using XCom.Content.Maps.Tilesets;

namespace XCom.Battlescape
{
	public class Tileset
	{
		private readonly TilesetHeader header;
		private readonly Tile[] tiles;

		public Tileset(byte[] data)
		{
			header = data.ReadStruct<TilesetHeader>(0);
			tiles = Enumerable.Range(0, header.TileCount)
				.Select(index => Marshal.SizeOf(header) + index * Marshal.SizeOf(typeof(Tile)))
				.Select(data.ReadStruct<Tile>)
				.ToArray();
		}

		public static readonly Tileset Forest0 = new Tileset(Tilesets.Forest0);
		public static readonly Tileset Forest1 = new Tileset(Tilesets.Forest1);
		public static readonly Tileset Forest2 = new Tileset(Tilesets.Forest2);
		public static readonly Tileset Forest3 = new Tileset(Tilesets.Forest3);
		public static readonly Tileset Forest4 = new Tileset(Tilesets.Forest4);
		public static readonly Tileset Forest5 = new Tileset(Tilesets.Forest5);
		public static readonly Tileset Forest6 = new Tileset(Tilesets.Forest6);
		public static readonly Tileset Forest7 = new Tileset(Tilesets.Forest7);
		public static readonly Tileset Forest8 = new Tileset(Tilesets.Forest8);
		public static readonly Tileset Forest9 = new Tileset(Tilesets.Forest9);
		public static readonly Tileset Forest10 = new Tileset(Tilesets.Forest10);
		public static readonly Tileset Forest11 = new Tileset(Tilesets.Forest11);

		private static TilePropertyPage[] LoadTilePropertyPages(byte[] data)
		{
			var recordSize = Marshal.SizeOf(typeof(TilePropertyPage));
			var count = data.Length / recordSize;
			if (data.Length % recordSize != 0)
				throw new InvalidOperationException("Invalid property page resource size.");
			return Enumerable.Range(0, count)
				.Select(index => index * recordSize)
				.Select(data.ReadStruct<TilePropertyPage>)
				.ToArray();
		}

		public static readonly TilePropertyPage[] CommonTiles = LoadTilePropertyPages(TilePropertyPages.Common);
		public static readonly TilePropertyPage[] ForestTiles = LoadTilePropertyPages(TilePropertyPages.Forest);
	}
}
