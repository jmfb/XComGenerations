using System.Globalization;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class CraftList : Screen
	{
		public CraftList()
		{
			var selectedBase = GameState.SelectedBase;

			AddControl(new Border(0, 0, 320, 200, ColorScheme.LightMagenta, Backgrounds.EquipCraft, 9));
			AddControl(new Label(8, 16, "INTERCEPTION CRAFT", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(24, 16, $"Base>{selectedBase.Name}", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Label(40, 16, "NAME", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(40, 110, "STATUS", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(40, 160, "WEAPON", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(48, 160, "SYSTEMS", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(40, 210, "CREW", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new Label(40, 268, "HWPs", Font.Normal, ColorScheme.LightMagenta));
			AddControl(new ListView<Craft>(58, 8, 8, selectedBase.Crafts, ColorScheme.Blue, Palette.GetPalette(9).GetColor(230), OnSelectCraft)
				.AddColumn(8, Alignment.Left, craft => "")
				.AddColumn(94, Alignment.Left, craft => craft.Name)
				.AddColumn(65, Alignment.Left, craft => craft.Status.Name())
				.AddColumn(47, Alignment.Left, GetCraftWeaponText)
				.AddColumn(46, Alignment.Left, craft => craft.SoldierIds.Count.ToString(CultureInfo.InvariantCulture))
				.AddColumn(27, Alignment.Left, craft => "0")); //TODO: hwp count for craft
			AddControl(new Button(176, 16, 288, 16, "OK", ColorScheme.Blue, Font.Normal, OnOk));
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(new Base());
		}

		private static void OnSelectCraft(Craft craft)
		{
			GameState.Current.SetScreen(new EquipCraft(craft));
		}

		private static string GetCraftWeaponText(Craft craft)
		{
			return string.Format(
				CultureInfo.CurrentCulture,
				"{0}\t/{1}",
				craft.Weapons.Count,
				craft.CraftType.Metadata().WeaponCount);
		}
	}
}
