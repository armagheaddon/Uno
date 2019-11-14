using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Taki_lala
{
    public partial class Form1 : Form
    {
        private int _ticks;
        private bool next= false;
        public Form1()
        {
            InitializeComponent();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("C\nD", "Black");
            dict.Add("1", "Green");
            dict.Add("2", "Yellow");
            dict.Add("3", "Red");
            dict.Add("4", "Blue");
            dict.Add("5", "Green");
            dict.Add("6", "Yellow");
            dict.Add("7", "Green");
            dict.Add("8", "Yellow");
            dict.Add("9", "Red");
            dict.Add("T", "Blue");
            Label[] cards = new Label[28];
            cards[0] = label1;
            cards[1] = label2;
            cards[2] = label3;
            cards[3] = label4;
            cards[4] = label5;
            cards[5] = label6;
            cards[6] = label7;
            cards[7] = label8;
            cards[8] = label9;
            cards[9] = label10;
            cards[10] = label11;
            cards[11] = label12;
            cards[12] = label13;
            cards[13] = label14;
            cards[14] = label15;
            cards[15] = label16;
            cards[16] = label17;
            cards[17] = label18;
            cards[18] = label19;
            cards[19] = label20;
            cards[20] = label21;
            cards[21] = label22;
            cards[22] = label23;
            cards[23] = label24;
            cards[24] = label25;
            cards[25] = label26;
            cards[26] = label27;
            cards[27] = label28;

            next = false;
            timer1.Start();

            foreach (KeyValuePair<string, string> item in dict)
            {
                for (int i = 4; i < cards.Length; i++)
                {
                    if (cards[i].Text == "")
                    {
                        cards[i].Text = item.Key;
                        cards[i].BackColor = Color.White;
                        if (item.Value == "Red")
                            cards[i].ForeColor = Color.Red;
                        if (item.Value == "Blue")
                            cards[i].ForeColor = Color.Blue;
                        if (item.Value == "Yellow")
                            cards[i].ForeColor = Color.Yellow;
                        if (item.Value == "Green")
                            cards[i].ForeColor = Color.Green;
                        break;
                    }
                }

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("wfwe"); 
            _ticks++;
            if (_ticks == 4)
            {
                Console.WriteLine("wfwe");
                next = true;
                timer1.Stop();
            }
        }
    }
}
