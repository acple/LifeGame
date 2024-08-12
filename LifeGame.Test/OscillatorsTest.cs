namespace LifeGame.Test;

public class OscillatorsTest
{
    private static void Run(Board board, int period)
    {
        var state = board.EnumerateGenerations().Select(x => x).Take(period * 2).ToArray();

        Assert.Equal(state[..period], state[period..]);
    }

    [Fact]
    public void Blinker()
        => Run(Examples.Blinker, period: 2);

    [Fact]
    public void Toad()
        => Run(Examples.Toad, period: 2);

    [Fact]
    public void Beacon()
        => Run(Examples.Beacon, period: 2);

    [Fact]
    public void Clock()
        => Run(Examples.Clock, period: 2);

    [Fact]
    public void Octagon()
        => Run(Examples.Octagon, period: 5);

    [Fact]
    public void Galaxy()
        => Run(Examples.Galaxy, period: 8);
}
