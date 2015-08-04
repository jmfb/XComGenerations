using System;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class NewBaseNamePrompt : Screen
	{
		private readonly Edit baseName;
		private readonly Func<string, Screen> action;

		public NewBaseNamePrompt(Func<string, Screen> action)
		{
			this.action = action;
			AddControl(new Border(60, 32, 192, 80, ColorScheme.Aqua, Backgrounds.Title, 0));
			AddControl(new Label(76, Label.CenterOf(32, 192), "Base Name?", Font.Large, ColorScheme.Aqua));
			baseName = new Edit(106, 54, 137, "", Font.Large, ColorScheme.Aqua, OnEditBaseName);
			AddControl(baseName);
		}

		public override void OnSetFocus()
		{
			baseName.BeginEdit();
		}

		private void OnEditBaseName(string name)
		{
			EndModal();
			var returnToScreen = action(name);
			GameState.Current.SetScreen(returnToScreen);
		}
	}
}
