using XCom.Controls;
using XCom.Data;
using XCom.Graphics;
using XCom.Music;
using XCom.Screens;

namespace XCom.Battlescape;

public class Battlescape : Screen, BattlescapeControlActions
{
	private readonly Battle battle;
	private readonly HoverScroll hoverScroll = new();
	private readonly BattlescapeToast toast = new();
	private bool hasFocus;
	private HandAction targetingHandAction;

	public Battlescape(Battle battle)
	{
		this.battle = battle;
		AddControl(new ClickArea(0, 0, 320, 144, OnMapLeftClick, OnMapRightClick));
		AddControl(new BattlescapeControls(battle, this));
		AddControl(toast);
		hoverScroll.OnScrollUp += battle.Map.ScrollUp;
		hoverScroll.OnScrollDown += battle.Map.ScrollDown;
		hoverScroll.OnScrollLeft += battle.Map.ScrollLeft;
		hoverScroll.OnScrollRight += battle.Map.ScrollRight;
	}

	public override void OnSetFocus()
	{
		MidiFiles.Play(MusicType.Battlescape);
		GameState.Current.OnIdle += OnIdle;
		hasFocus = true;
	}

	public override void OnKillFocus()
	{
		hasFocus = false;
		GameState.Current.OnIdle -= OnIdle;
	}

	public void OnIdle()
	{
		hoverScroll.OnIdle();
	}

	private void OnMapLeftClick()
	{
		var cursorLocation = battle.Map.GetCursorLocation();
		if (cursorLocation == null)
			return;
		var unitId = battle.HitTestUnit(cursorLocation);
		if (targetingHandAction != null)
		{
			// TODO: Throw/fire/waypoint for targeting action
			toast.Show("TODO: Take action");
		}
		else if (unitId != null && unitId.UnitType == UnitType.Soldier)
		{
			battle.SelectedUnitId = unitId;
		}
		else
		{
			// TODO: Move selected unit to target location
			toast.Show("TODO: Move");
		}
	}

	private void OnMapRightClick()
	{
		var cursorLocation = battle.Map.GetCursorLocation();
		if (cursorLocation == null)
			return;
		if (targetingHandAction != null)
			targetingHandAction = null;
		else
		{
			// TODO: Turn selected unit to face target location
			toast.Show("TODO: Turn");
		}
	}

	public void OnLeftWeapon()
	{
		targetingHandAction = null;
		// TODO: HWP, alien?
		var activeSoldier = battle.SelectedSoldier;
		if (activeSoldier == null)
			return;
		var item = activeSoldier.LeftHand;
		if (item == null)
			return;
		new ActionOptions(
			item,
			activeSoldier.MaxTimeUnits,
			value => OnHandAction(HandAction.Create(activeSoldier, Hand.Left, item, value))
		).DoModal(this);
	}

	public void OnRightWeapon()
	{
		targetingHandAction = null;
		// TODO: HWP, alien?
		var activeSoldier = battle.SelectedSoldier;
		if (activeSoldier == null)
			return;
		var item = activeSoldier.RightHand;
		if (item == null)
			return;
		new ActionOptions(
			item,
			activeSoldier.MaxTimeUnits,
			value => OnHandAction(HandAction.Create(activeSoldier, Hand.Right, item, value))
		).DoModal(this);
	}

