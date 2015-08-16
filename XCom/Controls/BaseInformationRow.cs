using System.Globalization;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls
{
	public class BaseInformationRow : InteractiveContainer
	{
		public BaseInformationRow(
			int topRow,
			string title,
			int colorIndex,
			int pixelsPerGroup,
			int groupSize,
			int value,
			int total,
			bool showRatio)
		{
			AddControl(new Label(topRow, 8, title, Font.Normal, ColorScheme.DarkYellow));
			var labelText = showRatio ?
				$"{value}\t:{total}" :
				total.ToString(CultureInfo.InvariantCulture);
			AddControl(new Label(topRow, 126, labelText, Font.Normal, ColorScheme.White));
			var palette = Palette.GetPalette(1);
			var fillColor = palette.GetColor(colorIndex);
			var borderColor = palette.GetColor(colorIndex + 4);
			var barWidth = total * pixelsPerGroup / groupSize;
			var barPosition = value * pixelsPerGroup / groupSize;
			AddControl(new Bar(topRow + 2, 166, barWidth, 5, barPosition, borderColor, fillColor));
		}
	}
}
