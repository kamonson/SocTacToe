using System;
using System.Net;
using System.Windows.Forms;

namespace SocTacToe
{
    /// <summary>
    /// Use for entering IP and Port Number for client socket
    /// </summary>
    public partial class IpPortForm : Form
    {
        private IPAddress _ip;
        private int _port;

        /// <summary>
        /// Return IPaddress value of IP Address
        /// </summary>
        /// <returns></returns>
        public IPAddress GetIp()
        {
            return _ip;
        }

        /// <summary>
        /// Return int value of Port
        /// </summary>
        public int GetPort()
        {
            return _port;
        }

        /// <summary>
        /// Make IP/Port Form
        /// </summary>
        public IpPortForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// send back IP Address and Port Number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            _ip = IPAddress.Parse(textBoxIP.Text);
            _port = int.Parse(textBoxPort.Text);
            Close();
        }

        /// <summary>
        /// Enter key starts the app
        /// </summary>
        /// <param name="sender">Enter</param>
        /// <param name="e">Key Press Event</param>
        private void StartWithEnter(object sender, KeyEventArgs e)
        {
            {
                if (e.KeyCode == Keys.Enter)
                    buttonStart.PerformClick();
            }
        }
    }
}
