﻿using System;
using System.Windows.Forms;

namespace Ex05_WinFormsOthello
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Othello());
        }
    }
}
