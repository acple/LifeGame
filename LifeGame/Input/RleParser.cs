using ParsecSharp;
using static ParsecSharp.Parser;
using static ParsecSharp.Text;

namespace LifeGame;

// https://conwaylife.com/wiki/Run_Length_Encoded
public class RleParser : IParser
{
    private record State(int X, int Y, ImmutableHashSet<Cell> Cells);

    private static readonly IParser<char, Board> parser = CreateParser();

    private static IParser<char, Board> CreateParser()
    {
        var whitespace = OneOf(" \t").Or(EndOfLine()).Ignore();
        var comment = Char('#').Right(Match(EndOfLine().Ignore() | EndOfInput()));
        var spacing = SkipMany(whitespace | comment);

        var header = Match(EndOfLine()).Right(spacing); // header is currently ignored

        var number = Many1(DecDigit()).ToInt().Left(spacing);
        var count = Optional(number, 1);
        var newline = Char('$').Right(spacing);
        var deadCell = Char('b').Right(spacing);
        var aliveCell = Char('o').Right(spacing);
        var end = Char('!').Right(spacing);

        IParser<char, State> Newline(int count, State state)
            => newline.Map(_ => state with { X = 0, Y = state.Y + count });

        IParser<char, State> DeadCell(int count, State state)
            => deadCell.Map(_ => state with { X = state.X + count });

        IParser<char, State> AliveCell(int count, State state)
            => aliveCell.Map(_ => state with { X = state.X + count, Cells = state.Cells.Union(Enumerable.Range(state.X, count).Select(x => new Cell(x, state.Y))) });

        var rle = Pure(new State(0, 0, []))
            .Chain(state => count.Bind(count => Choice(Newline(count, state), DeadCell(count, state), AliveCell(count, state))))
            .Left(end);

        var parser = Sequence(spacing, header, rle, EndOfInput(), (_, _, data, _) => new Board(data.Cells));

        return parser;
    }

    public Board Parse(string source)
        => parser.Parse(source).Value;
}
