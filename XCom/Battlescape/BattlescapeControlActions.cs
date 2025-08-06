namespace XCom.Battlescape;

public interface BattlescapeControlActions
{
	void OnLeftWeapon();
	void OnRightWeapon();
	void OnMoveUp();
	void OnMoveDown();
	void OnLevelUp();
	void OnLevelDown();
	void OnMiniMap();
	void OnToggleCrouch();
	void OnInventory();
	void OnCenterOnActiveUnit();
	void OnNextUnit();
	void OnDoneAndNextUnit();
	void OnToggleLevelView();
	void OnOptions();
	void OnEndTurn();
	void OnAbortMission();
	void OnOptionNoReserve();
	void OnOptionReserveSnapShot();
	void OnOptionReserveAimedShot();
	void OnOptionReserveAutoShot();
	void OnUnitStatistics();
}
