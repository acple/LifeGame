namespace LifeGame;

// https://conwaylife.com/wiki/Plaintext
public class Parser
{
    public Board Parse(string source)
        => this.Parse(source, deadCell: '.', aliveCell: 'O');

    public Board Parse(string source, char deadCell, char aliveCell)
    {
        var data = source
            .Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
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
