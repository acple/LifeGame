namespace LifeGame;

/// <summary>
/// Represents a runner for the game of life.
/// </summary>
public interface IRunner
{
    /// <summary>
    /// Runs the game of life on the specified board.
    /// </summary>
    /// <param name="board">The game board.</param>
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

        foreach (var (state, generation) in board.EnumerateGenerations().Select((state, generation) => (state, generation)))
        {
            Console.SetCursorPosition(0, 0);
            var width = Console.WindowWidth;

            Console.WriteLine($"generations: {generation}".PadRight(width));
            Console.WriteLine($"alive cells: {state.AliveCells.Count}".PadRight(width));
            Console.WriteLine(printer.PrintBoard(state));

            await Task.Delay(intervalMilliseconds, cancellationToken);
        }
    }
}
