using System;
using System.Text;

using Battleship.Game;

namespace Battleship
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new BattleshipGame();

            try 
            {
                var result = game.Run();
                System.Console.WriteLine(CreateSummary(result));
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("The game failed to run. Cause: {0}. Message: \"{1}\"", e.GetType(), e.Message);
            }

            Console.ReadKey();
        }

        private static string CreateSummary(string endState)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Post Game Analysis :");
            sb.AppendLine("");
            sb.AppendLine(endState);
            sb.AppendFormat("");
            sb.AppendLine("* = Boatpiece, o = missed shot, X = DIRECT HIT!");

            return sb.ToString();
        }
    }
}
