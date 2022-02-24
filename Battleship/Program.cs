using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

using Battleship.Game;

namespace Battleship
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new BattleshipGame();

            game.Run();
            
            Console.ReadKey();
        }
    }
}
