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
            Row = row;
            Cell = cell;
        }

        public static Coordinate ParseFromString(string str)
        {
            try
            {
                var row = Array.FindIndex(linearray, c => c == char.Parse(str.Substring(0, 1)));
                if (row < 0 || row >= boardSize)
                {
                    throw new ArgumentOutOfRangeException();
                }

                var cell = int.Parse(str.Substring(1)) - 1;
                if (cell < 0 || cell >= boardSize)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return new Coordinate(row, cell);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentOutOfRangeException || ex is FormatException || ex is ArgumentNullException)
                {
                    throw new FormatException("Malformatted coordinate");
                }

                throw;
            }
        }
    }
}