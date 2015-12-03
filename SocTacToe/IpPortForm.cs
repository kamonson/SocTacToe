using System;
using System.Net;
using System.Windows.Forms;

namespace SocTacToe
{
    public partial class IpPortForm : Form
    {
        public IPAddress Ip;

        public IPAddress GetIp()
        {
            return Ip;
        }

        public int Port;
        public int GetPort()
        {
            return Port;
        }

        public IpPortForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Ip = IPAddress.Parse(textBoxIP.Text);
            Port = int.Parse(textBoxPort.Text);
            Close();
        }
    }
}
