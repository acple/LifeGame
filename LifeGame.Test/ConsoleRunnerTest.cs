namespace LifeGame.Test;

public class ConsoleRunnerTest
{
    [Fact]
    public void PrintTest()
    {
        var board = Examples.Octagon;
        var runner = new ConsoleRunner(8, 8);
        runner.PrintBoard(board);
    }
}
