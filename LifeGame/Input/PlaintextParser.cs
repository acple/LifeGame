namespace LifeGame;

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
            .Split('\n', StringSplitOptions.TrimEntries)
            .Where(x => !x.StartsWith('!'))
            .ToArray();

        if (data.SelectMany(x => x).Any(x => x != deadCell && x != aliveCell))
            throw new ArgumentException("contains invalid char");

        var cells =
            from line in data.Select((value, y) => (value, y))
            from cell in line.value.Select((value, x) => (value, x))
            where cell.value == aliveCell
            select new Cell(cell.x, line.y);

        return new(cells);
    }
}
