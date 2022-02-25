using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship.Game
{
    public class Board
    {
        private const string rowSeparator = "---------------------";
        private const string cellSeparator = "|";
        private const string boatIcon = "*";
        private const string shotHitIcon = "X";
        private const string shotMissIcon = "o";

        private string[][] board;

        public Board(IEnumerable<Coordinate> ships)
        {
            board = Enumerable.Range(0, 10).Select(i => Enumerable.Range(0,10).Select(j => " ").ToArray()).ToArray();
            
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

            for (var i = 0; i < 10; i++)
            {
                AppendRowData(sb, Enumerable.Range(0, 10).Select(j => board[i][j]));
            }

            return sb.ToString();
        }
        
        private StringBuilder AppendRowData(StringBuilder sb, IEnumerable<string> boardChars)
        {
            if (boardChars.Count() != 10)
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