namespace LifeGame.Test;

public class ParserTest
{
    private static void Run(Board reference, string source)
    {
        var parser = new PlaintextParser();
        var board = parser.Parse(source);

        Assert.Equal(reference, board);
    }

    [Fact]
    public void ParseBlock()
        => Run(Patterns.Block, """
            !comment
            OO
            OO
            """);

    [Fact]
    public void ParseOctagon()
        => Run(Patterns.Octagon, """
            ...OO...
            ..O..O..
            .O....O.
            O......O
            O......O
            .O....O.
            ..O..O..
            ...OO...

            """);
}
