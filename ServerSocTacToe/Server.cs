using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerSocTacToe
{
    public static class SynchronousSocketListener
    {
        private static IPAddress _ipAddress;

        public static string GetIpString()
        {
            if (_ipAddress != null) return _ipAddress.ToString();
            return string.Empty;
        }

        //Handler is a public static object to conrol server end socket
        public static Socket Handler;

        // Incoming data from the client.
        public static string data;

        public static void StartListening()
        {
            // Data buffer for incoming data.
            byte[] bytes;

            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            _ipAddress = ipHostInfo.AddressList[1];
            IPEndPoint localEndPoint = new IPEndPoint(_ipAddress, 11000);
            Console.WriteLine(_ipAddress.ToString());

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and 
            // listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.
                while (true)
                {
                    Console.WriteLine(@"Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.
                    Handler = listener.Accept();
                    data = null;

                    // An incoming connection needs to be processed.
                    while (true)
                    {
                        bytes = new byte[1024];
                        int bytesRec = Handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>", StringComparison.Ordinal) > -1)
                        {
                            State.UpdateSetState(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                            break;
                        }
                    }
                    // Show the data on the console.
                    Console.WriteLine(@"Text received : {0}", data);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


            Handler.Shutdown(SocketShutdown.Both);
            Handler.Close();

        }
    }
}
