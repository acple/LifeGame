namespace LifeGame;

/// <summary>
/// Represents the game board for Conway's Game of Life.
/// </summary>
public partial class Board(ImmutableHashSet<Cell> cells) : IEquatable<Board>
{
    public Board(IEnumerable<Cell> cells) : this(cells.ToImmutableHashSet())
    { }

    /// <summary>
    /// Gets the collection of alive cells on the board.
    /// </summary>
    public IReadOnlyCollection<Cell> AliveCells => cells;

    /// <summary>
    /// Determines whether the specified cell is alive.
    /// </summary>
    /// <param name="cell">The cell to check.</param>
    /// <returns><c>true</c> if the cell is alive; otherwise, <c>false</c>.</returns>
    public bool IsAliveCell(Cell cell)
        => cells.Contains(cell);

    /// <summary>
    /// Advances the board to the next generation.
    /// </summary>
    /// <returns>A new <see cref="Board"/> representing the next generation.</returns>
    public Board Advance()
        => new(cells
            .SelectMany(cell => cell.Neighbors)
            .GroupBy(cell => cell)
            .Where(x => this.CheckState(x.Key, x.Count()))
            .Select(x => x.Key));

    /// <summary>
    /// Checks the state of the specified cell based on the count of its neighbors.
    /// </summary>
    private bool CheckState(Cell cell, int count)
        => count switch
        {
            1 => false, // underpopulation
            2 => cells.Contains(cell), // lives
            3 => true, // reproduction
            _ => false, // overpopulation
        };

    /// <summary>
    /// Enumerates the generations of the board starting from the current state.
    /// </summary>
    /// <returns>An enumerable of <see cref="Board"/> representing each generation.</returns>
    public IEnumerable<Board> EnumerateGenerations()
    {
        for (var current = this; ; current = current.Advance())
            yield return current;
    }

    #region Equality definitions

    public override int GetHashCode()
        => cells.Aggregate(0, HashCode.Combine);

    public override bool Equals(object? obj)
        => obj is Board board && this.Equals(board);

    public bool Equals(Board? other)
        => other is not null && cells.SetEquals(other.AliveCells);

    public static bool operator ==(Board left, Board right)
        => left.Equals(right);

    public static bool operator !=(Board left, Board right)
        => !(left == right);

    #endregion
}
