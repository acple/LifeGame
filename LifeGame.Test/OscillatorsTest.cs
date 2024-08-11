namespace LifeGame.Test;

public class OscillatorsTest
{
    private static void Run(int period, Board board)
    {
        var state = board.EnumerateGenerations().Select(x => x).Take(period * 2).ToArray();

        Assert.Equal(state[..period], state[period..]);
    }

    [Fact]
    public void Blinker()
        => Run(period: 2, Examples.Blinker);

    [Fact]
    public void Toad()
        => Run(period: 2, Examples.Toad);

    [Fact]
    public void Beacon()
        => Run(period: 2, Examples.Beacon);

    [Fact]
    public void Clock()
        => Run(period: 2, Examples.Clock);

    [Fact]
    public void Octagon()
        => Run(period: 5, Examples.Octagon);
}
