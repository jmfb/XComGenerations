using System.Collections.Generic;
using System.Linq;

namespace XCom.Data
{
	public class Soldier
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Rank Rank { get; set; }
		public ArmorType? Armor { get; set; }
		public int MissionCount { get; set; }
		public int KillCount { get; set; }
		public int DaysUntilRecovered { get; set; }
		public bool InPsiTraining { get; set; }
		public bool HasPsiSkill { get; set; }
		public SoldierStatistics OriginalStatistics { get; set; }
		public SoldierStatistics Statistics { get; set; }

		public Craft GetCraft()
		{
			return GameState.SelectedBase.Crafts.FirstOrDefault(craft => craft.SoldierIds.Contains(Id));
		}

		public string GetCraftName()
		{
			var craft = GetCraft();
			return craft == null ? "NONE" : craft.Name;
		}

		public string GetArmorName()
		{
			return Armor == null ? "NONE" : Armor.Value.Metadata().Name;
		}

		public static Soldier Create(int id)
		{
			var random = GameState.Current.Random;
			var statistics = SoldierStatistics.Create();
			var firstName = firstNames[random.Next(firstNames.Count)];
			var lastName = lastNames[random.Next(lastNames.Count)];
			return new Soldier
			{
				Id = id,
				Name = $"{firstName} {lastName}",
				Rank = Rank.Rookie,
				Armor = null,
				MissionCount = 0,
				KillCount = 0,
				DaysUntilRecovered = 0,
				InPsiTraining = false,
				HasPsiSkill = false,
				OriginalStatistics = statistics.Copy(),
				Statistics = statistics
			};
		}

		private static readonly List<string> firstNames = new List<string>
		{
			"Jacob",
			"Marcin",
			"Dom",
			"Nhat",
			"Mike",
			"James",
			"Jim",
			"Nick",
			"Kevin",
			"Chuck",
			"Steve",
			"Greg",
			"Blake",
			"Jason",
			"Tony",
			"Rob",
			"Chris",
			"Josh",
			"Jesse",
			"Randy",
			"Ben",
			"Ezra",
			"Joaquin",
			"Tim",
			"Dan",
			"Andrew",
			"Paul",
			"Zach"
		};

		private static readonly List<string> lastNames = new List<string>
		{
			"Buysse",
			"Polewski",
			"Piccione",
			"Nguyen",
			"Krautkramer",
			"Foss",
			"Belger",
			"Grant",
			"Strassburg",
			"Petrovits",
			"Barry",
			"Idzi",
			"Fastner",
			"Sedmak",
			"Schreiner",
			"Smith",
			"Adams",
			"Kirk",
			"Capriotti",
			"Berken",
			"Matthews",
			"Wingerter",
			"Welden",
			"Clarke",
			"Phoenix",
			"Ernst",
			"Regner",
			"Cooke",
			"Jackson",
			"Michel",
			"Moore",
			"Dixon",
			"Cheron",
			"McNichols"
		};
	}
}
