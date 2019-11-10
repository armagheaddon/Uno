using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Taki_lala
{
    class Card
    {
        private string value { get; set; }
        private string color { get; set; }

        public Card(string value, string color)
        {
            this.value = value;
            this.color = color;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
