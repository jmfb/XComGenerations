using XCom.Controls;
using XCom.Graphics;
using XCom.Music;
using XCom.Screens;

namespace XCom.Battlescape;

public class Battlescape : Screen, BattlescapeControlActions
{
	private readonly Battle battle;
	private readonly HoverScroll hoverScroll = new();
	private bool hasFocus;

	public Battlescape(Battle battle)
	{
		this.battle = battle;
		AddControl(new ClickArea(0, 0, 320, 144, OnMapLeftClick, OnMapRightClick));
		AddControl(new BattlescapeControls(battle, this));
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
		if (unitId != null && unitId.UnitType == UnitType.Soldier)
			battle.SelectedUnitId = unitId;
		// TODO: Other left click logic
	}

	private void OnMapRightClick()
	{
		var cursorLocation = battle.Map.GetCursorLocation();
		if (cursorLocation == null)
			return;
		// TODO: Right click logic
	}

	public void OnLeftWeapon()
	{
		// TODO: HWP, alien?
		var activeSoldier = battle.SelectedSoldier;
		if (activeSoldier == null)
			return;
		if (activeSoldier.LeftHand == null)
			return;
		// TODO: Parameterize with valid options and receive response
		new ActionOptions().DoModal(this);
	}

	public void OnRightWeapon()
	{
		// TODO: HWP, alien?
		var activeSoldier = battle.SelectedSoldier;
		if (activeSoldier == null)
			return;
		if (activeSoldier.RightHand == null)
			return;
		// TODO: Parameterize with valid options and receive response
		new ActionOptions().DoModal(this);
	}

	public void OnMoveUp()
	{
		//TODO
	}

	public void OnMoveDown()
	{
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
		//TODO
	}

	public void OnInventory()
	{
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
		battle.SelectNextUnit(false);
		OnCenterOnActiveUnit();
	}

	public void OnDoneAndNextUnit()
	{
		battle.SelectNextUnit(true);
		OnCenterOnActiveUnit();
	}

	public void OnToggleLevelView()
	{
		battle.Map.ViewAllLevels = !battle.Map.ViewAllLevels;
	}

	public void OnOptions()
	{
		GameState.Current.SetScreen(new GameOptions());
	}

	public void OnEndTurn()
	{
		//TODO: real end of turn logic
		battle.StartNextTurn();
		GameState.Current.SetScreen(new DisplayTurn(battle));
	}

	public void OnAbortMission()
	{
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
		battle.Map.Render(buffer, renderCursor: hasFocus);
		base.Render(buffer);
	}
}
