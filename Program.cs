using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Application.Run(form1);
        }
    }
}
