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
        public Game (int ID)
        {
            this.ID = ID;
            this.history = new List<Dictionary<string, dynamic>>();
        }
       
    }
}
