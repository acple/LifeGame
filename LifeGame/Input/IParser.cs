namespace LifeGame;

/// <summary>
/// Represents a parser for converting a source string into a Board object for Conway's Game of Life.
/// </summary>
public interface IParser
{
    /// <summary>
    /// Parses the source string and returns a Board object representing the game board.
    /// </summary>
    /// <param name="source">The source string to parse.</param>
    /// <returns>A Board object representing the game board.</returns>
    Board Parse(string source);
}
