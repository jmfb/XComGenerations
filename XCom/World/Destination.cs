using System;
using System.Linq;

namespace XCom.World
{
	public class Destination
	{
		public WorldObjectType WorldObjectType { get; set; }
		public int Number { get; set; }

		private dynamic Target
		{
			get
			{
				switch (WorldObjectType)
				{
				case WorldObjectType.XcomBase:
					return GameState.Current.Data.Bases.Single(@base => @base.Number == Number);
				case WorldObjectType.Waypoint:
					return GameState.Current.Data.Waypoints.Single(waypoint => waypoint.Number == Number);
				case WorldObjectType.Ufo:
				case WorldObjectType.LandingSite:
				case WorldObjectType.CrashSite:
					return GameState.Current.Data.Ufos.Single(ufo => ufo.Number == Number);
				}
				throw new NotImplementedException();
			}
		}

		public Location Location => Target.Location;
		public string Name => Target.Name;
	}
}
