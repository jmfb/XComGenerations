using System;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls
{
	public class TimeDisplay : Button
	{
		public TimeDisplay()
			: base(72, 257, 63, 39, "", ColorScheme.Blue, Font.Normal, () => {})
		{
		}

		public override bool HitTest(int row, int column)
		{
			return false;
		}

		public override void Render(GraphicsBuffer buffer)
		{
			base.Render(buffer);
			var time = GameState.Current.Data.Time;
			RenderTime(buffer, time);
			RenderDate(buffer, time);
		}

		private static void RenderDate(GraphicsBuffer buffer, DateTime time)
		{
			var weekday = time.ToString("dddd");
			var weekdayLeftColumn = Label.CenterOf(257, 63).CalculateTextColumn(weekday, Font.Normal);
			Font.Normal.DrawString(buffer, 87, weekdayLeftColumn, weekday, ColorScheme.LightBlue);
			Font.Normal.DrawString(buffer, 94, 267, time.Day.FormatOrdinal(), ColorScheme.LightBlue);
			Font.Normal.DrawString(buffer, 94, 295, time.ToString("MMM"), ColorScheme.LightBlue);
			var year = time.ToString("yyyy");
			var yearLeftColumn = Label.CenterOf(257, 63).CalculateTextColumn(year, Font.Normal);
			Font.Normal.DrawString(buffer, 101, yearLeftColumn, year, ColorScheme.LightBlue);
		}

		private static void RenderTime(GraphicsBuffer buffer, DateTime time)
		{
			var hour = time.ToString("%H");
			Font.Large.DrawString(buffer, 74, hour.Length == 1 ? 269 : 259, hour, ColorScheme.LightBlue);
			Font.Large.DrawString(buffer, 74, 279, ":", ColorScheme.LightBlue);
			Font.Large.DrawString(buffer, 74, 283, time.ToString("mm"), ColorScheme.LightBlue);
			Font.Large.DrawString(buffer, 74, 303, ":", ColorScheme.LightBlue);
			Font.Normal.DrawString(buffer, 80, 307, time.ToString("ss"), ColorScheme.LightBlue);
		}
	}
}
