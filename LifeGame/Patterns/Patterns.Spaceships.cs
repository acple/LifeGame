namespace LifeGame;

public static partial class Patterns
{
    /// <summary>
    /// <code>
    /// □■□
    /// □□■
    /// ■■■
    /// </code>
    /// </summary>
    public static Board Glider =>
        new([new(1, 0), new(2, 1), new(0, 2), new(1, 2), new(2, 2)]);

    /// <summary>
    /// <code>
    /// □□■□□□
    /// ■□□□■□
    /// □□□□□■
    /// ■□□□□■
    /// □■■■■■
    /// </code>
    /// </summary>
    public static Board Spaceship =>
        new([
            new(2, 0), new(0, 1), new(4, 1), new(5, 2), new(0, 3), new(5, 3),
            new(1, 4), new(2, 4), new(3, 4), new(4, 4), new(5, 4),
        ]);

    /// <summary>
    /// <code>
    /// ■□□■□
    /// □□□□■
    /// ■□□□■
    /// □■■■■
    /// </code>
    /// </summary>
    public static Board LightweightSpaceship =>
        new([new(0, 0), new(3, 0), new(4, 1), new(0, 2), new(4, 2), new(1, 3), new(2, 3), new(3, 3), new(4, 3)]);

    /// <summary>
    /// <code>
    /// □□■■□□□
    /// ■□□□□■□
    /// □□□□□□■
    /// ■□□□□□■
    /// □■■■■■■
    /// </code>
    /// </summary>
    public static Board HeavyweightSpaceship =>
        new([
            new(2, 0), new(3, 0), new(0, 1), new(5, 1), new(6, 2), new(0, 3), new(6, 3),
            new(1, 4), new(2, 4), new(3, 4), new(4, 4), new(5, 4), new(6, 4),
        ]);

    /// <summary>
    /// <code>
    /// □■■□□■■□
    /// □□□■■□□□
    /// □□□■■□□□
    /// ■□■□□■□■
    /// ■□□□□□□■
    /// □□□□□□□□
    /// ■□□□□□□■
    /// □■■□□■■□
    /// □□■■■■□□
    /// □□□□□□□□
    /// □□□■■□□□
    /// □□□■■□□□
    /// </code>
    /// </summary>
    public static Board CopperHead =>
        new([
            new(1, 0), new(2, 0), new(5, 0), new(6, 0),
            new(3, 1), new(4, 1),
            new(3, 2), new(4, 2),
            new(0, 3), new(2, 3), new(5, 3), new(7, 3),
            new(0, 4), new(7, 4),
            new(0, 6), new(7, 6),
            new(1, 7), new(2, 7), new(5, 7), new(6, 7),
            new(2, 8), new(3, 8), new(4, 8), new(5, 8),
            new(3, 10), new(4, 10),
            new(3, 11), new(4, 11),
        ]);
}
