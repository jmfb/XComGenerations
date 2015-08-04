namespace XCom.Data
{
	public class Stores
	{
		public Store<ArmorType> Armor { get; set; }

		public static Stores Create()
		{
			return new Stores
			{
				Armor = Store<ArmorType>.Create()
			};
		}
	}
}
