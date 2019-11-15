using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Threading;

namespace Taki_lala
{
    class Client
    {

        private Socket client;
        private byte[] bytes = new byte[1024];  // Data buffer for incoming data. 
        private Queue<Dictionary<string, dynamic>> incoming = new Queue<Dictionary<string, dynamic>>();
        private Thread receiveLoop;
        public Client()
        {
            try
            {
                // Establish the remote endpoint for the socket.  
                IPAddress ipAddress = IPAddress.Parse("10.0.0.13");       // Server IP
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 50000); // Server address

                // Create a TCP/IP  socket.  
                client = new Socket(SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                client.Connect(remoteEP);
                Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());
                receiveLoop = new Thread(new ThreadStart(ReceiveLoop));

                Console.WriteLine("Sending password");
                string password = "1234";
                Send(password);

                var data = GetIncoming();
                if (data["command"] != "Login Successful")
                {
                    throw new System.ArgumentException("Incorrect Password " + data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                CloseSocket();
                Environment.Exit(-1);
            }
        }

        public Dictionary<string, dynamic> GetIncoming()
        {
            while(incoming.Count() == 0)
            {
                DoNothing();
            }
            return incoming.Dequeue();
        }

        public void ReceiveLoop()
        {
            string data;
            while (client.Connected)
            {
                data = ReceiveToString();
                if (data == "")
                    break;
                else
                    TakeAPart(data);
            }
            incoming.Enqueue(null);
            CloseSocket();
        }

        public void TakeAPart(string newmsg)
        {
            int length;
            string single;
            Dictionary<string, dynamic> dict;
            while (newmsg != "")
            {
                Console.WriteLine(newmsg.Substring(0, 4));
                length = int.Parse(newmsg.Substring(0, 4));
                single = newmsg.Substring(4, length);
                Console.WriteLine(single);
                dict = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(single);
                incoming.Enqueue(dict);
                newmsg = newmsg.Substring(length + 4);
            }
        }

        public int ReceiveID()
        {
            Dictionary<string, dynamic> data = GetIncoming();
            string stringdata = data["command"];
            return stringdata[stringdata.Length - 1];
        }

        public string ReceiveToString()
        {
            try
            {
                int bytesRec = client.Receive(bytes);
                string received = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                return received;
            }
            catch (Exception e)
            {
                return "";
            }
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

        public void Send(Dictionary<string, dynamic> card, string order)
        {
            Dictionary<string, string> turnDict = new Dictionary<string, string>();
            turnDict.Add("order", order);
            turnDict.Add("card", JsonConvert.SerializeObject(card));

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

        public void DoNothing()
        {

        }
    }
}
