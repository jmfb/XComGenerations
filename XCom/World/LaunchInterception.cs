using System;
using System.Collections.Generic;
using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.World
{
	public class LaunchInterception : Screen
	{
		public LaunchInterception(Data.Base baseFilter = null)
		{
			AddControl(new Border(30, 0, 320, 140, ColorScheme.Green, Backgrounds.Craft, 10));
			AddControl(new Label(45, Label.Center, "LAUNCH INTERCEPTION", Font.Large, ColorScheme.Green));
			AddControl(new Label(70, 15, "CRAFT", Font.Normal, ColorScheme.Aqua));
			AddControl(new Label(70, 100, "STATUS", Font.Normal, ColorScheme.Aqua));
			AddControl(new Label(70, 165, "BASE", Font.Normal, ColorScheme.Aqua));
			AddControl(new Label(62, 242, "WEAPONS/", Font.Normal, ColorScheme.Aqua));
			AddControl(new Label(70, 242, "CREW/HWPs", Font.Normal, ColorScheme.Aqua));
			var selectionColor = Palette.GetPalette(10).GetColor(230);
			AddControl(new ListView<Craft>(78, 15, 7, GetCrafts(baseFilter), ColorScheme.Green, selectionColor, OnSelectCraft)
				.AddColumn(85, Alignment.Left, craft => craft.Name, craft => ColorScheme.Green)
				.AddColumn(65, Alignment.Left, craft => craft.Status.Name(), craft => craft.Status == CraftStatus.Ready ? ColorScheme.Yellow : ColorScheme.Green)
				.AddColumn(85, Alignment.Left, craft => craft.Base.Name, craft => ColorScheme.Green)
				.AddColumn(50, Alignment.Left,
					ColoredNumber(craft => craft.Weapons.Count),
					NumberSeparator,
					ColoredNumber(craft => craft.SoldierIds.Count),
					NumberSeparator,
					ColoredNumber(craft => craft.TotalHwpCount)));
			AddControl(new Button(145, 16, 288, 16, "Cancel", ColorScheme.Aqua, Font.Normal, EndModal));
		}

		private static Func<Craft, ColoredText> ColoredNumber(Func<Craft, int> number)
		{
			return craft => new ColoredText
			{
				Text = number(craft).FormatNumber(),
				Scheme = number(craft) == 0 ? ColorScheme.Green : ColorScheme.Yellow
			};
		}

		private static Func<Craft, ColoredText> NumberSeparator =>
			craft => new ColoredText { Text = "/", Scheme = ColorScheme.Green };

		private static List<Craft> GetCrafts(Data.Base baseFilter)
		{
			return GameState.Current.Data.Bases
				.Where(@base => baseFilter == null || @base == baseFilter)
				.SelectMany(@base => @base.Crafts)
				.ToList();
		}

		private void OnSelectCraft(Craft craft)
		{
			if (craft.Status != CraftStatus.Ready)
				return;
			EndModal();
			GameState.Current.SetScreen(new SelectDestination(craft));
		}
	}
}
