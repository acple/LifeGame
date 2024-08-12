using System.Text;

namespace LifeGame;

public interface IRunner
{
    Task RunGame(Board board, int intervalMilliseconds = 200, CancellationToken cancellationToken = default);
}

public class ConsoleRunner(int width, int height) : IRunner
{
    public async Task RunGame(Board board, int intervalMilliseconds = 200, CancellationToken cancellationToken = default)
    {
        Console.Clear();

        foreach (var (state, generation) in board.EnumerateGenerations().Select((state, generation) => (state, generation)))
        {
            Console.SetCursorPosition(0, 0);
            var width = Console.WindowWidth;

            Console.WriteLine($"generations: {generation}".PadRight(width));
            Console.WriteLine($"alive cells: {state.AliveCellCount}".PadRight(width));
            this.PrintBoard(state);

            await Task.Delay(intervalMilliseconds, cancellationToken);
        }
    }

    public void PrintBoard(Board board)
    {
        var matrix = Enumerable.Range(0, height)
            .Select(y => Enumerable.Range(0, width).Select(x => board.IsAliveCell(x, y)));

        foreach (var line in matrix)
            Console.WriteLine(line
                .Select(alive => alive ? '■' : '□')
                .Aggregate(new StringBuilder(width), (builder, cell) => builder.Append(cell))
                .ToString());
    }
}
