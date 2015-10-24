using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XCom.Data;

namespace XCom.Battlescape
{
	public class Battle
	{
		public int Turn { get; set; }
		public int CraftId { get; set; }
		public List<BattleSoldier> Soldiers { get; set; }
		public SelectedUnitId SelectedUnitId { get; set; }

		[JsonIgnore]
		public List<BattleItem> Stores { get; set; }
		[JsonIgnore]
		public Craft Craft => GameState.Current.Data.GetCraft(CraftId);
		[JsonIgnore]
		public Unit SelectedUnit => SelectedSoldier; //TODO: handle hwp/alien
		[JsonIgnore]
		public BattleSoldier SelectedSoldier => SelectedUnitId.UnitType == UnitType.Soldier ? Soldiers.Single(soldier => soldier.Id == SelectedUnitId.Id) : null;

		public void SelectNextUnit(bool doneThisTurn)
		{
			var soldier = SelectedSoldier;
			if (soldier == null)
				return; //TODO: handle hwp/alien
			if (doneThisTurn)
				soldier.DoneThisTurn = true;
			var index = Soldiers.IndexOf(soldier);
			var newSelectedSoldier = Enumerable.Range(0, Soldiers.Count - 1)
				.Select(value => (index + value + 1) % Soldiers.Count)
				.Select(nextIndex => Soldiers[nextIndex])
				.FirstOrDefault(nextSoldier => !nextSoldier.DoneThisTurn);
			if (newSelectedSoldier == null)
				return;
			SelectedUnitId = new SelectedUnitId
			{
				UnitType = UnitType.Soldier,
				Id = newSelectedSoldier.Id
			};
		}

		public void StartNextTurn()
		{
			++Turn;
			SelectedUnitId = new SelectedUnitId
			{
				UnitType = UnitType.Soldier,
				Id = Soldiers.First().Id
			};
			foreach (var soldier in Soldiers)
			{
				soldier.TimeUnits = soldier.MaxTimeUnits;
				soldier.Energy = Math.Min(soldier.MaxEnergy, soldier.Energy + soldier.Soldier.OriginalStatistics.TimeUnits / 3);
				soldier.DoneThisTurn = false;
			}
		}

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
				CraftId = craft.Id,
				Soldiers = craft.SoldierIds.Select(BattleSoldier.Create).ToList(),
				Stores = craft.Stores.Items.SelectMany(BattleItem.Create).ToList(),
				SelectedUnitId = new SelectedUnitId
				{
					UnitType = UnitType.Soldier,
					Id = craft.SoldierIds.First()
				}
			};
		}

		//TODO: CreateFromBase (Xcom base defense - ignore soldiers assigned to crafts that are out, ignore equipment on crafts that are out)
	}
}
