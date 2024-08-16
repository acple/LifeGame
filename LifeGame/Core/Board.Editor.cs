namespace LifeGame;

public partial class Board
{
    /// <summary>
    /// The empty board.
    /// </summary>
    public static Board Empty { get; } = new([]);

    /// <summary>
    /// Truncates the board to only include cells with non-negative coordinates.
    /// </summary>
    /// <returns>A new <see cref="Board"/> with truncated cells.</returns>
    public Board Truncate()
        => new(cells.Where(cell => 0 <= cell.X && 0 <= cell.Y));

    /// <summary>
    /// Truncates the board to fit within the specified width and height.
    /// </summary>
    /// <param name="maxWidth">The maximum width of the board.</param>
    /// <param name="maxHeight">The maximum height of the board.</param>
    /// <returns>A new <see cref="Board"/> with truncated cells.</returns>
    public Board Truncate(int maxWidth, int maxHeight)
        => new(cells.Where(cell => 0 <= cell.X && cell.X < maxWidth && 0 <= cell.Y && cell.Y < maxHeight));

    /// <summary>
    /// Translates the board by the specified x and y offsets.
    /// </summary>
    /// <param name="x">The x offset.</param>
    /// <param name="y">The y offset.</param>
    /// <returns>A new <see cref="Board"/> with translated cells.</returns>
    public Board Translate(int x, int y)
        => new(cells.Select(cell => new Cell(cell.X + x, cell.Y + y)));

    /// <summary>
    /// Rotates the board 90 degrees clockwise around the origin (0, 0).
    /// </summary>
    /// <returns>A new <see cref="Board"/> with rotated cells.</returns>
    public Board Rotate()
        => new(cells.Select(cell => new Cell(-cell.Y, cell.X)));

    /// <summary>
    /// Rotates the board 90 degrees clockwise around the specified cell (x, y).
    /// </summary>
    /// <param name="x">The x-coordinate of the pivot cell.</param>
    /// <param name="y">The y-coordinate of the pivot cell.</param>
    /// <returns>A new <see cref="Board"/> with rotated cells.</returns>
    public Board Rotate(int x, int y)
        => new(cells.Select(cell => new Cell(-cell.Y + x + y, cell.X - x + y)));

    /// <summary>
    /// Flips the board along the diagonal.
    /// </summary>
    /// <returns>A new <see cref="Board"/> with flipped cells.</returns>
    public Board Transpose()
        => new(cells.Select(cell => new Cell(cell.Y, cell.X)));

    /// <summary>
    /// Normalizes the board by translating it so that the top-left cell is at (0, 0).
    /// </summary>
    /// <returns>A new <see cref="Board"/> with normalized cells.</returns>
    public Board Normalize()
        => this.Translate(-cells.Min(cell => cell.X), -cells.Min(cell => cell.Y));

    /// <summary>
    /// Merges the current board with another board.
    /// </summary>
    /// <param name="board">The board to merge with.</param>
    /// <returns>A new <see cref="Board"/> containing cells from both boards.</returns>
    public Board Merge(Board board)
        => new(cells.Union(board.AliveCells));

    /// <summary>
    /// Removes the cells of another board from the current board.
    /// </summary>
    /// <param name="board">The board whose cells to remove.</param>
    /// <returns>A new <see cref="Board"/> with the specified cells removed.</returns>
    public Board Except(Board board)
        => new(cells.Except(board.AliveCells));

    /// <summary>
    /// Adds a cell to the board.
    /// </summary>
    /// <param name="cell">The cell to add.</param>
    /// <returns>A new <see cref="Board"/> with the cell added.</returns>
    public Board AddCell(Cell cell)
        => new(cells.Add(cell));

    /// <summary>
    /// Adds multiple cells to the board.
    /// </summary>
    /// <param name="cell">The cells to add.</param>
    /// <returns>A new <see cref="Board"/> with the cells added.</returns>
    public Board AddCell(params Cell[] cell)
        => this.AddCell(cell.AsEnumerable());

    /// <summary>
    /// Adds a collection of cells to the board.
    /// </summary>
    /// <param name="cell">The collection of cells to add.</param>
    /// <returns>A new <see cref="Board"/> with the cells added.</returns>
    public Board AddCell(IEnumerable<Cell> cell)
        => new(cells.Union(cell));

    /// <summary>
    /// Removes a cell from the board.
    /// </summary>
    /// <param name="cell">The cell to remove.</param>
    /// <returns>A new <see cref="Board"/> with the cell removed.</returns>
    public Board RemoveCell(Cell cell)
        => new(cells.Remove(cell));

    /// <summary>
    /// Removes multiple cells from the board.
    /// </summary>
    /// <param name="cell">The cells to remove.</param>
    /// <returns>A new <see cref="Board"/> with the cells removed.</returns>
    public Board RemoveCell(params Cell[] cell)
        => this.RemoveCell(cell.AsEnumerable());

    /// <summary>
    /// Removes a collection of cells from the board.
    /// </summary>
    /// <param name="cell">The collection of cells to remove.</param>
    /// <returns>A new <see cref="Board"/> with the cells removed.</returns>
    public Board RemoveCell(IEnumerable<Cell> cell)
        => new(cells.Except(cell));

    /// <summary>
    /// Fills the board with cells in a rectangular region defined by the start and end cells, including the start and end cells.
    /// </summary>
    /// <param name="start">The starting cell of the region.</param>
    /// <param name="end">The ending cell of the region.</param>
    /// <returns>A new <see cref="Board"/> with the filled cells.</returns>
    public Board Fill(Cell start, Cell end)
        => this.Fill(Math.Min(start.X, end.X), Math.Min(start.Y, end.Y), Math.Abs(end.X - start.X) + 1, Math.Abs(end.Y - start.Y) + 1);

    /// <summary>
    /// Fills the board with cells in a rectangular region defined by the specified coordinates, width, and height.
    /// </summary>
    /// <param name="x">The x-coordinate of the top-left corner of the region.</param>
    /// <param name="y">The y-coordinate of the top-left corner of the region.</param>
    /// <param name="width">The width of the region.</param>
    /// <param name="height">The height of the region.</param>
    /// <returns>A new <see cref="Board"/> with the filled cells.</returns>
    public Board Fill(int x, int y, int width, int height)
        => this.AddCell(Enumerable.Range(x, width)
            .SelectMany(_ => Enumerable.Range(y, height), (x, y) => new Cell(x, y)));
}
