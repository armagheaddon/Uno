using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taki_lala
{
    class Game
    {
        private int ID;
        private List<Dictionary<string, dynamic>> history;
        private Client client;
        public Game ()
        {
            client = new Client();
            this.ID = client.ReceiveID();
            Console.WriteLine("our id is" + ID);

            this.history = new List<Dictionary<string, dynamic>>();
        }
       
    }
}
