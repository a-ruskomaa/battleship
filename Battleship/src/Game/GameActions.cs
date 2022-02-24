using System.Linq;

namespace Battleship.Game
{
    /// <summary>
    ///   Represents actions done during a game of battleship
    /// </summary>
    public class GameActions
    {
        /// <summary>
        ///   Starting setup of board pieces
        /// </summary>
        public string[][] Pieces { get; }
        /// <summary>
        ///   Array of shots fired
        /// </summary>
        public string[] ShotsFired { get; }

        public GameActions(string[][] pieces, string[] shotsFired)
        {
            Pieces = pieces;
            ShotsFired = shotsFired;
        }

        public static GameActions FromJson(string filePath)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GameActions>(System.IO.File.ReadAllText(filePath));
        }
    }
}