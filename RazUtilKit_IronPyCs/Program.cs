﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RazUtilKit_IronPyCs
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (TrayIcon ti = new TrayIcon())
            {
                ti.Display();
                Application.Run();
            }
            //Application.Run(new Form1());
        }
    }
}
