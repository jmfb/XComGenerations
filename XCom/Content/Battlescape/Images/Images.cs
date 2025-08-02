using System.Resources;

namespace XCom.Content.Battlescape.Images;

public static class Images
{
	private static ResourceManager resourceMan;

	private static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
				resourceMan = new ResourceManager(
					"XCom.Content.Battlescape.Images.Images",
					typeof(Images).Assembly
				);
			return resourceMan;
		}
	}

	public static byte[] MotionScannerIcons =>
		(byte[])ResourceManager.GetObject("MotionScannerIcons", null);

	public static byte[] MediKitBodyParts =>
		(byte[])ResourceManager.GetObject("MediKitBodyParts", null);
}
