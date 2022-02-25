using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static Battleship.Constants.Constants;

namespace Battleship.Game
{
    /// <summary>
    ///   Allows analyzing the in-game actions and end state of a game of battleships. The board is
    ///   represented as a two-dimensional array of characters, where '*' represents a boat, 'o'
    ///   represents a missed shot and 'X' represents a hit.
    /// </summary>
    public class Board
    {
        private char[][] board;

        /// <summary>
        ///   Creates a new gaming board representation with ships placed to their initial coordinates.
        /// </summary>
        /// <param name="shots">Ship positions represented as an enumerable of <c>Coordinate</c> objects</param>
        public Board(IEnumerable<Coordinate> ships)
        {
            board = Enumerable.Range(0, boardSize).Select(i => Enumerable.Range(0, boardSize).Select(j => ' ').ToArray()).ToArray();

            foreach (var item in ships)
            {
                board[item.Row][item.Cell] = boatIcon;
            }
        }

        /// <summary>
        ///   Mutates the gaming board by applying fired shots. Hits will be marked with an 'X' and misses with an 'o'.
        /// </summary>
        /// <param name="shots">Fired shots represented as an enumerable of <c>Coordinate</c> objects</param>
        public void ApplyShots(IEnumerable<Coordinate> shots)
        {
            foreach (var item in shots)
            {
                var previousValue = board[item.Row][item.Cell];
                board[item.Row][item.Cell] = previousValue == boatIcon ? shotHitIcon : shotMissIcon;
            }
        }

        /// <summary>
        ///   Allows visual analysis of the current board state.
        /// </summary>
        /// <returns>
        ///   Returns a string representation of the board's state.
        /// </returns>
        public string GetBoardState()
        {
            var sb = new StringBuilder();

            sb.AppendLine(rowSeparator);

            for (var i = 0; i < boardSize; i++)
            {
                AppendRowData(sb, Enumerable.Range(0, boardSize).Select(j => board[i][j]));
            }

            return sb.ToString();
        }

        private StringBuilder AppendRowData(StringBuilder sb, IEnumerable<char> boardChars)
        {
            if (boardChars.Count() != boardSize)
            {
                throw new FormatException("Malformatted row coordinates");
            }

            sb.Append(cellSeparator);
            sb.AppendJoin(cellSeparator, boardChars);
            sb.Append(cellSeparator);
            sb.AppendLine();
            sb.AppendLine(rowSeparator);

            return sb;
        }
    }
}