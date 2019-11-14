using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Windows.Forms;


namespace Taki_lala
{
    class Game
    {
        Client client;

        private ScriptEngine engine;
        private ScriptScope scope;
        private ScriptSource source;
        private dynamic calcTurn;

        private int ID;
        private List<Dictionary<string, dynamic>> history;
        private Client client;
        public Game ()
        {
            client = new Client();
            this.ID = client.ReceiveID();
            Console.WriteLine("our id is" + ID);

            this.history = new List<Dictionary<string, dynamic>>();

            client = new Client();
            IronPythonSetUp();
            

        }
       
        public void IronPythonSetUp()
        {
            engine = Python.CreateEngine();     // Extract Python language engine from their grasp
            scope = engine.CreateScope();       // Introduce Python namespace (scope)
            source = engine.CreateScriptSourceFromFile("C:/Users/dooda/OneDrive/שולחן העבודה/Uno/bot_taki.py"); // Load the script. TODO: ADD PATH
            source.Execute(scope);
            calcTurn = scope.GetVariable("turn");
            //scope.SetVariable("params", d);         // This will be the name of the dictionary in python script
        }

        public void run()
        {

        }

        [STAThread]
        public static void RunGraphics()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
