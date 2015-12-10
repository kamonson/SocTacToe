using System;
using System.Windows.Forms;

namespace SynchronousSocketListener
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
            var form = new Form1();
            form.Show();
            form.AppendText("Let's Get Started!\n");
//            Server.StartListening(ref form);
            Application.Run(Server.StartListening());
        }
    }
}
