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
using System.Diagnostics;

namespace DatShell
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        private void start_Load(object sender, EventArgs e)
        {
            RegistryKey hkcu = Registry.CurrentUser;
            RegistryKey checkthemeing = hkcu.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true);
            string lighttheme = "0";
            try
            {
                lighttheme = checkthemeing.GetValue("SystemUsesLightTheme").ToString();
            }
			catch { }
            if (lighttheme == "0")
            {
                this.BackColor = Color.FromArgb(49, 49, 49);
                label1.ForeColor = Color.FromArgb(255, 255, 255);
                label2.ForeColor = Color.FromArgb(255, 255, 255);
                groupBox1.ForeColor = Color.FromArgb(255, 255, 255);
                button4.ForeColor = Color.FromArgb(0, 0, 0);
                button5.ForeColor = Color.FromArgb(0, 0, 0);
            }
            else
            {
                this.BackColor = Color.FromArgb(255, 255, 255);
                label1.ForeColor = Color.FromArgb(0, 0, 0);
                label2.ForeColor = Color.FromArgb(0, 0, 0);
                groupBox1.ForeColor = Color.FromArgb(0, 0, 0);
                button4.ForeColor = Color.FromArgb(255, 255, 255);
                button5.ForeColor = Color.FromArgb(255, 255, 255);
            }
            label1.Text = "Welcome, " + Environment.UserName.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("ms-settings://");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShellSettings settingsform = new ShellSettings();
            settingsform.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", "/c shutdown /s /t 0");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", "/c shutdown /r /t 0");
        }
    }
}
