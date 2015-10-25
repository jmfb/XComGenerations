using System;

namespace XCom.Battlescape
{
	public class TileGroups
	{
		private readonly TileGroup[] groups;

		private TileGroups(params TileGroup[] groups)
		{
			this.groups = groups;
		}

		public BattleLocation Create(Tile tile, int level)
		{
			var isGroundLevel = level == 0;
			var automaticallyInsertDirt = tile.Ground == 0 && isGroundLevel;
			const int dirtIndex = 1;
			var groundIndex = automaticallyInsertDirt ? dirtIndex : tile.Ground;
			return new BattleLocation(
				CreatePart(groundIndex),
				CreatePart(tile.WestWall),
				CreatePart(tile.NorthWall),
				CreatePart(tile.Entity));
		}

		private BattleLocationPart CreatePart(int index)
		{
			foreach (var group in groups)
			{
				if (index < group.TileCount)
					return new BattleLocationPart(group.PropertyPages[index], group.ImageGroup);
				index -= group.TileCount;
			}
			throw new InvalidOperationException("Index out of bounds of tile groups.");
		}

		public static readonly TileGroups Forest = new TileGroups(TileGroup.Common, TileGroup.Forest);
	}
}
