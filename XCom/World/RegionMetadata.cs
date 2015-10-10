namespace XCom.World
{
	public class RegionMetadata
	{
		public string Name { get; private set; }
		public int BaseCost { get; private set; }

		public static RegionMetadata Create(string name, int baseCost)
		{
			return new RegionMetadata
			{
				Name = name,
				BaseCost = baseCost
			};
		}
	}
}
