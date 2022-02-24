using Microsoft.VisualStudio.TestTools.UnitTesting;

using Battleship.Game;

namespace BattleshipTest;

[TestClass]
public class BattleshipTest
{
    private readonly string endResult = @"---------------------
| | |*|X|*|*|*| | | |
---------------------
| |o| | | |*|*|*| | |
---------------------
| | | | |*| | | |o| |
---------------------
| |o| | |X| |*|o| | |
---------------------
| | | | |*| |*| | | |
---------------------
| | |o| |*| | | | | |
---------------------
| | | | |o| | | |o| |
---------------------
|*| | | | | | |o| | |
---------------------
|*| | | | | | | | | |
---------------------
|*| | | | | | | | | |
---------------------
";

    [TestMethod]
    public void TestEndResult()
    {
        var game = new BattleshipGame();

        var result = game.Run();

        Assert.AreEqual(endResult, result);
    }
}