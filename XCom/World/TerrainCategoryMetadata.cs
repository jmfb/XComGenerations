using System.Linq;
using XCom.Battlescape.Tiles;

namespace XCom.World
{
	public class TerrainCategoryMetadata
	{
		public Tileset[] FlatTilesets { get; set; }
		public Tileset[] OtherTilesets { get; set; }

		public Tileset[] AllTilesets => FlatTilesets.Concat(OtherTilesets).ToArray();
		public Tileset[] SmallTilesets => AllTilesets.Where(tileset => tileset.RowCount == 10).ToArray();
	}
}
