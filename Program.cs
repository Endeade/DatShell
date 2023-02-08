using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.Net;
using System.IO;

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
            if (Directory.Exists("C:\\Windows\\datshell-utils"))
            {
                Process.Start("C:\\Windows\\datshell-utils\\ncmdc.exe", "win hide class Shell_TrayWnd");
            } else
            {
                Directory.CreateDirectory("C:\\Windows\\datshell-utils");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Endeade/DatShell/raw/main/ncmdc.exe", "C:\\Windows\\datshell-utils\\ncmdc.exe");
                }
                Process.Start("C:\\Windows\\datshell-utils\\ncmdc.exe", "win hide class Shell_TrayWnd");
            }
            Application.Run(form1);
        }
    }
}
