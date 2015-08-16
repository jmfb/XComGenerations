using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class ItemInformation : Screen
	{
		private readonly Screen returnToScreen;
		private readonly ItemType item;

		public ItemInformation(Screen returnToScreen, ItemType item)
		{
			this.returnToScreen = returnToScreen;
			this.item = item;
			AddControl(new Background(Backgrounds.InfoItem, 4));
			AddControl(new Button(5, 5, 30, 13, "OK", ColorScheme.Yellow, Font.Normal, OnOk));
			AddControl(new Button(5, 40, 30, 13, "<<", ColorScheme.Yellow, Font.Normal, OnPrevious));
			AddControl(new Button(5, 75, 30, 13, ">>", ColorScheme.Yellow, Font.Normal, OnNext));
			AddControl(new Label(24, 5, item.Metadata().Name, Font.Large, ColorScheme.LightBlue));
			//TODO: image
			//TODO: body of text
		}

		private void OnOk()
		{
			GameState.Current.SetScreen(returnToScreen);
		}

		private void OnPrevious()
		{
			//TODO: go to previous item
		}

		private void OnNext()
		{
			//TODO: go to next item
		}
	}
}
