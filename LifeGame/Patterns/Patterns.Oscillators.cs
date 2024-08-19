namespace LifeGame;

public static partial class Patterns
{
    /// <summary>
    /// <code>
    /// ■■■
    /// </code>
    /// </summary>
    public static Board Blinker =>
        new([new(0, 0), new(1, 0), new(2, 0)]);

    /// <summary>
    /// <code>
    /// □□■□
    /// ■□□■
    /// ■□□■
    /// □■□□
    /// </code>
    /// </summary>
    public static Board Toad =>
        new([new(2, 0), new(0, 1), new(3, 1), new(0, 2), new(3, 2), new(1, 3)]);

    /// <summary>
    /// <code>
    /// ■■□□
    /// ■□□□
    /// □□□■
    /// □□■■
    /// </code>
    /// </summary>
    public static Board Beacon =>
        new([new(0, 0), new(1, 0), new(0, 1), new(3, 2), new(2, 3), new(3, 3)]);

    /// <summary>
    /// <code>
    /// □□■□
    /// ■□■□
    /// □■□■
    /// □■□□
    /// </code>
    /// </summary>
    public static Board Clock =>
        new([new(2, 0), new(0, 1), new(2, 1), new(1, 2), new(3, 2), new(1, 3)]);

    /// <summary>
    /// <code>
    /// □□□■■□□□
    /// □□■□□■□□
    /// □■□□□□■□
    /// ■□□□□□□■
    /// ■□□□□□□■
    /// □■□□□□■□
    /// □□■□□■□□
    /// □□□■■□□□
    /// </code>
    /// </summary>
    public static Board Octagon =>
        new([
            new(3, 0), new(4, 0),
            new(2, 1), new(5, 1),
            new(1, 2), new(6, 2),
            new(0, 3), new(7, 3),
            new(0, 4), new(7, 4),
            new(1, 5), new(6, 5),
            new(2, 6), new(5, 6),
            new(3, 7), new(4, 7),
        ]);

    /// <summary>
    /// <code>
    /// ■■■■■■□■■
    /// ■■■■■■□■■
    /// □□□□□□□■■
    /// ■■□□□□□■■
    /// ■■□□□□□■■
    /// ■■□□□□□■■
    /// ■■□□□□□□□
    /// ■■□■■■■■■
    /// ■■□■■■■■■
    /// </code>
    /// </summary>
    public static Board Galaxy =>
        new([
            new(0, 0), new(1, 0), new(2, 0), new(3, 0), new(4, 0), new(5, 0), new(7, 0), new(8, 0),
            new(0, 1), new(1, 1), new(2, 1), new(3, 1), new(4, 1), new(5, 1), new(7, 1), new(8, 1),
            new(7, 2), new(8, 2),
            new(0, 3), new(1, 3), new(7, 3), new(8, 3),
            new(0, 4), new(1, 4), new(7, 4), new(8, 4),
            new(0, 5), new(1, 5), new(7, 5), new(8, 5),
            new(0, 6), new(1, 6),
            new(0, 7), new(1, 7), new(3, 7), new(4, 7), new(5, 7), new(6, 7), new(7, 7), new(8, 7),
            new(0, 8), new(1, 8), new(3, 8), new(4, 8), new(5, 8), new(6, 8), new(7, 8), new(8, 8),
        ]);

    /// <summary>
    /// <code>
    /// □□■□□□□■□□
    /// ■■□■■■■□■■
    /// □□■□□□□■□□
    /// </code>
    /// </summary>
    public static Board Pentadecathlon =>
        new([
            new(2, 0), new(7, 0),
            new(0, 1), new(1, 1), new(3, 1), new(4, 1), new(5, 1), new(6, 1), new(8, 1), new(9, 1),
            new(2, 2), new(7, 2),
        ]);

    /// <summary>
    /// <code>
    /// ■■■□□□
    /// ■■■□□□
    /// ■■■□□□
    /// □□□■■■
    /// □□□■■■
    /// □□□■■■
    /// </code>
    /// </summary>
    public static Board FigureEight =>
        new([
            new(0, 0), new(1, 0), new(2, 0), new(0, 1), new(1, 1), new(2, 1), new(0, 2), new(1, 2), new(2, 2),
            new(3, 3), new(4, 3), new(5, 3), new(3, 4), new(4, 4), new(5, 4), new(3, 5), new(4, 5), new(5, 5),
        ]);

    /// <summary>
    /// <code>
    /// □□■■■□□□■■■□□
    /// □□□□□□□□□□□□□
    /// ■□□□□■□■□□□□■
    /// ■□□□□■□■□□□□■
    /// ■□□□□■□■□□□□■
    /// □□■■■□□□■■■□□
    /// □□□□□□□□□□□□□
    /// □□■■■□□□■■■□□
    /// ■□□□□■□■□□□□■
    /// ■□□□□■□■□□□□■
    /// ■□□□□■□■□□□□■
    /// □□□□□□□□□□□□□
    /// □□■■■□□□■■■□□
    /// </code>
    /// </summary>
    public static Board Pulsar =>
        new([
            new(2, 0), new(3, 0), new(4, 0), new(8, 0), new(9, 0), new(10, 0),
            new(0, 2), new(5, 2), new(7, 2), new(12, 2),
            new(0, 3), new(5, 3), new(7, 3), new(12, 3),
            new(0, 4), new(5, 4), new(7, 4), new(12, 4),
            new(2, 5), new(3, 5), new(4, 5), new(8, 5), new(9, 5), new(10, 5),
            new(2, 7), new(3, 7), new(4, 7), new(8, 7), new(9, 7), new(10, 7),
            new(0, 8), new(5, 8), new(7, 8), new(12, 8),
            new(0, 9), new(5, 9), new(7, 9), new(12, 9),
            new(0, 10), new(5, 10), new(7, 10), new(12, 10),
            new(2, 12), new(3, 12), new(4, 12), new(8, 12), new(9, 12), new(10, 12),
        ]);
}
