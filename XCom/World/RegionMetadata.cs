using System.Collections.Generic;
using System.Linq;

namespace XCom.World
{
	public class RegionMetadata
	{
		public string Name { get; set; }
		public int BaseCost { get; set; }
		public IEnumerable<Region> Regions { get; set; }

		public bool IsInRegion(Location location) =>
			Regions.Any(region => region.Contains(location));
	}
}
