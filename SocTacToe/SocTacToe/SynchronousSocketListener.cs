using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocTacToe
{
    public class SynchronousSocketListener
    {

        // Incoming data from the client.
        private static string _data;

        public static void StartListening()
        {
            // _data buffer for incoming data.
            byte[] bytes;

            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
            var ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddress = ipHostInfo.AddressList[1];
            var localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.
            var listener = new Socket(AddressFamily.InterNetwork,
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
                    var handler = listener.Accept();
                    _data = null;

                    // An incoming connection needs to be processed.
                    while (true)
                    {
                        bytes = new byte[1024];
                        var bytesRec = handler.Receive(bytes);
                        _data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (_data.IndexOf("<EOF>", StringComparison.Ordinal) > -1)
                        {
                            break;
                        }
                    }

                    // Show the data on the console.
                    Console.WriteLine(@"Text received : {0}", _data);

                    // Echo the data back to the client.
                    var msg = Encoding.ASCII.GetBytes(_data);

                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine(@"Press ENTER to continue...");
            Console.Read();

        }
    }
}
