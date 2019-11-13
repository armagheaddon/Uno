using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taki_current
{
    public partial class Form1 : Form
    {
        public Form1()
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
            pictures[56] = chacol;
            pictures[57] = taki;




            for (int i = 0; i < game.Length; i++)
            {
                for (int h = 0; h < pictures.Length; h++)
                {
                    this.Controls.Remove(pictures[h]);
                }

                Dictionary<string, string> pileC = new Dictionary<string, string>();
                List<KeyValuePair<string, string >> hand = new List<KeyValuePair<string, string>>(); //  guess it works

                // pile card
                pileC = game[i][0];
                var c = pileC.First();
                string cur_pile = c.Value + c.Key;

                //the turn dir
                int turn_dir = game[i][2];

                //others cards
                int[] others = new int[3];
                others = game[i][4];
                first_player.Text = others[0].ToString();
                second_player.Text = others[1].ToString();
                third_player.Text = others[2].ToString();

                // our cards
                hand = game[i][6];
               


                //550- the middle of the x lenght, 610- almost in the botttom of the screen
                // we are taking from the middle few steps backwards in order to have half of the cards before the middle 
                // and the other half after....

                int hand_len = hand.Length;
                int x_start = 550 - 100 * hand_len / 2;
                int x = x_start;
                int y_start = 610;

                for ( int j = 0; j < hand_len; j++)
                {
                    if (j == 9)
                    {
                        x_start = 550 - 100 * hand_len / 2;
                        y_start = y_start - 170;
                    }
                    
                    var item = hand[j].First();
                    string value = item.Key;//value
                    string key = item.Value;//color
                    string pic = value + key;/// needed to asjust to our words...
                    int counter = 0;
                    x = x + 110 * j;



                    for (int k = 0; k < pictures.Length; k++)
                    {   
                        
                            // finding the needed picture
                            if (pic== pictures[k].Name)
                            {
                                pictures[k].Location = new System.Drawing.Point(x, y_start);
                                this.Controls.Add(pictures[k]);
                            }

                            //pile card
                            if (cur_pile == pictures[k].Name)
                            {
                                pictures[k].Location = new System.Drawing.Point(83, 31);
                                this.Controls.Add(pictures[k]);
                            }
                    }
                    
                }

            }
            
        }

        public object hand { get; }
    }
}
