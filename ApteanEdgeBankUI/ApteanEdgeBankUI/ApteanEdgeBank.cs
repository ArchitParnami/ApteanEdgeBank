using ApteanEdgeBankAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApteanEdgeBankUI
{

    static class ApteanEdgeBank
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DataHandler DH = new DataHandler();
            Application.Run(new LoginForm(DH));
        }
    }
}
