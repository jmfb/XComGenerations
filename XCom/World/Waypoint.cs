using System.Linq;
using XCom.Data;

namespace XCom.World
{
	public class Waypoint
	{
		public int Number { get; set; }
		public Location Location { get; set; }

		public string Name => $"WAYPOINT-{Number}";
		public Craft TargetedBy => GameState.Current.Data.ActiveInterceptors.Single(craft =>
				craft.Destination?.WorldObjectType == WorldObjectType.Waypoint &&
				craft.Destination?.Number == Number);
	}
}
