using System.Collections.Immutable;

namespace LifeGame;

public partial class Board(ImmutableHashSet<Cell> cells) : IEquatable<Board>
{
    private readonly ImmutableHashSet<Cell> cells = cells;

    public Board(IEnumerable<Cell> cells) : this(cells.ToImmutableHashSet())
    { }

    public int AliveCellCount => this.cells.Count;

    public bool IsAliveCell(int x, int y)
        => this.cells.Contains(new(x, y));

    public Board Advance()
        => new(this.cells
            .SelectMany(cell => cell.Neighbors)
            .GroupBy(cell => cell)
            .Where(x => this.CheckState(x.Key, x.Count()))
            .Select(x => x.Key));

    private bool CheckState(Cell cell, int count)
        => count switch
        {
            1 => false, // underpopulation
            2 => this.cells.Contains(cell), // lives
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
        => this.cells.Aggregate(0, HashCode.Combine);

    public override bool Equals(object? obj)
        => obj is Board board && this.Equals(board);

    public bool Equals(Board? other)
        => other is not null && this.cells.SetEquals(other.cells);

    public static bool operator ==(Board left, Board right)
        => left.Equals(right);

    public static bool operator !=(Board left, Board right)
        => !(left == right);

    #endregion
}
