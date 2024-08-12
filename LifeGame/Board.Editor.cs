namespace LifeGame;

public partial class Board
{
    public Board Truncate()
        => this.Truncate(int.MaxValue, int.MinValue);

    public Board Truncate(int maxWidth, int maxHeight)
        => new(this.cells.Where(cell => 0 <= cell.X && cell.X < maxWidth && 0 <= cell.Y && cell.Y < maxHeight));

    public Board Translate(int x, int y)
        => new(this.cells.Select(cell => new Cell(cell.X + x, cell.Y + y)));

    public Board Rotate()
    {
        var y = this.cells.Max(cell => cell.Y);
        return new(this.cells.Select(cell => new Cell(-cell.Y + y, cell.X)));
    }

    public Board Flip()
        => new(this.cells.Select(cell => new Cell(cell.Y, cell.X)));

    public Board Normalize()
    {
        var x = this.cells.Min(cell => cell.X);
        var y = this.cells.Min(cell => cell.Y);
        return new(this.cells.Select(cell => new Cell(cell.X - x, cell.Y - y)));
    }

    public Board Merge(Board board)
        => new(this.cells.Union(board.cells));

    public Board Except(Board board)
        => new(this.cells.Except(board.cells));

    public Board AddCell(Cell cell)
        => new(this.cells.Add(cell));

    public Board AddCells(IEnumerable<Cell> cells)
        => new(this.cells.Union(cells));

    public Board RemoveCell(Cell cell)
        => new(this.cells.Remove(cell));

    public Board RemoveCells(IEnumerable<Cell> cells)
        => new(this.cells.Except(cells));
}
