using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DatShell
{
	static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static Form1 form1 = new Form1();
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            RegistryKey hkcu = Registry.CurrentUser;
            RegistryKey checkthemeing = hkcu.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true);
            if (checkthemeing != null)
            {
                
            }
            else
            {
                hkcu.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true);
            }
            Application.Run(form1);
        }
    }
}
