using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cabinet_medical
{
	static class Program
	{
		public static Button button;
		public static Button button1;
		public static ToolStripMenuItem toolStripMenuItemN;
		public static ToolStripMenuItem toolStripMenuItemS;
		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
