namespace LifeGame;

public readonly record struct Cell(int X, int Y)
{
    public readonly IReadOnlyCollection<Cell> Neighbors =>
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
