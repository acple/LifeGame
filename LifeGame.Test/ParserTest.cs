namespace LifeGame.Test;

public class ParserTest
{
    private static void Run<TParser>(TParser parser, Board reference, string source)
        where TParser : IParser
    {
        var board = parser.Parse(source);
        Assert.Equal(reference, board);
    }

    [Fact]
    public void ParsePlaintextBlock()
        => Run(new PlaintextParser(), Patterns.Block, """
            !Name: Block
            !The most common still life.
            !www.conwaylife.com/wiki/index.php?title=Block
            OO
            OO

            """);

    [Fact]
    public void ParsePlaintextOctagon()
        => Run(new PlaintextParser(), Patterns.Octagon, """
            !Name: Octagon 2
            !Author: Sol Goodman and Arthur Taber
            !The first known period 5 oscillator.
            !www.conwaylife.com/wiki/index.php?title=Octagon_2
            ...OO
            ..O..O
            .O....O
            O......O
            O......O
            .O....O
            ..O..O
            ...OO

            """);

    [Fact]
    public void ParseRleBeehive()
        => Run(new RleParser(), Patterns.BeeHive, """
            #N Beehive
            #O John Conway
            #C An extremely common 6-cell still life.
            #C www.conwaylife.com/wiki/index.php?title=Beehive
            x = 4, y = 3, rule = B3/S23
            b2ob$o2bo$b2o!
            """);

    [Fact]
    public void ParseRleGlider()
        => Run(new RleParser(), Patterns.Glider, """
            #N Glider
            #O Richard K. Guy
            #C The smallest, most common, and first discovered spaceship. Diagonal, has period 4 and speed c/4.
            #C www.conwaylife.com/wiki/index.php?title=Glider
            x = 3, y = 3, rule = B3/S23
            bob$2bo$3o!
            """);
}
