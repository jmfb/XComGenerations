using System;
using System.Windows.Forms;
using XCom.Content.Movies;
using XCom.Music;
using XCom.Screens;
using XCom.World;
using MainMenu = XCom.Screens.MainMenu;

namespace XCom
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			try
			{
				LoadLargeStaticResources();
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				GameState.Current.SetScreen(new MovieScreen(Movies.Introduction, MusicType.Introduction, new MainMenu()));
				Application.Run(new MainForm());
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
			}
		}

		private static void LoadLargeStaticResources()
		{
			Map.Instance = new Map();
		}
	}
}
