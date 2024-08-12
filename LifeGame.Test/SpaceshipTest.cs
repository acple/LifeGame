namespace LifeGame.Test;

public class SpaceshipTest
{
    private static void Run(Board board, int period, int x, int y)
    {
        var state = board.EnumerateGenerations().Select(x => x).Take(period * 2).ToArray();

        Assert.Equal(state[..period].Select(board => board.Translate(x, y)), state[period..]);
    }

    [Fact]
    public void Glider()
        => Run(Examples.Glider, period: 4, x: 1, y: 1);

    [Fact]
    public void Spaceship()
        => Run(Examples.Spaceship, period: 4, x: 2, y: 0);

    [Fact]
    public void LightweightSpaceship()
        => Run(Examples.LightweightSpaceship, period: 4, x: 2, y: 0);
}
