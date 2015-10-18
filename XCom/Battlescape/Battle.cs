using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using XCom.Data;

namespace XCom.Battlescape
{
	public class Battle
	{
		public int Turn { get; set; }
		public List<BattleSoldier> Soldiers { get; set; }

		[ScriptIgnore]
		public List<BattleItem> Stores { get; set; }

		public BattleSoldier NextSoldier(BattleSoldier soldier)
		{
			var index = Soldiers.IndexOf(soldier);
			var nextIndex = (index + 1) % Soldiers.Count;
			return Soldiers[nextIndex];
		}

		public BattleSoldier PreviousSoldier(BattleSoldier soldier)
		{
			var index = Soldiers.IndexOf(soldier);
			var previousIndex = (index + Soldiers.Count - 1) % Soldiers.Count;
			return Soldiers[previousIndex];
		}

		public static Battle CreateFromCraft(Craft craft)
		{
			return new Battle
			{
				Turn = 1,
				Soldiers = craft.SoldierIds.Select(BattleSoldier.Create).ToList(),
				Stores = craft.Stores.Items.SelectMany(BattleItem.Create).ToList()
			};
		}

		//TODO: CreateFromBase (Xcom base defense - ignore soldiers assigned to crafts that are out, ignore equipment on crafts that are out)
	}
}
