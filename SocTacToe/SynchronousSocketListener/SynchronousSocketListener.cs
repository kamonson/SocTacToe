﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SynchronousSocketListener
{
    public static class SynchronousSocketListener
    {

        // Incoming data from the client.
        private static string _data;

        public static void StartServer()
        {
           Form1 form = new Form1();
            //form.Show();
            form.AppendText("Let's Get Started!\n");
            StartListening(ref form);
    }

        private static void StartListening(ref Form1 serverForm)
        {
            // _data buffer for incoming data.
            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
            var ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddress = ipHostInfo.AddressList[3];
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
                    serverForm.AppendText("Waiting for a connection...");
                    serverForm.ShowDialog();
                    // Program is suspended while waiting for an incoming connection.
                    var handler = listener.Accept();
                    _data = null;

                    // An incoming connection needs to be processed.
                    while (true)
                    {
                        var bytes = new byte[1024];
                        var bytesRec = handler.Receive(bytes);
                        _data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (_data.IndexOf("<EOF>", StringComparison.Ordinal) > -1)
                        {
                            break;
                        }
                    }

                    // Show the data on the console.
                    Console.WriteLine(@"Text received : {0}", _data);
                    serverForm.AppendText("\nText received : " + _data);

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
                serverForm.AppendText ("\n" + e);
            }

            Console.WriteLine(@"
Press ENTER to continue...");
            Console.Read();

        }
    }
}