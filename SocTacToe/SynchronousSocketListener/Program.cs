
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

using System.Windows.Forms;

namespace SocTacToeServer
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
            SynchronousSocketListener.StartListening();
            Application.Run(new Form1());
        }
    }
}
