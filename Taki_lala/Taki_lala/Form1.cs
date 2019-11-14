﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taki_lala
{
    public partial class Form1 : Form
    {
        public Form1(dynamic history)
        {
            InitializeComponent();
            Console.WriteLine(onered.Name);
            Console.WriteLine(threered.Name);
            Console.WriteLine(twored.Name);

            PictureBox[] pictures = new PictureBox[58];
            pictures[0] = oneblue;
            pictures[1] = twoblue;
            pictures[2] = threeblue;
            pictures[3] = fourblue;
            pictures[4] = fiveblue;
            pictures[5] = sixblue;
            pictures[6] = sevenblue;
            pictures[7] = eightblue;
            pictures[8] = nineblue;
            pictures[9] = plusblue;
            pictures[10] = plustwoblue;
            pictures[11] = takiblue;
            pictures[12] = stopblue;
            pictures[13] = chdirblue;
            pictures[14] = onered;
            pictures[15] = twored;
            pictures[16] = threered;
            pictures[17] = fourred;
            pictures[18] = fivered;
            pictures[19] = sixred;
            pictures[20] = sevenred;
            pictures[21] = eightred;
            pictures[22] = ninered;
            pictures[23] = plusred;
            pictures[24] = plustwored;
            pictures[25] = takired;
            pictures[26] = stopred;
            pictures[27] = chadirred;
            pictures[28] = oneyellow;
            pictures[29] = twoyellow;
            pictures[30] = fouryellow;
            pictures[31] = fiveyellow;
            pictures[32] = sixyellow;
            pictures[33] = sevenyellow;
            pictures[34] = eightyellow;
            pictures[35] = nineyellow;
            pictures[36] = plusyellow;
            pictures[37] = plustwoyellow;
            pictures[38] = takiyellow;
            pictures[39] = stopyellow;
            pictures[40] = chadiryellow;
            pictures[41] = onegreen;
            pictures[42] = twogreen;
            pictures[43] = threegreen;
            pictures[44] = fourgreen;
            pictures[45] = fivegreen;
            pictures[46] = sixgreen;
            pictures[47] = sevengreen;
            pictures[48] = eightgreen;
            pictures[49] = ninegreen;
            pictures[50] = plusgreen;
            pictures[51] = plustwogreen;
            pictures[52] = takigreen;
            pictures[53] = stopgreen;
            pictures[54] = chadirgreen;
            pictures[55] = threeyellow;
            pictures[56] = chacolall;
            pictures[57] = takiall;

            //check if u can print all cards
            //for (int h = 0; h < pictures.Length; h++)
            //    this.Controls.Add(pictures[h]);
            /*
            List<Dictionary<string, dynamic>> game = new List<Dictionary<string, dynamic>>();
            Dictionary<string, dynamic> dict1 = new Dictionary<string, dynamic>();
            dict1.Add("one", "red");
            Dictionary<string, dynamic> dict2 = new Dictionary<string, dynamic>();
            dict2.Add("two", "yellow");
            Dictionary<string, dynamic> dict4 = new Dictionary<string, dynamic>();
            dict4.Add("stop", "yellow");
            Dictionary<string, dynamic> dict5 = new Dictionary<string, dynamic>();
            dict5.Add("plustwo", "blue");
            Dictionary<string, dynamic> dict3 = new Dictionary<string, dynamic>();
            dict3.Add("taki", "red");
            Dictionary<string, dynamic> dict6 = new Dictionary<string, dynamic>();
            dict6.Add("two", "blue");
            Dictionary<string, dynamic> dict7 = new Dictionary<string, dynamic>();
            dict7.Add("stop", "red");
            Dictionary<string, dynamic> dict8 = new Dictionary<string, dynamic>();
            dict8.Add("chacol", "all");
            Dictionary<string, dynamic> dict9 = new Dictionary<string, dynamic>();
            dict9.Add("one", "green");
            Dictionary<string, dynamic> dict10 = new Dictionary<string, dynamic>();
            dict10.Add("two", "red");
            Dictionary<string, dynamic> dict11 = new Dictionary<string, dynamic>();
            dict11.Add("three", "green");
            Dictionary<string, dynamic> dict12 = new Dictionary<string, dynamic>();
            dict12.Add("eight", "red");
            List<Dictionary<string, dynamic>> hand1 = new List<Dictionary<string, dynamic>>();
            hand1.Add(dict2);
            hand1.Add(dict3);
            hand1.Add(dict4);
            hand1.Add(dict5);
            hand1.Add(dict6);
            hand1.Add(dict7);
            hand1.Add(dict8);
            hand1.Add(dict9);
            hand1.Add(dict10);
            List<int> otherss = new List<int>();

            otherss.Add(0);
            otherss.Add(3);
            otherss.Add(4);
            otherss.Add(7);
            Dictionary<string, dynamic> dict = new Dictionary<string, dynamic>()
            {
                {"pile",dict1 },
                {"turn", 2 },
                {"turn_dir",1 },
                {"pile_color","red" },
                {"others", otherss },
                {"players", otherss },
                {"hand", hand1 },
                {"winners",otherss }
            };

            game.Add(dict);
            */


            foreach (Dictionary<string, dynamic> turn in history)
            {
                for (int h = 0; h < pictures.Length; h++)
                {
                    this.Controls.Remove(pictures[h]);
                }

                Dictionary<string, dynamic> pileC = new Dictionary<string, dynamic>();
                List<KeyValuePair<string, dynamic>> hand = new List<KeyValuePair<string, dynamic>>(); //  guess it works

                // pile card
                pileC = turn["pile"];
                var c = pileC.First();
                string str;
                string cur_pile = c.Key + c.Value;
                Console.WriteLine(cur_pile);
                if (c.Key == "1")
                    cur_pile = "one" + c.Value;
                if (c.Key == "2")
                    cur_pile = "two" + c.Value;
                if (c.Key == "3")
                    cur_pile = "three" + c.Value;
                if (c.Key == "4")
                    cur_pile = "four" + c.Value;
                if (c.Key == "5")
                    cur_pile = "five" + c.Value;
                if (c.Key == "6")
                    cur_pile = "six" + c.Value;
                if (c.Key == "7")
                    cur_pile = "seven" + c.Value;
                if (c.Key == "8")
                    cur_pile = "eight" + c.Value;
                if (c.Key == "9")
                    cur_pile = "nine" + c.Value;


                //the turn dir
                int turn_dir = turn["turn_dir"];

                //others cards
                List<int> others = new List<int>();
                others = turn["others"];
                first_player.Text = others[1].ToString();
                second_player.Text = others[2].ToString();
                third_player.Text = others[3].ToString();
                if (turn_dir == 1)
                {
                    this.Controls.Remove(right);
                    this.Controls.Add(left);
                }
                if (turn_dir == -1)
                {
                    this.Controls.Remove(left);
                    this.Controls.Add(right);
                }



                // our cards
                List<Dictionary<string, dynamic>> OurHand = turn["hand"];



                //550- the middle of the x lenght, 610- almost in the botttom of the screen
                // we are taking from the middle few steps backwards in order to have half of the cards before the middle 
                // and the other half after....

                int hand_len = OurHand.Count;
                Console.WriteLine(hand_len);
                int x_start = 450 - 100 * hand_len / 2;
                int x = x_start;
                int y_start = 510;

                for (int j = 0; j < hand_len; j++)
                {
                    if (j == 8)
                    {
                        x = 450 - 100 * hand_len / 2;
                        Console.WriteLine(x_start);
                        y_start = y_start - 155;
                        Console.WriteLine(y_start);
                    }

                    var item = OurHand[j].First();
                    string value = item.Key;//value
                    string key = item.Value;//color
                    //matching strings

                    string pic = value + key;/// needed to asjust to our words...
                    if (item.Key == "1")
                        pic = "one" + key;
                    if (item.Key == "2")
                        pic = "two" + key;
                    if (item.Key == "3")
                        pic = "three" + key;
                    if (item.Key == "4")
                        pic = "four" + key;
                    if (item.Key == "5")
                        pic = "five" + key;
                    if (item.Key == "6")
                        pic = "six" + key;
                    if (item.Key == "7")
                        pic = "seven" + key;
                    if (item.Key == "8")
                        pic = "eight" + key;
                    if (item.Key == "9")
                        pic = "nine" + key;
                    //int counter = 0;
                    x = x + 105;



                    for (int k = 0; k < pictures.Length; k++)
                    {

                        // finding the needed picture
                        if (pic == pictures[k].Name)
                        {
                            pictures[k].Location = new System.Drawing.Point(x, y_start);
                            this.Controls.Add(pictures[k]);
                        }

                        //pile card
                        if (cur_pile == pictures[k].Name)
                        {
                            pictures[k].Location = new System.Drawing.Point(525, 140);
                            this.Controls.Add(pictures[k]);
                        }
                    }

                }

            }

        }



        public object hand { get; }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
