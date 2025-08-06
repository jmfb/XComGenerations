namespace XCom.Battlescape;

public class HandAction
{
	public Unit SourceUnit { get; set; }
	public Hand Hand { get; set; }
	public BattleItem Item { get; set; }
	public ActionValue Value { get; set; }

	public static HandAction Create(
		Unit sourceUnit,
		Hand hand,
		BattleItem item,
		ActionValue value
	) =>
		new()
		{
			SourceUnit = sourceUnit,
			Hand = hand,
			Item = item,
			Value = value,
		};
}
