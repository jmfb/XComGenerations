using System;
using System.Linq;

namespace XCom.World
{
	public class Destination
	{
		public WorldObjectType WorldObjectType { get; set; }
		public int Number { get; set; }

		public Location Location
		{
			get
			{
				switch (WorldObjectType)
				{
				case WorldObjectType.XcomBase:
					return GameState.Current.Data.Bases.Single(@base => @base.Number == Number).Location;
				case WorldObjectType.Waypoint:
					return GameState.Current.Data.Waypoints.Single(waypoint => waypoint.Number == Number).Location;
				}
				throw new NotImplementedException();
			}
		}
	}
}
