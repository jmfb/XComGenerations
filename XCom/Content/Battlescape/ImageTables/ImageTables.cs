using System.Resources;

namespace XCom.Content.Battlescape.ImageTables;

public static class ImageTables
{
	private static ResourceManager resourceMan;

	private static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
				resourceMan = new ResourceManager(
					"XCom.Content.Battlescape.ImageTables.ImageTables",
					typeof(ImageTables).Assembly
				);
			return resourceMan;
		}
	}

	public static byte[] Cursors => (byte[])ResourceManager.GetObject("Cursors", null);
}
