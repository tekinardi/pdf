using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace pdf
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                //string fileName = args[0];
                //MessageBox.Show(fileName);


                //Check file exists
                //if (File.Exists(fileName))
                //{
                //    Application.EnableVisualStyles();
                //    Application.SetCompatibleTextRenderingDefault(false);

                //    Yeni MainFrom = new Yeni();
                //    MainFrom.OpenFile(fileName);
                //    Application.Run(MainFrom);
                //}
                ////The file does not exist
                //else
                //{
                //    MessageBox.Show("The file does not exist!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    Application.EnableVisualStyles();
                //    Application.SetCompatibleTextRenderingDefault(false);
                //    Application.Run(new Yeni());
                //}
            }
            //without args
            //else
            //{


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Yeni());
            //}
        }
    }
}
