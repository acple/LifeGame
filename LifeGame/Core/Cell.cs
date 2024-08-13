namespace LifeGame;

/// <summary>
/// Represents a cell in Conway's Game of Life.
/// </summary>
/// <param name="X">The x-coordinate of the cell.</param>
/// <param name="Y">The y-coordinate of the cell.</param>
public readonly record struct Cell(int X, int Y)
{
    /// <summary>
    /// The neighboring cells of the current cell.
    /// </summary>
    public IReadOnlyCollection<Cell> Neighbors =>
    [
        new(this.X - 1, this.Y - 1),
        new(this.X + 0, this.Y - 1),
        new(this.X + 1, this.Y - 1),

        new(this.X - 1, this.Y + 0),

        new(this.X + 1, this.Y + 0),

        new(this.X - 1, this.Y + 1),
        new(this.X + 0, this.Y + 1),
        new(this.X + 1, this.Y + 1),
    ];
}
