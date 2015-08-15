﻿using System;
using System.Windows.Forms;

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
				Application.Run(new MainForm());
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
			}
		}
	}
}
