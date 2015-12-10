using System;
using System.Net;
using System.Windows.Forms;

namespace SocTacToe
{
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
    }
}
