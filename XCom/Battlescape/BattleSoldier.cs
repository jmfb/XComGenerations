using Newtonsoft.Json;
using XCom.Data;

namespace XCom.Battlescape
{
	public class BattleSoldier
	{
		public int Id { get; set; }

		public BattleItem[] RightShoulder { get; set; }
		public BattleItem[] LeftShoulder { get; set; }
		public BattleItem RightHand { get; set; }
		public BattleItem LeftHand { get; set; }
		public BattleItem[] RightLeg { get; set; }
		public BattleItem[] LeftLeg { get; set; }
		public BattleItem[,] BackPack { get; set; }
		public BattleItem[,] Belt { get; set; }

		public int TimeUnits { get; set; }
		public int Energy { get; set; }
		public int Health { get; set; }
		public int HeadFatalWounds { get; set; }
		public int RightArmFatalWounds { get; set; }
		public int LeftArmFatalWounds { get; set; }
		public int BodyFatalWounds { get; set; }
		public int RightLegFatalWounds { get; set; }
		public int LeftLegFatalWounds { get; set; }
		public int Bravery { get; set; }
		public int Morale { get; set; }
		public int Reactions { get; set; }
		public int FiringAccuracy { get; set; }
		public int ThrowingAccuracy { get; set; }
		public int Strength { get; set; }

		public int FrontArmor { get; set; }
		public int LeftArmor { get; set; }
		public int RightArmor { get; set; }
		public int RearArmor { get; set; }
		public int UnderArmor { get; set; }

		[JsonIgnore]
		public Soldier Soldier => GameState.Current.Data.GetSoldier(Id);
		[JsonIgnore]
		public int TotalFatalWounds =>
			HeadFatalWounds +
			RightArmFatalWounds +
			LeftArmFatalWounds +
			BodyFatalWounds +
			RightLegFatalWounds +
			LeftLegFatalWounds;

		public static BattleSoldier Create(int soldierId)
		{
			var soldier = GameState.Current.Data.GetSoldier(soldierId);
			var statistics = soldier.Statistics;
			var armorMetadata = soldier.Armor?.Metadata();
			return new BattleSoldier
			{
				Id = soldierId,

				RightShoulder = new BattleItem[2],
				LeftShoulder = new BattleItem[2],
				RightHand = null,
				LeftHand = null,
				RightLeg = new BattleItem[2],
				LeftLeg = new BattleItem[2],
				BackPack = new BattleItem[3, 3],
				Belt = new BattleItem[2, 4],

				TimeUnits = statistics.TimeUnits,
				Energy = statistics.Stamina,
				Health = statistics.Health,
				HeadFatalWounds = 0,
				RightArmFatalWounds = 0,
				LeftArmFatalWounds = 0,
				BodyFatalWounds = 0,
				RightLegFatalWounds = 0,
				LeftLegFatalWounds = 0,
				Bravery = statistics.Bravery,
				Morale = 100,
				Reactions = statistics.Reactions,
				FiringAccuracy = statistics.FiringAccuracy,
				ThrowingAccuracy = statistics.ThrowingAccuracy,
				Strength = statistics.Strength,

				FrontArmor = armorMetadata?.FrontArmor ?? 12,
				LeftArmor = armorMetadata?.LeftArmor ?? 8,
				RightArmor = armorMetadata?.RightArmor ?? 8,
				RearArmor = armorMetadata?.RearArmor ?? 5,
				UnderArmor = armorMetadata?.UnderArmor ?? 2
			};
		}
	}
}
