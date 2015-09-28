using System;
using System.Windows.Forms;
using XCom.Content.Movies;
using XCom.Screens;
using MainMenu = XCom.Screens.MainMenu;

namespace XCom
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				GameState.Current.SetScreen(new MovieScreen(Movies.Introduction, new MainMenu()));
				Application.Run(new MainForm());
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
			}
		}
	}
}
