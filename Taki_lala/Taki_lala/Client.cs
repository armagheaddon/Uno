using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace Taki_lala
{
    class Client
    {

        private Socket client;
        private byte[] bytes = new byte[1024];  // Data buffer for incoming data. 
        private Queue<Dictionary<string, dynamic>> msg = new Queue<Dictionary<string, dynamic>>();
        public Client()
        {
            try
            {
                // Establish the remote endpoint for the socket.  
                IPAddress ipAddress = IPAddress.Parse("192.168.1.146");       // Server IP
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 50000); // Server address

                // Create a TCP/IP  socket.  
                client = new Socket(SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                client.Connect(remoteEP);
                Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());
                Console.WriteLine("Sending password");
                string password = "1234";
                Send(password);
                var data = Receive();
                if (data["command"] == "Login Successful")
                {
                    int ID = ReceiveID();
                    Console.WriteLine("our id is"+ ID);
                }
                else
                    throw new System.ArgumentException("Incorrect Password "+data);
                //TODO: add receive.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                CloseSocket();
                Environment.Exit(-1);
            }
        }

        public void TakeAPart (string newmsg)
        {
            int length = (int)newmsg[0] * 1000 + (int)newmsg[1] * 100 + (int)newmsg[2] * 10 + (int)newmsg[3] - 1;
            newmsg.Substring(0, length);
        }
        public int ReceiveID()
        {
            Dictionary<string, dynamic> data = Receive();
            Console.WriteLine(data);
            string stringdata = data["command"];
            return stringdata[stringdata.Length - 1];
        }
        public string ReceiveToString()
        {
            int bytesRec = client.Receive(bytes);
            string received = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            return received;
        }
        public Dictionary<string, dynamic> Receive()
        {
            // Receive the game's state from the server.  
            int bytesRec = client.Receive(bytes);
            string received = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(received);
        }

        public void Send(string str)
        {
            // Encode the data string into a byte array.  
            byte[] msg = Encoding.ASCII.GetBytes(str);

            // Send the data through the socket.  
            client.Send(msg);
        }

        public void Send(Card card, string order)
        {
            Dictionary<string, string> turnDict = new Dictionary<string, string>();
            turnDict.Add("order", order);
            turnDict.Add("card", card.ToJson());

            // Encode the data string into a byte array.  
            byte[] msg = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(turnDict));

            // Send the data through the socket.  
            client.Send(msg);
        }

        public void CloseSocket()
        {
            // Release the socket.  
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }
}
