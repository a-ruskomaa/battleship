using System.Linq;
using System.Collections.Generic;

namespace Battleship.Game
{
    /// <summary>
    ///   Represents actions done during a game of battleship
    /// </summary>
    public class GameActions
    {
        /// <summary>
        ///   Coordinates of board pieces
        /// </summary>
        public IEnumerable<Coordinate> Pieces { get; }
        /// <summary>
        ///   Coordinates of fired shots
        /// </summary>
        public  IEnumerable<Coordinate> ShotsFired { get; }

        public GameActions(string[][] pieces, string[] shotsFired)
        {
            Pieces = pieces.SelectMany(row => row.Select(cell => Coordinate.ParseFromString(cell)));

            ShotsFired = shotsFired.Select((shot, index) => !string.IsNullOrEmpty(shot) ? new Coordinate(index / 10, index % 10) : null).Where(coordinate => coordinate is not null);
        }

        public static GameActions FromJson(string filePath)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GameActions>(System.IO.File.ReadAllText(filePath));
        }
    }
}