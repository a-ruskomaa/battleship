using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Text;

using Battleship.Game;

namespace Battleship
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new BattleshipGame();

            var result = game.Run();

            PrintSummary(result);
            
            Console.ReadKey();
        }

        public static void PrintSummary(string endState)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Post Game Analysis :");
            sb.AppendLine("");
            sb.AppendLine(endState);
            sb.AppendFormat("");
            sb.AppendLine("* = Boatpiece, o = missed shot, X = DIRECT HIT!");

            Console.Out.WriteLine(sb.ToString());
        }
    }
}
