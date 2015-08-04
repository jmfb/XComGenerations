using System.Globalization;
using XCom.Graphics;
using XCom.Fonts;

namespace XCom.Controls
{
	public class SoldierInformationRow : InteractiveContainer
	{
		public SoldierInformationRow(
			int topRow,
			string label,
			int originalValue,
			int currentValue,
			int colorIndex)
		{
			AddControl(new Label(topRow, 6, label, Font.Normal, ColorScheme.LightMagenta));
			var valueLabel = currentValue.ToString(CultureInfo.InvariantCulture);
			AddControl(new Label(topRow, 131, valueLabel, Font.Normal, ColorScheme.White));

			var palette = Palette.GetPalette(1);
			var borderColor = palette.GetColor(colorIndex + 7);
			var fillColor = palette.GetColor(colorIndex + 3);
			var unfilledColor = palette.GetColor(colorIndex);
			AddControl(new Bar(topRow, 150, currentValue, 7, originalValue, borderColor, fillColor, unfilledColor));
		}
	}
}
