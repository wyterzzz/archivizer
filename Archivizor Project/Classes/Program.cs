using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Archivizer_Project;

namespace Archivizor_Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                Type objType = Type.GetType("Archivizor_Project." + args[0]);
                Form frm = (Form)Activator.CreateInstance(objType, new object[] { Manage(args) });
                Application.Run(frm);
            }
            else
            {
                Application.Run(new MainForm());
            }
        }

        private static String[] Manage(String[] parameters)
        {
            String[] newArr = new String[parameters.Length - 1];
            for (int i = 0; i < parameters.Length - 1; i++)
                newArr[i] = parameters[i + 1];
            return newArr;
        }
    }
}
