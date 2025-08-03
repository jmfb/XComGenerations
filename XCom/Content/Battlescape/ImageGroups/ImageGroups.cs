using System.Resources;

namespace XCom.Content.Battlescape.ImageGroups;

public static class ImageGroups
{
	private static ResourceManager resourceMan;

	private static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
				resourceMan = new ResourceManager(
					"XCom.Content.Battlescape.ImageGroups.ImageGroups",
					typeof(ImageGroups).Assembly
				);
			return resourceMan;
		}
	}

	public static byte[] Cursors => (byte[])ResourceManager.GetObject("Cursors", null);
	public static byte[] MeleeHit => (byte[])ResourceManager.GetObject("MeleeHit", null);
	public static byte[] Miscellaneous => (byte[])ResourceManager.GetObject("Miscellaneous", null);
}
