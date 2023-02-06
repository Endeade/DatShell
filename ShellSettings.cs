using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using static System.Environment;
using System.Management;
using Microsoft.VisualBasic.Devices;

namespace DatShell
{
    public partial class ShellSettings : Form
    {
        public ShellSettings()
        {
            InitializeComponent();
        }

        private void ShellSettings_Load(object sender, EventArgs e)
        {
            RegistryKey hkcu = Registry.CurrentUser;
            RegistryKey checkthemeing = hkcu.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true);
            string lighttheme = checkthemeing.GetValue("SystemUsesLightTheme").ToString();
            if (lighttheme == "0")
            {
                this.BackColor = Color.FromArgb(49, 49, 49);
                label1.ForeColor = Color.FromArgb(255, 255, 255);
                label2.ForeColor = Color.FromArgb(255, 255, 255);
                label3.ForeColor = Color.FromArgb(255, 255, 255);
                tabPage1.BackColor = Color.FromArgb(49, 49, 49);
                tabPage2.BackColor = Color.FromArgb(49, 49, 49);
            }
            else
            {
                this.BackColor = Color.FromArgb(255, 255, 255);
                label1.ForeColor = Color.FromArgb(0, 0, 0);
                label2.ForeColor = Color.FromArgb(0, 0, 0);
                label3.ForeColor = Color.FromArgb(0, 0, 0);
                tabPage1.BackColor = Color.FromArgb(255, 255, 255);
                tabPage2.BackColor = Color.FromArgb(255, 255, 255);
            }
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey cpuidentifierhklm = hklm.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0", true);
            string cpuidentifier = cpuidentifierhklm.GetValue("ProcessorNameString").ToString();
            ulong ram = (new ComputerInfo().TotalPhysicalMemory) / (1024 * 1024);
            label3.Text = "System Specs:\nCPU: " + cpuidentifier + "\nRAM: " + ram.ToString() + "MB\nCurrent User: " + Environment.UserName.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey hkcu = Registry.CurrentUser;
            RegistryKey checkthemeing = hkcu.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true);
            string lighttheme = checkthemeing.GetValue("SystemUsesLightTheme").ToString();
            if (lighttheme == "0")
            {
                checkthemeing.SetValue("SystemUsesLightTheme", "1");
            }
            else
            {
                MessageBox.Show("Light theme is already set.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey hkcu = Registry.CurrentUser;
            RegistryKey checkthemeing = hkcu.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true);
            string lighttheme = checkthemeing.GetValue("SystemUsesLightTheme").ToString();
            if (lighttheme == "1")
            {
                checkthemeing.SetValue("SystemUsesLightTheme", "0");
            }
            else
            {
                MessageBox.Show("Dark theme is already set.");
            }
        }
    }
}
