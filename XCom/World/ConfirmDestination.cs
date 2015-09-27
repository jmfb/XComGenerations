using System;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.World
{
	public class ConfirmDestination : Screen
	{
		private readonly Action action;

		public ConfirmDestination(string name, Action action)
		{
			this.action = action;
			AddControl(new Border(64, 16, 224, 72, ColorScheme.Green, Backgrounds.Craft, 0));
			AddControl(new Label(80, Label.CenterOf(16, 224), $"TARGET: {name}", Font.Large, ColorScheme.Green));
			AddControl(new Button(104, 68, 50, 12, "OK", ColorScheme.Aqua, Font.Normal, OnOk));
			AddControl(new Button(104, 138, 50, 12, "CANCEL", ColorScheme.Aqua, Font.Normal, EndModal));
		}

		private void OnOk()
		{
			action();
			EndModal();
			GameState.Current.SetScreen(Geoscape);
		}
	}
}
