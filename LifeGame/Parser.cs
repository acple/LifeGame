namespace LifeGame;

/// <summary>
/// Represents a parser for converting a source string into a Board object for Conway's Game of Life.
/// </summary>
public interface IParser
{
    /// <summary>
    /// Parses the source string and returns a Board object representing the game board.
    /// </summary>
    /// <param name="source">The source string to parse.</param>
    /// <returns>A Board object representing the game board.</returns>
    Board Parse(string source);
}

public record PlaintextParserConfig(char DeadCell, char AliveCell);

// https://conwaylife.com/wiki/Plaintext
public class PlaintextParser(PlaintextParserConfig config) : IParser
{
    public PlaintextParser() : this(new('.', 'O'))
    { }

    public Board Parse(string source)
    {
        var deadCell = config.DeadCell;
        var aliveCell = config.AliveCell;

        var data = source
            .Split(['\r', '\n'], StringSplitOptions.TrimEntries)
            .Where(x => !x.StartsWith('!'))
            .ToArray();

        if (string.Concat(data) is var concat && concat.Distinct().Count() > 2 || !concat.Contains(deadCell) && !concat.Contains(aliveCell))
            throw new ArgumentException("contains invalid char");

        var cells =
            from line in data.Select((value, y) => (value, y))
            from cell in line.value.Select((value, x) => (value, x))
            where cell.value == aliveCell
            select new Cell(cell.x, line.y);

        return new(cells);
    }
}
