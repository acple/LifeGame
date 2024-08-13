namespace LifeGame;

public static partial class Examples
{
    /// <summary>
    /// <code>
    /// ■■
    /// ■■
    /// </code>
    /// </summary>
    public static Board Block =>
        new([new(0, 0), new(0, 1), new(1, 0), new(1, 1)]);

    /// <summary>
    /// <code>
    /// □■■□
    /// ■□□■
    /// □■■□
    /// </code>
    /// </summary>
    public static Board BeeHive =>
        new([new(1, 0), new(2, 0), new(0, 1), new(3, 1), new(1, 2), new(2, 2)]);

    /// <summary>
    /// <code>
    /// □■■□
    /// ■□□■
    /// □■□■
    /// □□■□
    /// </code>
    /// </summary>
    public static Board Loaf =>
        new([new(1, 0), new(2, 0), new(0, 1), new(3, 1), new(1, 2), new(3, 2), new(2, 3)]);

    /// <summary>
    /// <code>
    /// ■■□
    /// ■□■
    /// □■□
    /// </code>
    /// </summary>
    public static Board Boat =>
        new([new(0, 0), new(1, 0), new(0, 1), new(2, 1), new(1, 2)]);

    /// <summary>
    /// <code>
    /// □■□
    /// ■□■
    /// □■□
    /// </code>
    /// </summary>
    public static Board Tub =>
        new([new(1, 0), new(0, 1), new(2, 1), new(1, 2)]);
}
