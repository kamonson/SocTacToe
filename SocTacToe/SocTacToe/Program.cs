using System;
using System.Windows.Forms;

namespace SocTacToe //run program
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
            SynchronousSocketClient.StartClient();
            Application.Run(new SocTacToe(new SynchronousSocketClient()));
        }


    }
}

