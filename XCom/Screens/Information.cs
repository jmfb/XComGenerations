using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class Information : Screen
	{
		public Information()
		{
			AddControl(new Border(10, 32, 256, 180, ColorScheme.Green, Backgrounds.Title, 0));
			AddControl(new Label(33, Label.Center, "UFOpaedia", Font.Large, ColorScheme.Yellow));
			AddControl(new Button(50, 48, 224, 12, "XCOM CRAFT & ARMAMENT", ColorScheme.Green, Font.Normal, OnCraftAndArmament));
			AddControl(new Button(63, 48, 224, 12, "HEAVY WEAPONS PLATFORMS", ColorScheme.Green, Font.Normal, OnHeavyWeaponsPlatforms));
			AddControl(new Button(76, 48, 224, 12, "WEAPONS AND EQUIPMENT", ColorScheme.Green, Font.Normal, OnWeaponsAndEquipment));
			AddControl(new Button(89, 48, 224, 12, "ALIEN ARTIFACTS", ColorScheme.Green, Font.Normal, OnAlienArtifacts));
			AddControl(new Button(102, 48, 224, 12, "BASE FACILITIES", ColorScheme.Green, Font.Normal, OnBaseFacilities));
			AddControl(new Button(115, 48, 224, 12, "ALIEN LIFE FORMS", ColorScheme.Green, Font.Normal, OnAlienLifeForms));
			AddControl(new Button(128, 48, 224, 12, "ALIEN RESEARCH", ColorScheme.Green, Font.Normal, OnAlienResearch));
			AddControl(new Button(141, 48, 224, 12, "UFO COMPONENTS", ColorScheme.Green, Font.Normal, OnUfoComponents));
			AddControl(new Button(154, 48, 224, 12, "UFOs", ColorScheme.Green, Font.Normal, OnUfos));
			AddControl(new Button(167, 48, 224, 12, "OK", ColorScheme.Green, Font.Normal, OnOk));
		}

		private static void OnCraftAndArmament()
		{
			//TODO:
		}

		private static void OnHeavyWeaponsPlatforms()
		{
			//TODO:
		}

		private static void OnWeaponsAndEquipment()
		{
			GameState.Current.SetScreen(new ItemInformationList());
		}

		private static void OnAlienArtifacts()
		{
			//TODO:
		}

		private static void OnBaseFacilities()
		{
			//TODO:
		}

		private static void OnAlienLifeForms()
		{
			//TODO:
		}

		private static void OnAlienResearch()
		{
			//TODO:
		}

		private static void OnUfoComponents()
		{
			//TODO:
		}

		private static void OnUfos()
		{
			//TODO:
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(Geoscape);
		}
	}
}
