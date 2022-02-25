namespace Battleship.Constants
{
    public static class Constants
    {
        public static readonly char[] linearray = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
        public static readonly string rowSeparator = "---------------------";
        public static readonly string cellSeparator = "|";
        public static readonly char boatIcon = '*';
        public static readonly char shotHitIcon = 'X';
        public static readonly char shotMissIcon = 'o';
        public static readonly int boardSize = 10;
    }
}
