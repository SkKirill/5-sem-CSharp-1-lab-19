using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Printing;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using Comparable_Mark.Forms;

namespace Comparable_Mark
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			System.Windows.Forms.Application.Run(new MainForm());
		}
	}
}