using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerSocTacToe
{
    /// <summary>
    /// Socket for Server, listen and a call back to update Form function is handled here, but response is processed on the form.
    /// </summary>
    public static class SynchronousSocketListener
    {
        private static IPAddress _ipAddress;

        /// <summary>
        /// Get the Server IP Address
        /// </summary>
        /// <returns></returns>
        public static string GetIpString()
        {
            if (_ipAddress != null) return _ipAddress.ToString();
            return string.Empty;
        }

        //Handler is a public static object to conrol server end socket
        public static Socket Handler;

        // Incoming data from the client.
        public static string data;

        /// <summary>
        /// Sets IP and Port for game use, then listes for client connection, updates Form GUI with callback. Response is handled in Form turn Managment
        /// </summary>
        /// <param name="updateFormCallback">Run Update on form 1</param>
        public static void StartListening(SocTacToe.Del updateFormCallback)
        {
            // Data buffer for incoming data.
            byte[] bytes;

            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            //1 for school IP and 4 for home
            _ipAddress = ipHostInfo.AddressList[1];
            IPEndPoint localEndPoint = new IPEndPoint(_ipAddress, 11000);
            Console.WriteLine(_ipAddress.ToString());
            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            // Bind the socket to the local endpoint and 
            // listen for incoming connections.
            updateFormCallback();
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
                            //update the form GUI to reflect recived state then wait for user input
                            State.UpdateSetState(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                            updateFormCallback();
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
        }

        /// <summary>
        /// Shut down the socket
        /// </summary>
        public static void ShutdownConnection()
        {
            if (Handler != null)
            {
                Handler.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);
                Handler.Disconnect(false);
                Handler.Shutdown(SocketShutdown.Both);
                Handler.Close();
            }
        }
    }
}
