using System;

using static Battleship.Constants.Constants;

namespace Battleship.Game
{
    public class Coordinate
    {
        public int Row { get; }
        public int Cell { get; }

        public Coordinate(int row, int cell)
        {
            if (cell < 0 || cell >= boardSize)
            {
                throw new ArgumentOutOfRangeException(String.Format("Invalid cell value: {0}", cell));
            }
            if (row < 0 || row >= boardSize)
            {
                throw new ArgumentOutOfRangeException(String.Format("Invalid row value: {0}", row));
            }
            Row = row;
            Cell = cell;
        }

        /// <summary>
        ///   Parses a string to create a new Coordinate object. Row and Cell indexes are zero-based.
        /// </summary>
        /// <example>
        ///   <code>
        ///     Coordinate.ParseFromString("a10") ~~~ new Coordinate(0,9)
        ///     Coordinate.ParseFromString("b2") ~~~ new Coordinate(1,1)
        ///   </code>
        /// </example>
        /// <param name="str">A string representating the param, for example "a10". Valid ranges are a-j and 1-10</param>
        /// <returns>
        ///   Returns a new Coordinate object
        /// </returns>
        /// <exception cref="FormatException"></exception>
        public static Coordinate ParseFromString(string str)
        {
            try
            {
                var row = Array.FindIndex(linearray, c => c == char.Parse(str.Substring(0, 1)));
                var cell = int.Parse(str.Substring(1)) - 1;

                return new Coordinate(row, cell);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentOutOfRangeException || ex is FormatException || ex is ArgumentNullException)
                {
                    throw new FormatException(string.Format("Invalid coordinate: {0}", str));
                }

                throw;
            }
        }
    }
}