namespace XCom.Data
{
	public class Stores
	{
		public Store<ArmorType> Armor { get; set; }

		public int Space => 0; //TODO: calculate space used by items in storage

		public static Stores Create()
		{
			return new Stores
			{
				Armor = Store<ArmorType>.Create()
			};
		}
	}
}
