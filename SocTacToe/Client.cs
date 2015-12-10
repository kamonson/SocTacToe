﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocTacToe
{
    public static class SynchronousSocketClient
    {
        //handler is a public static object to conrol client end socket
        public static Socket Sender;
        public static void StartClient(IPAddress ip, int port)
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

                    // Send the data through the socket.
                    Sender.Send(msg);

                    // Receive the response from the remote device.
                    int bytesRec = Sender.Receive(bytes);
                    Console.WriteLine(@"Echoed test = {0}",
                        Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    State.UpdateSetState(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(@"ArgumentNullException : {0}", ane);
                    Sender.Shutdown(SocketShutdown.Both);
                    Sender.Close();
                }
                catch (SocketException se)
                {
                    Console.WriteLine(@"SocketException : {0}", se);
                    Sender.Shutdown(SocketShutdown.Both);
                    Sender.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(@"Unexpected exception : {0}", e);
                    Sender.Shutdown(SocketShutdown.Both);
                    Sender.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Sender.Shutdown(SocketShutdown.Both);
                Sender.Close();
            }
        }
    }
}
