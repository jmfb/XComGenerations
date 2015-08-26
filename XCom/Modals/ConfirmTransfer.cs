using System;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;
using XCom.Screens;

namespace XCom.Modals
{
	public class ConfirmTransfer : Screen
	{
		private readonly int cost;
		private readonly Action confirmationAction;

		public ConfirmTransfer(string destination, int cost, Action confirmationAction)
		{
			this.cost = cost;
			this.confirmationAction = confirmationAction;
			AddControl(new Border(60, 0, 320, 80, ColorScheme.DarkYellow, Backgrounds.Funds, 6));
			AddControl(new Label(75, Label.Center, $"Transfer Items to {destination}", Font.Large, ColorScheme.Blue));
			AddControl(new Label(95, 110, "Cost", Font.Large, ColorScheme.Blue));
			AddControl(new Label(95, 170, $"${cost.FormatNumber()}", Font.Large, ColorScheme.LightMagenta));
			AddControl(new Button(115, 16, 128, 16, "OK", ColorScheme.Purple, Font.Normal, OnOk));
			AddControl(new Button(115, 176, 128, 16, "CANCEL", ColorScheme.Purple, Font.Normal, EndModal));
		}

		private void OnOk()
		{
			if (cost > GameState.Current.Data.Funds)
			{
				SwitchToModal(new NotEnoughMoney(ColorScheme.LightMagenta, Backgrounds.Funds));
			}
			else
			{
				EndModal();
				confirmationAction();
			}
		}
	}
}
