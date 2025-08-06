using XCom.Battlescape.Tiles;
using XCom.Content.Overlays;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Battlescape;

public class BattlescapeControls : InteractiveContainer
{
	private readonly Battle battle;

	public BattlescapeControls(Battle battle, BattlescapeControlActions actions)
	{
		this.battle = battle;
		AddControl(new Overlay(Overlays.BattlescapeControls, 4));
		AddControl(new ClickArea(144, 0, 48, 56, actions.OnLeftWeapon));
		AddControl(new ClickArea(144, 272, 48, 56, actions.OnRightWeapon));
		AddControl(new ClickArea(144, 48, 32, 16, actions.OnMoveUp));
		AddControl(new ClickArea(160, 48, 32, 16, actions.OnMoveDown));
		AddControl(new ClickArea(144, 80, 32, 16, actions.OnLevelUp));
		AddControl(new ClickArea(160, 80, 32, 16, actions.OnLevelDown));
		AddControl(new ClickArea(144, 112, 32, 16, actions.OnMiniMap));
		AddControl(new ClickArea(160, 112, 32, 16, actions.OnToggleCrouch));
		AddControl(new ClickArea(144, 144, 32, 16, actions.OnInventory));
		AddControl(new ClickArea(160, 144, 32, 16, actions.OnCenterOnActiveUnit));
		AddControl(new ClickArea(144, 176, 32, 16, actions.OnNextUnit));
		AddControl(new ClickArea(160, 176, 32, 16, actions.OnDoneAndNextUnit));
		AddControl(new ClickArea(144, 208, 32, 16, actions.OnToggleLevelView));
		AddControl(new ClickArea(160, 208, 32, 16, actions.OnOptions));
		AddControl(new ClickArea(144, 240, 32, 16, actions.OnEndTurn));
		AddControl(new ClickArea(160, 240, 32, 16, actions.OnAbortMission));
		AddControl(new ClickArea(176, 48, 30, 12, actions.OnOptionNoReserve));
		AddControl(new ClickArea(188, 48, 30, 12, actions.OnOptionReserveAimedShot));
		AddControl(new ClickArea(176, 78, 30, 12, actions.OnOptionReserveSnapShot));
		AddControl(new ClickArea(188, 78, 30, 12, actions.OnOptionReserveAutoShot));
		AddControl(new ClickArea(176, 108, 164, 24, actions.OnUnitStatistics));
	}

	public override void Render(GraphicsBuffer buffer)
	{
		base.Render(buffer);
		DrawUnitInformation(buffer, battle.SelectedUnit);
		// TODO: Black/Gray color scheme?
		Font.Small.DrawString(
			buffer,
			150,
			232,
			battle.Map.ViewAllLevels ? "2" : "1",
			ColorScheme.White
		);
		var activeSoldier = battle.SelectedSoldier;
		// TODO: Ammunition counts
		activeSoldier?.LeftHand?.Render(buffer, 148, 8, isCentered: true);
		activeSoldier?.RightHand?.Render(buffer, 148, 280, isCentered: true);
		// TODO: HWP, alien?
	}

	private static void DrawUnitInformation(GraphicsBuffer buffer, Unit unit)
	{
		if (unit == null)
			return;
		Font.Normal.DrawString(buffer, 176, 134, unit.Name, ColorScheme.Blue);
		Font.Small.DrawString(buffer, 186, 136, $"{unit.TimeUnits}", ColorScheme.LightGreen);
		Font.Small.DrawString(buffer, 194, 136, $"{unit.Health}", ColorScheme.Red);
		Font.Small.DrawString(buffer, 186, 154, $"{unit.Energy}", ColorScheme.Orange);
		Font.Small.DrawString(buffer, 194, 154, $"{unit.Morale}", ColorScheme.Purple);
		new Bar(185, 170, unit.MaxTimeUnits, 3, unit.TimeUnits, 55, 48).Render(buffer);
		new Bar(189, 170, unit.MaxEnergy, 3, unit.Energy, 23, 16).Render(buffer);
		new Bar(193, 170, unit.MaxHealth, 3, unit.Health, 39, 32).Render(buffer);
		new Bar(197, 170, unit.MaxMorale, 3, unit.Morale, 249, 247).Render(buffer);
		unit.Rank?.Image().Render(buffer, 177, 107);
	}
}
