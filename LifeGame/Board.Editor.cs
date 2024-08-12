namespace LifeGame;

public partial class Board
{
    public Board Truncate()
        => new(cells.Where(cell => 0 <= cell.X && 0 <= cell.Y));

    public Board Truncate(int maxWidth, int maxHeight)
        => new(cells.Where(cell => 0 <= cell.X && cell.X < maxWidth && 0 <= cell.Y && cell.Y < maxHeight));

    public Board Translate(int x, int y)
        => new(cells.Select(cell => new Cell(cell.X + x, cell.Y + y)));

    public Board Rotate()
    {
        var y = cells.Max(cell => cell.Y);
        return new(cells.Select(cell => new Cell(-cell.Y + y, cell.X)));
    }

    public Board Flip()
        => new(cells.Select(cell => new Cell(cell.Y, cell.X)));

    public Board Normalize()
    {
        var x = cells.Min(cell => cell.X);
        var y = cells.Min(cell => cell.Y);
        return new(cells.Select(cell => new Cell(cell.X - x, cell.Y - y)));
    }

    public Board Merge(Board board)
        => new(cells.Union(board.AliveCells));

    public Board Except(Board board)
        => new(cells.Except(board.AliveCells));

    public Board AddCell(Cell cell)
        => new(cells.Add(cell));

    public Board AddCell(params Cell[] cell)
        => this.AddCell(cell.AsEnumerable());

    public Board AddCell(IEnumerable<Cell> cell)
        => new(cells.Union(cell));

    public Board RemoveCell(Cell cell)
        => new(cells.Remove(cell));

    public Board RemoveCell(params Cell[] cell)
        => this.RemoveCell(cell.AsEnumerable());

    public Board RemoveCell(IEnumerable<Cell> cell)
        => new(cells.Except(cell));
}
