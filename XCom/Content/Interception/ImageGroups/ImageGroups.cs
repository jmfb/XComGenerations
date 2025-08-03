using System.Resources;

namespace XCom.Content.Interception.ImageGroups;

public static class ImageGroups
{
	private static ResourceManager resourceMan;

	private static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
				resourceMan = new ResourceManager(
					"XCom.Content.Interception.ImageGroups.ImageGroups",
					typeof(ImageGroups).Assembly
				);
			return resourceMan;
		}
	}

	public static byte[] Icons => (byte[])ResourceManager.GetObject("Icons", null);
	public static byte[] OtherIcons => (byte[])ResourceManager.GetObject("OtherIcons", null);
}
