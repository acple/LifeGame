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
        => Run(Patterns.Block);

    [Fact]
    public void BeeHive()
        => Run(Patterns.BeeHive);

    [Fact]
    public void Loaf()
        => Run(Patterns.Loaf);

    [Fact]
    public void Boat()
        => Run(Patterns.Boat);

    [Fact]
    public void Tub()
        => Run(Patterns.Tub);

    [Fact]
    public void Carrier()
        => Run(Patterns.Carrier);

    [Fact]
    public void Pond()
        => Run(Patterns.Pond);

    [Fact]
    public void Snake()
        => Run(Patterns.Snake);
}
