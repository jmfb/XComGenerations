using XCom.Controls;
using XCom.Data;
using XCom.Graphics;
using XCom.Music;
using XCom.Screens;

namespace XCom.Battlescape;

public class ActionOptions : Screen
{
	private Action<ActionValue> action;

	public ActionOptions(BattleItem item, int unitMaxTimeUnits, Action<ActionValue> action)
	{
		this.action = action;
		AddControl(
			new ClickArea(
				0,
				0,
				GraphicsBuffer.GameWidth,
				GraphicsBuffer.GameHeight,
				EndModal,
				EndModal
			)
		);

		var values = new List<ActionValue>();

		var metadata = item.Metadata;
		if (metadata is WeaponMetadata weaponMetadata)
			values.AddRange(
				weaponMetadata.Shots.Select(shot => new ActionValue
				{
					ActionType = shot.ShotType.Metadata().ActionType,
					Name = $"{shot.ShotType.Metadata().Name} Shot",
					Accuracy = shot.Accuracy,
					TimeUnits = PercentageTimeUnits(unitMaxTimeUnits, shot.TimeUnits),
				})
			);
		if (metadata is GrenadeMetadata grenadeMetadata && !item.IsPrimed)
			values.Add(
				new ActionValue
				{
					ActionType = ActionType.PrimeGrenade,
					Name = "Prime Grenade",
					Accuracy = null,
					TimeUnits = PercentageTimeUnits(unitMaxTimeUnits, 50),
				}
			);
		// TODO: Equipment actions (stun, medikit, scan, psi, etc.)

		values.Add(
			new ActionValue
			{
				ActionType = ActionType.Throw,
				Name = "Throw",
				Accuracy = null,
				TimeUnits = PercentageTimeUnits(unitMaxTimeUnits, 25),
			}
		);

		var topRow = GraphicsBuffer.GameHeight - values.Count * ActionOption.Height;
		foreach (var value in values)
		{
			AddControl(
				new ActionOption(
					topRow,
					value.Name,
					value.Accuracy,
					value.TimeUnits,
					() => OnSelect(value),
					EndModal
				)
			);
			topRow += ActionOption.Height;
		}
	}

	private static int PercentageTimeUnits(int unitMaxTimeUnits, int percentage) =>
		(unitMaxTimeUnits * percentage) / 100;

	public override bool IsSilentModal => true;

	private void OnSelect(ActionValue value)
	{
		WindowsSoundEffect.ButtonPush.Play();
		EndModal();
		action(value);
	}
}
