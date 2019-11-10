using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Taki_lala
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
   
        static void Main(string[] args)
        {

        }

        [STAThread]
        public static void RunGraphics()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
