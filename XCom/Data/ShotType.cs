using XCom.Battlescape;

namespace XCom.Data;

public enum ShotType
{
	Auto,
	Snap,
	Aimed,
}

public static class ShotTypeExtensions
{
	public static ShotMetadata Metadata(this ShotType shotType)
	{
		return metadata[shotType];
	}

	private static ShotMetadata Shot(string name, ActionType actionType)
	{
		return new ShotMetadata { Name = name, ActionType = actionType };
	}

	private static readonly Dictionary<ShotType, ShotMetadata> metadata = new()
	{
		{ ShotType.Auto, Shot("Auto", ActionType.AutoShot) },
		{ ShotType.Snap, Shot("Snap", ActionType.SnapShot) },
		{ ShotType.Aimed, Shot("Aimed", ActionType.AimedShot) },
	};
}
