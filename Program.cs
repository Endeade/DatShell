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
            Process.Start("Properties.Resources.ncmdc", "win hide class Shell_TrayWnd");
            Process.Start("cmd.exe", "/c taskkill /f /im explorer.exe");
            Process.Start("explorer.exe");
            Application.Run(form1);
        }
    }
}
