namespace LifeGame;

public partial class Board(IEnumerable<Cell> cells) : IEquatable<Board>
{
    // Must have a concrete type of HashSet<T> to use SetComparer, do not modify it's elements.
    private readonly HashSet<Cell> cells = cells.ToHashSet();

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

    public override int GetHashCode()
        => HashSet<Cell>.CreateSetComparer().GetHashCode(this.cells);

    public override bool Equals(object? obj)
        => obj is Board board && this.Equals(board);

    public bool Equals(Board? other)
        => other is not null && HashSet<Cell>.CreateSetComparer().Equals(this.cells, other.cells);
}
