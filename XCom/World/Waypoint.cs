using System.Linq;
using Newtonsoft.Json;
using XCom.Data;

namespace XCom.World
{
	public class Waypoint
	{
		public int Number { get; set; }
		public Location Location { get; set; }

		[JsonIgnore]
		public string Name => $"WAYPOINT-{Number}";
		[JsonIgnore]
		public Craft TargetedBy => GameState.Current.Data.ActiveInterceptors.Single(craft =>
				craft.Destination?.WorldObjectType == WorldObjectType.Waypoint &&
				craft.Destination?.Number == Number);
	}
}
