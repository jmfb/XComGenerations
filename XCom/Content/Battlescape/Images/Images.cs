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

	public static byte[] MotionScannerBorder =>
		(byte[])ResourceManager.GetObject("MotionScannerBorder", null);

	public static byte[] MotionScannerBackground =>
		(byte[])ResourceManager.GetObject("MotionScannerBackground", null);

	public static byte[] MediKitBoard => (byte[])ResourceManager.GetObject("MediKitBoard", null);

	public static byte[] MediKitBodyParts =>
		(byte[])ResourceManager.GetObject("MediKitBodyParts", null);

	public static byte[] SpecialActionIcons =>
		(byte[])ResourceManager.GetObject("SpecialActionIcons", null);

	public static byte[] MapBorder => (byte[])ResourceManager.GetObject("MapBorder", null);

	public static byte[] MapPreviews => (byte[])ResourceManager.GetObject("MapPreviews", null);

	public static byte[] SoldierStats => (byte[])ResourceManager.GetObject("SoldierStats", null);
}
