using System.Collections.Generic;

namespace XCom.Data
{
	public enum ShotType
	{
		Auto,
		Snap,
		Aimed
	}

	public static class ShotTypeExtensions
	{
		public static ShotMetadata Metadata(this ShotType shotType)
		{
			return metadata[shotType];
		}

		private static ShotMetadata Shot(string name)
		{
			return new ShotMetadata
			{
				Name = name
			};
		}

		private static readonly Dictionary<ShotType, ShotMetadata> metadata = new Dictionary<ShotType, ShotMetadata>
		{
			{ ShotType.Auto, Shot("Auto") },
			{ ShotType.Snap, Shot("Snap") },
			{ ShotType.Aimed, Shot("Aimed") }
		};
	}
}
