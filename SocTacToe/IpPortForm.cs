using System;
using System.Net;
using System.Windows.Forms;

namespace SocTacToe
{
    public partial class IpPortForm : Form
    {
        private IPAddress _ip;
        private int _port;

        public IpPortForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            _ip = IPAddress.Parse(textBoxIP.Text);
            _port = int.Parse(textBoxPort.Text);
            var state = new SynchronousSocketClient();
            state.StartClient(_ip, _port);
            
        }
    }
}
