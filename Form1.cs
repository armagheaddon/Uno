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
                Dictionary<string, string> openWith = new Dictionary<string, string>();
                hand = game[i][6];
                int x_start = 550 - 77 * hand.Length / 2;
                int x = x_start;
                int y_start = 610;

                for ( int j = 0; j < hand.Length; j++)
                {
                    if (j == 10)
                    {
                        x_start = 550 - 77 * hand.Length / 2;
                        y_start = y_start - 100;
                    }
                    
                    var item = hand[j].First();
                    string value = item.Key;//value
                    string key = item.Value;//color
                    string pic = value + key;
                    int counter = 0;
                    x = x + 77 * j;



                    for (int k = 0; k < pictures.Length; k++)
                    {     
                            if (pic== pictures[k].Name)
                        {

                            pictures[k].Location = new System.Drawing.Point(x, y_start);
                            this.Controls.Add(pictures[k]);
                        }
                    }
                    
                }

            }
            
        }

        public object hand { get; }
    }
}
