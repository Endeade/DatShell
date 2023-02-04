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
            this.StartPosition = FormStartPosition.Manual;
            RegistryKey hkcu = Registry.CurrentUser;
            RegistryKey checkthemeing = hkcu.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true);
            string lighttheme = checkthemeing.GetValue("SystemUsesLightTheme").ToString();
            if (lighttheme == "0")
            {
                this.BackColor = Color.FromArgb(49, 49, 49);
                label1.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.BackColor = Color.FromArgb(255, 255, 255);
                label1.ForeColor = Color.FromArgb(0, 0, 0);
            }
            label1.Text = "Welcome, " + Environment.UserName.ToString();
        }
    }
}
