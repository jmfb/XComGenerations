using XCom.Data;

namespace XCom.World
{
	public class UfoFactory
	{
		//TODO: put ufo strategy state here

		public Ufo TryCreate()
		{
			//TODO: put some real logic in here.
			if (GameState.Current.Random.Next(0, 100) < 80)
				return null;
			var ufo = Ufo.Create(UfoType.SmallScout, UfoStatus.Flying, AlienType.Sectoid, AlienMissionType.AlienResearch, RegionType.Europe);
			ufo.Location = new Location { Longitude = 0, Latitude = 0 };
			ufo.Destination = new Location { Longitude = 0, Latitude = -300 };
			return ufo;
		}
	}
}
