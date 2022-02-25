using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static Battleship.Constants.Constants;

namespace Battleship.Game
{
    public class Board
    {
        private string[][] board;

        public Board(IEnumerable<Coordinate> ships)
        {
            board = Enumerable.Range(0, boardSize).Select(i => Enumerable.Range(0,boardSize).Select(j => " ").ToArray()).ToArray();
            
            foreach (var item in ships)
            {
                board[item.Row][item.Cell] = boatIcon;
            }
        }

        public void ApplyShots(IEnumerable<Coordinate> shots)
        {
            foreach (var item in shots)
            {
                var previousValue = board[item.Row][item.Cell];
                board[item.Row][item.Cell] = previousValue == boatIcon ? shotHitIcon : shotMissIcon;
            }
        }

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
        
        private StringBuilder AppendRowData(StringBuilder sb, IEnumerable<string> boardChars)
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