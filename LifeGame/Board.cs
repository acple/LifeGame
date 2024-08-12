using System.Collections.Immutable;

namespace LifeGame;

public partial class Board(ImmutableHashSet<Cell> cells) : IEquatable<Board>
{
    public Board(IEnumerable<Cell> cells) : this(cells.ToImmutableHashSet())
    { }

    public IReadOnlyCollection<Cell> AliveCells => cells;

    public bool IsAliveCell(Cell cell)
        => cells.Contains(cell);

    public Board Advance()
        => new(cells
            .SelectMany(cell => cell.Neighbors)
            .GroupBy(cell => cell)
            .Where(x => this.CheckState(x.Key, x.Count()))
            .Select(x => x.Key));

    private bool CheckState(Cell cell, int count)
        => count switch
        {
            1 => false, // underpopulation
            2 => cells.Contains(cell), // lives
            3 => true, // reproduction
            _ => false, // overpopulation
        };

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
