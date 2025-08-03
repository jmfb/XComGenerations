using System.Resources;

namespace XCom.Content.Interception.ImageTables;

public static class ImageTables
{
	private static ResourceManager resourceMan;

	private static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
				resourceMan = new ResourceManager(
					"XCom.Content.Interception.ImageTables.ImageTables",
					typeof(ImageTables).Assembly
				);
			return resourceMan;
		}
	}

	public static byte[] Icons => (byte[])ResourceManager.GetObject("Icons", null);
	public static byte[] OtherIcons => (byte[])ResourceManager.GetObject("OtherIcons", null);
}
