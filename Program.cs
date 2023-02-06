using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

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
            Process.Start("C:\\Windows\\System32\\taskkill.exe", "/f /im explorer.exe");
            Application.EnableVisualStyles();
            RegistryKey hkcu = Registry.CurrentUser;
            RegistryKey checkthemeing = hkcu.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true);
            if (checkthemeing != null)
            {
                Application.Run(form1);
            }
            else
            {
                hkcu.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true);
                Application.Run(form1);
            }
        }
    }
}
