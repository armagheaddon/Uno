using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace Taki_lala
{
    class Game
    {
        private Client client;

        private ScriptEngine engine;
        private ScriptScope scope;
        private ScriptSource source;
        private dynamic calcTurn;

        private int myID;
        private List<Dictionary<string, dynamic>> history;

        public Game ()
        {
            client = new Client();
            Console.WriteLine("connected");
            this.myID = client.ReceiveID();
            Console.WriteLine("our id is " + myID);
            Console.WriteLine("id type - " + myID.GetType());

            this.history = new List<Dictionary<string, dynamic>>();
            IronPythonSetUp();
            runGameLoop();

        }
       
        public void IronPythonSetUp()
        {
            Console.WriteLine("iron python setup");
            engine = Python.CreateEngine();     // Extract Python language engine from their grasp
            scope = engine.CreateScope();       // Introduce Python namespace (scope)
            source = engine.CreateScriptSourceFromFile("C:/Users/dooda/OneDrive/שולחן העבודה/Uno/bot_taki.py"); // Load the script. TODO: ADD PATH
            source.Execute(scope);
            calcTurn = scope.GetVariable("turn");
            //scope.SetVariable("params", d);         // This will be the name of the dictionary in python script
            Console.WriteLine("finished setup");
        }

        public void runGameLoop()
        {
            Console.WriteLine("GAME LOOP STARTED");
            List<dynamic> myAction;
            List<dynamic> vars;
            var gameState = client.GetIncoming();

            while(gameState != null)
            {
                history.Add(gameState);
                Console.WriteLine(gameState["turn"] + "'s turn");
                if (gameState["turn"] == myID)
                {
                    Console.WriteLine("my turn!!!!!!!!!!!");
                    vars = calcVars(gameState);
                    myAction = calcTurn(vars[0], vars[1], vars[2], vars[3], vars[4], vars[5]);
                    Console.WriteLine("Action - "+myAction);
                    for (int i = 0; i < myAction[0].Count(); i++)
                    {
                        if(i == myAction[0].Count() - 1)
                        {
                            if(myAction[1] == "draw card")
                            {
                                var card = new Dictionary<string, dynamic>();
                                card.Add("color", "");
                                card.Add("card", "");
                                client.Send(card, myAction[1]);
                            }
                            else
                                client.Send(myAction[0][i], myAction[1]);
                        }
                        else
                            client.Send(myAction[0][i], "");

                        gameState = client.GetIncoming();
                        history.Add(gameState);
                    }
                    Console.WriteLine("");
                }
                gameState = client.GetIncoming();
            }
            RunGraphics();
        }

        public List<dynamic> calcVars(dynamic gameState)
        {
            List<dynamic> vars = new List<dynamic>();
            int myIndex;

            vars.Add(gameState["hand"]);

            gameState["players"] = gameState["players"].ToObject<List<int>>();
            myIndex = gameState["players"].IndexOf(myID);

            vars.Add(amountOfCards(myIndex, gameState["others"], 1, gameState["turn_dir"]));
            vars.Add(amountOfCards(myIndex, gameState["others"], 1, -gameState["turn_dir"]));
            vars.Add(gameState["pile"]);
            vars.Add(gameState["pile_color"]);
            var lastTurn = history[history.Count - 2];
            vars.Add(amountOfCards(lastTurn["turn"], lastTurn["others"], 1, -lastTurn["turn_dir"]));
            return vars;
        }

        public int amountOfCards(dynamic myIndex, dynamic others, int distance, dynamic direction)
        {
            var neededIndex = myIndex;
            for (int i = distance; i > 0; i--)
            {
                if (neededIndex == others.Count - 1 && direction > 0)
                    neededIndex = 0;
                else
                {
                    if (neededIndex == 0 && direction < 0)
                        neededIndex = others.Count - 1;
                    else
                        neededIndex += direction;
                }
            }
            return others[Convert.ToInt32(neededIndex)];
        }

        [STAThread]
        public void RunGraphics()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(history));
        }
    }
}
