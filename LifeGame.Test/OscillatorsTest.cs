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
        => Run(Patterns.Blinker, period: 2);

    [Fact]
    public void Toad()
        => Run(Patterns.Toad, period: 2);

    [Fact]
    public void Beacon()
        => Run(Patterns.Beacon, period: 2);

    [Fact]
    public void Clock()
        => Run(Patterns.Clock, period: 2);

    [Fact]
    public void Octagon()
        => Run(Patterns.Octagon, period: 5);

    [Fact]
    public void Galaxy()
        => Run(Patterns.Galaxy, period: 8);

    [Fact]
    public void Pentadecathlon()
        => Run(Patterns.Pentadecathlon, period: 15);

    [Fact]
    public void FigureEight()
        => Run(Patterns.FigureEight, period: 8);

    [Fact]
    public void Pulsar()
        => Run(Patterns.Pulsar, period: 3);
}
