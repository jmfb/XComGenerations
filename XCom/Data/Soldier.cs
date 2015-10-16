using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using XCom.Content.Paperdolls;

namespace XCom.Data
{
	public class Soldier
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public SkinColor SkinColor { get; set; }
		public Gender Gender { get; set; }
		public Rank Rank { get; set; }
		public ArmorType? Armor { get; set; }
		public int MissionCount { get; set; }
		public int KillCount { get; set; }
		public int DaysUntilRecovered { get; set; }
		public bool InPsiTraining { get; set; }
		public bool HasPsiSkill { get; set; }
		public SoldierStatistics OriginalStatistics { get; set; }
		public SoldierStatistics Statistics { get; set; }

		[ScriptIgnore]
		public Craft Craft => GameState.SelectedBase.Crafts.FirstOrDefault(craft => craft.SoldierIds.Contains(Id));
		[ScriptIgnore]
		public string CraftName => IsWounded ? "WOUNDED" : Craft?.Name ?? "NONE";
		[ScriptIgnore]
		public string ArmorName => Armor?.Metadata().Name ?? "NONE";
		[ScriptIgnore]
		public bool IsWounded => DaysUntilRecovered > 0;
		[ScriptIgnore]
		public byte[] Paperdoll
		{
			get
			{
				switch (Armor)
				{
				case ArmorType.FlyingSuit:
					return Paperdolls.FlyingSuit;
				case ArmorType.PowerSuit:
					return Paperdolls.PowerSuit;
				case ArmorType.PersonalArmor:
					return GetPersonalArmorPaperdoll(SkinColor, Gender);
				default:
					return GetCoverallsPaperdoll(SkinColor, Gender);
				}
			}
		}

		private static byte[] GetPersonalArmorPaperdoll(SkinColor skinColor, Gender gender)
		{
			switch (skinColor)
			{
			case SkinColor.White:
				return gender == Gender.Male ?
					Paperdolls.PersonalArmorWhiteMale :
					Paperdolls.PersonalArmorWhiteFemale;
			case SkinColor.Tan:
				return gender == Gender.Male ?
					Paperdolls.PersonalArmorTanMale :
					Paperdolls.PersonalArmorTanFemale;
			case SkinColor.Brown:
				return gender == Gender.Male ?
					Paperdolls.PersonalArmorBrownMale :
					Paperdolls.PersonalArmorBrownFemale;
			case SkinColor.Black:
				return gender == Gender.Male ?
					Paperdolls.PersonalArmorBlackMale :
					Paperdolls.PersonalArmorBlackFemale;
			}
			throw new InvalidOperationException("Invalid skin color.");
		}

		private static byte[] GetCoverallsPaperdoll(SkinColor skinColor, Gender gender)
		{
			switch (skinColor)
			{
			case SkinColor.White:
				return gender == Gender.Male ?
					Paperdolls.CoverallsWhiteMale :
					Paperdolls.CoverallsWhiteFemale;
			case SkinColor.Tan:
				return gender == Gender.Male ?
					Paperdolls.CoverallsTanMale :
					Paperdolls.CoverallsTanFemale;
			case SkinColor.Brown:
				return gender == Gender.Male ?
					Paperdolls.CoverallsBrownMale :
					Paperdolls.CoverallsBrownFemale;
			case SkinColor.Black:
				return gender == Gender.Male ?
					Paperdolls.CoverallsBlackMale :
					Paperdolls.CoverallsBlackFemale;
			}
			throw new InvalidOperationException("Invalid skin color.");
		}

		public static Soldier Create(int id)
		{
			var random = GameState.Current.Random;
			var statistics = SoldierStatistics.Create();
			var genders = EnumEx.GetValues<Gender>().ToList();
			var gender = genders[random.Next(genders.Count)];
			var firstNames = gender == Gender.Male ? maleFirstNames : femaleFirstNames;
			var firstName = firstNames[random.Next(firstNames.Count)];
			var lastName = lastNames[random.Next(lastNames.Count)];
			var skinColors = EnumEx.GetValues<SkinColor>().ToList();
			var skinColor = skinColors[random.Next(skinColors.Count)];
			return new Soldier
			{
				Id = id,
				Name = $"{firstName} {lastName}",
				SkinColor = skinColor,
				Gender = gender,
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

		private static readonly List<string> maleFirstNames = new List<string>
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

		private static readonly List<string> femaleFirstNames = new List<string>
		{
			"Anne",
			"Rebecca",
			"Wrishali",
			"Becky",
			"Christy",
			"Nikki",
			"Michelle",
			"Christine",
			"Courtney",
			"Jenna",
			"Jennifer",
			"Andrea",
			"Denise",
			"Charlesa",
			"Tracy",
			"Beth",
			"Nicole",
			"Diane",
			"Sharon",
			"Shannon",
			"Meagan",
			"Catherine",
			"Katy",
			"Elizabeth"
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
