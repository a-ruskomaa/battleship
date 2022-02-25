namespace Battleship.Game
{
    public class BattleshipGame
    {
        public string Run()
        {
            var gameActions = GameActions.FromJson("battlezone.json");

            var board = new Board(gameActions.Pieces);

            board.ApplyShots(gameActions.ShotsFired);

            return board.GetBoardState();
        }
    }
}
