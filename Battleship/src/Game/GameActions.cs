using System.Linq;
using System.Collections.Generic;

using static Battleship.Constants.Constants;

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

        /// <summary>
        ///   Creates a new GameActions object. This constructor should not be called directly.
        /// </summary>
        public GameActions(string[][] pieces, string[] shotsFired)
        {
            Pieces = pieces.SelectMany(row => row.Select(cell => Coordinate.ParseFromString(cell)));

            ShotsFired = shotsFired.Select((shot, index) => !string.IsNullOrEmpty(shot) ? new Coordinate(index / boardSize, index % boardSize) : null).Where(coordinate => coordinate is not null);
        }

        /// <summary>
        ///   Parses the battleship positions and fired shots from the awkwardly formatted json file
        /// </summary>
        /// <param name="filePath">The file name and path of the json file relative to the working directory</param>
        public static GameActions FromJson(string filePath)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GameActions>(System.IO.File.ReadAllText(filePath));
        }
    }
}