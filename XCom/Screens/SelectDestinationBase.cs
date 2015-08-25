using System.Linq;
using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class SelectDestinationBase : Screen
	{
		public SelectDestinationBase()
		{
			AddControl(new Border(30, 20, 280, 140, ColorScheme.DarkYellow, Backgrounds.Funds, 10));
			AddControl(new Label(38, Label.Center, "Select Destination Base", Font.Large, ColorScheme.DarkYellow));
			AddControl(new Label(54, 30, "Current Funds>", Font.Normal, ColorScheme.DarkYellow));
			AddControl(new DynamicLabel(54, 98, () => "$" + GameState.Current.Data.Funds.FormatNumber(), Font.Normal, ColorScheme.White));
			AddControl(new Label(64, 28, "Name", Font.Large, ColorScheme.DarkYellow));
			AddControl(new Label(64, 160, "Area", Font.Large, ColorScheme.DarkYellow));
			var otherBases = GameState.Current.Data.Bases.Where(@base => !ReferenceEquals(@base, GameState.SelectedBase)).ToList();
			AddControl(new ListView<Data.Base>(80, 28, 7, otherBases, ColorScheme.DarkYellow, Palette.GetPalette(10).GetColor(230), OnSelectBase)
				.AddColumn(2, Alignment.Left, @base => "")
				.AddColumn(130, Alignment.Left, @base => @base.Name, @base => ColorScheme.LightMagenta)
				.AddColumn(116, Alignment.Left, @base => @base.Area));
			AddControl(new Button(146, 28, 264, 16, "Cancel", ColorScheme.DarkYellow, Font.Normal, OnCancel));
		}

		private static void OnSelectBase(Data.Base @base)
		{
			GameState.Current.SetScreen(new Transfer(@base));
		}

		private static void OnCancel()
		{
			GameState.Current.SetScreen(new Base());
		}
	}
}
