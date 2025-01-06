namespace LifeGame;

/// <summary>
/// Represents a runner for Conway's Game of Life.
/// </summary>
public interface IRunner
{
    /// <summary>
    /// Runs the game on the specified board.
    /// </summary>
    /// <param name="board">The initial state of the game board.</param>
    /// <param name="intervalMilliseconds">The interval between generations in milliseconds.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task RunGame(Board board, int intervalMilliseconds = 200, CancellationToken cancellationToken = default);
}

public class ConsoleRunner(IPrinter printer) : IRunner
{
    public ConsoleRunner(int width, int height) : this(new Printer(width, height))
    { }

    public async Task RunGame(Board board, int intervalMilliseconds = 200, CancellationToken cancellationToken = default)
    {
        Console.Clear();

        foreach (var (generation, current) in board.EnumerateGenerations().Index())
        {
            Console.SetCursorPosition(0, 0);
            var width = Console.WindowWidth;

            Console.WriteLine($"generations: {generation}".PadRight(width));
            Console.WriteLine($"alive cells: {current.AliveCells.Count}".PadRight(width));
            Console.WriteLine(printer.PrintBoard(current));

            await Task.Delay(intervalMilliseconds, cancellationToken);
        }
    }
}
