using System.Text;

namespace LifeGame;

/// <summary>
/// Represents a printer for converting a Board object into a string representation.
/// </summary>
public interface IPrinter
{
    /// <summary>
    /// Prints the board to a string representation.
    /// </summary>
    /// <param name="board">The game board to print.</param>
    /// <returns>A string representation of the game board.</returns>
    string PrintBoard(Board board);
}

public record PrinterConfig(char DeadCell, char AliveCell, int Witdh, int Height);

public class Printer(PrinterConfig config) : IPrinter
{
    public Printer(int width, int height) : this(new('□', '■', width, height))
    { }

    public string PrintBoard(Board board)
    {
        var deadCell = config.DeadCell;
        var aliveCell = config.AliveCell;
        var width = config.Witdh;
        var height = config.Height;

        var matrix = Enumerable.Range(0, height)
            .Select(y => Enumerable.Range(0, width).Select(x => board.IsAliveCell(new(x, y))));

        var size = width * height + height;
        var lines = matrix.Aggregate(new StringBuilder(size, size),
            (builder, line) => line
                .Select(alive => alive ? aliveCell : deadCell)
                .Aggregate(builder, (builder, cell) => builder.Append(cell))
                .Append('\n'))
            .Remove(size - 1, 1) // remove trailing newline
            .ToString();

        return lines;
    }
}