	private void OnHandAction(HandAction handAction)
	{
		var actionType = handAction.Value.ActionType;
		var timeUnits = handAction.Value.TimeUnits;
		var item = handAction.Item;

		// TODO: HWP, alien?
		var activeSoldier = battle.SelectedSoldier;
		if (activeSoldier == null)
			return;

		if (activeSoldier.TimeUnits < timeUnits)
		{
			toast.Show($"Not Enough Time Units!");
			return;
		}

		var metadata = item.Metadata;
		if (metadata is GrenadeMetadata grenadeMetadata)
		{
			if (actionType == ActionType.PrimeGrenade)
			{
				if (item.IsPrimed)
					throw new InvalidOperationException("Grenade is already primed.");
				if (!grenadeMetadata.HasTimer)
				{
					activeSoldier.TimeUnits -= timeUnits;
					item.IsPrimed = true;
					toast.Show("Grenade is Activated!");
				}
				else
				{
					new SetTimerModal(timer =>
					{
						activeSoldier.TimeUnits -= timeUnits;
						item.IsPrimed = true;
						item.Timer = timer;
					}).DoModal(this);
				}
			}
		}

		if (metadata is WeaponMetadata weaponMetadata)
		{
			var isShot =
				actionType == ActionType.SnapShot
				|| actionType == ActionType.AutoShot
				|| actionType == ActionType.AimedShot;
			if (isShot)
			{
				if (weaponMetadata.UsesAmmunition && item.Rounds == 0)
				{
					toast.Show("No Ammunition Loaded!");
				}
				else
				{
					targetingHandAction = handAction;
				}
			}
		}

		// TODO: Other item type actions
		// TODO: Handle different action types (Scan, Probe, Psi, MediKit, Launch)

		if (actionType == ActionType.Throw)
		{
			targetingHandAction = handAction;
		}
	}

	public void OnMoveUp()
	{
		targetingHandAction = null;
		//TODO
	}

	public void OnMoveDown()
	{
		targetingHandAction = null;
		//TODO
	}

	public void OnLevelUp()
	{
		battle.Map.SelectNextLevelUp();
	}

	public void OnLevelDown()
	{
		battle.Map.SelectNextLevelDown();
	}

	public void OnMiniMap()
	{
		//TODO
	}

	public void OnToggleCrouch()
	{
		targetingHandAction = null;
		//TODO
	}

	public void OnInventory()
	{
		targetingHandAction = null;
		//TODO: detect if the active unit is a soldier, otherwise just return
		//TODO: use the ground of the active soldier
		var ground = battle.Stores ?? new List<BattleItem>();
		var activeSoldier = battle.SelectedSoldier;
		if (activeSoldier == null)
			return;
		GameState.Current.SetScreen(new Inventory(battle, activeSoldier, ground, false));
	}

	public void OnCenterOnActiveUnit()
	{
		battle.Map.CenterOn(battle.SelectedUnit.Location);
	}

	public void OnNextUnit()
	{
		targetingHandAction = null;
		battle.SelectNextUnit(false);
		OnCenterOnActiveUnit();
	}

	public void OnDoneAndNextUnit()
	{
		targetingHandAction = null;
		battle.SelectNextUnit(true);
		OnCenterOnActiveUnit();
	}

	public void OnToggleLevelView()
	{
		battle.Map.ViewAllLevels = !battle.Map.ViewAllLevels;
	}

	public void OnOptions()
	{
		targetingHandAction = null;
		GameState.Current.SetScreen(new GameOptions());
	}

	public void OnEndTurn()
	{
		targetingHandAction = null;
		//TODO: real end of turn logic
		battle.StartNextTurn();
		GameState.Current.SetScreen(new DisplayTurn(battle));
	}

	public void OnAbortMission()
	{
		targetingHandAction = null;
		new AbortMission().DoModal(this);
	}

	public void OnOptionNoReserve()
	{
		//TODO
	}

	public void OnOptionReserveSnapShot()
	{
		//TODO
	}

	public void OnOptionReserveAimedShot()
	{
		//TODO
	}

	public void OnOptionReserveAutoShot()
	{
		//TODO
	}

	public void OnUnitStatistics()
	{
		var activeSolider = battle.SelectedSoldier;
		if (activeSolider == null)
			return;
		GameState.Current.SetScreen(new ViewSoldierStatistics(battle, activeSolider));
	}

	public override void Render(GraphicsBuffer buffer)
	{
		battle.Map.Render(buffer, renderCursor: hasFocus, GetCursorMode());
		base.Render(buffer);
	}

	private CursorMode GetCursorMode() =>
		targetingHandAction == null ? CursorMode.Select
		: targetingHandAction.Value.ActionType == ActionType.Throw ? CursorMode.Throw
		: CursorMode.Target;
}
