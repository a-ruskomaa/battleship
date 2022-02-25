using System;

namespace Battleship.Game
{
    public class Coordinate
    {
        private static readonly char[] linearray = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
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
                var row = Array.FindIndex(Coordinate.linearray, c => c == char.Parse(str.Substring(0, 1)));
                if (row < 0 || row > 9)
                {
                    throw new ArgumentOutOfRangeException();
                }

                var cell = int.Parse(str.Substring(1)) - 1;
                if (cell < 0 || cell > 9)
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