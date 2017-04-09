using System;
using System.Windows.Forms;
using networking;
using services;

namespace Firmatransport
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

            IServer server = new ServerProxy("127.0.0.1", 55555);
            Application.Run(new Login(server));
        }
    }
}
