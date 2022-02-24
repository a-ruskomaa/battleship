using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Text;

using Battleship.Extensions;

namespace Battleship.Game
{
    public class Board
    {
        // Declaring variables
        public static void SetValue(Board lauta, string cordinate, object arvo)
        {
            // Reflection is cool, right : http://stackoverflow.com/questions/619767/set-object-property-using-reflection
            var pi = typeof(Board).GetField(cordinate, BindingFlags.NonPublic | BindingFlags.Instance);
            pi.SetValue(lauta, (int)arvo);
        }

        public static int? GetValue(Board lauta, string cordinate)
        {
            return typeof(Board).GetField(cordinate, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(lauta) as int?;
        }

        // GameBoard
        private int a1, a2, a3, a4, a5, a6, a7, a8, a9, a10 = 0;
        private int b1, b2, b3, b4, b5, b6, b7, b8, b9, b10 = 0;
        private int c1, c2, c3, c4, c5, c6, c7, c8, c9, c10 = 0;
        private int d1, d2, d3, d4, d5, d6, d7, d8, d9, d10 = 0;
        private int e1, e2, e3, e4, e5, e6, e7, e8, e9, e10 = 0;
        private int f1, f2, f3, f4, f5, f6, f7, f8, f9, f10 = 0;
        private int g1, g2, g3, g4, g5, g6, g7, g8, g9, g10 = 0;
        private int h1, h2, h3, h4, h5, h6, h7, h8, h9, h10 = 0;
        private int i1, i2, i3, i4, i5, i6, i7, i8, i9, i10 = 0;
        private int j1, j2, j3, j4, j5, j6, j7, j8, j9, j10 = 0;

        private const string rowSeparator = "---------------------";
        private const string cellSeparator = "|";

        private StringBuilder AppendRowData(StringBuilder sb, params int[] rowCoordinates)
        {
            if (rowCoordinates.Length != 10)
            {
                throw new FormatException("Malformatted row coordinates");
            }

            var boardChars = rowCoordinates.Select(x => x.ToBoardCharacter());

            sb.Append(cellSeparator);
            sb.AppendJoin(cellSeparator, boardChars);
            sb.Append(cellSeparator);
            sb.AppendLine();
            sb.AppendLine(rowSeparator);

            return sb;
        }

        public string GetBoardState()
        {
            var sb = new StringBuilder();

            sb.AppendLine(rowSeparator);
            AppendRowData(sb, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10);
            AppendRowData(sb, b1, b2, b3, b4, b5, b6, b7, b8, b9, b10);
            AppendRowData(sb, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10);
            AppendRowData(sb, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10);
            AppendRowData(sb, e1, e2, e3, e4, e5, e6, e7, e8, e9, e10);
            AppendRowData(sb, f1, f2, f3, f4, f5, f6, f7, f8, f9, f10);
            AppendRowData(sb, g1, g2, g3, g4, g5, g6, g7, g8, g9, g10);
            AppendRowData(sb, h1, h2, h3, h4, h5, h6, h7, h8, h9, h10);
            AppendRowData(sb, i1, i2, i3, i4, i5, i6, i7, i8, i9, i10);
            AppendRowData(sb, j1, j2, j3, j4, j5, j6, j7, j8, j9, j10);

            return sb.ToString();
        }

    }
}