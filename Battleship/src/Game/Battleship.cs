using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

using PelilautaPahkina.Game;
using PelilautaPahkina.Extensions;

namespace PelilautaPahkina.Game
{
    public class Battleship
    {
        public void Run()
        {
            var board = new Board();

            dynamic bäm = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(System.IO.File.ReadAllText("battlezone.json"));

            // DEPLOY ZE ARMAAADA!
            foreach (var o in bäm.pieces)
            {
                foreach (var o2 in o)
                {
                    Board.SetValue(board, o2, 1);
                }
            }

            var linearray = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };

            // FIRE ZE CANNONS!
            for (int i = 0; i < 100; i++)
            {
                if (!string.IsNullOrEmpty(bäm.shotsFired[i].ToString()))
                    Board.SetValue(board, linearray[i.GetLinearrayNumber()] + "" + (i % 10 + 1), 4); //SHOT FIRED!
            }

            // SINKING THE BISHMARK!
            foreach (var o in bäm.pieces) // VAC ENABLED!
            {
                foreach (var o2 in o)
                {
                    var PaatinPaikka = Board.GetValue(board, o2);

                    if (PaatinPaikka != 1 && PaatinPaikka == 4)
                        Board.SetValue(board, o2, 9); // OSU JA UPPOS!
                }
            }

            board.DrawBoard();
            Console.ReadKey();
        }
    }
}
