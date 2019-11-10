using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Taki_lala
{
    class Client
    {

        private Socket client;
        private byte[] bytes = new byte[1024];  // Data buffer for incoming data. 

        public Client()
        {
            try
            {
                // Establish the remote endpoint for the socket.  
                IPAddress ipAddress = IPAddress.Parse("0.0.0.0");       // Server IP
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000); // Server address

                // Create a TCP/IP  socket.  
                Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                client.Connect(remoteEP);
                Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                CloseSocket();
                Environment.Exit(0);
            }
        }

        public string Receive()
        {
            // Receive from the server.  
            int bytesRec = client.Receive(bytes);
            return Encoding.ASCII.GetString(bytes, 0, bytesRec);
        }

        public void Send(string str)
        {
            // Encode the data string into a byte array.  
            byte[] msg = Encoding.ASCII.GetBytes(str);

            // Send the data through the socket.  
            int bytesSent = client.Send(msg);
        }

        public void CloseSocket()
        {
            // Release the socket.  
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }
}
