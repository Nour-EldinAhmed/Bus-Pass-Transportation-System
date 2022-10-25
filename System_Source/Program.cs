//using Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_Station
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
          //Application.Run(new Frist_Page());
            // Application.Run(new Map_Bus());
            Application.Run(new Menu());
            //  Application.Run(new Admin());


        }
    }
}
