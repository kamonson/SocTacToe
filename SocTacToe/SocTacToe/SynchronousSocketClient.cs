using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocTacToe
{
    public class SynchronousSocketClient
    {
        public static void StartClient()
        {
            // Data buffer for incoming data.
            var bytes = new byte[1024];

            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // This example uses port 11000 on the local computer.
                var ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                var ipAddress = ipHostInfo.AddressList[3];
                //ipAddress = {10.28.34.71}
                var remoteEp = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.
                var sender = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    sender.Connect(remoteEp);

                    Console.WriteLine(@"Socket connected to {0}",
                        sender.RemoteEndPoint);

                    // Encode the data string into a byte array.
                    var msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

                    // Send the data through the socket.
                    sender.Send(msg);

                    // Receive the response from the remote device.
                    var bytesRec = sender.Receive(bytes);
                    Console.WriteLine(@"Echoed test = {0}",
                        Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    // Release the socket.
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(@"ArgumentNullException : {0}", ane);
                }
                catch (SocketException se)
                {
                    Console.WriteLine(@"SocketException : {0}", se);
                }
                catch (Exception e)
                {
                    Console.WriteLine(@"Unexpected exception : {0}", e);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}