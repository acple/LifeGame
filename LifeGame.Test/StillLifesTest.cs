namespace LifeGame.Test;

public class StillLifesTest
{
    private static void Run(Board board)
    {
        var next = board.Advance();

        Assert.Equal(board, next);
    }

    [Fact]
    public void Block()
        => Run(Examples.Block);

    [Fact]
    public void BeeHive()
        => Run(Examples.BeeHive);

    [Fact]
    public void Loaf()
        => Run(Examples.Loaf);

    [Fact]
    public void Boat()
        => Run(Examples.Boat);

    [Fact]
    public void Tub()
        => Run(Examples.Tub);
}
