using System.Linq;
using System.Web.Script.Serialization;
using XCom.Data;

namespace XCom.World
{
	public class Waypoint
	{
		public int Number { get; set; }
		public Location Location { get; set; }

		[ScriptIgnore]
		public string Name => $"WAYPOINT-{Number}";
		[ScriptIgnore]
		public Craft TargetedBy => GameState.Current.Data.ActiveInterceptors.Single(craft =>
				craft.Destination?.WorldObjectType == WorldObjectType.Waypoint &&
				craft.Destination?.Number == Number);
	}
}
