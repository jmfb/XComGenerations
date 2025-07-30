using XCom.Content.Images.Equipment;
using XCom.Data;
using XCom.Graphics;

namespace XCom.Controls;

public class CraftCargoPreview(Craft craft) : Drawable
{
	private static readonly Image crew = new(Equipment.Crew);
	private static readonly Image tank = new(Equipment.Tank);
	private static readonly Image items = new(Equipment.Items);

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

		nextLeftColumn = 96;
		foreach (var index in Enumerable.Range(0, (craft.TotalItemCount + 3) / 4))
		{
			var leftColumn = nextLeftColumn;
			nextLeftColumn += items.Width - 2;
			items.Render(buffer, 120, leftColumn);
		}
		foreach (var index in Enumerable.Range(0, craft.TotalHwpCount))
		{
			var leftColumn = nextLeftColumn;
			nextLeftColumn += tank.Width - 2;
			tank.Render(buffer, 120, leftColumn);
		}
	}
}
