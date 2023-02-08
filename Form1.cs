using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Microsoft.Win32;
using static System.Windows.Forms.Timer;

namespace DatShell
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    break;
            }

            base.OnFormClosing(e);
        }

        System.Timers.Timer myTimer = new System.Timers.Timer(1000);
        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;
            int y = Screen.PrimaryScreen.Bounds.Bottom - 50;
            this.Location = new Point(0, y);
            Size formSize = new Size(Screen.GetWorkingArea(this).Width, Screen.GetWorkingArea(this).Height);
            this.Size = new Size(formSize.Width, 50);
            RegistryKey hkcu = Registry.CurrentUser;
            RegistryKey checkthemeing = hkcu.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true);
            string lighttheme = checkthemeing.GetValue("SystemUsesLightTheme").ToString();
            if (lighttheme == "0")
            {
                this.BackColor = Color.FromArgb(49, 49, 49);
                label1.ForeColor = Color.FromArgb(255, 255, 255);
                pictureBox1.Image = Properties.Resources.dark;
            } else
            {
                this.BackColor = Color.FromArgb(255, 255, 255);
                label1.ForeColor = Color.FromArgb(0, 0, 0);
                pictureBox1.Image = Properties.Resources.light;
            }
            label1.Text = DateTime.Now.ToString("HH:mm:ss\nyyyy-MM-dd");
            var timer = new System.Windows.Forms.Timer {Interval = 1000};
            timer.Tick += (o, args) =>
            {
                label1.Text = DateTime.Now.ToString("HH:mm:ss\nyyyy-MM-dd");
            };
            timer.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var startform = new start();
            startform.ShowDialog();
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == "startform")
                {
                    startform.Close();
                }
            }
        }
    }
}
