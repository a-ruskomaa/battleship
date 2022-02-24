using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

using Battleship.Extensions;

namespace Battleship.Game
{
    public class BattleshipGame
    {
        public string Run()
        {
            var board = new Board();

            var gameActions = GameActions.FromJson("battlezone.json");

            // DEPLOY ZE ARMAAADA!
            foreach (var o in gameActions.Pieces)
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
                if (!string.IsNullOrEmpty(gameActions.ShotsFired[i].ToString()))
                    Board.SetValue(board, linearray[i.GetLinearrayNumber()] + "" + (i % 10 + 1), 4); //SHOT FIRED!
            }

            // SINKING THE BISHMARK!
            foreach (var o in gameActions.Pieces) // VAC ENABLED!
            {
                foreach (var o2 in o)
                {
                    var PaatinPaikka = Board.GetValue(board, o2);

                    if (PaatinPaikka != 1 && PaatinPaikka == 4)
                        Board.SetValue(board, o2, 9); // OSU JA UPPOS!
                }
            }

            return board.GetBoardState();
        }
    }
}
