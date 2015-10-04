namespace XCom.Data
{
	public class SoldierStatistics
	{
		public int TimeUnits { get; set; }
		public int Stamina { get; set; }
		public int Health { get; set; }
		public int Bravery { get; set; }
		public int Reactions { get; set; }
		public int FiringAccuracy { get; set; }
		public int ThrowingAccuracy { get; set; }
		public int Strength { get; set; }
		public int PsionicStrength { get; set; }
		public int PsionicSkill { get; set; }

		public static SoldierStatistics Create()
		{
			var random = GameState.Current.Random;
			return new SoldierStatistics
			{
				TimeUnits = random.Next(50, 60),
				Stamina = random.Next(40, 70),
				Health = random.Next(25, 40),
				Bravery = random.Next(1, 6) * 10,
				Reactions = random.Next(30, 60),
				FiringAccuracy = random.Next(40, 70),
				ThrowingAccuracy = random.Next(50, 80),
				Strength = random.Next(20, 40),
				PsionicStrength = 0,
				PsionicSkill = 0
			};
		}

		public SoldierStatistics Copy()
		{
			return (SoldierStatistics)MemberwiseClone();
		}
	}
}
