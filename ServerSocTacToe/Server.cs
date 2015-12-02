using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerSocTacToe
{

    public partial class Form1 : Form
    {
        private string _data;
        private bool _serving;
        delegate void SetTextCallback(string text); //make thread safe call to _update lable
        private State _state = new State();

        public Form1()
        {
            InitializeComponent();
        }

        private void startSocTacToeServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread listenerThread = new Thread(Listen);
            listenerThread.Start();
        }

        private void Listen()
        {
            // enable form to display form info
            // _data buffer for incoming data.
            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
            _serving = true;
            var ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddress = ipHostInfo.AddressList[1];
            var localEndPoint = new IPEndPoint(ipAddress, 11000);
            Console.WriteLine(@"IP address is: " + ipAddress + @" Port is: 11000");
            UpdateText(@"IP address is: " + ipAddress + Environment.NewLine + @"Port is: 11000");
            // Create a TCP/IP socket.
            var listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and 
            // Listen for incoming connections.
            try
            {
                while (_serving)
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(10);

                    // Start listening for connections.
                    Console.WriteLine(@"Waiting for a connection...");
                    UpdateText(@"Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.
                    var handler = listener.Accept();
                    _data = null;

                    // An incoming connection needs to be processed.

                    var bytes = new byte[1024];
                    var bytesRec = handler.Receive(bytes);
                    _data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (_data.IndexOf("<EOF>", StringComparison.Ordinal) > -1)
                    {
                        // Show the data on the console.
                        Console.WriteLine(@"Text received : {0}", _data);
                        UpdateText(@"Text received : " + _data);

                        //_update state text seperated with new line into vector <EOF> chopped off, WILL BE GOOD TO CHECK FOR WINNER AT SERVER
                        _state.SetState(_data);

                        // Send the data Array holding current state <EOF> added to the client NEED TO BE ABLE TO HANDLE MULTIPLE CLIENTS
                        var msg = Encoding.ASCII.GetBytes(_state.GetState());

                        handler.Send(msg);
                    }
                    else
                    {
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                UpdateText(ex.ToString());
            }
            Console.WriteLine(@"Server is dead");
            UpdateText(@"Server is dead");
            Console.Read();
        }

        private void stopSocTacToeServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _serving = false;
        }

        private void UpdateText(string text) //use callback to set run label _update on GUI thread instead of listener thread
        {
            if (label1.InvokeRequired)
            {
                var d = new SetTextCallback(UpdateText);
                Invoke(d, new object[] { text });
            }
            else
            {
                label1.Text += Environment.NewLine + text;
                label1.Refresh();
            }
        }
    }
}