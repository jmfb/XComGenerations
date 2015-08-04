using System.Linq;
using XCom.Content.Images.Equipment;
using XCom.Data;
using XCom.Graphics;

namespace XCom.Controls
{
	public class CraftCargoPreview : Drawable
	{
		private readonly Craft craft;

		private static readonly Image crew = new Image(Equipment.Crew);
		private static readonly Image tank = new Image(Equipment.Tank);
		private static readonly Image items = new Image(Equipment.Items);

		public CraftCargoPreview(Craft craft)
		{
			this.craft = craft;
		}

		public void Render(GraphicsBuffer buffer)
		{
			var space = craft.CraftType.Metadata().Space;
			if (space == 0)
				return;

			var nextLeftColumn = 96;
			foreach (var index in Enumerable.Range(0, craft.SoldierIds.Count))
			{
				var leftColumn = nextLeftColumn;
				nextLeftColumn += crew.Width - 1;
				crew.Render(buffer, 96, leftColumn);
			}
			//TODO: tanks preview
			//TODO: items preview
		}
	}
}
