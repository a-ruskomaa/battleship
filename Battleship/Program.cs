using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

using PelilautaPahkina.Game;

namespace PelilautaPahkina
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new Battleship();

            game.Run();
        }
    }
}
