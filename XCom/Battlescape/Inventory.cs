using XCom.Content.Overlays;
using XCom.Controls;
using XCom.Screens;

namespace XCom.Battlescape
{
	public class Inventory : Screen
	{
		public Inventory()
		{
			AddControl(new Overlay(Overlays.Tactical));
			AddControl(new ClickArea(1, 238, 35, 23, OnOk));
			AddControl(new ClickArea(1, 274, 23, 23, OnPreviousSoldier));
			AddControl(new ClickArea(1, 298, 23, 23, OnNextSoldier));
			AddControl(new ClickArea(32, 288, 33, 26, OnUnloadWeapon));
			AddControl(new ClickArea(137, 288, 33, 15, OnNextEquipment));
		}

		private static void OnOk()
		{
		}

		private static void OnPreviousSoldier()
		{
		}

		private static void OnNextSoldier()
		{
		}

		private static void OnUnloadWeapon()
		{
		}

		private static void OnNextEquipment()
		{
		}
	}
}
