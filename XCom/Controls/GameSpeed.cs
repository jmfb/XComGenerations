using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls
{
	public class GameSpeed : InteractiveContainer
	{
		private readonly Toggle[] speeds;
		private readonly int[] multipliers;
		private int selection;

		public GameSpeed()
		{
			speeds = new[]
			{
				new Toggle(112, 257, 31, 13, "5  Secs", ColorScheme.Blue, Font.Time, () => OnSpeedChange(0)),
				new Toggle(112, 289, 31, 13, "1   Min", ColorScheme.Blue, Font.Time, () => OnSpeedChange(1)),
				new Toggle(126, 257, 31, 13, "5 Mins", ColorScheme.Blue, Font.Time, () => OnSpeedChange(2)),
				new Toggle(126, 289, 31, 13, "30 Mins", ColorScheme.Blue, Font.Time, () => OnSpeedChange(3)),
				new Toggle(140, 257, 31, 13, "1  Hour", ColorScheme.Blue, Font.Time, () => OnSpeedChange(4)),
				new Toggle(140, 289, 31, 13, "1  Day", ColorScheme.Blue, Font.Time, () => OnSpeedChange(5))
			};
			multipliers = new[]
			{
				5,
				60,
				5 * 60,
				30 * 60,
				60 * 60,
				24 * 60 * 60
			};

			foreach (var speed in speeds)
				AddControl(speed);

			selection = 0;
			speeds[0].Value = true;
		}

		private void OnSpeedChange(int index)
		{
			speeds[selection].Value = false;
			selection = index;
		}

		public int Multiplier => multipliers[selection];

		public void Reset()
		{
			speeds[selection].Value = false;
			selection = 0;
			speeds[0].Value = true;
		}
	}
}
