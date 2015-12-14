using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocTacToe
{
    /// <summary>
    /// modified socket to send states and wait for a state reply from server
    /// </summary>
    public static class SynchronousSocketClient
    {
        //handler is a public static object to conrol client end socket
        public static Socket Sender;

        /// <summary>
        /// Socket for the client to pass states, also calls back to the form and updates GUI
        /// </summary>
        /// <param name="ip">IPAddress</param>
        /// <param name="port">Int Port</param>
        /// <param name="updateFormCallback">Run Update on Form1</param>
        public static void StartClient(IPAddress ip, int port, SocTacToe.Del updateFormCallback)
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];

            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                IPEndPoint remoteEp = new IPEndPoint(ip, port);

                // Create a TCP/IP  socket.
                Sender = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    Sender.Connect(remoteEp);

                    Console.WriteLine(@"Socket connected to {0}",
                        Sender.RemoteEndPoint);

                    // Encode the data string into a byte array.
                    byte[] msg = Encoding.ASCII.GetBytes(State.GetStateString());

                    // Send the state through the socket.
                    Sender.Send(msg);
                    updateFormCallback();
                    // Receive the response from the remote device.
                    int bytesRec = Sender.Receive(bytes);
                    Console.WriteLine(@"Echoed test = {0}",
                        Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    //Update state from response
                    State.UpdateSetState(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    Console.WriteLine(@"recived response: " + Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    updateFormCallback();
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(@"ArgumentNullException : {0}", ane);
                    ShutdownConnection();
                }
                catch (SocketException se)
                {
                    Console.WriteLine(@"SocketException : {0}", se);
                    ShutdownConnection();
                }
                catch (Exception e)
                {
                    Console.WriteLine(@"Unexpected exception : {0}", e);
                    ShutdownConnection();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ShutdownConnection();
            }

        }

        /// <summary>
        /// close listener socket
        /// </summary>
        public static void ShutdownConnection()
        {
            if (Sender != null)
            {
                Sender.Close();
            }
        }
    }
}
