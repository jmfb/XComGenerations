using XCom.Battlescape.Tiles;
using XCom.Data;

namespace XCom.Battlescape
{
	public interface Unit
	{
		string Name { get; }
		int MaxTimeUnits { get; }
		int TimeUnits { get; }
		int MaxHealth { get; }
		int Health { get; }
		int MaxEnergy { get; }
		int Energy { get; }
		int MaxMorale { get; }
		int Morale { get; }
		Rank? Rank { get; }
		MapLocation Location { get; }
	}
}
