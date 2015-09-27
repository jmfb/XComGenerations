using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.World
{
	public class RedirectCraft : Screen
	{
		private readonly Craft craft;

		public RedirectCraft(Craft craft)
		{
			this.craft = craft;
			AddControl(new Border(8, 8, 240, 184, ColorScheme.Green, Backgrounds.Craft, 10));
			AddControl(new Label(20, 32, craft.Name, Font.Large, ColorScheme.Green));
			AddControl(new LabeledValue(36, 32, "STATUS>", craft.MissionStatus, Font.Normal, ColorScheme.Green, ColorScheme.Yellow));
			AddControl(new LabeledValue(52, 32, "BASE>", craft.Base.Name, Font.Normal, ColorScheme.Green, ColorScheme.Aqua));
			AddControl(new LabeledValue(60, 32, "SPEED>", ((int)craft.Speed).FormatNumber(), Font.Normal, ColorScheme.Green, ColorScheme.Aqua));
			AddControl(new LabeledValue(68, 32, "MAXIMUM SPEED>", craft.CraftType.Metadata().Speed.FormatNumber(), Font.Normal, ColorScheme.Green, ColorScheme.Aqua));
			AddControl(new LabeledValue(76, 32, "ALTITUDE>", craft.Altitude, Font.Normal, ColorScheme.Green, ColorScheme.Aqua));
			AddControl(new LabeledValue(84, 32, "FUEL>", craft.FuelPercent.FormatPercent(), Font.Normal, ColorScheme.Green, ColorScheme.Aqua));
			AddControl(new LabeledValue(92, 32, "WEAPON-1>", craft.Weapons.Count >= 1 ? craft.Weapons[0].WeaponType.Metadata().Name : "NONE", Font.Normal, ColorScheme.Green, ColorScheme.Aqua));
			if (craft.Weapons.Count >= 1)
				AddControl(new LabeledValue(92, 164, "ROUNDS>", craft.Weapons[0].Ammunition.FormatNumber(), Font.Normal, ColorScheme.Green, ColorScheme.Aqua));
			AddControl(new LabeledValue(100, 32, "WEAPON-2>", craft.Weapons.Count == 2 ? craft.Weapons[1].WeaponType.Metadata().Name : "NONE", Font.Normal, ColorScheme.Green, ColorScheme.Aqua));
			if (craft.Weapons.Count == 2)
				AddControl(new LabeledValue(100, 164, "ROUNDS>", craft.Weapons[1].Ammunition.FormatNumber(), Font.Normal, ColorScheme.Green, ColorScheme.Aqua));
			AddControl(new Button(116, 32, 192, 12, "RETURN TO BASE", ColorScheme.Aqua, Font.Normal, OnReturnToBase));
			AddControl(new Button(132, 32, 192, 12, "SELECT NEW TARGET", ColorScheme.Aqua, Font.Normal, OnSelectNewTarget));
			AddControl(new Button(148, 32, 192, 12, "PATROL", ColorScheme.Aqua, Font.Normal, OnPatrol));
			AddControl(new Button(164, 32, 192, 12, "CANCEL", ColorScheme.Aqua, Font.Normal, EndModal));
		}

		private void OnReturnToBase()
		{
			craft.StartToReturnToBase();
			EndModal();
		}

		private void OnSelectNewTarget()
		{
			//TODO: select new target
		}

		private void OnPatrol()
		{
			craft.Patrol();
			EndModal();
		}
	}
}
