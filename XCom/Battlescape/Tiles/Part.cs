using Newtonsoft.Json;
using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class Part
	{
		public TileType TileType { get; set; }
		public int Index { get; set; }

		[JsonIgnore]
		public PartData PartData => TileType.Part(Index);

		public void Render(GraphicsBuffer buffer, int topRow, int leftColumn)
		{
			//TODO: cycle through animated frames (but control cycling through door frames)
			var partData = PartData;
			var image = TileType.Image(partData.Images[0]);
			if (image == null)
				return;
			buffer.DrawItem(topRow - partData.VerticalImageOffset, leftColumn, image);
		}
	}
}
